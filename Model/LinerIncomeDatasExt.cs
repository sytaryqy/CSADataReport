using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSADataReport.Model
{
    public partial class LinerIncomeDatas
    {
        //_userCompany字段，存放Model.Companies对象
        private Companies _userCompany;
        //U_UserCompany属性，操作_userCompany字段
        public Companies L_UserCompany
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

        //_linerCompany字段，存放Model.LinerCompany对象
        private LinerCompany _linerCompany;
        //L_linerCompany属性，操作_linerCompany字段
        public LinerCompany L_linerCompany
        {
            get
            {
                if (_linerCompany == null)
                {
                    _linerCompany = new LinerCompany();
                }
                return _linerCompany;
            }
            set
            {
                _linerCompany = value;
            }
        }
    }
}
