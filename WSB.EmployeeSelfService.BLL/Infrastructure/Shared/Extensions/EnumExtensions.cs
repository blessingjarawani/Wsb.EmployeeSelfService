using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WSB.EmployeeSelfService.BLL.Infrastructure.Shared.Extensions
{
    public static class EnumExtensions
    {
        public static string DisplayName(this Enum enumValue)
        {
            try
            {
                var displayAttr = enumValue.GetType().GetMember(enumValue.ToString())
                       .First()
                       .GetCustomAttribute<DisplayAttribute>();
                return displayAttr != null ? displayAttr.Name : enumValue.ToString();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }
    }
}
