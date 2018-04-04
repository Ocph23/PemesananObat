using AppShared;
using AppShared.Interfaces.Data;

namespace AppShared.Interfaces.Models
{
    public interface IObat:Iobat
    {
        bool SaveChange();
        ISupplier Supplier { get; set; }
    }

    
}
