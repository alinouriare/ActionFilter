using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.B_Domain_Log.AppModels;
using Fhs.Cachless.C_DataAccess_Log.DA;
using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.D_Common.Model;

namespace Fhs.Cachless.B_Domain_Log.AppDomains
{
    public abstract class _BaseLogRoot<T> : _BaseLogApp where T : _BaseAppLogModel, new()
    {
        #region Variables

        public T RootData
        {
            get
            {
                try
                {
                    if (_rootData == null)
                        ReloadRoot();

                    return _rootData ?? (_rootData = new T());
                }
                catch (Exception e)
                {
                    AddExceptionData(e);
                }

                return null;
            }
            set
            {
                var temp = value;

                if (temp == null)
                {
                    _id = 0;
                    _objectId = Guid.Empty;
                    _oldRootData = null;
                    ReloadRoot();
                    return;
                }


                _rootData = temp;
            }
        }

        private T _rootData = null;
        private T _oldRootData = null;
        private int _id = 0;
        private Guid _objectId = Guid.Empty;
        #endregion

        #region Constructors

        public _BaseLogRoot()
        {
            try
            {
                MakeDefaults();
            }
            catch (Exception e)
            {
                AddExceptionData(e);
            }
        }
        public _BaseLogRoot(int id)
        {
            try
            {
                MakeDefaults();

                if (id <= 0) return;

                var tempData = new T();
                _rootData = (T)GetBaseDataByIdAndType(id, tempData.ObjectType);

                var loadDeleteData = ThisAppContext.GetSystemConfig("DataBaseGroup", "IsLoadDeleteIteminDB", false);
                if (_rootData == null ||
                    (!loadDeleteData && _rootData.DeleteTime != null))
                {
                    AddExceptionData(new Exception("داده فراخوانی شده با شناسه " + id + " وجود ندارد و یا حذف شده است ."));
                    _rootData = new T();
                    return;
                }

                _id = _rootData.Id;
                _objectId = _rootData.ObjectId;
                _oldRootData = (T)_BaseAppLogModel.GetBaseDataByObjecType(tempData.ObjectType, _rootData.MakeDataBaseModel());

            }
            catch (Exception e)
            {
                AddExceptionData(e);
            }
        }
        public _BaseLogRoot(Guid objectId)
        {
            try
            {
                MakeDefaults();

                if (objectId == Guid.Empty) return;

                var tempData = new T();
                _rootData = (T)GetBaseDataByIdAndType(objectId, tempData.ObjectType);

                var loadDeleteData = ThisAppContext.GetSystemConfig("DataBaseGroup", "IsLoadDeleteIteminDB", false);
                if (_rootData == null ||
                    (!loadDeleteData && _rootData.DeleteTime != null))
                {
                    AddExceptionData(new Exception("داده فراخوانی شده با شناسه " + objectId + " وجود ندارد و یا حذف شده است ."));
                    _rootData = new T();
                    return;
                }

                _id = _rootData.Id;
                _objectId = _rootData.ObjectId;
                _oldRootData = (T)GetBaseDataByIdAndType(objectId, tempData.ObjectType);

            }
            catch (Exception e)
            {
                AddExceptionData(e);
            }
        }
        public _BaseLogRoot(T data, bool loadOldDataAgaing = false)
        {
            try
            {
                MakeDefaults();

                if (data == null) return;

                _rootData = data;
                _id = data.Id;
                _objectId = data.ObjectId;

                if (loadOldDataAgaing)
                    _oldRootData = (T)GetBaseDataByIdAndType(_id, data.ObjectType);
                else
                    _oldRootData = data;
            }
            catch (Exception e)
            {
                AddExceptionData(e);
            }
        }

        #endregion

        #region Methods

        public OperationStatusResult Save()
        {
            try
            {
                if (RootData == null)
                    throw new Exception("داده ریشه ذخیره سازی یافت نشد! RootData = null.");


                RootData.LastUpdateTime = DateTime.Now;
                if (Id == 0 &&
                    _oldRootData == null)
                    RootData.CreateTime = DateTime.Now;

                var result = SaveBaseRoot();

                if (result.Status == OperationStatusEnum.Success ||
                    result.Status == OperationStatusEnum.SuccessfulWithAlarmingDetails)
                {
                    _id = result.IdentifyData.DataId;
                    _objectId = result.IdentifyData.DataObjectId;

                    ReloadRoot();
                }

                return result;
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return new OperationStatusResult(OperationStatusEnum.Failed, new IdentifyClass(), e);
            }
        }
        public bool Delete()
        {
            try
            {
                #region Delete FileDataRelation
                #endregion

                #region Delete TagDataRelation
                #endregion

                #region Delete Comment
                #endregion

                #region Delete RootData

                var deleteRootFlag = DeleteBaseRoot();
                #endregion

                #region Add Log To DB
                #endregion


                return deleteRootFlag;
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return false;
            }
        }

