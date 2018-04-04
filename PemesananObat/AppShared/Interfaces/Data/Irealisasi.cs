using System;

namespace AppShared.Interfaces.Data
{ 

     public interface Irealisasi  
   {
         int PesananId {  get; set;} 

         int obatId {  get; set;}
        float Jumlah { get; set; }
        int PetugasId { get; set; }
        DateTime Tanggal { get; set; }
    }
}


