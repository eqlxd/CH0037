using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prac_ManualResetEvent01
{
    class Program
    {
        // mre is used to block and release threads manually. It is
        // created in the unsignaled state.
        private static ManualResetEvent mre = new ManualResetEvent(false);//mre对象可以对线程进行控制，false表示初始状态为阻塞状态:"调用waitone（），则线程暂停"
        static void Main(string[] args)
        {   // mre is used to block and release threads manually. It is
            // created in the unsignaled state.
        
            Console.WriteLine("\nStart 3 named threads that block on a ManualResetEvent:\n");
            for (int i = 0; i <= 2; i++)
            {
                Thread t = new Thread(ThreadProc);  //将函数ThreadProc赋给线程
                t.Name = "Thread_" + i;
                t.Start(); //开始线程：跑函数ThreadProc，但因为mre对象可以对线程进行控制，false表示初始状态为阻塞状态:"调用waitone（），则线程暂停"
                Thread.Sleep(1000);
            }
            Thread.Sleep(500);
            Console.WriteLine("\nWhen all three threads have started, press Enter to call Set()" +
            "\nto release all the threads.\n");
            Console.ReadLine();
            mre.Set();  //mre.set()释放线程
            Thread.Sleep(500);
            Console.WriteLine("\nWhen a ManualResetEvent is signaled, threads that call WaitOne()" +
            "\ndo not block. Press Enter to show this.\n");
            Console.ReadLine();
            for (int i = 3; i <= 4; i++)
            {
                Thread t = new Thread(ThreadProc);
                t.Name = "Thread_" + i;
                t.Start();
            }
            Thread.Sleep(500);
            Console.WriteLine("\nPress Enter to call Reset(), so that threads once again block" +
            "\nwhen they call WaitOne().\n");
            Console.ReadLine();
            mre.Reset();//mre.set()使mre.waitone()可以暂停线程
            // Start a thread that waits on the ManualResetEvent.
            Thread t5 = new Thread(ThreadProc);
            t5.Name = "Thread_5";
            t5.Start();
            Thread.Sleep(500);
            Console.WriteLine("\nPress Enter to call Set() and conclude the demo.");
            Console.ReadLine();
            mre.Set();
            // If you run this example in Visual Studio, uncomment the following line:
            //Console.ReadLine();
        }
        private static void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;
            Console.WriteLine(name + " starts and calls mre.WaitOne()");
            mre.WaitOne(); //阻塞线程，直到调用Set方法才能继续执行
            Console.WriteLine(name + " ends.");
        }
    }}
