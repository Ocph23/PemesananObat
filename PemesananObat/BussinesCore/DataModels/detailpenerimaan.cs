using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShared.Interfaces.Data;
using Ocph.DAL;
 
 namespace DALCore.DataTransfer 
{ 
     [TableName("detailpenerimaan")] 
     public class detailpenerimaan :BaseNotify , Idetailpenerimaan
   {
          [DbColumn("obatId")] 
          public int obatId 
          { 
               get{return _obatid;} 
               set{ 

                    SetProperty(ref _obatid, value);
                     }
          } 

          [DbColumn("TanggalTerima")] 
          public DateTime TanggalTerima 
          { 
               get{return _tanggalterima;} 
               set{ 

                    SetProperty(ref _tanggalterima, value);
                     }
          } 

          [DbColumn("ExpireDate")] 
          public DateTime ExpireDate 
          { 
               get{return _expiredate;} 
               set{ 

                    SetProperty(ref _expiredate, value);
                     }
          } 

          [DbColumn("Jumlah")] 
          public float Jumlah 
          { 
               get{return _jumlah;} 
               set{ 

                    SetProperty(ref _jumlah, value);
                     }
          } 

          private int  _obatid;
           private DateTime  _tanggalterima;
           private DateTime  _expiredate;
           private float  _jumlah;
      }
}


