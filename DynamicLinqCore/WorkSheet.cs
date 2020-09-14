using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicLinqCore
{
    public class WorkSheet
    {
        public int Id { get; set; }

        public string Protocol { get; set; }

        public List<WorkSheetField> Fields { get; set; }

    }
}
