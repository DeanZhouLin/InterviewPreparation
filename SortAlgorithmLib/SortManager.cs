using System;
using System.Collections.Generic;

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
}
