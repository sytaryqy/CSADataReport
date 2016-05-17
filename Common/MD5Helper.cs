using System;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace Maticsoft.Common
{
    public class MD5Helper
    {
        public string GetMD5(string str)
        {
            byte[] btys = Encoding.UTF8.GetBytes(str);

            byte[] btysMD5 = MD5.Create().ComputeHash(btys);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < btysMD5.Length; i++)
            {
                sb.Append(btysMD5[i].ToString("x").Length == 1 ? "0" + btysMD5[i].ToString("x") : btysMD5[i].ToString("x"));
            }
            return sb.ToString();
        }
    }
}