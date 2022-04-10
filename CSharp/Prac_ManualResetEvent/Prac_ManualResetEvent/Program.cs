using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prac_ManualResetEvent
{
    class Program
    {
        static void Main(string[] args)
        {
            MyThread myt = new MyThread();
            while (true)
            {
                Console.WriteLine("输入 stop后台线程挂起 start 开始执行！");
                string str = Console.ReadLine(); //挂起，只有输入后，下一步语句才会执行
                //打印了一段语句后，进入了readline（）模式，该线程仍然在继续执行中，

                if (str.ToLower().Trim() == "stop")
                {
                    myt.Stop();
                }
                if (str.ToLower().Trim() == "start")
                {
                    myt.Start();
                }
            }
        }
    }

    //class Program
    //{
    //    static void DownLoad()
    //    {
    //        Console.WriteLine("DownLoad Begin " + Thread.CurrentThread.ManagedThreadId);
    //        //Thread.Sleep(1000);
    //        Console.WriteLine("DownLoad End" + Thread.CurrentThread.ManagedThreadId);
    //    }
    //    static void Main(string[] args)
    //    {
    //        //创建Thread对象
    //        Thread thread1 = new Thread(DownLoad);
    //        Thread thread2 = new Thread(DownLoad);
    //        //启动线程
    //        thread2.Start();
    //        thread1.Start();

    //        Console.WriteLine("Main::" + Thread.CurrentThread.ManagedThreadId);
    //        Console.ReadKey();
    //    }
    //}
}
