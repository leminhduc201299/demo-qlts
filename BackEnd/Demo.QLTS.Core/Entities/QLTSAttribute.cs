using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.QLTS.Core.Entities
{
    /// <summary>
    /// Class Attribute đánh dấu thông tin bắt buộc nhập
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class Required : Attribute
    {
        public string ErrorMsg { get; set; }
        public Required(string errorMsg = null)
        {
            ErrorMsg = errorMsg;
        }
    }
}
