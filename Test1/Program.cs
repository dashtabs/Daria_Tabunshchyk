using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Homework
{
    [TestFixture]
    public class Task1
    {
        [Test]
        public void Test1()
        {
            IEnumerable<int> list = IntegersFromList(new List<object>() { 1, 0, "b", 2, "a" });
            Assert.AreEqual(list, new List<int>() { 1, 0, 2 });
        }
        [Test]
        public void Test2()
        {
            IEnumerable<int> list = IntegersFromList(new List<object>() { "b", "a" });
            Assert.AreEqual(list, new List<int>());
        }

        public static IEnumerable<int> IntegersFromList(List<object> smth)
        {
            return smth.OfType<int>();
        }
    }
    [TestFixture]
    public class Task2
    {
        [Test]
        public void Test3()
        {
            string str = "sTress";
            Assert.AreEqual('T', First_Non_Repearing_Letter(str));
        }

        [Test]
        public void Test4()
        {
            string str = "hheelloo";
            Assert.AreEqual(' ', First_Non_Repearing_Letter(str));
        }

        public static int NO_OF_CHARS = 256;
        public static char[] count = new char[NO_OF_CHARS];

        public static char First_Non_Repearing_Letter(string smth)
        {
            string str = smth.ToLower();
            for (int j = 0; j < smth.Length; j++)
            {
                count[str[j]]++;
            }

            int index = -1, i;

            for (i = 0; i < str.Length; i++)
            {
                if (count[str[i]] == 1)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                return ' ';
            }
            else
            {
                return smth[index];
            }
        }
    }
    [TestFixture]
    public class Task3
    {
        [Test]
        public void Test5()
        {
            int root = Digital_Root(16);
            Assert.AreEqual(7, root);
        }
        [Test]
        public void Test6()
        {
            int root = Digital_Root(132189);
            Assert.AreEqual(6, root);
        }
        public static int Digital_Root(int n)
        {
            int root = 0;
            while (n > 0 || root > 9)
            {
                if (n == 0)
                {
                    n = root;
                    root = 0;
                }
                root += n % 10;
                n /= 10;
            }
            return root;
        }
    }
    [TestFixture]
    public class Task4
    {
        [Test]
        public void Test7()
        {
            int[] nums = { 1, 3, 6, 2, 2, 0, 4, 5};
            int sum = 5;
            Assert.AreEqual(4, Number_Of_Pairs(nums, sum));
        }
        [Test]
        public void Test8()
        {
            int[] nums = { 1, 1, 1, 1 };
            int sum = 3;
            Assert.AreEqual(0, Number_Of_Pairs(nums, sum));
        }
        public static int Number_Of_Pairs(int[] numbers, int sum)
        {
            int number = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                for (int j = i+1; j < numbers.Length; j++)
                {
                    if ((numbers[i] + numbers[j]) == sum){
                        number++;
                    }
                }
            }
            return number;
        }
    }
    [TestFixture]
    public class Task5
    {
        [Test]
        public void Test9()
        {
           string s = "Fred:Corwill;Wilfred:Corwill;" +
                "Barney:TornBull;Betty:Tornbull;" +
                "Bjon:Tornbull;Raphael:Corwill;" +
                "Alfred:Corwill";
            Assert.AreEqual("(CORWILL, ALFRED)(CORWILL, FRED)" +
                "(CORWILL, RAPHAEL)(CORWILL, WILFRED)" +
                "(TORNBULL, BARNEY)(TORNBULL, BETTY)" +
                "(TORNBULL, BJON)", Sort_Friends(s));
        }
        [Test]
        public void Test10()
        {
            string s = "Fred:Corwill;Fred:Corwill;Barney:TornBull";
            Assert.AreEqual("(CORWILL, FRED)(CORWILL, FRED)(TORNBULL, BARNEY)", Sort_Friends(s));        }
        public static string Sort_Friends(string s)
        {
            return "(" + string.Join(")(",
        s.
        ToUpper().
        Split(';').
        Select(n => n.Split(':')).
        Select(n => string.Join(", ", n.Reverse())).
        OrderBy(n => n)) + ")";
        }
    }
    [TestFixture]
    public class Extra1
    {
        [Test]
        public void Test11()
        {
            int num = 2;
            Assert.AreEqual(-1, Next_Bigger(num));
        }
        [Test]
        public void Test12()
        {
            int num = 12;
            Assert.AreEqual(21, Next_Bigger(num));
        }
        public static int Next_Bigger(int num)
        {
            List<int> Int_List = new List<int>();
            List<int> Copy1 = new List<int>();
            List<int> Copy2 = new List<int>();

            while (num > 0)
            {
                Int_List.Add(num % 10);
                Copy1.Add(num % 10);
                Copy2.Add(num % 10);
                num = num / 10;
            }
            Copy1.Reverse();
            Copy2.Reverse();
            Int_List.Reverse();
            var pivot_index = -1;

            for ( int i = Int_List.Count - 1; i > 0; i--)
            {
                if (Int_List[i] > Int_List[i - 1])
                {
                    pivot_index = i - 1;
                    break;
                }
            }
            if (pivot_index == -1) return pivot_index;

            int n = Int_List.Count, x = Int_List[pivot_index];

            Copy1.RemoveRange(pivot_index, n - pivot_index);
            List<int> left = Copy1;

            Copy2.RemoveRange(0, (left.Count + 1));
            List<int> right = Copy2;
            right.Sort();

            int Smallest_Max = 0;
            for (int i = 0; i < right.Count; i++)
            {
                if (right[i] > x)
                {
                    Smallest_Max = right[i];
                    right.RemoveAt(i);
                    break;
                }
            }

            left.Add(Smallest_Max);

            right.Add(x);
            right.Sort();

            List<int> Final_List = left.Concat(right).ToList();

            int result = int.Parse(string.Join(",", Final_List).Replace(",", ""));

            return result;
        }
    }
    [TestFixture]
    public class Extra2
    {
        [Test]
        public void Test13()
        {
            string result = IPv4Address(32);
            Assert.AreEqual("0.0.0.32", result);
        }
        [Test]
        public void Test14()
        {
            string result = IPv4Address(2149583361);
            Assert.AreEqual("128.32.10.1", result);
        }

        public static string IPv4Address(uint input)
        {
            return IPAddress.Parse(input.ToString()).ToString();
        }
    }
}

