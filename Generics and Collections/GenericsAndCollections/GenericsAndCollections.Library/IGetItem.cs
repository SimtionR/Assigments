using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndCollections.Library
{
    public interface IGetItem<out T>
    {
        T GetItem(int index);
    }
}