        public static T GetDataById(int id)
        {
            try
            {
                var tType = new T();
                var data = GetBaseDataByIdAndType(id, tType.ObjectType);

                if (data == null ||
                    data.ObjectType != tType.ObjectType ||
                    !(data is T))
                    return null;

                return (T)data;
            }
            catch (Exception e)
            {
                AddStaticExceptionData(e);
                return null;
            }
        }
        public static T GetDataById(Guid id)
        {
            try
            {
                var tType = new T();
                var data = GetBaseDataByIdAndType(id, tType.ObjectType);

                if (data.ObjectType != tType.ObjectType ||
                    !(data is T))
                    return null;

                return (T)data;
            }
            catch (Exception e)
            {
                AddStaticExceptionData(e);
                return null;
            }
        }
        public static List<T> GetAllData()
        {
            try
            {
                var tType = new T();
                var daDA = _BaseLogDA.GetBaseDataAccessByObjectType(tType.ObjectType);
                var dbList = daDA.GetAllBaseDbModel();
                var result = new List<T>();

                foreach (var baseDBModel in dbList)
                {
                    var item = _BaseAppLogModel.GetBaseDataByObjecType(tType.ObjectType, baseDBModel);

                    if (item.ObjectType != tType.ObjectType ||
                       !(item is T)) continue;

                    result.Add((T)item);
                }

                return result;
            }
            catch (Exception e)
            {
                AddStaticExceptionData(e);
                return new List<T>();
            }
        }

        protected static _BaseAppLogModel GetBaseDataByIdAndType(int id, ObjectTypeEnum objType)
        {
            try
            {
                var dbData = _BaseLogDA.GetBaseDataByObjectId(id, objType);

                if (dbData == null) return null;

                return _BaseAppLogModel.GetBaseDataByObjecType(objType, dbData);
            }
            catch (Exception e)
            {
                AddStaticExceptionData(e);
                return null;
            }
        }
        protected static _BaseAppLogModel GetBaseDataByIdAndType(Guid id, ObjectTypeEnum objType)
        {
            try
            {
                var dbData = _BaseLogDA.GetBaseDataByObjectId(id, objType);

                if (dbData == null) return null;

                return _BaseAppLogModel.GetBaseDataByObjecType(objType, dbData);
            }
            catch (Exception e)
            {
                AddStaticExceptionData(e);
                return null;
            }
        }
        #endregion

        #region Abstract Methods

        protected abstract OperationStatusResult SaveBaseRoot();
        protected abstract bool DeleteBaseRoot();

        #endregion

        #region Abstract Implementation Methods

        protected sealed override int GetDataId()
        {
            try
            {
                if (RootData != null)
                    return RootData.Id;
                return 0;
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return 0;
            }
        }
        protected sealed override Guid GetDataObjectId()
        {
            try
            {
                if (RootData != null)
                    return RootData.ObjectId;
                return Guid.Empty;
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return Guid.Empty;
            }
        }
        protected sealed override ObjectTypeEnum GetDataObjectType()
        {
            try
            {
                if (RootData != null)
                    return RootData.ObjectType;
                return ObjectTypeEnum.Null;
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return ObjectTypeEnum.Error;
            }
        }
        protected sealed override string GetDataName()
        {
            try
            {
                if (RootData != null)
                    return RootData.GetObjectName();
                return "";
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return "";
            }
        }
        protected sealed override IdentifyClass GetDataIdentifyData()
        {
            try
            {
                if (RootData != null)
                    return RootData.IdentifyData;
                return new IdentifyClass();
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return new IdentifyClass();
            }
        }

        #endregion

        #region Helper Methods

        private void MakeDefaults()
        {
            try
            {
                _id = 0;
                _objectId = Guid.Empty;
                _rootData = new T();
                _oldRootData = null;
            }
            catch (Exception e)
            {
                AddExceptionData(e);
            }
        }

        public void ReloadRoot()
        {
            try
            {
                CleanExceptionDataList();

                var tempData = new T();
                if (_id > 0)
                {
                    _rootData = (T)GetBaseDataByIdAndType(_id, tempData.ObjectType);

                    var loadDeleteData = ThisAppContext.GetSystemConfig("DataBaseGroup", "IsLoadDeleteIteminDB", false);
                    if (_rootData == null ||
                        (!loadDeleteData && _rootData.DeleteTime != null))
                    {
                        AddExceptionData(new Exception("داده فراخوانی شده با شناسه " + _id + " وجود ندارد و یا حذف شده است ."));
                        _rootData = new T();
                        return;
                    }
                    else
                        _oldRootData = (T)_BaseAppLogModel.GetBaseDataByObjecType(tempData.ObjectType, _rootData.MakeDataBaseModel());
                }
                else if (_objectId != Guid.Empty)
                {
                    _rootData = (T)GetBaseDataByIdAndType(_objectId, tempData.ObjectType);

                    var loadDeleteData = ThisAppContext.GetSystemConfig("DataBaseGroup", "IsLoadDeleteIteminDB", false);
                    if (_rootData == null ||
                        (!loadDeleteData && _rootData.DeleteTime != null))
                    {
                        AddExceptionData(new Exception("داده فراخوانی شده با شناسه " + _objectId +
                                                       " وجود ندارد و یا حذف شده است ."));
                        _rootData = new T();
                        return;
                    }
                    else
                        _oldRootData = (T)_BaseAppLogModel.GetBaseDataByObjecType(tempData.ObjectType, _rootData.MakeDataBaseModel());
                }
                else
                {
                    _rootData = new T();
                    _oldRootData = null;
                }

                _id = _rootData.Id;
                _objectId = _rootData.ObjectId;
            }
            catch (Exception e)
            {
                AddExceptionData(e);
            }
        }



        #endregion
    }
}
