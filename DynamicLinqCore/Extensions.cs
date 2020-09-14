using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
