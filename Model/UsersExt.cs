using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSADataReport.Model
{
    public partial class Users
    {
        //_userCompany字段，存放Model.Companies对象
        private Companies _userCompany;
        //U_UserCompany属性，操作_userCompany字段
        public Companies U_UserCompany
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

        //_userRoles字段，存放Model.UserRoles对象
        private UserRoles _userRoles;
        //U_UserRoles属性，操作_userRoles字段
        public Model.UserRoles U_UserRoles
        {
            get
            {
                if (_userRoles == null)
                {
                    _userRoles = new UserRoles();
                }
                return _userRoles;
            }
            set
            {
                _userRoles = value;
            }
        }

        //_userStateId字段，存放Model.UserStates对象
        private Model.UserStates _userStateId;

        //U_UserStates属性，操作_userRoles字段
        public Model.UserStates U_UserStates
        {
            get
            {
                if (_userStateId == null)
                {
                    _userStateId = new UserStates();
                }
                return _userStateId;
            }
            set
            {
                _userStateId = value;
            }
        }
    }
}
