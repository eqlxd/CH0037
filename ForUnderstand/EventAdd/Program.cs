using System;
using System.Collections.Generic;

namespace EventAdd
{
    class Program
    {
        static void Main(string[] args)
        {
            Test tst = new Test();

            //给发出的一个事件（OnAddEvent），增加一个
            tst.OnAddEvent += new EventHandler<AddEventData>(AddEvent);//对事件Class变量使用+=进行委托


            tst.CallAddEvent();         // 触发事件
            Console.Read(); // 暂停程序
        }
        // 事件处理函数
        static void AddEvent(object sender, EventArgs e)
        {
            AddEventData ad = (AddEventData)e;
            int c = ad.a + ad.b;
            Console.WriteLine("触发事件AddEvent, a+b={0}", c);
        }
    }

    //步骤1：定义事件的参数，应继承自EventArgs
    public class AddEventData : EventArgs
    {
        public int a;
        public int b;
    }

    //步骤2：定义事件
    public class Test
    {
        //2.1:定义一个事件对象，该对象有两个参数（事件的发送者，事件参数）
        public event EventHandler<AddEventData> OnAddEvent;
        //注意：这里虽然叫eventHandler，但并不是事件的处理者，而是管理者

        //定义可以触发此事件的函数
        public void CallAddEvent()
        {
            if (OnAddEvent != null)
            {
                AddEventData ad = new AddEventData();
                ad.a = 1;
                ad.b = 2;
                OnAddEvent(this, ad);//到此，一个事件发生了，this发出，发出的事件参数为实例ad
            }
        }
    }
}
