using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prac_ManualResetEvent
{
    class MyThread //这只是一个普通的类
    {
        //Thread t = null;   //类里有一个字段，线程对象，分配内存
        ManualResetEvent manualEvent = new ManualResetEvent(true);//为true,一开始就可以执行
        //ManualResetEvent 是一线程用来控制别一个线程的信号。可以把它看成 操作系统原理中说到的pv操作

        private void Run()
        {
            int i = 0;
            while (true)
            {
                this.manualEvent.WaitOne();//阻止当前线程，直到当前 WaitHandle 收到信号。(继承自 WaitHandle)
                Console.WriteLine("这里是 {0}", Thread.CurrentThread.ManagedThreadId);               
                Console.WriteLine("这是第{0}次循环",i++);
                Thread.Sleep(5000);
            }
        }
        public void Start()
        {
            this.manualEvent.Set();
        }
        public void Stop()
        {
            this.manualEvent.Reset();
        }
        public MyThread() 
        {
            Thread t = new Thread(this.Run); //新建一个线程，该线程调用了本类实例的run函数
            t.Start();
        }
    }

}

