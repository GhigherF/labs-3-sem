using System.Diagnostics;
using System.Reflection;
using System.Xml.Serialization;
using static lab4.Boquet.Plant.Bush;
using static System.Net.Mime.MediaTypeNames;

namespace lab4
{
    public class Testik1 : NullReferenceException
    {
        public static void WTF<T>(T a)
        {
           // Debug.Assert(false,"SSSHHHIIITTT!!!!");
            if (a==null)
            {
                throw new Exception(typeof(T)+" is NULL");
            }
        }
    }
    public class Testik2 : Exception
    {
        public Testik2(string message) : base(message) { }
    }

public class Testik3 : ArgumentException
{
  public Testik3(string message) : base(message) { }
}



public class Controller<T>
    {
        public void find(Listik<Cactus> temp1, Listik<Boquet.Plant.Flower.Rose> temp2, Listik<Boquet.Plant.Flower.Gladioulus> temp3,string match)
        {
            foreach (var i in temp1.elements)
            {
                if (i!=null) { if (i.color==match) Console.WriteLine($"{i.name}--{match}"); break;}

            }
            foreach (var i in temp2.elements)
            {
                if (i!=null) { if (i.color==match) Console.WriteLine($"{i.name}--{match}"); break; }

            }
            foreach (var i in temp3.elements)
            {
                if (i!=null) { if (i.color==match) Console.WriteLine($"{i.name}--{match}"); break; }

            }
        }
       public void sort(Listik<Cactus> temp1, Listik<Boquet.Plant.Flower.Rose> temp2, Listik<Boquet.Plant.Flower.Gladioulus> temp3)
        {
            int[] temp=new int[3];
            
            foreach (var i in temp1.elements)
            {
                if (i!=null) {temp[0]=i.price; break;}
           
            }
            foreach (var i in temp2.elements)
            {
                if (i!=null) { temp[1]=i.price; break; }

            }
            foreach (var i in temp3.elements)
            {
                if (i!=null) { temp[2]=i.price; break; }

            }
            int[] tmp = new int[3];
            tmp[0]=temp[0];
            tmp[1]=temp[1];
            tmp[2]=temp[2];

            Array.Sort(temp);

            for(int i = 0;i<3;i++)
            {
                if (temp[i]==tmp[0])
                {
                    temp1.Print();
                }
                if (temp[i]==tmp[1])
                {
                    temp2.Print();
                }
                if (temp[i]==tmp[2])
                {
                    temp3.Print();
                }
            }
        }

        public void price(Listik<Cactus> temp1,Listik<Boquet.Plant.Flower.Rose> temp2,Listik<Boquet.Plant.Flower.Gladioulus> temp3)
        {
            int sum = 0;
            
           
           foreach(var i in temp1.elements)
            {
                if (i != null)
                {
                    sum+=i.price;
                }
                
            }
            foreach (var i in temp2.elements)
            {
                if (i != null)
                {
                    sum+=i.price;
                }
            }
            foreach (var i in temp3.elements)
            {
                if (i != null)
                {
                    sum+=i.price;
                }
            }

            Console.WriteLine($"Total sum:{sum}");
        }
       
    }

    public abstract class ATD<T>
    {
        public abstract void Add(T item);
        public abstract void Remove(T item);
        public abstract void Print();
    }


    public  class Listik<T> : ATD<T>
    {
        public int k = 0;
        int n = 0;
        public T[]elements=new T[5];
              
       
    public override void Add(T item)
        {
            
            elements[k++]=item;

        }
        public override void Remove(T item) 
        {
            elements[k-1]=default(T);
        }
        public override void Print()
        {
           foreach(T i in elements)
            {
                
                if (i is Cactus temp)
                {
                    Console.WriteLine($"Name:{temp.name}\nPrice:{temp.price}\n");
                }
                if (i is Boquet.Plant.Flower.Rose temp1)
                {
                    Console.WriteLine($"Name:{temp1.name}\nPrice:{temp1.price}\n");
                }
                if (i is Boquet.Plant.Flower.Gladioulus temp2)
                {
                    Console.WriteLine($"Name:{temp2.name}\nPrice:{temp2.price}\n");
                }
   
            }
        }
    }
 
