namespace Delegates
{
    public delegate int WorkPerformedHandler(int hourse, WorkTypeEnum workType);//Creates a method "type" for function pointers
    internal class Program
    {
        static void Main(string[] args)
        {
            //adds the WorkPerformed1 as the WorkPerformedHandler type
            var delegate1 = new WorkPerformedHandler(WorkPerformed1);
            var delegate2 = new WorkPerformedHandler(WorkPerformed2);

            //Added the delegate2 to the delegate1, so when delegate1 is called so is delegate2, delegates can be chained together(probably a linked list)
            delegate1 += delegate2;

            //calls the delegate1, which dups the data to the function called WorkPerformed1, passes or points the data to the WorkPerformed1
            int finalHours = delegate1(10, WorkTypeEnum.Golf);

            Console.ReadLine();
        }

        static int WorkPerformed1(int hours, WorkTypeEnum workType)
        {
            Console.WriteLine("WorkPerformd1 called " + hours.ToString());
            return hours + 1;
        }
        static int WorkPerformed2(int hours, WorkTypeEnum workType)
        {
            Console.WriteLine("WorkPerformd2 called " + workType.ToString());
            return hours + 1;
        }
    }

    public enum WorkTypeEnum
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
