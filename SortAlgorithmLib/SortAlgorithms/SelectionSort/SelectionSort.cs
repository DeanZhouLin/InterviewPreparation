using System.Collections.Generic;

namespace SortAlgorithmLib
{
    public class SelectionSort<SortFieldType, EntityType> : SortBase<SortFieldType, EntityType>
    {

        public override void Sort(List<SortEntity<SortFieldType, EntityType>> sourceList, SortDirection sd = SortDirection.ASC)
        {
            int lsCount = sourceList.Count;
            for (int i = 0; i < lsCount; i++)
            {
                int minOrMaxTempIndex = i;
                for (int j = i + 1; j < lsCount; j++)
                {
                    var res = sourceList[j].CompareTo(sourceList[minOrMaxTempIndex].SortField);
                    switch (sd)
                    {
                        case SortDirection.ASC:
                            if (res <= 0) continue;
                            minOrMaxTempIndex = j;
                            break;
                        case SortDirection.DESC:
                            if (res >= 0) continue;
                            minOrMaxTempIndex = j;
                            break;
                    }
                }
                if (i == minOrMaxTempIndex) continue;
                ExChangeTwoEntity(sourceList, minOrMaxTempIndex, i);
            }
        }

    }
}