    public struct Action
    {
       public string action;
        public override string ToString()
        {
            return action;
        }
    }
    public enum Month:short
    {
        January=1,February,March,April,May,Lune,July,August,September,Spooktober,NoNutNovember,December
    
    }


    public class Printer
    {
        public void IAmPrinting(Need gg)
        {
            if (gg is Cactus) Console.WriteLine("Cactus---"+gg.ToString());
            else if (gg is lab4.Boquet.Plant.Flower.Rose) Console.WriteLine("Rose----"+gg.ToString());
            else if (gg is lab4.Boquet.Plant.Flower.Gladioulus) Console.WriteLine("Gladiolus----"+gg.ToString());
        }
    }
   public abstract class Need
    {
        public int a = 5;
        public int price;
        public int beauty ;
        virtual  public void  Cool()
        {
            Console.WriteLine("COOOOOOOL");
            
        }
    }

    sealed public class Test
    {
        public int a = 2;
    }
    interface IFlower
    {
        string name { get; set;}
        public void Cool();
    }
    interface ITest:IFlower
    {

    }
 
    public class Boquet
    {

       public class Plant
        {
            public class Bush//куст
            {
             
             public class Cactus:Need,IFlower//,Test
                {
                    public void ToString(Cactus arr)
                    {
                        Console.WriteLine("Price"+arr.price);
                        Console.WriteLine("Beauty:"+arr.beauty);
                    }
                    public override void Cool()
                    {
                        Console.WriteLine("Class Cool");
                    }
                    void IFlower.Cool()
                    {
                        Console.WriteLine("Inteface Cool");
                    }

                    public string name { get; set; } = "Kakaktus";
               
