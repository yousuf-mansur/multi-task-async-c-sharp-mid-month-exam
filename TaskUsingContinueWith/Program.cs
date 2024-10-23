using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskUsingContinueWith
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
            for (int counter = 1; counter < 13; counter++)
            {
                if (counter % 3 == 0)
                {
                    WriteFactorialUsingTaskContinueWith(counter);
                }
                else
                {
                    Console.WriteLine(counter);
                }
            }
        }

        private static void WriteFactorialUsingTaskContinueWith(int counter)
        {
            Task<int> task = Task.Run<int>(() => 
            {
                int result = FindFactorialWithDelay(counter);
                return result;


            });
            task.ContinueWith(new Action<Task<int>>((a) =>
            {
                Console.WriteLine($"Factorial of {counter} is {a.Result}");
            }));
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
