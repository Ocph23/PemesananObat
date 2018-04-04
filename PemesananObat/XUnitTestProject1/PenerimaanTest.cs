using AppShared.Interfaces.Models;
using BussinesCore.Domain;
using BussinesCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject1
{
   public  class PenerimaanTest
    {
        private PenerimaanDomain domain;

        public PenerimaanTest()
        {
            ISupplier sup = new SupplierDomain().GetSupliers().FirstOrDefault();
            domain = new PenerimaanDomain(sup);
        }


        [Fact]
        public void GetPenerimaan()
        {
            var result = domain.ToList();
            Assert.NotNull(result);
        }


        [Fact]
        public void CreatePenerimaan_expected_No_Throw()
        {
            SystemException ex;
            var result = new ObatDomain().GetDataObat().FirstOrDefault();
            if (result != null)
            {
                var obat = new ItemRealisasi
                {
                    Id = result.Id,
                    KodeObat = result.KodeObat,
                    Name = result.Name,
                    Satuan = result.Satuan,
                    Jumlah = 30,
                    ExpireDate = DateTime.Now,
                    Tanggal = DateTime.Now,
                    Supplier = domain.Supplier,
                    SupplierId = result.SupplierId
                };
            
                domain.Add(obat);
                Assert.True(domain.Count>0);
            }else
            {
                ex = new SystemException();
            }
           // Assert.Null(result);
        }
    }
}
