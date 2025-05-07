namespace Lambdas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var worker = new Worker();

            //Lambda function instead of a specific defined function, also uses delegate inference
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine("Worked: " + e.Hours + " hour(s) doing: " + e.WorkType);
                Console.WriteLine("WorkPerformed lambda called");
            };

            //Same thing
            worker.WorkCompleted += (s, e) =>
            {
                Console.WriteLine("Work has completed lambda");
            };

            worker.DoWork(8, WorkTypeEnum.Golf);

            //another example of lambda functions
            var customers = new List<Customer>
            {
                new Customer("Phoenix", "John", "Doe", 1),
                new Customer("Phoenix", "Jane", "Doe", 500),
                new Customer("Seattle", "Suki", "Pizzoro", 3),
                new Customer("New York City", "Michelle", "Smith", 4)
            };

            var phoenixCustomers = customers
                .Where(c => c.City == "Phoenix")// --> Uses a lambda function that returns a bool
                .OrderBy(c => c.LastName);// --> Uses a lambda function that returns a string

            //With full syntax for better understanding
            var phoenixCustomersFullSyntax = customers
                .Where((c) =>
                {
                    var result = c.City == "Phoenix";
                    return result;
                })
                .OrderBy((c) =>
                {
                    var result = c.LastName;
                    return result;
                });

            foreach (var customer in phoenixCustomers)
            {
                Console.WriteLine("Without full syntax: ");
                Console.WriteLine(customer.FirstName + " " + customer.LastName);
            }

            foreach(var customer in phoenixCustomersFullSyntax) 
            {
                Console.WriteLine("With full syntax: ");
                Console.WriteLine(customer.FirstName + " " + customer.LastName);
            }

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
