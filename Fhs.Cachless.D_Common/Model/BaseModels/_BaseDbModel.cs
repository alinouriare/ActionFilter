using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.D_Common.Enums;

namespace Fhs.Cachless.D_Common.Model.BaseModels
{
    public abstract class _BaseDbModel
    {
        #region Variables

        public int Id { get; set; }
        public System.Guid ObjectId { get; set; }
        public ObjectTypeEnum ObjectType
        {
            get
            {
                try
                {
                    var keyWord = "Table";
                    var tableName = GetChildClassName();
                    if (tableName.EndsWith(keyWord))
                        tableName = tableName.Substring(0, tableName.LastIndexOf(keyWord, StringComparison.Ordinal));

                    var objType = ObjectTypeEnum.Null;
                    if (Enum.TryParse(tableName, out objType))
                        return objType;

                    return ObjectTypeEnum.Null;
                }
                catch (Exception ex)
                {
                    return ObjectTypeEnum.Error;
                }
            }
        }
        public IdentifyClass IdentifyData
        {
            get
            {
                return new IdentifyClass(Id, ObjectId, ObjectType, "Base Table:" + GetChildClassName());
            }
        }
        public System.DateTime CreateTime { get; set; }
        public System.DateTime LastUpdateTime { get; set; }
        #endregion

        #region Constructors

        public _BaseDbModel()
        {
            MakeDefaults();
        }
        #endregion

        #region Abstract Methods

        protected abstract String GetChildClassName();

        #endregion

        #region Helper Methods

        private void MakeDefaults()
        {
            Id = 0;
            ObjectId = Guid.Empty;
            CreateTime = DateTime.Now;
            LastUpdateTime = DateTime.Now;
        }
        #endregion
    }
}
