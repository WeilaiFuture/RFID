using System;
using System.IO.Pipes;

namespace test
{
    //结点
    public class MyNode
    {
        private double num;
        private MyNode next;

        //构造函数
        public MyNode()
        {
            num = 1;
            next = null;
        }
        //属性：num的值
        public double Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
            }
        }
        //属性：指针
        public MyNode Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            MyNode head = new MyNode();
            Console.WriteLine("请输入k的大小：");
            int n = int.Parse(Console.ReadLine());//读取n的大小
            Console.WriteLine("{0}", MathFunc(n, head));
        }

        static double MathFunc(int n, MyNode node)
        {
            double ans = 1;//因为0的阶乘是1因此，默认答案从1开始
            //用单链表保存n的阶乘的值，也可以用通过循环只保存当前i的阶乘的值
            //前者可以重现n的阶乘，当数据很大时、多次输入时减少时间，后者不可重现但节省空间
            MyNode current = node;
            MyNode next = current.Next;
            for (int i = 1; i <= n; i++)
            {
                ans += i * i;
                //判断链表中是否存储数据、重现
                if (next == null)
                {
                    next = new MyNode();
                    next.Num = current.Num * (i + 1);
                }
                ans += 1 / current.Num;
                current = next;
                next = current.Next;
            }
            return ans;
        }
    }
}
