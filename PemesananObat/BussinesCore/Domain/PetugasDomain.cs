using AppShared.Interfaces.Models;
using BussinesCore.Models;
using DALCore;
using System.Collections.Generic;
using System.Linq;

namespace BussinesCore.Domain
{
    public class PetugasDomain
    {
        private List<IPetugas> list;

        public List<IPetugas> GetDataPetugas()
        {
            if (list == null)
            {
                list = new List<IPetugas>();
                using (var db = new OcphDbContext())
                {
                    var result = from a in db.Petugas.Select()
                                 select new Petugas
                                 {
                                     Id = a.Id,  
                                     Nama = a.Nama
                                 };


                    foreach (var item in result)
                    {
                        list.Add(item);
                    }
                }
            }
            return list;
        }


        public IPetugas CreateModel()
        {
            return new Petugas();
        }


    }
}
