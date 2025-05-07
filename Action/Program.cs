namespace ActionFunc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Creating function pointers using our own custom delegate
            var data = new ProcessData();
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;

            //1.Method that uses our custom delegate
            data.Process(10, 20, multiplyDel);

            //2.Creating function pointers with the build in delegate Action
            Action<int, int> addAction = (x, y) => Console.WriteLine($"Action Result: {x + y}");
            Action<int, int> multiplyAction = (x, y) => Console.WriteLine($"Action Result: {x * y}");

            //2.Method that uses the built in Action delegate
            data.ProcessAction(10, 20, multiplyAction);

            //3.Using an INVOCATION list to chain multiple functions calls
            Action<int, int> invocationList = (x, y) => Console.WriteLine($"Invocation Result 1: {x + y}");
            invocationList += (x, y) => Console.WriteLine($"Invocation Result 2: {x * y}");

            //3.Passing the INVOCATION list to be called in another method
            data.ProcessAction(10, 20, invocationList);

            //4.Creating function pointers with the built in delegate Func
            Func<int, int, int> addFunc = (x, y) => x + y;
            Func<int, int, int> multiplyFunc = (x, y) => x * y;

            //4.Method that uses the built in Func delegate
            data.ProcessFunc(10, 20, multiplyFunc);

            Console.ReadLine();
        }
    }

    public enum WorkTypeEnum
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }

    //taskkill /IM Lambdas.exe /F command to kill the app if it bugs out
}
