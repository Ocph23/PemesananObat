using AppShared.Interfaces.Models;
using BussinesCore.Models;
using DALCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BussinesCore.Domain
{
    public class ObatDomain
    {
        private List<IObat> list;

        public List<IObat> GetDataObat()
        {
           if(list==null)
            {
                list = new List<IObat>();
                using (var db = new OcphDbContext())
                {
                    var result = from a in db.Obat.Select()
                                 join b in db.Suppliers.Select() on a.SupplierId equals b.Id
                                 select new Obat
                                 {
                                     Id = a.Id,
                                     Name = a.Name,
                                     SupplierId = a.SupplierId,
                                     Satuan = a.Satuan,
                                     Supplier = new Supplier { Contact = b.Contact, Name = b.Name, Id = b.Id }
                                 };
                    foreach(var item in result)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }

        public bool Delete(IObat obat)
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    var deleted = db.Obat.Delete(O => O.Id == obat.Id);
                    if (deleted)
                    {
                        list.Remove(obat);
                    }
                    return deleted;
                }
                catch (Exception ex)
                {
                    throw new SystemException(ex.Message);
                }
            }
        }

        public IObat CreateModel(ISupplier supplier)
        {
            return new Obat { Supplier = supplier, SupplierId = supplier.Id };
        }


    }
          
}