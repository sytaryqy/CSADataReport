using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSADataReport.Model
{
    public partial class IncomeDatas
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
    }
}
