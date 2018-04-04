using AppShared.Interfaces.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesCore.Models
{
    internal class Petugas : IPetugas
    {
        public int Id { get; set; }
        public string Nama { get; set; }
    }
}
