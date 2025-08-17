using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Libralgo.Business.Extensions
{
    public static class EnumHelper
    {
        public static List<SelectListItem> GetEnums<T>()
        {
            var values = Enum.GetValues(typeof(T));

            var selectList = new List<SelectListItem>();

            foreach (var value in values)
            {
                selectList.Add(new SelectListItem { Text = value.ToString(), Value = value.ToString() });
            }

            return selectList;
        }
    }
}
