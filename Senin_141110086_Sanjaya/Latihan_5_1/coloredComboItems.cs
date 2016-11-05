using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Reflection;
namespace Latihan_3_1
{

    class coloredComboItems
    {
        //static List<Color> GetConstants(Type enumType)
        //{
        //    MethodAttributes attributes = MethodAttributes.Static | MethodAttributes.Public;
        //    PropertyInfo[] properties = enumType.GetProperties();
        //    List<Color> list = new List<Color>();
        //    for (int i = 0; i < properties.Length; i++)
        //    {
        //        PropertyInfo info = properties[i];
        //        if (info.PropertyType == typeof(Color))
        //        {
        //            MethodInfo getMethod = info.GetGetMethod();
        //            if ((getMethod != null) && ((getMethod.Attributes & attributes) == attributes))
        //            {
        //                object[] index = null;
        //                list.Add((Color)info.GetValue(null, index));
        //            }
        //        }
        //    }
        //    return list;
        //}
        public static List<coloredComboObject> GetColors()
        {
            List<coloredComboObject> lst = new List<coloredComboObject>();
            var webColors =
              Enum.GetValues(typeof(KnownColor))
                .Cast<KnownColor>()
                .Where(k => k >= KnownColor.Transparent && k < KnownColor.ButtonFace) //Exclude system colors
                .Select(k => Color.FromKnownColor(k))
                .OrderBy(c => c.GetHue())
                .ThenBy(c => c.GetSaturation())
                .ThenBy(c => c.GetBrightness());
            foreach (Color list in webColors.ToList())
            {
                lst.Add(new coloredComboObject(list.Name, list));
            }
            return lst;
        }
    }
}
