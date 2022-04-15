using System;
using System.Collections.Generic;
using System.Text;
using static DelegatedUnd01.Program;

namespace DelegatedUnd01
{
    class Otaku
    {
        

        //属性：宅男的名字
        public string Name { get; set; }
        //属性：宅男想吃什么
        public string DishName { get; set; }
        //属性：宅男饿不饿
        private bool hungryOrNot;

        public bool HungryOrNot
        {
            get { return hungryOrNot; }
            set { hungryOrNot = value; }
        }
        ////重写一下构造方法，让宅男初始状态是“饿”的
        public Otaku()
        {
            hungryOrNot = true;
        }
        public void WalkIn()
        {
            Console.WriteLine("我走进了餐厅...");
        }
        public void SitDown()
        {
            Console.WriteLine("我坐了下来...");
        }
        public void Thinking()
        {
            for (int i = 0; i < 5; i++)
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("该吃点什么呢？");
            }
        }
        public void OrderDish()
        {
            Console.WriteLine("就决定要吃你了！{0}!", this.DishName);
        }
        public void Eat()
        {
            if (this.HungryOrNot == true)
            {
                Console.WriteLine("我吃了{0},我饱了", this.DishName);
                this.hungryOrNot = false;
            }
            else
            {
                Console.WriteLine("还是算了吧，我已经很饱了");
            }
        }
        public void ViewBHu()
        {
            Console.WriteLine("我刷了B面的知乎，里面各个都是人才，我超喜欢里面的！");
        }
        public void PlayGames()
        {
            Console.WriteLine("嘤嘤嘤，没有野王带带瑶瑶吗？瑶瑶超可爱的QAQ");
        }
        public void Sleep()
        {
            Console.WriteLine("我睡着啦...");
        }
        public void GoToWork()
        {
            Console.WriteLine("996是我修来的福报！");
        }

        

        public void EnjoyAHappyDay(ThingsToDo noonRest)
        {
            GoToWork();
            Eat();

            //这里的形式参数是委托实例，所以可以被像方法一样调用
            noonRest();

            GoToWork();

            Console.WriteLine("真是美好的一天啊...");
        }
    }
}
