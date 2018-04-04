using AppShared.Interfaces.Models;
using BussinesCore.Domain;
using System.Linq;
using Xunit;

namespace XUnitTestProject1
{
    public class ManageSupplierTest
    {
        SupplierDomain domain = new SupplierDomain();

        [Fact]
        public void GetAllSUpplier()
        {
            var result = domain.GetSupliers();
            Assert.NotNull(result);
        }


        [Fact]
        public void AddNewSupplier()
        {
            ISupplier supplier = domain.CreateNewSupplier("SupplierName", "081148");
            supplier.SaveChange();
            Assert.True(supplier.Id > 0);
        }

        [Fact]
        public void UpdateSupplier()
        {
            ISupplier supplier = domain.GetSupliers().Where(O => O.Id == 4).FirstOrDefault();
            supplier.Name = "Apakek";
            supplier.SaveChange();
            Assert.True(supplier.Name == "Apakek");
        }


        [Fact]
        public void DeleteSupplier()
        {
            ISupplier supplier = domain.GetSupliers().Where(O => O.Id == 3).FirstOrDefault();
            var data = domain.Delete(supplier);
            Assert.True(data);
        }



    }
}
