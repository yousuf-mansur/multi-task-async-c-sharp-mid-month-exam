using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDelegate
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
                    WriteFactorialUsingAsyncDelegate(counter);
                }
                else
                {
                    Console.WriteLine(counter);
                }
            }
        }

        private static void WriteFactorialUsingAsyncDelegate(int counter)
        {
            Func<int, int> FindFactorial = FindFactorialWithDelay;
            FindFactorial.BeginInvoke(counter, (iAsyncResult) =>
            {
                AsyncResult asyncResult = iAsyncResult as AsyncResult;
                Func<int, int> del = asyncResult.AsyncDelegate as Func<int, int>;
                int factorial = del.EndInvoke(asyncResult);
                Console.WriteLine($"Factorial of {counter} is {factorial}");

            }, null);
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
