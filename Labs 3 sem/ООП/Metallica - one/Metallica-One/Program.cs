using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
static void Main()
{
    ///////////////////ONE/////////////////////
    bool a = false;
    byte b = 0;
    sbyte c = 1;
    char d = 'a';
    decimal e = 9E5m;
    double f = 2.3;
    float g = 5.6F;
    int h = -2;
    uint i = 9;
    nint j = -99;
    nuint k = 11;
    long l = -1112;
    ulong r = 122313;
    short v = 2;
    ushort s = 3;
    Console.Beep();
    /////////////////TWO////////////////////////////////
    int q = b+c;
    int bb = d;
    double gg = l;
    long ll = h;
    long lll = j;
    Console.WriteLine(q);
    Console.WriteLine(bb);
    Console.WriteLine(gg);
    Console.WriteLine(ll);
    Console.WriteLine(lll);

    uint kk = (uint)h;
    decimal ff = (decimal)g;
    float vhs = (float)f;
    short qq = (short)l;
    int bbq = (int)r;
    Console.WriteLine(kk);
    Console.WriteLine(ff);
    Console.WriteLine(vhs);
    Console.WriteLine(qq);
    Console.WriteLine(bbq);


    Convert.ToDouble(c);
    Console.WriteLine(c);

    ///////////////////////THREE///////////////////////
    int cat = 56;
    object box = cat;
    Console.WriteLine(box);
    int sinep = (int)box;
    Console.WriteLine(sinep);

    //////////////////////Four////////////////////////
    var arab = 300;
    var abba = 9e10;
    Console.WriteLine(arab.GetType());
    Console.WriteLine(abba.GetType());
    ////////////////////Five///////////////////////
    object ggg = null;
    Console.WriteLine(ggg);
    ////////////////////////Sex///////////////////////
    var bbbb = 64;
    Console.WriteLine(bbbb);
    //  bbbb=2.1E6;
    Console.WriteLine(bbbb);

    ///////////////////////////////////Stringi//////////////////////////
    ///a///
    ///
    string aaaa = "qwertyy", beee = "qwerty";
    Console.WriteLine(String.Compare(aaaa, beee));
    ///a.i///
    string one = "one one one ";
    string two = "two two ";
    string three = "3";
    one=String.Concat(one, two);
    Console.WriteLine(one);
    Console.WriteLine(two.Clone());
    three=two.Substring(4, 4);
    Console.WriteLine(three);
    var nn = one.Split(" ");
    Console.WriteLine(nn[4]);
    three=one.Insert(4, three);
    Console.WriteLine(three);
    three=three.Replace("two", "");
    Console.WriteLine(three);
    Console.WriteLine($"is {0} more than {1}?", a, b);
    ///b////
    string no1 = "";
    string no2 = null;
    Console.WriteLine(String.Compare(no1, no2));
    Console.WriteLine(String.IsNullOrEmpty(no1));
    Console.WriteLine(String.IsNullOrEmpty(no2));
    //c//
    StringBuilder sb = new StringBuilder("GHIGHER");
    sb.Insert(0, "BEST ");
    sb.AppendLine(" REALLY COOL");
    sb.Replace("GHIGHER", "C#");
    Console.WriteLine(sb);

    ////////////////////MASSIVE////////////////////////
    ///a///
    int[,] dim2 = new int[2, 2];
    for (i=0; i<2; i++)
    {
        for (j=0; j<2; j++)
        {
            dim2[i, j]=Convert.ToInt32(Console.ReadLine());
        }
    }

    Console.WriteLine();
    for (i=0; i<2; i++)
    {
        for (j=0; j<2; j++)
        {
            Console.Write(dim2[i, j]);
            Console.Write(' ');

        }
        Console.WriteLine();
    }
    ///b///
    string[] strings = new string[5];
    for (i=1; i<=4; i++)
    {
        for (j=1; j<=i; j++)
        {
            strings[i]=strings[i]+"gg";
        }
    }

    Console.WriteLine("Length:"+strings.Length);
    Console.WriteLine();
    for (i=1; i<=4; i++)
    {
        Console.Write(strings[i]+" ");
    }

    int pos = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine();
    string val = Console.ReadLine();
    strings[pos]=val;
    for (i=1; i<=4; i++)
    {
        Console.Write(strings[i]+" ");
    }
    ////c//////
    double[][] arr = new double[3][];
    arr[0]=new double[2] { 1, 2 };
    arr[1]=new double[3] { 1, 2, 3 };
    arr[2]=new double[4] { 1, 2, 3, 4 };
    for (i=0; i<arr.Length; i++)
    {
        for (j=0; j<arr[i].Length; j++)
        {
            Console.Write(arr[i][j]+" ");
        }
    }
    ///d///
    var kok = "ghigher";
    Console.WriteLine(" ");
    Console.WriteLine(kok.GetType());

    var dik = new int[1, 2, 2];
    Console.WriteLine(dik.GetType());
    ///////////КОРТЕЖ///////////////
    ///a,b///
    (int, string, char, string, ulong) cort = (52, "ghigher", '!', "KSIS", 89876);
    Console.WriteLine($"Int:{cort.Item1},string:{cort.Item2},char:{cort.Item3},string:{cort.Item4},ulong:{cort.Item5}");
    Console.WriteLine($"Int:{cort.Item1},char:{cort.Item3},ulong:{cort.Item5}");
    ///c///
    var cortex = ("GG", 228);
    (string name, int age) = cortex;


    string name2;
    int age2;
    (name2, age2) = cortex;
    Console.WriteLine(name);
    Console.WriteLine(age);
    Console.WriteLine(name2);
    Console.WriteLine(age2);
    ///d////
    (int, int) s1 = (1, 2);
    (int, int) s2 = (1, 2);
    Console.WriteLine(s1 == s2);
    ///////////////5//////////
    Console.WriteLine("N:");
    int count = Convert.ToInt32(Console.ReadLine());
    int[] array = new int[count];
    for (i=0; i<count; i++)
    {
        array[i]=Convert.ToInt32(Console.ReadLine());
    }
    Console.WriteLine("String:");
    string strrts = Console.ReadLine();

    (int, int, int, char) function(int[] array, string strrts)
    {
        int min = 999999999, max = -99999999, sum = 0;
        for (int i = 0; i<array.Length; i++)
        {
            if (array[i]>max) max=array[i];
            if (array[i]<min) min=array[i];
            sum+=array[i];
        }
        var result = (1, 2, 2, 'g');
        char kkkkkkk = strrts[0];
        result =(min, max, sum, kkkkkkk);
        return result;
    }

    Console.WriteLine(function(array, strrts));
    int lol = int.MaxValue;
    //checked
    //{
    //    Console.WriteLine(lol+50);
    //}
    unchecked
    {
        Console.WriteLine(lol+50);
    }
}
Main();

