using System;


namespace DelegatedUnd01
{
    class Program
    {
        //定义一种委托类型，这种委托可以封装参数列表为空，没有返回值的方法
        delegate void FindSthToEat();
        //定义一种委托类型，这种委托可以封装参数列表为空，没有返回值的方法
        public delegate void ThingsToDo();


        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Otaku Rosen = new Otaku();
            Rosen.Name = "Rosen";
            Rosen.DishName = "午饭";

            //用委托对午休的内容进行封装
            ThingsToDo rest1 = new ThingsToDo(Rosen.ViewBHu);         
            ThingsToDo rest2 = new ThingsToDo(Rosen.Sleep);
            ThingsToDo rest3 = new ThingsToDo(Rosen.PlayGames);

           // 第一天
            Console.WriteLine("\n现在是周一");
            Rosen.EnjoyAHappyDay(rest1);

            //第二天
            Console.WriteLine("\n现在是周二");
            Rosen.EnjoyAHappyDay(rest2);

            //第三天
            Console.WriteLine("\n现在是周三");
            Rosen.EnjoyAHappyDay(rest3);




            Console.ReadLine();
        }
    }
}
