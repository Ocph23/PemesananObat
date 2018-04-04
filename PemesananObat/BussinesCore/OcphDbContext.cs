using DALCore.DataTransfer;
using Ocph.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace DALCore
{
    internal class OcphDbContext:Ocph.DAL.Provider.MySql.MySqlDbConnection
    {
        public OcphDbContext()
        {
            ConnectionString = "server=localhost;database=dbobat_data;uid=root;password=";
        }


        public IRepository<supplier> Suppliers { get { return new Repository<supplier>(this); } }
        public IRepository<obat> Obat { get { return new Repository<obat>(this); } }
        public IRepository<pemesanan> Pemesanan { get { return new Repository<pemesanan>(this); } }
        public IRepository<detailpemesanan> DetailPemesanan { get { return new Repository<detailpemesanan>(this); } }
        public IRepository<detailpenerimaan> DetailPenerimaan { get { return new Repository<detailpenerimaan>(this); } }
        public IRepository<petugas> Petugas { get { return new Repository<petugas>(this); } }
        public IRepository<realisasi> Realisasi { get { return new Repository<realisasi>(this); } }
    }
}
