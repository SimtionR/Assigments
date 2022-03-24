using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndCollections.Library
{
    public interface ISetItem<in T>
    {
        void SetItem(T item, int index);
    }
}
