using AppShared;
using AppShared.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesCore.Models
{
    public class ItemRealisasi
    {
        public int Id { get; set; }
        public IObat Obat { get; set; }
        public float Jumlah { get; set; }
        public DateTime Tanggal { get; set; }
        public string KodeObat { get; set; }
        public string Name { get;  set; }
        public SatuanObat Satuan { get; set; }
        public int SupplierId { get; set; }
        public DateTime ExpireDate { get;  set; }
        internal Supplier Supplier { get; set; }
    }
}
