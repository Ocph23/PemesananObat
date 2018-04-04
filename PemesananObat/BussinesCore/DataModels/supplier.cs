using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShared.Interfaces.Data;
using Ocph.DAL;
 
 namespace DALCore.DataTransfer 
{ 
     [TableName("supplier")] 
     public class supplier : BaseNotify ,Isupplier
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

          [DbColumn("Contact")] 
          public string Contact 
          { 
               get{return _contact;} 
               set{ 

                    SetProperty(ref _contact, value);
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

          private int  _id;
           private string  _contact;
           private string  _name;
      }
}


