using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambdas
{
    public class WorkPerformedEventArgs
    {
        public int Hours { get; set; }
        public WorkTypeEnum WorkType { get; set; }
        public WorkPerformedEventArgs(int hours, WorkTypeEnum workType)
        {
            Hours = hours;
            WorkType = workType;
        }
    }
}
