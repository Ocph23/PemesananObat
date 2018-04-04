using AppShared;
using AppShared.Interfaces.Models;
using BussinesCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class ManageObatTest
    {
        ObatDomain domain = new ObatDomain();
        SupplierDomain supDoimain = new SupplierDomain();

        [Fact]
        public void GetAllObat()
        {
            List<IObat> list = domain.GetDataObat();
            Assert.NotNull(list);
        }

        [Fact]
        public void AddNewObat()
        {
            var supplier = supDoimain.GetSupliers().FirstOrDefault();
            IObat obat= domain.CreateModel(supplier);
            obat.Name = "Obat Apakek";
            obat.Satuan = SatuanObat.Tablet;
            obat.SaveChange();
        }


        [Fact]
        public void DeleteObat()
        {
            IObat obat= domain.GetDataObat().Where(O => O.Id == 3).FirstOrDefault();
            bool data = domain.Delete(obat);
            Assert.True(data);
        }


        [Fact]
        public void DeleteObatExpectation_throw_Exception()
        {
            IObat obat = domain.GetDataObat().Where(O => O.Id == 2).FirstOrDefault();
            Exception ex= Assert.Throws<SystemException>(()=>domain.Delete(obat));
            Assert.NotNull(ex);
        }


    }
}
