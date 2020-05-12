using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.C_DataAccess_Log.DBModel;
using Fhs.Cachless.D_Common.Enums;
using Fhs.Cachless.D_Common.Model;
using Fhs.Cachless.D_Common.Model.BaseModels;

namespace Fhs.Cachless.C_DataAccess_Log.DA
{
    public class AppRequestLogDA:_BaseLogDA
    {
        public AppRequestLogDA() : base(ObjectTypeEnum.AppRequestLog)
        {
        }

        #region Abstract Methods

        public override List<_BaseDbModel> GetAllBaseDbModel()
        {
            var itemList = GetAllAppRequestLogTable();
            return itemList.ConvertAll(x => (_BaseDbModel)x).ToList();
        }

        public override _BaseDbModel GetBaseDbModelById(int id)
        {
            return GetAppRequestLogTableById(id);
        }

        public override _BaseDbModel GetBaseDbModelById(Guid id)
        {
            return GetAppRequestLogTableById(id);
        }

        public override IdentifyClass InsertBaseDbModel(_BaseDbModel data)
        {
            if (data == null ||
                !(data is AppRequestLogTable)) return new IdentifyClass();

            return InsertAppRequestLogTable((AppRequestLogTable)data);
        }

        public override bool UpdateBaseDbModel(_BaseDbModel data)
        {
            if (data == null ||
                !(data is AppRequestLogTable)) return false;

            return UpdateAppRequestLogTable((AppRequestLogTable)data);
        }

        public override bool DeleteBaseDbModel(int id)
        {
            return DeleteAppRequestLogTable(id);
        }

        public override bool DeleteBaseDbModel(Guid id)
        {
            return DeleteAppRequestLogTable(id);
        }


        #endregion

        #region Public Methods of AppRequestLog

        public List<AppRequestLogTable> GetAllAppRequestLogTable()
        {
            try
            {
                return ContextDb.AppRequestLogTables.AsNoTracking().Select(x => x).ToList();
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return new List<AppRequestLogTable>();
            }
        }

        public AppRequestLogTable GetAppRequestLogTableById(int id)
        {
            try
            {
                return ContextDb.AppRequestLogTables.AsNoTracking().FirstOrDefault(x => x.Id == id);
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return null;
            }
        }

        public AppRequestLogTable GetAppRequestLogTableById(Guid id)
        {
            try
            {
                return ContextDb.AppRequestLogTables.AsNoTracking().FirstOrDefault(x => x.ObjectId == id);
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return null;
            }
        }

        public IdentifyClass InsertAppRequestLogTable(AppRequestLogTable data)
        {
            try
            {
                if (data == null) return new IdentifyClass();

                if (data.ObjectId == Guid.Empty)
                    data.ObjectId = Guid.NewGuid();
                data.CreateTime = DateTime.Now;
                data.LastUpdateTime = DateTime.Now;

                ContextDb.AppRequestLogTables.Add(data);
                ContextDb.SaveChanges();

                return new IdentifyClass(data.Id, data.ObjectId, data.ObjectType);
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return new IdentifyClass();
            }
        }

        public bool UpdateAppRequestLogTable(AppRequestLogTable data)
        {
            try
            {
                data.LastUpdateTime = DateTime.Now;

                var oldData = ContextDb.AppRequestLogTables.First(x => x.Id == data.Id);
                if (oldData == null) return false;

                data.Id = oldData.Id;
                data.ObjectId = oldData.ObjectId;
                data.CreateTime = oldData.CreateTime;

                var prop = ContextDb.Entry(oldData);
                prop.CurrentValues.SetValues(data);
                ContextDb.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return false;
            }
        }

        public bool DeleteAppRequestLogTable(int id)
        {
            try
            {
                var oldData = ContextDb.AppRequestLogTables.FirstOrDefault(x => x.Id == id);

                if (oldData == null) return true;

                ContextDb.AppRequestLogTables.Remove(oldData);
                ContextDb.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return false;
            }
        }

        public bool DeleteAppRequestLogTable(Guid id)
        {
            try
            {
                var oldData = ContextDb.AppRequestLogTables.FirstOrDefault(x => x.ObjectId == id);

                if (oldData == null) return true;

                ContextDb.AppRequestLogTables.Remove(oldData);
                ContextDb.SaveChanges();

                return true;
            }
            catch (Exception e)
            {
                AddExceptionData(e);
                return false;
            }
        }


        #endregion

        #region Specific Methods of AppRequestLog

        #endregion

        #region Helper Methods
        #endregion
    }
}
