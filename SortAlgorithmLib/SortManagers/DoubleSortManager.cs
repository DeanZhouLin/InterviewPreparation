using System;

namespace SortAlgorithmLib
{

    public sealed class DoubleSortManager<EntityType> : SortManager<double, EntityType>
    {
        public DoubleSortManager(Func<EntityType, double> getSortFieldFunc)
            : base(getSortFieldFunc, (x, y) =>
            {
                if (x - y > 0)
                {
                    return 1;
                }
                if (x - y < 0)
                {
                    return -1;
                }
                return 0;
            })
        {
            SortBase = new BubbleSort<double, EntityType>();
        }
    }

}