                    public int GetHashCode(Cactus arr)
                    {
                        return arr.price.GetHashCode();
                    }
                   public System.Type GetType <T>(T arr)
                    {

                      return arr.GetType();
                    }
                   public bool Equals(Cactus arr,Cactus arr2)
                    { 
                        return(arr.price==arr2.price&&arr.beauty==arr2.beauty);
                    }
                   public int price = 200;
                   public int beauty = 40;
                    public string color = "green";
                }
            }
            public class Flower
            { 
              public  class Rose:Need,IFlower
                {
                    public void ToString(Rose arr)
                    {
                        Console.WriteLine("Price"+arr.price);
                        Console.WriteLine("Beauty:"+arr.beauty);
                    }
                    public  void Cool()
                    {
                        Console.WriteLine("Cool");
                    }
                    public string name { get; set; } = "Rose";
                    public int price = 1000;
                   public int beauty = 100;
                    public string color = "white";
                }
                public class Gladioulus:Need,IFlower
                {
                    public void ToString(Gladioulus arr)
                    {
                        Console.WriteLine("Price"+arr.price);
                        Console.WriteLine("Beauty:"+arr.beauty);
                    }
                    public void Cool()
                    {
                        Console.WriteLine("Cool");
                    }
                    public string name { get; set; } = "Gladiouliousuis";
                    public int price = 400;
                    public int beauty = 70;
                    public string color = "violet";
                }

            }
        }
        class Paper
        {
            int price1 = 50;
            int density1 = 300;//плотность
            int price2 = 70;
            int density2 = 450;
        }
    }
    /// <summary>
    /// ///////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
   internal partial class gg
    {
        private int a = 5;       
    }
    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>
    public static class main
    {
        public static void Main()
        {


            //  test1.ToString(test1);
            //Console.WriteLine(test1.GetHashCode(test1));
            //  Console.WriteLine(test1.GetType(test1));

            //Boquet.Plant.Bush.Cactus temp1=new Boquet.Plant.Bush.Cactus();
            //Boquet.Plant.Flower.Rose temp2 = new Boquet.Plant.Flower.Rose();
            //  Console.WriteLine(temp1 is IFlower);
            //  Console.WriteLine(temp1 is ITest);
            //  ITest gg=temp1 as ITest;
            //  Console.WriteLine(gg is ITest);
            //Console.WriteLine(temp1.a);
            //  temp2.name="rose";
            //temp1.Cool();
            //  IFlower temp=temp1;
            //  temp.Cool();
            //  temp2.Cool();
            //Need tst1 = new Boquet.Plant.Bush.Cactus();
            //Need tst2 = new Boquet.Plant.Flower.Rose();
            //Need tst3=new Boquet.Plant.Flower.Gladioulus();
            //Need[] arr = {tst1,tst2,tst3};
            //Printer gg= new Printer();
            //foreach (var i in arr)
            //{
            //    gg.IAmPrinting(i);
            //}
            //gg b = new gg();
            //Console.WriteLine(b.b);

            //5 lab
            //Action toDo=new Action();
            //toDo.action="Some Action";
            //Action toDo2=new Action();
            //toDo2.action="Some other Action";
            //Console.WriteLine($"1.{toDo.ToString()}\n2.{toDo2.ToString()}");
            //Console.WriteLine((Month)9);

            //Listik<Boquet.Plant.Flower.Rose> gg = new Listik<Boquet.Plant.Flower.Rose>();
            //Boquet.Plant.Flower.Rose rose = new Boquet.Plant.Flower.Rose();
            //Cactus cactus = new Cactus();
            //Boquet.Plant.Flower.Gladioulus gladioulus = new Boquet.Plant.Flower.Gladioulus();
            //gg.Add(rose);
            //gg.Remove(rose);
            //gg.Add(rose);
            //gg.Remove(rose);
            //gg.Add(rose);

            
            //Listik<Cactus> qq = new Listik<Cactus>();
            
            //Listik<Boquet.Plant.Flower.Gladioulus> zz = new Listik<Boquet.Plant.Flower.Gladioulus>();
            //zz.Add(gladioulus);
            //zz.Add(gladioulus);
            //zz.Print();
            //Controller<Cactus> tmp = new Controller<Cactus>();
            //tmp.price(qq, gg, zz);
            //tmp.sort(qq,gg,zz);
            //tmp.find(qq,gg,zz,"violet");

            string test = null;
            int monthTest = 13;
            bool i = false;
            int j = 0;
            try
            {
                try
                {
                    //Testik1.WTF(test);

                    //if (monthTest<0||monthTest>12) throw new Testik2("Месяц неверный");

                    Listik<Cactus> qq = new Listik<Cactus>();
                    Controller<Cactus> tmp = new Controller<Cactus>();
                    Listik<Boquet.Plant.Flower.Gladioulus> zz = new Listik<Boquet.Plant.Flower.Gladioulus>();
                    Listik<Boquet.Plant.Flower.Rose> gg = new Listik<Boquet.Plant.Flower.Rose>();
                    string a = "gg";
                    if (a!="violet"&&a!="white"&&a!="green") throw new Testik3("Цвет неверный");
                    tmp.find(qq, gg, zz, a);

                    //Listik<Cactus> qq = new Listik<Cactus>();
                    //Controller<Cactus> tmp = new Controller<Cactus>();
                    //Listik<Boquet.Plant.Flower.Gladioulus> zz = new Listik<Boquet.Plant.Flower.Gladioulus>();
                    //Listik<Boquet.Plant.Flower.Rose> gg = new Listik<Boquet.Plant.Flower.Rose>();
                    //string a =null;
                    //Testik1.WTF(a);
                    //tmp.find(qq, gg, zz, a);

                    //Listik<Cactus> qq = null;
                    //Testik1.WTF(qq);
                    //qq.Add(new Cactus());
                    //qq.Print();
                }
                catch
                {
                    Console.WriteLine("Беда-беда\n");
                    throw;
                }
            }
            catch (Exception e) when (j==0)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine();
                Console.WriteLine(e.StackTrace);
                Console.WriteLine();
                Console.WriteLine(e.TargetSite);
                Console.WriteLine();
            }
            finally
            {
                Environment.Exit(0);
            }
            Console.WriteLine("То что не должны увидеть");
        }
    }
    
}