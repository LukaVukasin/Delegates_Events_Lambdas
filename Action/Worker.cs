using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFunc
{
    //public delegate int WorkPerformedHandler(int hours, WorkTypeEnum workType);
    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs>? WorkPerformed;
        public event EventHandler? WorkCompleted;

        public void DoWork(int hours, WorkTypeEnum workType)
        {
            for (int i = 0; i < hours; i++)
            {
                Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkTypeEnum workType)
        {
            WorkPerformed?.Invoke(this, new WorkPerformedEventArgs(hours, workType));
        }

        protected virtual void OnWorkCompleted()
        {
            WorkCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
