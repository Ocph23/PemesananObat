using System;

namespace AppShared.Interfaces.Data
{ 

     public interface Iobat  
   {
         int Id {  get; set;} 

         string KodeObat {  get; set;} 

         string Name {  get; set;} 

         SatuanObat Satuan {  get; set;} 

         int SupplierId {  get; set;} 

     }
}


