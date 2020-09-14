using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLinqCore
{
    public class WorkSheetField
    {
        public int Id { get; set; }
        public string FieldName { get; set; }
        public string FieldValue { get; set; }

        public WorkSheet WorkSheet { get; set; }

    }
}
