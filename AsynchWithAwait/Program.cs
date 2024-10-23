using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsynchWithAwait
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DoTask();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
            finally { Console.ReadKey(); }
        }

        private static void DoTask()
        {
            for (int counter = 1; counter <= 13; counter++)
            {
                if (counter % 3 == 0)
                {
                    WriteFactorialusingAsynchAndAwaitt(counter);
                }
                else
                {
                    Console.WriteLine(counter);
                }
            }
        }

        private static async void WriteFactorialusingAsynchAndAwaitt(int counter)
        {
            int result= await Task.Run(()=>FindFactorialWithDelay(counter));
            Console.WriteLine($"Factorial of {counter} is {result}");
        }

        

        private static int FindFactorialWithDelay(int counter)
        {
            int result = 1;

            for (int i = 1; i <= counter; i++)
            {
                Thread.Sleep(500);
                result = result * i;
            }
            return result;
        }
    }
}
