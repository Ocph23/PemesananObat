using AppShared.Interfaces.Models;
using DALCore;
using System;
using System.Collections.Generic;
using System.Linq;
using BussinesCore.Models;

namespace BussinesCore.Domain
{
    public class PemesananDomain
    {
        public List<IPemesanan> list;

        public List<IPemesanan> GetDataPesanan()
        {
            if (list == null)
            {
                list = new List<IPemesanan>();
                using (var db = new OcphDbContext())
                {
                    var result = from a in db.Pemesanan.Select()
                                 join b in db.DetailPemesanan.Select() on a.Id equals b.PemesananId
                                 join c in db.Petugas.Select() on a.PetugasId equals c.Id
                                 select new Pemesanan
                                 {
                                     Id = a.Id, KodePemesanan = a.KodePemesanan,
                                     PetugasId = a.PetugasId, Tanggal = a.Tanggal, Petugas = new Petugas { Id = c.Id, Nama = c.Nama }
                                 };

                    foreach (var item in result)
                    {
                        var p = from a in db.DetailPemesanan.Where(O => O.PemesananId == item.Id)
                                join o in db.Obat.Select() on a.ObatId equals o.Id
                                join s in db.Suppliers.Select() on o.SupplierId equals s.Id
                                select new ItemPemesanan
                                {
                                    Jumlah = a.Jumlah,
                                    Obat = new Obat
                                    {
                                        Id = o.Id,
                                        KodeObat = o.KodeObat,
                                        Name = o.Name,
                                        Satuan = o.Satuan,
                                        Supplier = new Supplier { Contact = s.Contact, Id = s.Id, Name = s.Name },
                                    },
                                    TanggalPesan = item.Tanggal
                                };

                        item.Pesanan = new List<ItemPemesanan>();
                        foreach (var obat in p)
                        {
                            item.Pesanan.Add(obat);
                        }

                        var real = from a in db.Realisasi.Where(O => O.PesananId == item.Id)
                                                join o in db.Obat.Select() on a.obatId equals o.Id
                                                join s in db.Suppliers.Select() on o.SupplierId equals s.Id
                                                select new ItemRealisasi
                                                {
                                                    Jumlah = a.Jumlah, Id=item.Id,
                                                    Obat = new Obat
                                                    {
                                                        Id = o.Id,
                                                        KodeObat = o.KodeObat,
                                                        Name = o.Name,
                                                        Satuan = o.Satuan,
                                                        Supplier = new Supplier { Contact = s.Contact, Id = s.Id, Name = s.Name }
                                                    },
                                                    Tanggal = a.Tanggal
                                                };

                        item.Realisasi = new List<ItemRealisasi>();
                        foreach (var obat in real)
                        {
                            item.Realisasi.Add(obat);
                        }
                        list.Add(item);
                    }
                }
            }

            return list;
        }

        public bool Delete(IPemesanan pesanan)
        {
            using (var db = new OcphDbContext())
            {
                var trans = db.BeginTransaction();
                try
                {
                    var delPesanan = db.DetailPemesanan.Delete(O => O.PemesananId == pesanan.Id);
                    var delReal = db.Realisasi.Delete(O => O.PesananId == pesanan.Id);
                    var delitem = db.Pemesanan.Delete(O => O.Id == pesanan.Id);
                    if (delitem && delPesanan && delReal)
                    {
                        var p =  list.Where(O => O.Id == pesanan.Id).FirstOrDefault();
                        list.Remove(p);
                        trans.Commit();
                        return true;
                    }else
                    {
                        throw new SystemException("Data Tidak Dapat Dihapus");
                    }
                  
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new SystemException(ex.Message);
                }
            }
        }

        public IPemesanan CreateModel(IPetugas petugas)
        {
            return new Pemesanan { KodePemesanan=Helper.GenerateCodePemesanan(), Tanggal=DateTime.Now, PetugasId=petugas.Id };
        }

    }
}
