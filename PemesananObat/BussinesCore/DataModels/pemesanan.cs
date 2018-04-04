using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShared.Interfaces.Data;
using Ocph.DAL;
 
 namespace DALCore.DataTransfer 
{ 
     [TableName("pemesanan")] 
     public class pemesanan :BaseNotify, Ipemesanan
   {
          [PrimaryKey("Id")] 
          [DbColumn("Id")] 
          public int Id 
          { 
               get{return _id;} 
               set{ 

                    SetProperty(ref _id, value);
                     }
          } 

          [DbColumn("KodePemesanan")] 
          public string KodePemesanan 
          { 
               get{return _kodepemesanan;} 
               set{ 

                    SetProperty(ref _kodepemesanan, value);
                     }
          } 

          [DbColumn("Tanggal")] 
          public DateTime Tanggal 
          { 
               get{return _tanggal;} 
               set{ 

                    SetProperty(ref _tanggal, value);
                     }
          } 

          [DbColumn("PetugasId")] 
          public int PetugasId 
          { 
               get{return _petugasid;} 
               set{ 

                    SetProperty(ref _petugasid, value);
                     }
          } 

          private int  _id;
           private string  _kodepemesanan;
           private DateTime  _tanggal;
           private int  _petugasid;
      }
}


