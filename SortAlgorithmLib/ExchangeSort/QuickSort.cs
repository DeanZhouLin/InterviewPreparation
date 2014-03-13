using System.Collections.Generic;

namespace SortAlgorithmLib.ExchangeSort
{
    public class QuickSort<SortFieldType, EntityType> : SortBase<SortFieldType, EntityType>
    {
        public override void Sort(List<SortEntity<SortFieldType, EntityType>> sourceList, SortDirection sd = SortDirection.ASC)
        {
            int lsCount = sourceList.Count;
            ExecQuickSort(sourceList, 0, lsCount - 1);
        }

        private static int Division(List<SortEntity<SortFieldType, EntityType>> sourceList, int left, int right)
        {
            SortEntity<SortFieldType, EntityType> baseNum = sourceList[left];
            while (left < right)
            {
                //从数组的右端开始向前找，一直找到比base小的数字为止(包括base同等数)
                while (left < right && sourceList[right].CompareTo(baseNum.SortField) >= 0)
                {
                    right--;
                }

                //最终找到了比baseNum小的元素，要做的事情就是此元素放到base的位置
                sourceList[left] = sourceList[right];

                //从数组的左端开始向后找，一直找到比base大的数字为止（包括base同等数）
                while (left < right && sourceList[left].CompareTo(baseNum.SortField) <= 0)
                {
                    left++;
                }

                //最终找到了比baseNum大的元素，要做的事情就是将此元素放到最后的位置
                sourceList[right] = sourceList[left];
            }

            //最后就是把baseNum放到该left的位置
            sourceList[left] = baseNum;

            //最终，我们发现left位置的左侧数值部分比left小，left位置右侧数值比left大
            //至此，我们完成了第一篇排序
            return left;
        }

        private void ExecQuickSort(List<SortEntity<SortFieldType, EntityType>> sourceList, int left, int right)
        {
            while (true)
            {
                //左下标一定小于右下标，否则就超越了
                if (left < right)
                {
                    int i = Division(sourceList, left, right);
                    ExecQuickSort(sourceList, left, i - 1);
                    left = i + 1;
                    continue;
                }
                break;
            }
        }
    }
}