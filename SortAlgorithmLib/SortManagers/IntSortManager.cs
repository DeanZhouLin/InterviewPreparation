using System;

namespace SortAlgorithmLib
{
    public sealed class IntSortManager<EntityType> : SortManager<int, EntityType>
    {
        public IntSortManager(Func<EntityType, int> getSortFieldFunc)
            : base(getSortFieldFunc, (x, y) => x - y)
        {
            SortBase = new BubbleSort<int, EntityType>();
        }
    }
}
