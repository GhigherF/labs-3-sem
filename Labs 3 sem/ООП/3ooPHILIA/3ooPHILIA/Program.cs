// See https://aka.ms/new-console-template for more information
using lab3;
using System.Buffers;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization.Formatters;
using System.Security.Cryptography.X509Certificates;
using System.Text.Encodings.Web;
namespace lab3
{
    public static class extend
    {
       public static void dot(this string[] str)
        {
            for (int i = 0; i<str.Length; i++)
            {
                str[i]+='.';
            }
        }
        public static void dot(this Set set)
        {
            for (int i = 0; i<set.length; i++)
            {
                set.sValues[i]+='.';
            }
        }

    }
   
    public class Set
    {
        public static class StatisticOperation
        {
            
            public static int? Sum(Set set)
            {
                int? sum = 0;
                for (int i = 0; i<set.length; i++)
                {
                    if (set.iValues[i]!=null) sum+=set.iValues[i];
                }

                   
                return sum;
            }
            public static int? Mix(Set set)
            {
                int? min=int.MaxValue;
                int? max=int.MinValue; 
                for (int i = 0; i<set.length; i++)
                {
                    if (set.iValues[i]!=null&&set.iValues[i]<min) min=set.iValues[i];
                    if (set.iValues[i]!=null&&set.iValues[i]>max) max=set.iValues[i];
                }
                return max-min;
            }
            public static int? Length(Set set)
            {
                int k = 0;
                for(int i = 0;i<set.length;i++)
                {
                    if (set.iValues[i]!=null) k+=1;
                }
                return k;
            }
            public static Set Zero(Set set)
            {
                Set tset = set;
                int k = 0;
                for (int i = 0; i< set.length; i++)
                {
                    if (set.iValues[i]==0&&set.iValues!=null)
                    {
                        set.iValues[i]=null; k+=1;
                    }
                }int j = -1;
                Console.WriteLine(k);
                Console.WriteLine(set.length);
               
                for(int i = 0;i<set.length-k;i++)
                {   j+=1;
                    while (set.iValues[j]==null) j+=1;
                    tset.iValues[i]=set.iValues[j];
                    
                } 
                tset.length=set.length-k+1;
                return tset;
              

            }
        }
        public class Production
        {
            int ID;
            string Name;
        }
        public class Developer
        {
            string FIO;
            int ID;
            string otdel;
        }


        public int length=-1;
       // public bool?[] flags;
        public int?[] iValues;
        public string?[] sValues;
        public bool?[] bValues;
        string type;

        public void Show<T>(T[] a)
        {
            if (length==-1) length=a.Length;
            for (int i = 0; i<length; i++)
            {
                if (a[i]!=null)
                {
  Console.Write(a[i]+" ");
                }
              
            }

            Console.WriteLine();
        }
        
        public Set(int?[] set)
        {
            int?[] a = set;
            iValues = a;
            type="int";
            Show(a);
        }
        public Set(string?[] set)
        {
            string?[] a = set;
            sValues = a;
            type="string";
            Show(a);
        }
        public Set(bool?[] set)
        {
            bool?[] a = set;
            bValues = a;
            type="bool";
            Show(a);
        }
        public void Showk()
        {
            switch (type)
            {
                case "int":
                    {
                        Show(iValues);
                        break;
                    }
                case "string":
                    {
                        Show(sValues);
                        break;
                    }
                case "bool":
                    {
                        Show(bValues);
                        break;
                    }
            }

        }
       
       public void minus(int match)
        {
            int?[] tmp = iValues;
           for (int i = 0; i<length; i++)
            {
                if (tmp[i] == match)
                {
                    tmp[i]=null;
                }
            }

            int temp = length;
            int j = 0;
            for (int i = 0; i<temp; i++)
            {
                if (tmp[i]!=null)
                {
                    iValues[j]=tmp[i];
                    j+=1;
                }
            }
            length=j;
        }
        public static Set operator -(Set set,int a)
        {
           set.minus(a);
            return set;
        }

        public void minus(bool match)
        {
            bool?[] tmp = (bValues);
            for (int i = 0; i<length; i++)
            {
                if (tmp[i] == match)
                {
                    tmp[i]=null;
                }
            }

            int temp = length;
            int j = 0;
            for (int i = 0; i<temp; i++)
            {
                if (tmp[i]!=null)
                {
                    bValues[j]=tmp[i];
                    j+=1;
                }
            }
            length=j;
        }
        public static Set operator -(Set set, bool a)
        {
            set.minus(a);
            return set;
        }

