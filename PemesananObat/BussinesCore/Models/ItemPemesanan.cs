using AppShared;
using AppShared.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesCore.Models
{
    public class ItemPemesanan
    {
        public int Id { get; set; }
        public IObat Obat { get; set; }
        public float Jumlah { get; set; }
        public DateTime TanggalPesan { get; set; }
    }
}
