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
    public class PemesananObatTest
    {
        PemesananDomain domain = new PemesananDomain();

        [Fact]
        public void GetAllPesanan()
        {
            var result = domain.GetDataPesanan();
            Assert.NotNull(result);
        }

        [Fact]
        public void InsertNewPemesanan ()
        {
            IPetugas petugas = new PetugasDomain().GetDataPetugas().FirstOrDefault();
            var result = domain.CreateModel(petugas);
            result.Pesanan = new List<IObat>();
            IObat obat = new ObatDomain().GetDataObat().FirstOrDefault();
            result.Pesanan.Add(obat);
            result.SaveChange();


            Assert.NotNull(result);
        }

    }
}
