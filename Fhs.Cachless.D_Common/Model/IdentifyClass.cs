using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fhs.Cachless.D_Common.Enums;

namespace Fhs.Cachless.D_Common.Model
{
    public class IdentifyClass
    {
        #region Variables

        public int DataId { get; set; }
        public Guid DataObjectId { get; set; }
        public ObjectTypeEnum DataType { get; set; }
        public String DataName { get; set; }

        public bool IsEmpty
        {
            get
            {
                if (DataId == 0 && DataObjectId == Guid.Empty && DataType == ObjectTypeEnum.Null)
                    return true;
                return false;
            }
        }

        private static String _seprator = "_";

        #endregion

        #region Constructors

        public IdentifyClass()
        {
            MakeDefaults();
        }

        public IdentifyClass(int dataId, Guid dataObjectId, ObjectTypeEnum objType, string dataName = "")
        {
            try
            {
                MakeDefaults();

                DataId = dataId;
                DataObjectId = dataObjectId;
                DataType = objType;
            }
            catch (Exception)
            {
                
            }
        }
        public IdentifyClass(string identifyStr)
        {
            try
            {
                MakeDefaults();

                if (String.IsNullOrEmpty(identifyStr) ||
                    String.IsNullOrWhiteSpace(identifyStr))
                    return;

                var strArray = identifyStr.Split(new string[] { _seprator }, StringSplitOptions.None);

                if (strArray.Length < 3)
                    return;

                var id = 0;
                if (int.TryParse(strArray[0], out id))
                    DataId = id;

                var gid = Guid.Empty;
                if (Guid.TryParse(strArray[1], out gid))
                    DataObjectId = gid;

                var dtype = ObjectTypeEnum.Null;
                if (Enum.TryParse(strArray[2], out dtype))
                    DataType = dtype;

                if (strArray.Length >= 3)
                    DataName = strArray[3];
            }
            catch (Exception e)
            {
                MakeDefaults();
            }
        }

        #endregion

        #region Methods

        public static bool operator ==(IdentifyClass a, IdentifyClass b)
        {
            var isANull = ((Object)a == null);
            var isBNull = ((Object)b == null);

            if (isANull && isBNull) return true;
            else if (isANull || isBNull) return false;
            else if (a.IsEmpty && b.IsEmpty) return true;

            if (a.DataObjectId == b.DataObjectId &&
                a.DataId == b.DataId &&
                a.DataType == b.DataType)
                return true;

            return false;
        }
        public static bool operator !=(IdentifyClass a, IdentifyClass b)
        {
            return !(a == b);
        }

        #endregion

        #region Helper Methods

        private void MakeDefaults()
        {
            DataId = 0;
            DataObjectId = Guid.Empty;
            DataType = ObjectTypeEnum.Null;
        }

        public override string ToString()
        {
            var dataName = "";
            if (!String.IsNullOrWhiteSpace(DataName) &&
                !String.IsNullOrEmpty(DataName))
                dataName = _seprator + DataName;

            return String.Format("{1}{0}{2}{0}{3}{4}", _seprator, DataId, DataObjectId, DataType, dataName);
        }
        protected bool Equals(IdentifyClass other)
        {
            return DataId == other.DataId && DataObjectId.Equals(other.DataObjectId) && DataType == other.DataType;
        }
        public override bool Equals(object obj)
        {
            return (base.Equals(obj) && (this == (IdentifyClass)obj));
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = DataId;
                hashCode = (hashCode * 397) ^ DataObjectId.GetHashCode();
                hashCode = (hashCode * 397) ^ (int)DataType;
                return hashCode;
            }
        }

        #endregion

    }
}
