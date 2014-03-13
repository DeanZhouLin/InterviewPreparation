using System;

namespace SortAlgorithmLib
{

    public sealed class StringSortManager<EntityType> : SortManager<string, EntityType>
    {
        public StringSortManager(Func<EntityType, string> getSortFieldFunc)
            : base(getSortFieldFunc, (x, y) =>
            {
                double dx, dy;
                double.TryParse(x, out dx);
                double.TryParse(y, out dy);

                if (dx - dy > 0)
                {
                    return 1;
                }
                if (dx - dy == 0)
                {
                    return 0;
                }
                return -1;
            })
        {
            SortBase = new BubbleSort<string, EntityType>();
        }
    }

}
