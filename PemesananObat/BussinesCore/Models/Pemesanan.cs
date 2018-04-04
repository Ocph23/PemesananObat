using AppShared;
using AppShared.Interfaces.Models;
using DALCore;
using DALCore.DataTransfer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BussinesCore.Models
{
    public class Pemesanan : IPemesanan, IConvertToDataObject<pemesanan, IPemesanan>
    {
        public int Id { get; set; }
        public string KodePemesanan { get; set; }
        public DateTime Tanggal { get; set; }
        public IPetugas Petugas { get; set; }
        public List<ItemRealisasi> Realisasi { get; set; }
        public List<ItemPemesanan> Pesanan { get; set; }
        public int PetugasId { get; set; }
        public bool IsValid => IsValidAction();

        private bool IsValidAction()
        {
           if(string.IsNullOrEmpty(KodePemesanan) || PetugasId<=0)
            {
                return false;
            }
            return true;
        }

        public pemesanan ConvertToDataObject(IPemesanan obj)
        {
            return new pemesanan { Id = obj.Id, PetugasId = obj.PetugasId, Tanggal = obj.Tanggal, KodePemesanan=obj.KodePemesanan};
        }

        public void SaveChange()
        {
            using (var db = new OcphDbContext())
            {
                var trans = db.BeginTransaction();
                try
                {
                    if (IsValid)
                    {
                        var obj = ConvertToDataObject(this);
                        bool isSaved = true;
                        if (this.Id <= 0)
                        {
                            this.Id = db.Pemesanan.InsertAndGetLastID(obj);
                            if (Id <= 0)
                                isSaved = false;
                        }
                        else
                        {
                            isSaved = db.Pemesanan.Update(O => new { O.KodePemesanan, O.PetugasId, O.Tanggal }, obj, O => O.Id == obj.Id);
                        }

                        if (this.Pesanan != null)
                        {
                            foreach (var item in this.Pesanan)
                            {
                                var data = db.DetailPemesanan.Where(O => O.PemesananId == Id && O.ObatId == item.Id).FirstOrDefault();
                                if (data == null)
                                {
                                    isSaved = db.DetailPemesanan.Insert(new detailpemesanan { ObatId = item.Id, PemesananId = Id });
                                    if (!isSaved)
                                        throw new SystemException("Data Tidak Tersimpan");
                                }
                                else
                                {
                                    if (!db.DetailPemesanan.Update(O => new { O.ObatId }, new detailpemesanan { ObatId = item.Id }, O => O.PemesananId == Id))
                                    {
                                        throw new SystemException("Data Tidak Tersimpan");
                                    }
                                }
                            }
                        }

                        if (this.Realisasi != null)
                        {
                            foreach (var item in this.Pesanan)
                            {
                                if (item.Id <= 0)
                                {
                                    item.Id = db.Realisasi.InsertAndGetLastID(new realisasi { obatId = item.Id, PesananId = Id });
                                    if (item.Id <= 0)
                                        throw new SystemException("Data Tidak Tersimpan");
                                }
                                else
                                {
                                    if (!db.Realisasi.Update(O => new { O.obatId }, new realisasi { obatId = item.Id }, O => O.PesananId == Id))
                                    {
                                        throw new SystemException("Data Tidak Tersimpan");
                                    }
                                }
                            }
                        }


                        trans.Commit();
                       
                    }
                    else
                        throw new SystemException("Data Tidak Valid");
                   
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new SystemException(ex.Message);
                }
            }

        }

      
    }
}
