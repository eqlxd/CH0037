using System;

namespace DelegateUnd
{
    //声明一个委托
    public delegate void TimeEventHandler(object obj, TimeEventArgs args);
    //TimeEventArgs是我们自己定义的一个类,用于保存事件中的参数.这里我们分别保存时间的时分秒
    public class TimeEventArgs : EventArgs
    {
        private int hour;
        private int minute;
        private int second;
        public TimeEventArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }
        public int Hour
        {
            get
            {
                return this.hour;
            }
        }
        public int Minute
        {
            get
            {
                return this.minute;
            }
        }
        public int Second
        {
            get
            {
                return this.second;
            }
        }
    }

    //观察者类,它有一个符合我们上面定义的"委托"的方法
    //也就是void ShowTime(object obj,TimeEventArgs args)
    //从这个方法的定义可以看到,我们只会关心返回类型和方法的参数,而方法名称则无所谓
    class MyClassEventHandler
    {
        public void ShowTime(object obj, TimeEventArgs args)  
        {
            Console.WriteLine("现在时间：" + args.Hour + ":" + args.Minute + ":" + args.Second);
        }
    }

    //时钟类
    class Clock
    {
        //我们在这个类中定义了一个"TimeChanged"事件,注意其前面有两个关键字"event"和"TimeEventHandler"
        //其中event表示这是一个事件，而不是方法或属性,TimeEventHandler则指出,谁要监听TimeChanged事件,
        //它就必须有一个符合TimeEventHandler（委托）的方法
        public event TimeEventHandler TimeChanged;
        public Clock()
        {
            //注意,这里的null的含义是指TimeChanged事件当前还没有观察者关注它
            //如果某个观察者要关注TimeChanged事件,它必须要让这个事件知道,方法是使用操作符"+="来借助委托将其加载到事件上
            TimeChanged = null;
        }
        //时钟开始走动，我们的目标是每秒钟触发一次TimeChanged事件
        public void go()
        {
            DateTime initi = DateTime.Now;
            int h1 = initi.Hour;
            int m1 = initi.Minute;
            int s1 = initi.Second;
            while (true)
            {
                DateTime now = DateTime.Now;
                int h2 = now.Hour;
                int m2 = now.Minute;
                int s2 = now.Second;
                if (s2 != s1)
                {
                    h1 = h2;
                    m1 = m2;
                    s1 = s2;
                    //首先建立一个TimeEventArgs对象来保存相关参数,这里是时分秒
                    TimeEventArgs args = new TimeEventArgs(h2, m2, s2);
                    //注意这种写法,这一句是用来触发事件,事件不是类,所以不用使用"new"关键字,而且我们看到,这里TimeChanged的两个参数跟我们的委托（TimeEventHandler）是一致的
                    //其中第一个参数是触发这个事件的对象,我们这里使用的是一个时钟实例(this)
                    TimeChanged(this, args);
                }
            }
        }
    }
        class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
                Clock clock = new Clock(); //实例化一个时钟            
                MyClassEventHandler tehc = new MyClassEventHandler(); //实例化一个观察者类

            //将事件跟我们定义的观察者进行连接
            //这样,clock就会知道,每当TimeChanged事件被触发,就会去通知这个观察者
            //注意我们连接的时候使用的并不是直接的观察者类实例中的ShowTime()方法
            //而是一个委托,并在这个委托中传递ShowTime()方法,这也是"委托"的真正意义所在:
            //我有一个方法,但我委托你来帮我关联到事件,因为事件只会直接跟委托打交道,
            //而不是观察者的具体某个方法
            clock.TimeChanged += new TimeEventHandler(tehc.ShowTime);
            clock.go();
        }
    }
}
