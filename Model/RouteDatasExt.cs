using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSADataReport.Model
{
    public partial class RouteDatas
    {
        //_userCompany字段，存放Model.Companies对象
        private Companies _userCompany;
        //R_UserCompany属性，操作_userCompany字段
        public Companies R_UserCompany
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

        //_routes字段，存放Model.Routes对象
        private Routes _routes;
        //R_Routes属性，操作_routes字段
        public Routes R_Routes
        {
            get
            {
                if (_routes == null)
                {
                    _routes = new Routes();
                }
                return _routes;
            }
            set
            {
                _routes = value;
            }
        }

        //_lines字段，存放Model.Lines对象
        private Lines _lines;
        //R_Lines属性，操作_lines字段
        public Lines R_Lines
        {
            get
            {
                if (_lines == null)
                {
                    _lines = new Lines();
                }
                return _lines;
            }
            set
            {
                _lines = value;
            }
        }
    }
}
