using AppShared;
using AppShared.Interfaces.Models;
using DALCore;
using DALCore.DataTransfer;
using System;

namespace BussinesCore.Models
{
    internal class Obat : IObat,IConvertToDataObject<obat,IObat>
    {
        private ISupplier _supplier;

        public ISupplier Supplier {
            get { return _supplier; }
            set
            {
                _supplier = value;
                SupplierId = value.Id;
            }
        }
        public int Id {get;set;}
        public string Name {get;set;}
        public SatuanObat Satuan {get;set;}
        public int SupplierId {get;set;}
        public string KodeObat { get; set; }

        public obat ConvertToDataObject(IObat obj)
        {
            return new obat { Id = obj.Id, Name = obj.Name, Satuan = obj.Satuan, SupplierId = obj.SupplierId };
        }

        public bool SaveChange()
        {
            using (var db = new OcphDbContext())
            {
                try
                {
                    bool isSaved = true;
                    var dataObject = ConvertToDataObject(this);
                    if(Id<=0)
                    {
                        Id = db.Obat.InsertAndGetLastID(dataObject);
                        if (Id <= 0)
                            isSaved = false;
                    }else
                    {
                        var updated = db.Obat.Update(O => new
                        {
                            O.Name,
                            O.Satuan,
                            O.SupplierId
                        }, dataObject, O => O.Id == dataObject.Id);

                        if (!updated)
                            isSaved = false;
                    }

                    return isSaved;

                }
                catch (Exception ex)
                {

                    throw new SystemException(ex.Message);
                }
            }
        }
    }
}
