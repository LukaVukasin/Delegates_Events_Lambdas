using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionFunc
{
    public delegate int BizRulesDelegate(int x, int y);

    public class ProcessData
    {
        //delegates enable us to pass functions as input parameters of ther functions, like below
        public void Process(int x, int y, BizRulesDelegate del) 
        {
            var result = del(x, y);
            Console.WriteLine($"Result: {result}");
        }

        //Built in delegate that does not return a value
        public void ProcessAction(int x, int y, Action<int, int> action) 
        {
            //We have no idea what the function does, it is DELEGATED somewhere else!
            action(x, y);
            Console.WriteLine("Action has been processed");
        }


        //Built in delegate that returns a value
        public void ProcessFunc(int x, int y, Func<int, int, int> func)
        {
            var result = func(x, y);
            Console.WriteLine($"Result from func: {result}");
        }
    }
}
