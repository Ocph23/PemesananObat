using System;
using System.Collections.Generic;
using System.Text;

namespace AppShared
{
   public interface IConvertToDataObject<T,M> 
    {
        T ConvertToDataObject(M obj);
    }
}
