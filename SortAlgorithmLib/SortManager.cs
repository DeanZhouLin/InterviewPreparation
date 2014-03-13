using System;
using System.Collections.Generic;
using SortAlgorithmLib.ExchangeSort;

namespace SortAlgorithmLib
{

    public class SortManager<SortFieldType, EntityType>
    {
        public Func<EntityType, SortFieldType> GetSortFieldFunc { get; set; }
        public Func<SortFieldType, SortFieldType, int> CompareToFunc { get; set; }
        public SortBase<SortFieldType, EntityType> SortBase { get; set; }

        public SortManager(Func<EntityType, SortFieldType> getSortFieldFunc, Func<SortFieldType, SortFieldType, int> compareToFunc)
        {
            GetSortFieldFunc = getSortFieldFunc;
            CompareToFunc = compareToFunc;
        }

        public virtual List<EntityType> Sort(SortBase<SortFieldType, EntityType> sortBase, List<EntityType> sourceList, SortDirection sd = SortDirection.ASC)
        {
            SortBase = sortBase;
            return Sort(sourceList, sd);
        }

        public virtual List<EntityType> Sort(List<EntityType> sourceList, SortDirection sd = SortDirection.ASC)
        {
            var sortLs = SortEntity<SortFieldType, EntityType>.ConvertToSortEntities(sourceList, GetSortFieldFunc, CompareToFunc);
            SortBase.Sort(sortLs, sd);
            return SortEntity<SortFieldType, EntityType>.ConvertToEntities(sortLs);
        }

    }

    public sealed class IntSortManager<EntityType> : SortManager<int, EntityType>
    {
        public IntSortManager(Func<EntityType, int> getSortFieldFunc)
            : base(getSortFieldFunc, (x, y) => x - y)
        {
            SortBase = new BubbleSort<int, EntityType>();
        }
    }

    public sealed class DoubleSortManager<EntityType> : SortManager<double, EntityType>
    {
        public DoubleSortManager(Func<EntityType, double> getSortFieldFunc)
            : base(getSortFieldFunc, (x, y) =>
            {
                if (x - y > 0)
                {
                    return 1;
                }
                if (x - y == 0)
                {
                    return 0;
                }
                return -1;
            })
        {
            SortBase = new BubbleSort<double, EntityType>();
        }
    }

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
