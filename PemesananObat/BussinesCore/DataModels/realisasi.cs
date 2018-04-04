using System; 
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppShared.Interfaces.Data;
using Ocph.DAL;
 
 namespace DALCore.DataTransfer 
{ 
     [TableName("realisasi")] 
     public class realisasi : BaseNotify ,Irealisasi
   {
          [DbColumn("PesananId")] 
          public int PesananId 
          { 
               get{return _pesananid;} 
               set{ 

                    SetProperty(ref _pesananid, value);
                     }
          } 

          [DbColumn("obatId")] 
          public int obatId 
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

        [DbColumn("PetugasId")]
        public int PetugasId
        {
            get { return _petugasId; }
            set
            {

                SetProperty(ref _petugasId, value);
            }
        }

        [DbColumn("Tanggal")]
        public DateTime Tanggal {
            get { return _tanggal; }
            set
            {

                SetProperty(ref _tanggal, value);
            }
        }
        private int  _pesananid;
           private int  _obatid;
        private float _jumlah;
        private DateTime _tanggal;
        private int _petugasId;
    }
}


