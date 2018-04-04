using AppShared.Interfaces.Models;
using BussinesCore.Models;
using DALCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DALCore.DataTransfer;

namespace BussinesCore.Domain
{
    public class PenerimaanDomain:ICollection<ItemRealisasi>
    {
        private ArrayList items = new ArrayList();

        public PenerimaanDomain(ISupplier supplier)
        {
            this.Supplier = supplier;
            Task<List<ItemRealisasi>> task=  Task.Factory.StartNew(()=> GetItemsPenerimaan());
            CompleteTaskAsync(task);
        }

        private async void CompleteTaskAsync(Task<List<ItemRealisasi>> task)
        {
            var res = await task;
            foreach(var item in res )
            {
                items.Add(item);
            }
        }

        private List<ItemRealisasi> GetItemsPenerimaan()
        {
            using (var db = new OcphDbContext())
            {
                var res = from a in db.DetailPenerimaan.Select()
                          join b in db.Obat.Where(O=>O.SupplierId==Supplier.Id) on a.obatId equals b.Id
                          join c in db.Suppliers.Select() on b.SupplierId equals c.Id
                          select new ItemRealisasi
                          {
                              Jumlah = a.Jumlah,
                              KodeObat = b.KodeObat,
                              Name = b.Name,
                              Satuan = b.Satuan, Id=a.obatId,
                              SupplierId = c.Id, ExpireDate=a.ExpireDate, Tanggal=a.TanggalTerima,
                              Supplier = new Supplier { Contact = c.Contact, Id = c.Id, Name = c.Name }
                          };
                return res.ToList();
            }
        }

        public ISupplier Supplier { get; }

        public int Count => items.Count;

        public bool IsReadOnly => false;

        private bool saveValidate(ItemRealisasi item)
        {
            if (item.Id <= 0 || item.ExpireDate == new DateTime() || item.Tanggal == new DateTime() || item.Jumlah <= 0)
                return false;
            return true;
        }

        public void Add(ItemRealisasi item)
        {
            try
            {
                if (saveValidate(item))
                {
                    using (var db = new OcphDbContext())
                    {
                        if (db.DetailPenerimaan
                            .Insert(
                            new detailpenerimaan
                            {
                                ExpireDate = item.ExpireDate,
                                Jumlah = item.Jumlah,
                                obatId = item.Id,
                                TanggalTerima = item.Tanggal
                            }))
                            items.Add(item);
                        else
                            throw new SystemException("Data Tidak Tersimpan");
                    }
                }else
                {
                    throw new SystemException("Data Tidak Valid");
                }
               
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(ItemRealisasi item)
        {
          return  items.Contains(item);
        }

        public void CopyTo(ItemRealisasi[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ItemRealisasi> GetEnumerator()
        {
            return (IEnumerator<ItemRealisasi>)items.GetEnumerator();
        }

        public bool Remove(ItemRealisasi item)
        {
            try
            {
                items.Remove(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
