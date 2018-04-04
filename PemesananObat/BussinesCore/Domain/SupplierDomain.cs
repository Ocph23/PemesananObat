using AppShared.Interfaces.Models;
using BussinesCore.Models;
using DALCore;
using System.Collections.Generic;

namespace BussinesCore.Domain
{
    public class SupplierDomain
    {
        private List<ISupplier> list;

        public List<ISupplier> GetSupliers()
        {
            if (list == null)
            {
               list= new List<ISupplier>();

                using (var db = new OcphDbContext())
                {
                    var data = db.Suppliers.Select();
                    foreach (var item in data)
                    {
                        list.Add(new Supplier { Contact = item.Contact, Id = item.Id, Name = item.Name });
                    }
                }   
            }
            return list;
        }

        public ISupplier CreateNewSupplier(string supplierName, string contact)
        {
            return new Supplier { Contact = contact, Name = supplierName };
        }

        public bool Delete(ISupplier supplier)
        {
            using (var db = new OcphDbContext())
            {
                return db.Suppliers.Delete(j => j.Id == supplier.Id);
            }   
        }
    }
}
