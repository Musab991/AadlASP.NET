using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Aadl.Models.General
{
    public static class EnumExtensions
    {
        public static IEnumerable<SelectListItem> GetEnumSelectList<TEnum>()
            where TEnum : struct, IConvertible
        {
            if (!typeof(TEnum).IsEnum)
            {
                throw new ArgumentException("TEnum must be an enumerated type");
            }

            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>().Select(e => new SelectListItem
            {
                Value = Convert.ToInt32(e).ToString(),
                Text = e.GetType()
                        .GetMember(e.ToString())
                        .First()
                        .GetCustomAttribute<DisplayAttribute>()?.GetName() ?? e.ToString()
            });
        }
    }
}
