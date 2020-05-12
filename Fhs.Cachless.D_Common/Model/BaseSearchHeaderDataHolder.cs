using Fhs.Cachless.D_Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fhs.Cachless.D_Common.Model
{
    public class BaseSearchHeaderDataHolder<T>
    {
        #region Variables
        public const int DefaultPageSize = 30;
        public const String MainDefaultFilterName = "MainFilter";
        public const int PageSizeIndexer = 5;

        public int Index
        {
            get { return _index; }
            set
            {
                var temp = value;
                if (temp < 0)
                    temp = 0;
                _index = temp;

            }
        }
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                var temp = value;
                //if (temp <= 7)
                //    temp = 7;
                _pageSize = temp;

            }
        }
        public T SearchType { get; set; }
        public String SearchValue { get; set; }
        public String SearchOrder { get; set; }
        public SearchOrderDirectionEnum SearchOrderDirection { get;set;}
        public String SelectedFilter
        {
            get { return _selectedFilterName; }
            set
            {
                var temp = value ?? "";
                if (String.IsNullOrWhiteSpace(temp) ||
                    String.IsNullOrEmpty(temp))
                    temp = MainDefaultFilterName;

                if (!_numberOfDataListByFilter.ContainsKey(temp))
                    _numberOfDataListByFilter.Add(temp, 0);

                _selectedFilterName = temp;

            }
        }
        public int TotalCount
        {
            get { return _totalCount; }
            set
            {
                var temp = value;
                if (temp < 0)
                    temp = 0;
                _totalCount = temp;

            }
        }

        /// <summary>
        /// کل صفحات
        /// </summary>
        public int MaxPage { get; private set; }

        /// <summary>
        /// آخرین شماره صفحه ای که با علامت ... دیده می شود
        /// </summary>
        public int MaxDotIndex { get; private set; }

        /// <summary>
        /// اولین شماره صفحه ای که با علامت ... دیده می شود
        /// </summary>
        public int MinDotIndex { get; private set; }

        /// <summary>
        /// کمترین شماره صفحه ای که به شکل عددی دیده می شود
        /// </summary>
        public int IndexMin { get; private set; }

        /// <summary>
        /// بیشترین شماره صفحه ای که به شکل عددی دیده می شود
        /// </summary>
        public int IndexMax { get; private set; }

        private Dictionary<String, int> _numberOfDataListByFilter = new Dictionary<string, int>();
        private String _selectedFilterName = MainDefaultFilterName;
        private int _index = 0;
        private int _totalCount = 0;
        private int _pageSize = DefaultPageSize;
        #endregion

        #region Constructors
        public BaseSearchHeaderDataHolder()
        {
            MakeDefaults();
        }
        public BaseSearchHeaderDataHolder(int index, T sType, string sval, string selectedFilter = "", int pageSize = DefaultPageSize, string order = "",SearchOrderDirectionEnum direction = SearchOrderDirectionEnum.Ascending)
        {
            MakeDefaults();

            Index = index;
            SearchType = sType;
            SearchValue = sval;

            if (!String.IsNullOrEmpty(selectedFilter) &&
                !String.IsNullOrWhiteSpace(selectedFilter))
            {
                SelectedFilter = selectedFilter;
                _numberOfDataListByFilter = new Dictionary<string, int>();
                _numberOfDataListByFilter.Add(SelectedFilter, 0);
            }


            //if (pageSize > 7)
            PageSize = pageSize;

            SearchOrder = order;
            SearchOrderDirection = direction;
        }
        public BaseSearchHeaderDataHolder(int index, T sType, string sval, Object selectedFilter, int pageSize = DefaultPageSize, string order = "", SearchOrderDirectionEnum direction = SearchOrderDirectionEnum.Ascending)
        {
            MakeDefaults();

            Index = index;
            SearchType = sType;
            SearchValue = sval;

            if (selectedFilter != null)
            {
                var filterType = selectedFilter.GetType();

                if (filterType.IsEnum)
                {
                    _numberOfDataListByFilter = new Dictionary<string, int>();
                    SelectedFilter = selectedFilter.ToString();
                    var nameList = Enum.GetNames(filterType);

                    foreach (var str in nameList)
                        AddFilterCount(str, 0);
                }

            }

            if (pageSize >= 10)
                PageSize = pageSize;

            SearchOrder = order;
            SearchOrderDirection = direction;
        }
        public BaseSearchHeaderDataHolder(BaseSearchHeaderDataHolder<T> dataHolder)
        {
            MakeDefaults();

            Index = dataHolder.Index;
            TotalCount = dataHolder.TotalCount;
            SearchType = dataHolder.SearchType;
            SearchValue = dataHolder.SearchValue;
            SelectedFilter = dataHolder.SelectedFilter;
            PageSize = dataHolder.PageSize;
            SearchOrder = dataHolder.SearchOrder;
            SearchOrderDirection = dataHolder.SearchOrderDirection;
            MaxPage = dataHolder.MaxPage;
            MaxDotIndex = dataHolder.MaxDotIndex;
            MinDotIndex = dataHolder.MinDotIndex;
            IndexMin = dataHolder.IndexMin;
            IndexMax = dataHolder.IndexMax;

            _numberOfDataListByFilter = dataHolder.GetFilterDictionay();

        }
        #endregion

        #region Methods

        public void CleanFilterName()
        {
            _numberOfDataListByFilter = new Dictionary<string, int>();
            _numberOfDataListByFilter.Add(SelectedFilter, 0);
        }
        public void AddFilterCount(string filterName, int count)
        {
            try
            {
                if (_numberOfDataListByFilter == null)
                    _numberOfDataListByFilter = new Dictionary<string, int>();

                if (_numberOfDataListByFilter.ContainsKey(filterName))
                    _numberOfDataListByFilter[filterName] = count;
                else
                    _numberOfDataListByFilter.Add(filterName, count);
            }
            catch (Exception e)
            {
                ThisAppContext.AddLogInDb(e);
            }
        }
        public int GetFilterCount(string filterName)
        {
            if (_numberOfDataListByFilter.ContainsKey(filterName))
                return _numberOfDataListByFilter[filterName];

            return 0;
        }
        public Dictionary<String, int> GetFilterDictionay()
        {
            return _numberOfDataListByFilter;
        }


        #endregion

        #region Helper methods

        private void MakeDefaults()
        {
            Index = 0;
            PageSize = DefaultPageSize;
            SearchType = default(T);
            SearchValue = "";
            SearchOrder = "";
            SearchOrderDirection = SearchOrderDirectionEnum.Ascending;
            _selectedFilterName = MainDefaultFilterName;
            MaxDotIndex = 0;
            MinDotIndex = 0;
            IndexMin = 0;
            IndexMax = 0;

            _numberOfDataListByFilter = new Dictionary<string, int>();
            _numberOfDataListByFilter.Add(_selectedFilterName, 0);
        }
        public void ReCulculateDataHolder()
        {
            try
            {
                if (Index > (TotalCount / PageSize) && Index != 0)
                {
                    Index = (TotalCount / PageSize) - 1;
                    if (Index < 0) Index = 0;
                }

                #region Culculate PageIndexer

                MaxPage = (TotalCount / PageSize) + 1;
                if (TotalCount % PageSize == 0 && TotalCount > 0) MaxPage--;

                var minIndx = (Index / PageSizeIndexer) * PageSizeIndexer;
                var maxIndx = (((Index / PageSizeIndexer) + 1) * PageSizeIndexer) - 1;
                MaxDotIndex = -1;
                MinDotIndex = -1;

                IndexMin = 0;
                IndexMax = 0;


                if ((maxIndx + 1) > MaxPage)
                    maxIndx = MaxPage - 1;

                if (minIndx - 1 >= 0)
                    MinDotIndex = minIndx - 1;

                if (maxIndx + 1 <= (MaxPage - 1))
                    MaxDotIndex = maxIndx + 1;

                IndexMin = MinDotIndex != -1 ? MinDotIndex : minIndx;
                IndexMax = MaxDotIndex != -1 ? MaxDotIndex : maxIndx;

                #endregion
            }
            catch (Exception e)
            {
                ThisAppContext.AddLogInDb(e);
            }

        }

        #endregion

    }
}
