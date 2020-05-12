using Fhs.Cachless.D_Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Model
{
    public class SearchHeaderDataHolder<T, V> : BaseSearchHeaderDataHolder<T> where V : class
    {
        #region Variables
        public const int DefaultPageSize = 30;
        public const String MainDefaultFilterName = "MainFilter";
        private IdentifyClass dataId;

        public List<V> DataList { get; set; }

        #endregion

        #region Constructors
        public SearchHeaderDataHolder()
        {
            MakeDefaults();
        }
        public SearchHeaderDataHolder(int index, T sType, string sval, string selectedFilter = "", int pageSize = DefaultPageSize, string order = "", SearchOrderDirectionEnum direction = SearchOrderDirectionEnum.Ascending) : base(index, sType, sval, selectedFilter, pageSize, order, direction)
        {
            MakeDefaults();
        }
        public SearchHeaderDataHolder(int index, T sType, string sval, Object selectedFilter, int pageSize = DefaultPageSize, string order = "", SearchOrderDirectionEnum direction = SearchOrderDirectionEnum.Ascending) : base(index, sType, sval, selectedFilter, pageSize, order, direction)
        {
            MakeDefaults();
        }
        public SearchHeaderDataHolder(BaseSearchHeaderDataHolder<T> dataHolder) : base(dataHolder)
        {
            MakeDefaults();
        }

        #endregion

        #region Methods

        #endregion

        #region Helper methods

        private void MakeDefaults()
        {
            DataList = new List<V>();
        }

        #endregion

    }
}
