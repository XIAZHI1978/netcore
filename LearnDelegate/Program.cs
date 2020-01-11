using System;
using System.Linq.Expressions;

namespace LearnDelegate
{
    class Program
    {
        public delegate int CalulatorAdd(int x, int y);
        static void Main(string[] args)
        {
            //委托
            CalulatorAdd cAdd = new CalulatorAdd(Add);
            Console.WriteLine("Delegate Results : " + cAdd.Invoke(1, 1));

            //匿名方法            
            CalulatorAdd cAdd1 = delegate (int x, int y) { return x + y; };
            Console.WriteLine("Annoymous Results : " + cAdd1.Invoke(1, 2));

            //Lambda语法
            CalulatorAdd cAdd2 = (int x, int y) => { return x + y; };
            Console.WriteLine("Lambda 01 Results : " + cAdd2.Invoke(1, 3));

            CalulatorAdd cAdd3 = (x, y) => { return x + y; };
            Console.WriteLine("Lambda 02 Results : " + cAdd3.Invoke(1, 4));

            CalulatorAdd cAdd4 = (x, y) => x + y;
            Console.WriteLine("Lambda 03 Results : " + cAdd4.Invoke(1, 5));


            //泛型委托
            Func<int, int, int> cAdd5= (int x, int y) => { return x + y; };
            Console.WriteLine("Func 01 Results : " + cAdd5.Invoke(1, 6));

            Func<int, int, int> cAdd6= (x, y) => { return x + y; };
            Console.WriteLine("Func 02 Results : " + cAdd6.Invoke(1, 7));

            Func<int, int, int> cAdd7 = (x, y) => x + y;
            Console.WriteLine("Func 03 Results : " + cAdd7.Invoke(1, 8));

            //表达式树
            Expression<Func<int,int,int>> exp = (x,y) => x+y;

            Func<int, int, int> func = exp.Compile();
            Console.WriteLine("Expression 01 Results : " + func(1, 9));

        }

        public static int Add(int x, int y)
        {
            return x + y;
        }
    }
}
