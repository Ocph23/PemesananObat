using System;

namespace AppShared.Interfaces.Data
{

    public interface Idetailpenerimaan
    {
        int obatId { get; set; }

        DateTime TanggalTerima { get; set; }

        DateTime ExpireDate { get; set; }

        float Jumlah { get; set; }

    }
}


