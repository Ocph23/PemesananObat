using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShared.Interfaces.Data;
using Ocph.DAL;
 
 namespace DALCore.DataTransfer 
{ 
     [TableName("detailpemesanan")] 
     public class detailpemesanan :BaseNotify , Idetailpemesanan
   {
          [DbColumn("PemesananId")] 
          public int PemesananId 
          { 
               get{return _pemesananid;} 
               set{ 

                    SetProperty(ref _pemesananid, value);
                     }
          } 

          [DbColumn("ObatId")] 
          public int ObatId 
          { 
               get{return _obatid;} 
               set{ 

                    SetProperty(ref _obatid, value);
                     }
          }
        [DbColumn("Jumlah")]
        public float Jumlah
        {
            get { return _jumlah; }
            set
            {

                SetProperty(ref _jumlah, value);
            }
        }
        private int  _pemesananid;
           private int  _obatid;
        private float _jumlah;
    }
}


