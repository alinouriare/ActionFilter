using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.D_Common.Enums;

namespace Fhs.Cachless.D_Common.Model
{
    public class InformationLogHolder
    {
        #region Variables

        public Guid Id { get { return _id; } }
        public String HolderName { get; set; }
        public bool HasError
        {
            get
            {
                return _logDataList != null &&
                      _logDataList.Any(x => x.LogType == InformationLogTypeEnum.Exception ||
                                            x.LogType == InformationLogTypeEnum.Error);
            }
        }
        public bool HasLog
        {
            get
            {
                return _logDataList != null &&
                      _logDataList.Count > 0;
            }
        }
        public int Count
        {
            get
            {
                if (_logDataList != null)
                    return _logDataList.Count;

                return 0;
            }
        }

        private List<InformationLog> _logDataList = new List<InformationLog>();
        private Guid _id = Guid.NewGuid();

        #endregion

        #region Constructors
        public InformationLogHolder()
        {
            MakeDefault();
        }
        public InformationLogHolder(string holderName)
        {
            MakeDefault();

            HolderName = holderName;
        }
        #endregion

        #region Methods

        public void CleanInformationLog()
        {
            _logDataList = new List<InformationLog>();
        }
        public void AddInformationLog(InformationLog log)
        {
            if (_logDataList == null)
                CleanInformationLog();

            _logDataList.Add(log);
        }
        public void AddInformationLog(List<InformationLog> logList)
        {
            if (_logDataList == null)
                CleanInformationLog();

            _logDataList.AddRange(logList);
        }
        public void AddExceptionData(Exception ex)
        {
            if (_logDataList == null)
                CleanInformationLog();

            _logDataList.Add(new InformationLog(ex));
        }
        public void AddInformationLogList(List<InformationLog> dataList)
        {
            if (_logDataList == null)
                CleanInformationLog();

            _logDataList.AddRange(dataList);
        }
        public void AddExceptionDataList(List<Exception> exList)
        {
            if (_logDataList == null)
                CleanInformationLog();
            foreach (var item in exList)
            {
                _logDataList.Add(new InformationLog(item));
            }

        }
        public List<InformationLog> GetInformationDataList()
        {
            if (_logDataList == null)
                CleanInformationLog();

            var result = new List<InformationLog>();

            result.AddRange(_logDataList);

            return result;
        }

        #endregion

        #region Helper Methods

        private void MakeDefault()
        {
            _id = Guid.NewGuid();
            HolderName = _id.ToString();

            _logDataList = new List<InformationLog>();
        }

        #endregion

    }
}
