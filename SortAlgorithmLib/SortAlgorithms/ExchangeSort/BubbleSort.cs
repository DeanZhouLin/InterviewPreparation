﻿using System.Collections.Generic;

namespace SortAlgorithmLib
{
    public class BubbleSort<SortFieldType, EntityType> : SortBase<SortFieldType, EntityType>
    {

        public override void Sort(List<SortEntity<SortFieldType, EntityType>> sourceList, SortDirection sd = SortDirection.ASC)
        {
            int lsCount = sourceList.Count;
            for (int i = 0; i < lsCount; i++)
            {
                for (int j = lsCount - 1; j > i; j--)
                {
                    var res = sourceList[j - 1].CompareTo(sourceList[j].SortField);
                    switch (sd)
                    {
                        case SortDirection.ASC:
                            if (res <= 0) continue;
                            ExChangeTwoEntity(sourceList, j, j - 1);
                            break;
                        case SortDirection.DESC:
                            if (res >= 0) continue;
                            ExChangeTwoEntity(sourceList, j, j - 1);
                            break;
                    }
                }
            }
        }

    }
}