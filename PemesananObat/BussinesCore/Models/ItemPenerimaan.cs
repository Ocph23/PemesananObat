using AppShared;
using AppShared.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesCore.Models
{
    public class ItemPenerimaan
    {
        public int Id { get; set; }
        public IObat Obat { get; set; }
        public float Jumlah { get; set; }
        public DateTime TanggalPenerimaan { get; set; }
        public DateTime ExpireDate { get;  set; }
        
    }
}
