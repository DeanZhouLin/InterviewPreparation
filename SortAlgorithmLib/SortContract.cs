using System;
using System.Collections.Generic;
using System.Linq;
using SortAlgorithmLib.ExchangeSort;

namespace SortAlgorithmLib
{
    /// <summary>
    /// 排序方向
    /// </summary>
    public enum SortDirection
    {
        /// <summary>
        /// 升序
        /// </summary>
        ASC,
        /// <summary>
        /// 降序
        /// </summary>
        DESC
    }

    /// <summary>
    /// 实际进行排序的类型定义
    /// </summary>
    /// <typeparam name="SortFieldType">待排序字段的类型</typeparam>
    /// <typeparam name="EntityType">待排序实体的类型</typeparam>
    public class SortEntity<SortFieldType, EntityType> : IComparable<SortFieldType>
    {
        /// <summary>
        /// 比较方法
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
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

    /// <summary>
    /// 排序抽象类，实现对List的排序功能
    /// </summary>
    /// <typeparam name="SortFieldType">待排序字段的类型</typeparam>
    /// <typeparam name="EntityType">待排序实体的类型</typeparam>
    public abstract class SortBase<SortFieldType, EntityType>
    {
        /// <summary>
        /// 执行排序
        /// </summary>
        /// <param name="sourceList">待排序列表</param>
        /// <param name="sd">升序/降序</param>
        public abstract void Sort(List<SortEntity<SortFieldType, EntityType>> sourceList, SortDirection sd = SortDirection.ASC);
    }

}
