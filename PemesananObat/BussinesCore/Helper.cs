using DALCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesCore
{
    public static class Helper
    {
        public static string GenerateCodePemesanan()
        {
            using (var db = new OcphDbContext())
            {
                var a = db.Pemesanan.GetLastItem();
                if(a!=null)
                {
                    int res = int.Parse(a.KodePemesanan);
                    return string.Format("{0:D5}", res+1);
                }else
                {
                    return string.Format("{0:D5}", 1);
                }
            }
        }
    }
}