        public void minus(string match)
        {
            string[] tmp = sValues;
            for (int i = 0; i<length; i++)
            {
                if (tmp[i] == match)
                {
                    tmp[i]=null;
                }
            }

            int temp = length;
            int j = 0;
            for (int i = 0; i<temp; i++)
            {
                if (tmp[i]!=null)
                {
                    sValues[j]=tmp[i];
                    j+=1;
                }
            }
            length=j;
        }
        public static Set operator -(Set set, string a)
        {
            set.minus(a);
            return set;
        }


        public static Set? operator *(Set set, Set set2)
        {
            Set set3= set2;
            Set tset = set;
            Set tset2 = set2;
            if (set.ToString()!=set2.ToString()) { Console.WriteLine("Множества разных типов"); return set3; }

            else
            {

                switch (tset.type)
                {
                    case "int":
                        {
                            int k = 0;
                            for (int i = 0; i<tset.length; i++)
                            {
                                for (int j = 0; j<tset2.length; j++)
                                {
                                    if (tset.iValues[i]==tset2.iValues[j]&&tset.iValues[i]!=null&&tset2.iValues[j]!=null)
                                    {
                                        set3.iValues[k]=tset.iValues[i];
                                        k+=1;
                                        tset.iValues[i]=null;
                                        tset2.iValues[j]=null;
                                    }
                                }

                            }
                            set3.length=k;
                            return set3;
                        }
                    case "bool":
                        {
                            int k = 0;
                            for (int i = 0; i<tset.length; i++)
                            {
                                for (int j = 0; j<tset2.length; j++)
                                {
                                    if (tset.bValues[i]==tset2.bValues[j]&&tset.bValues[i]!=null&&tset2.bValues[j]!=null)
                                    {
                                        set3.bValues[k]=tset.bValues[i];
                                        k+=1;
                                        tset.bValues[i]=null;
                                        tset2.bValues[j]=null;
                                    }
                                }

                            }
                            set3.length =k;
                            return set3;
                        }
                    case "string":
                        {
                            int k = 0;
                            for (int i = 0; i<tset.length; i++)
                            {
                                for (int j = 0; j<tset2.length; j++)
                                {
                                    if (tset.sValues[i]==tset2.sValues[j]&&tset.sValues[i]!=null&&tset2.sValues[j]!=null)
                                    {
                                        set3.sValues[k]=tset.sValues[i];
                                        k+=1;
                                        tset.sValues[i]=null;
                                        tset2.sValues[j]=null;
                                    }
                                }

                            }
                            set3.length =k;
                            return set3;
                        }
                    default:
                        {
                            return set3;
                        }
                }



            }

        } 
        public static bool operator <(Set set,Set set2)
    {
            if (set.length!=set2.length) return false;
            if (set.type!=set2.type) return false;
            int k = 0;
            Set tset1 = set;
            Set tset2 = set2;
            switch (tset1.type)
            {
                case "int":
                    {
                        for (int i = 0; i<tset1.length; i++)
                        {
                            for (int j = 0; j<tset2.length; j++)
                            {
                                if (tset1.iValues[i]==tset2.iValues[j])
                                {
                                    tset1.iValues[i]=null;
                                    tset2.iValues[i]=null;
                                    k+=1;
                                }
                            }
                        }
                        if (k==tset1.length) return true; else return false;
                    }
                case "bool":
                    {
                        for (int i = 0; i<tset1.length; i++)
                        {
                            for (int j = 0; j<tset2.length; j++)
                            {
                                if (tset1.bValues[i]==tset2.bValues[j])
                                {
                                    tset1.bValues[i]=null;
                                    tset2.bValues[i]=null;
                                    k+=1;
                                }
                            }
                        }
                        if (k==tset1.length) return true; else return false;
                    }
                case "string":
                    {
                        for (int i = 0; i<tset1.length; i++)
                        {
                            for (int j = 0; j<tset2.length; j++)
                            {
                                if (tset1.sValues[i]==tset2.sValues[j])
                                {
                                    tset1.sValues[i]=null;
                                    tset2.sValues[i]=null;
                                    k+=1;
                                }
                            }
                        }
                        if (k==tset1.length) return true; else return false;
                    }
                    default : { return false; }

            }

           

    }
        public static bool operator&(Set set,Set set2)
        {
            Console.WriteLine("Ну мне лень");
            return true;
        }
        public static bool operator >(Set set, Set set2)
        {
            if (set.type!=set2.type) return false;
            int k = 0;
            Set tset1 = set;
            Set tset2 = set2;
            switch (tset1.type)
            {
                case "int":
                    {
                        for (int i = 0; i<tset1.length; i++)
                        {
                            for (int j = 0; j<tset2.length; j++)
                            {
                                if (tset1.iValues[i]==tset2.iValues[j])
                                {
                                    tset1.iValues[i]=null;
                                    tset2.iValues[i]=null;
                                    k+=1;
                                }
                            }
                        }
                        if (k==tset1.length) return true; else return false;
                    }
                case "bool":
                    {
                        for (int i = 0; i<tset1.length; i++)
                        {
                            for (int j = 0; j<tset2.length; j++)
                            {
                                if (tset1.bValues[i]==tset2.bValues[j])
                                {
                                    tset1.bValues[i]=null;
                                    tset2.bValues[i]=null;
                                    k+=1;
                                }
                            }
                        }
                        if (k==tset1.length) return true; else return false;
                    }
                case "string":
                    {
                        for (int i = 0; i<tset1.length; i++)
                        {
                            for (int j = 0; j<tset2.length; j++)
                            {
                                if (tset1.sValues[i]==tset2.sValues[j])
                                {
                                    tset1.sValues[i]=null;
                                    tset2.sValues[i]=null;
                                    k+=1;
                                }
                            }
                        }
                        if (k==tset1.length) return true; else return false;
                    }
                default: { return false; }

            }



        }

    }

 

}


