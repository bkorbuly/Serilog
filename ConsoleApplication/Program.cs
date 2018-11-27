using System;
using Serilog;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            InitLogging();

            Log.Logger.Verbose("Application started in appdomain {DomainID}",
                                             AppDomain.CurrentDomain.Id);

            Log.Logger.Debug("Application started with {CommandLineArguments}",
                                          args);

            var firstNum = int.Parse(args[0]);
            var secondNum = int.Parse(args[1]);

            Log.Logger.Debug("Attempting to divide {FirstNumber} by {SecondNumber}",
                                          firstNum, secondNum);

            Log.Logger.Warning("This is a simulated warning");

            int result = 0;

            try
            {
                result = firstNum / secondNum;
            }
            catch (Exception ex)
            {
                Log.Logger.Error(ex, 
                                            "Error trying to divide {FirstNumber} by {SecondNumber}",
                                            firstNum, secondNum);

                Console.ReadLine();

                Environment.Exit(-1);
            }
            

            Log.Logger.Information("{FirstNumber} divided by {SecondNumber} is {Result}",
                                          firstNum, secondNum, result);


            Console.ReadLine();
        }

        private static void InitLogging()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug() 
                .WriteTo.ColoredConsole()
                .CreateLogger();
        }
    }
}
