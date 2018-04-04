using System;

namespace AppShared.Interfaces.Data
{ 

     public interface Ipemesanan  
   {
         int Id {  get; set;} 

         string KodePemesanan {  get; set;} 

         DateTime Tanggal {  get; set;} 

         int PetugasId {  get; set;} 

     }
}


