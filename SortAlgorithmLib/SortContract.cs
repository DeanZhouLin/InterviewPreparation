using System;
using System.Collections.Generic;
using System.Linq;
using SortAlgorithmLib.ExchangeSort;

namespace SortAlgorithmLib
{

    public enum SortDirection
    {
        ASC,
        DESC
    }

    public class SortEntity<SortFieldType, EntityType> : IComparable<SortFieldType>
    {

        public int CompareTo(SortFieldType other)
        {
            return CompareToFunc(SortField, other);
        }

        public SortFieldType SortField { get; set; }
        public EntityType CurrEntity { get; set; }

        private Func<SortFieldType, SortFieldType, int> CompareToFunc { get; set; }

        public static List<SortEntity<SortFieldType, EntityType>> ConvertToSortEntities(List<EntityType> sourceList, Func<EntityType, SortFieldType> getSortFieldFunc, Func<SortFieldType, SortFieldType, int> compareToFunc)
        {
            return sourceList.Select(v => new SortEntity<SortFieldType, EntityType>
            {
                SortField = getSortFieldFunc(v),
                CurrEntity = v,
                CompareToFunc = compareToFunc
            }).ToList();
        }

        public static List<EntityType> ConvertToEntities(List<SortEntity<SortFieldType, EntityType>> sourceList)
        {
            return sourceList.Select(c => c.CurrEntity).ToList();
        }

    }

    public class SortManager<SortFieldType, EntityType>
    {

        public Func<EntityType, SortFieldType> GetSortFieldFunc { get; set; }
        public Func<SortFieldType, SortFieldType, int> CompareToFunc { get; set; }

        public SortManager(Func<EntityType, SortFieldType> getSortFieldFunc, Func<SortFieldType, SortFieldType, int> compareToFunc)
        {
            GetSortFieldFunc = getSortFieldFunc;
            CompareToFunc = compareToFunc;
        }

        public List<EntityType> BubbleSortList(List<EntityType> sourceList, SortDirection sd = SortDirection.ASC)
        {
            var sortLs = SortEntity<SortFieldType, EntityType>.ConvertToSortEntities(sourceList, GetSortFieldFunc, CompareToFunc);
            sortLs = BubbleSort<SortFieldType, EntityType>.Sort(sortLs, sd);
            return SortEntity<SortFieldType, EntityType>.ConvertToEntities(sortLs);
        }

    }

    public sealed class IntSortManager : SortManager<int, int>
    {

        public IntSortManager()
            : base(i => i, (x, y) => x - y)
        {
        }

    }
}
