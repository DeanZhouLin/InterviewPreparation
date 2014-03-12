using System.Collections.Generic;

namespace SortAlgorithmLib.ExchangeSort
{
    public static class BubbleSort<SortFieldType, EntityType>
    {
        public static List<SortEntity<SortFieldType, EntityType>> Sort(List<SortEntity<SortFieldType, EntityType>> sourceList, SortDirection sd = SortDirection.ASC)
        {
            int lsCount = sourceList.Count;
            for (int i = 0; i < lsCount; i++)
            {
                for (int j = lsCount - 1; j > i; j--)
                {
                    var res = sourceList[j - 1].CompareTo(sourceList[j].SortField);
                    SortEntity<SortFieldType, EntityType> temp;
                    switch (sd)
                    {
                        case SortDirection.ASC:
                            if (res <= 0) continue;
                            temp = sourceList[j];
                            sourceList[j] = sourceList[j - 1];
                            sourceList[j - 1] = temp;
                            break;
                        case SortDirection.DESC:
                            if (res >= 0) continue;
                            temp = sourceList[j];
                            sourceList[j] = sourceList[j - 1];
                            sourceList[j - 1] = temp;
                            break;
                    }
                }
            }
            return sourceList;
        }
    }
}
