using System.Collections.Generic;
using AppShared.Interfaces.Data;
using BussinesCore.Models;

namespace AppShared.Interfaces.Models
{
    public interface IPemesanan:Ipemesanan
    {
        IPetugas Petugas { get; set; }
        List<ItemRealisasi> Realisasi { get; set; }
        List<ItemPemesanan> Pesanan { get; set; }

        void SaveChange();
    }
}
