using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShared;
using AppShared.Interfaces.Data;
using Ocph.DAL;
 
 namespace DALCore.DataTransfer 
{ 
     [TableName("obat")] 
     public class obat :BaseNotify , Iobat
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

          [DbColumn("KodeObat")] 
          public string KodeObat 
          { 
               get{return _kodeobat;} 
               set{ 

                    SetProperty(ref _kodeobat, value);
                     }
          } 

          [DbColumn("Name")] 
          public string Name 
          { 
               get{return _name;} 
               set{ 

                    SetProperty(ref _name, value);
                     }
          } 

          [DbColumn("Satuan")] 
          public SatuanObat Satuan 
          { 
               get{return _satuan;} 
               set{ 

                    SetProperty(ref _satuan, value);
                     }
          } 

          [DbColumn("SupplierId")] 
          public int SupplierId 
          { 
               get{return _supplierid;} 
               set{ 

                    SetProperty(ref _supplierid, value);
                     }
          } 

          private int  _id;
           private string  _kodeobat;
           private string  _name;
           private SatuanObat  _satuan;
           private int  _supplierid;
      }
}


