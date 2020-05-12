using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.D_Common.Enums;

namespace Fhs.Cachless.D_Common.Model
{
    public class OperationStatusResult
    {
        #region Variables
        public OperationStatusEnum Status { get; set; }
        public IdentifyClass IdentifyData { get; set; }
        public bool HasErrorMessage
        {
            get
            {
                try
                {
                    if (MessageList.Count > 0 &&
                        MessageList.Any(x => x.LogType == InformationLogTypeEnum.Error ||
                                             x.LogType == InformationLogTypeEnum.Exception))
                        return true;

                    return false;
                }
                catch (Exception e)
                {
                    AddToMessageList(e);
                    return false;
                }
            }
        }
        public List<InformationLog> MessageList
        {
            get
            {
                var result = new List<InformationLog>();
                try
                {
                    if (_messageList == null || _messageList.Count == 0) return result;

                    result.AddRange(_messageList);
                }
                catch (Exception e)
                {
                    result.Add(new InformationLog(e));
                }

                return result;
            }
        }


        private List<InformationLog> _messageList = new List<InformationLog>();
        #endregion

        #region Constructors
        public OperationStatusResult()
        {
            MakeDefaults();
        }
        public OperationStatusResult(OperationStatusEnum status, IdentifyClass identifyData)
        {
            MakeDefaults();
            Status = status;
            IdentifyData = identifyData;


        }
        public OperationStatusResult(OperationStatusEnum status, IdentifyClass identifyData, Exception e)
        {
            MakeDefaults();
            Status = status;
            IdentifyData = identifyData;

            AddToMessageList(e);

        }
        public OperationStatusResult(OperationStatusEnum status, IdentifyClass identifyData, List<Exception> eList)
        {
            MakeDefaults();
            Status = status;
            IdentifyData = identifyData;

            AddToMessageList(eList);

        }
        public OperationStatusResult(OperationStatusEnum status, IdentifyClass identifyData, InformationLog e)
        {
            MakeDefaults();

            Status = status;
            IdentifyData = identifyData;

            AddToMessageList(e);
        }
        public OperationStatusResult(OperationStatusEnum status, IdentifyClass identifyData, List<InformationLog> eList)
        {
            MakeDefaults();

            Status = status;
            IdentifyData = identifyData;

            AddToMessageList(eList);
        }
        #endregion

        #region Helper Methods

        private void MakeDefaults()
        {
            Status = OperationStatusEnum.Null;
            IdentifyData = new IdentifyClass();
            _messageList = new List<InformationLog>();
        }

        public void CleanMessageList()
        {
            _messageList = new List<InformationLog>();
        }
        public void AddToMessageList(InformationLog data)
        {
            if (_messageList == null)
                _messageList = new List<InformationLog>();

            _messageList.Add(data);
        }
        public void AddToMessageList(List<InformationLog> dataList)
        {
            if (_messageList == null)
                _messageList = new List<InformationLog>();

            _messageList.AddRange(dataList);
        }

        public void AddToMessageList(Exception data)
        {
            if (_messageList == null)
                _messageList = new List<InformationLog>();

            _messageList.Add(new InformationLog(data));
        }
        public void AddToMessageList(List<Exception> dataExList)
        {
            if (_messageList == null)
                _messageList = new List<InformationLog>();

            _messageList.AddRange(dataExList.Select(x => new InformationLog(x)).ToList());
        }

        #endregion
    }
}
