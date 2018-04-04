using AppShared;
using AppShared.Interfaces.Models;
using DALCore;
using DALCore.DataTransfer;
using System;

namespace BussinesCore.Models
{
    internal class Supplier : ISupplier, IConvertToDataObject<supplier, ISupplier>
    {
        public int Id {get;set;}
        public string Contact {get;set;}
        public string Name {get;set;}
        public bool IsValidModel => ValidateModel();

        private bool ValidateModel()
        {
            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Contact))
                return false;
            else
                return true;
        }

        public void SaveChange()
        {
            try
            {
                if (IsValidModel)
                {
                    using (var db = new OcphDbContext())
                    {
                        var obj = ConvertToDataObject(this);
                        if (Id <= 0)
                        {
                            Id = db.Suppliers.InsertAndGetLastID(obj);
                            if (Id <= 0)
                                throw new SystemException("Data Tidak Tersimpan");
                        }
                        else
                        {
                            var isUPdated = db.Suppliers.Update(O => new { O.Contact, O.Name }, obj, O => Id == obj.Id);
                            if (!isUPdated)
                                throw new SystemException("Data Tidak Tersimpan");
                        }
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

        public supplier ConvertToDataObject(ISupplier obj)
        {
            return new supplier { Contact = obj.Contact, Id = obj.Id, Name = obj.Name };
        }
    }
}
