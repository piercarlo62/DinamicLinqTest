using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
<<<<<<< HEAD
using System.Text.RegularExpressions;
=======
>>>>>>> bb8c64620c7ba8e76e6688df6ab6424a60f5d42d
using System.Threading.Tasks;

namespace DynamicLinqCore
{
    public static class StringExtensions
    {
        public static string GetPropertyValue(this List<WorkSheetField> fields, string fieldName)
        {
            foreach (var field in fields)
            {
                if (field.FieldName == fieldName)
                    return field.FieldValue;
            }
            return string.Empty;
        }
<<<<<<< HEAD

        public static string FormatValueAsProperty(this string strValue, bool AddDesc)
        {
            if (strValue.Contains(" desc"))
                strValue = strValue.Replace(" desc", "");
            if (AddDesc)
            {
                return Regex.Replace(strValue, "[\\s-_!+\"'%/=()\\[\\]{}<>,;:*~ˇ^˘°\\\\#&@]", "").StripAccent().AddDesc();
            }
            else
                return Regex.Replace(strValue, "[\\s-_!+\"'%/=()\\[\\]{}<>,;:*~ˇ^˘°\\\\#&@]", "").StripAccent();
        }

        public static string StripAccent(this string strValue)
        {
            string A;
            string B;
            int i;
            const string AccChars = "ŠŽšžŸÀÁÂÃÄÅÇÈÉÊËÌÍÎÏÐÑÒÓÔÕÖÙÚÛÜÝàáâãäåçèéêëìíîïðñòóôõöùúûüýÿ";
            const string RegChars = "SZszYAAAAAACEEEEIIIIDNOOOOOUUUUYaaaaaaceeeeiiiidnooooouuuuyy";
            for (i = 0; i < AccChars.Length; i++)
            {
                A = AccChars.Substring(i, 1);
                B = RegChars.Substring(i, 1);
                strValue = strValue.Replace(A, B);
            }

            return strValue;
        }

        public static string AddDesc(this string strValue)
        {
            return strValue + " desc";
        }
    }

    public static class ListExtensions
    {
        public static List<string> GetFormattedValueAsAPropertyList(this List<string> list)
        {
            List<string> listToReturn = new List<string>();
            foreach (var item in list)
            {
                if (item.Contains(" desc"))
                {
                    var str = item.Replace(" desc", "");
                    listToReturn.Add(str.FormatValueAsProperty(true));
                }
                else
                {
                    listToReturn.Add(item.FormatValueAsProperty(false));
                }
            }

            return listToReturn;
        }
=======
>>>>>>> bb8c64620c7ba8e76e6688df6ab6424a60f5d42d
    }
}
