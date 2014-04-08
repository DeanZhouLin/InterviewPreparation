using System.Collections.Generic;

namespace SortAlgorithmLib
{
    public class HeapSort<SortFieldType, EntityType> : SortBase<SortFieldType, EntityType>
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

        /// <summary>
        /// 构建堆
        /// </summary>
        /// <param name="sourceList">待排序的集合</param>
        /// <param name="parent">父节点</param>
        /// <param name="length">输出根堆时剔除最大值使用</param>
        private static void HeapAdjust(List<SortEntity<SortFieldType, EntityType>> sourceList, int parent, int length)
        {
            //temp保存当前父节点
            var temp = sourceList[parent];

            //得到左孩子
            int child = 2 * parent + 1;

            while (child < length)
            {
                //如果parent有右孩子，则要判断做孩子是否小于右孩子
                if (child + 1 < length && sourceList[child].CompareTo(sourceList[child + 1].SortField) < 0)
                {
                    child++;
                }

                //父节点大于子节点，就不用交换
                if (temp.CompareTo(sourceList[child].SortField) >= 0)
                {
                    break;
                }

                //将较大的子节点赋值给父节点
                sourceList[parent] = sourceList[child];

                //然后将子节点作为父节点，以防止是否破坏根堆时重新构造
                parent = child;

                //找到该父节点较小的左孩子节点
                child = 2 * parent + 1;
            }

            //最后将temp值赋给较大的子节点，以形成两值交换
            sourceList[parent] = temp;
        }

    }
}