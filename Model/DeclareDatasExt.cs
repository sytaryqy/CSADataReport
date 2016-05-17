using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSADataReport.Model
{
    public partial class DeclareDatas
    {
        //_userCompany字段，存放Model.Companies对象
        private Companies _userCompany;
        //U_UserCompany属性，操作_userCompany字段
        public Companies D_UserCompany
        {
            get
            {
                if (_userCompany == null)
                {
                    _userCompany = new Companies();
                }
                return _userCompany;
            }
            set
            {
                _userCompany = value;
            }
        }

        ////_DeclareOperationType字段，存放Model.DeclareOperationTypes对象
        //private DeclareOperationTypes _DeclareOperationType;
        ////D_UserRoles属性，操作_DeclareOperationType字段
        //public Model.DeclareOperationTypes D_DeclareOperationType
        //{
        //    get
        //    {
        //        if (_DeclareOperationType == null)
        //        {
        //            _DeclareOperationType = new DeclareOperationTypes();
        //        }
        //        return _DeclareOperationType;
        //    }
        //    set
        //    {
        //        _DeclareOperationType = value;
        //    }
        //}

        ////_DeclareType字段，存放Model.DeclareTypes对象
        //private Model.DeclareTypes _DeclareType;

        ////D_DeclareType属性，操作_DeclareType字段
        //public Model.DeclareTypes D_DeclareType
        //{
        //    get
        //    {
        //        if (_DeclareType == null)
        //        {
        //            _DeclareType = new DeclareTypes();
        //        }
        //        return _DeclareType;
        //    }
        //    set
        //    {
        //        _DeclareType = value;
        //    }
        //}
    }
}
