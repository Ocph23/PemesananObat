using System;
 
 namespace AppShared.Interfaces.Data
{ 

     public interface Idetailpemesanan  
   {
         int PemesananId {  get; set;} 

         int ObatId {  get; set;}
        float Jumlah { get; set; }

    }
}


