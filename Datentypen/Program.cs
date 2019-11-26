using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datentypen
{
    class Program
    {
        static void Main(string[] args)
        {
            Baum baum = new Baum();
            baum.Add(50);
            baum.Add(100);
            baum.Add(25);
            baum.Add(12);
            baum.Add(15);
            baum.Add(210);
            baum.Add(150);
            baum.Add(170);

            //Console.WriteLine(baum.RootNode.Inhalt);
            Console.ReadKey();

            #region AlteListen


            //    List<int> test = new List<int>();


            //    //int[] test3 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            //    //int[] test2 = new int[] { 1, 2, 3, 4, 5 };

            //    //test2.CopyTo(test3, 4);
            //    //foreach (var item in test3)
            //    //{
            //    //    Console.WriteLine(item);
            //    //}


            //    //Console.ReadKey();

            //    ArrayList<int> arraylist = new ArrayList<int>();
            //    int[] array = new int[]{1,2,3,4,5,6,7,8,9,10};

            //    array[1] = 3;
            //    Console.WriteLine(array[1]);

            //    ArrayList<int> arraylist2 = new ArrayList<int>();
            //    //arraylist2.Add(1);
            //    //arraylist2.Add(2);
            //    //arraylist2.Add(3);
            //    //arraylist2.Add(4);
            //    //arraylist2.Add(5);
            //    //arraylist2.Add(6);
            //    //arraylist2.Add(7);
            //    //arraylist2.Add(8);
            //    //arraylist2.Add(9);
            //    //arraylist2.Add(10);
            //    arraylist.Add(11);
            //    arraylist.Add(22);
            //    arraylist.Add(33);
            //    arraylist.Add(44);
            //    arraylist.Add(55);
            //    arraylist.Add(66);
            //    arraylist.Add(77);
            //    arraylist.Add(88);
            //    arraylist.RemoveAt(2);


            //    foreach (var item in arraylist)
            //    {
            //        Console.WriteLine(item);
            //    }

            //    Console.ReadKey();
            //    //  arraylist.Remove(25433);

            //    foreach (int j in array)
            //    {
            //        Console.WriteLine(j);
            //    }

            #endregion

        }
    }
}