static class main
{
    static void Main()
    {
        int?[] a = { 1, 2, 1, 1, 5, 4, 1 };
        string?[] ex= { "To", "Hell", "And", "Back" };
        int?[] zeroBithes = { 0, 5, 6, 0, 2, 4, 0, 1, 0, 0, 4 };
        int?[] gg = { 11, 5, 2, 3, 4, 6, 7 };
        string?[] b = { "a", "b", "c" };
        string?[] fuckinLast= { "Rip", "and", "Tear" };
        string?[] bb = {"c"};
        int?[] q = {1,2,3,4};
        int?[] qq = {1,2,3,4};
        int?[] qqq = { 1, 2, 3};
        int?[] qqqq = { 1, 2, 3, 4 };
        int?[] empty = {};
        bool?[] e = { true, false,true,true};
        var temp = a;
        var temptemp = a;
        Set example = new Set(ex);
        Set fucingLast = new Set(fuckinLast);
        Set tmptmp = new Set(a);
        Set zeroBithees = new Set(zeroBithes);
        Set emty=new Set(empty);
        Set c = new Set(a);
        Set d = new Set(b);
        Set f = new Set(e);
        Set u = new Set(gg);
        Set h = new Set(bb);
        Set zz= new Set(q);
        Set zzz= new Set(qq);
        Set zzzz = new Set(qqqq);
        Set zzzzz = new Set(qqq);
        Set tmp= new Set(temp);
        Console.WriteLine("----------------------------------------");
        c=c-1;
        c.Showk();
        d=d-"a"-"b";
        d.Showk();
        f=f-true;
        f.Showk();
        tmp=d*h;
        tmp.Showk();
        zz.Showk();
        zzz.Showk();    
        Console.WriteLine(zz<zzz);
        zzzzz.Showk();
        zzzz.Showk();
        Console.WriteLine(zzzzz>zzzz);
        Console.WriteLine(c&d);
        object Production = new Set.Production();
        Set.Developer developer = new Set.Developer();
        Console.WriteLine("----------------------------------------");
        tmptmp.Showk();
        Console.WriteLine("Sum:"+Set.StatisticOperation.Sum(tmptmp));
        Console.WriteLine("Max-Min:"+Set.StatisticOperation.Mix(tmptmp));
        Console.WriteLine("Length:"+Set.StatisticOperation.Length(tmptmp));
        zeroBithees.Showk();
        zeroBithees=Set.StatisticOperation.Zero(zeroBithees);
        zeroBithees.Showk();
        extend.dot(fuckinLast);
        for(int i = 0;i < fuckinLast.Length;i++)
        {
            Console.Write(fuckinLast[i]);
        }
        Console.WriteLine();
        example.dot();
        example.Showk();

    }
}

