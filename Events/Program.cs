namespace Events
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();
            worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);//adding the call back function to the function pipeline
            worker.WorkCompleted += new EventHandler(Worker_WorkCompleted);
            //Delegate inference, compiler creates the delegate on its own, simpler syntax
            worker.WorkCompleted += Worker_WorkCompleted;
            //This is a lambda function, which is pretty much an Anonymous function with a specific signature
            worker.WorkCompleted += (s, e) => {
                Console.WriteLine("Work has completed lambda");
            };

            worker.DoWork(8, WorkTypeEnum.Golf);

            Console.ReadLine();
        }

        //Call back function/ event handler
        static void Worker_WorkPerformed(object? sender, WorkPerformedEventArgs e)
        {
            Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
        }

        static void Worker_WorkCompleted(object? sender, EventArgs e)
        {
            Console.WriteLine("Work has completed");
        }
    }

    public enum WorkTypeEnum
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }

    //taskkill /IM Events.exe /F command to kill the app if it bugs out
}
