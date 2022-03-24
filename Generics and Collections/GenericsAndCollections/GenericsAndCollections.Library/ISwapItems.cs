using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsAndCollections.Library
{
    public interface ISwapItems <T>
    {
        void SwapItemsByIndex(int firstItemIndex, int secondItemIndex);

        void SwapItems(T firstItem, T secondItem);
    }
}
