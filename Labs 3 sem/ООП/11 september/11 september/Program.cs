using System.Reflection;
using System.Text;

namespace lab11
{
   
    interface ITest
    {

    }



    public static class Reflector
    {
        public static Nigga Create<Nigga>(object?[] parms)
        {
            Type type =typeof(Nigga);
            ConstructorInfo constructor=type.GetConstructor(parms.Select(a=>a.GetType()).ToArray());
            return (Nigga)constructor.Invoke(parms);
        }

        public static Type type = typeof(Set);
        public static string GetInfo(Type clas)
        {
            string gg = "";
            gg+=A(clas);
            gg+=B(clas);
            gg+="\nСписок методов:\n\n";
            var temp=C(clas);
            foreach (var i in temp)
            {
                gg+=i+'\n';
            }
            var temp2 = D_1(clas);
            gg+="\nСписок полей:\n\n";
            foreach (var i in temp2)
            {
                gg+=i+'\n';
            }

            var temp3 = D_2(clas);
            gg+="\nСписок свойств:\n\n";
            foreach (var i in temp3)
            {
                gg+=i+'\n';
            }

            var temp4 = E(clas);
            gg+="\nСписок реализованных интерфейсов:\n\n";
            foreach (var i in temp4)
            {
                gg+=i+'\n';
            }

            var temp5 = F(clas);
            gg+=$"\nСписок Методов, содержащих \"{type}\":\n\n";
            foreach (var i in temp5)
            {
                gg+=i+'\n';
            }
           

            gg+="\n-----------------------------------------------------\n";
            return gg;

           
        }

        public static void Invoke(object obj,string[] parameters,MethodInfo methodName)
        { 
            methodName.Invoke(obj,parameters);
        }





        public static string A(Type clas)
        {
            return "\nИнформация о сборке: "+clas.Assembly.ToString()+"\n";
        }

        public static string B(Type clas)
        {
            bool flag = false;
            foreach (ConstructorInfo i in clas.GetConstructors(BindingFlags.Public|BindingFlags.Instance))
            {
                flag = true;

            }
            return "\n Наличие публичного конструктора: "+flag+"\n";
        }

        public static IEnumerable<string> C(Type clas)
        {
            return clas.GetMethods(BindingFlags.Public|BindingFlags.Instance).Select(x => x.Name).Distinct();

        }

        public static IEnumerable<string>D_1(Type clas)
        {
            return clas.GetFields().Select(x => x.Name).Distinct();
        }

        public static IEnumerable<string> D_2(Type clas)
        {
            return clas.GetProperties().Select(x => x.Name).Distinct();
        }

        public static IEnumerable<string> E(Type clas)
        {
            return clas.GetInterfaces().Select(x => x.Name).Distinct();
        }

        public static IEnumerable<string> F(Type clas)
        {      
            return clas.GetMethods().Where(a=>a.GetParameters().Any(a=>a.ParameterType==type)).Select(a => a.Name).Distinct();

          
            
        }


        public static void writeInfo(string gg)
        {
            File.WriteAllText("text.txt",gg);
        }
    }





    /////////////////////////////////////////////////////////////////////////////////////////////
    public class Set : ITest//Это из 3 лабы
    {
        public Set(int a)
        {
            Console.WriteLine("Объект создан");
        }
        public int test {get;set;}
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
                int? min = int.MaxValue;
                int? max = int.MinValue;
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
                for (int i = 0; i<set.length; i++)
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
                }
                int j = -1;
                Console.WriteLine(k);
                Console.WriteLine(set.length);

                for (int i = 0; i<set.length-k; i++)
                {
                    j+=1;
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


        public int length = -1;
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
        public static Set operator -(Set set, int a)
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
            Set set3 = set2;
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

        public static string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            StringBuilder result = new StringBuilder(length);

            for (int i = 0; i < length; i++)
            {
                result.Append(chars[random.Next(chars.Length)]);
            }

            return result.ToString();
        }


        public static bool operator <(Set set, Set set2)
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
                default: { return false; }

            }



        }
        public static bool operator &(Set set, Set set2)
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
/////////////////////////////////////////////////////////////////////////////////////////////
public static class Out//из 7 лабы
    {
        public static int test
        {
            get;set;
        }
        public static void ReadFromFile(string fileName)
    {
            if (!File.Exists(fileName)) { Console.WriteLine("ФАЙЛИКА НЕМАЕ"); Environment.Exit(0); } ;
        string gg = File.ReadAllText(fileName);
        Console.WriteLine(gg);

    }
}
 /////////////////////////////////////////////////////////////////////////////////////////////

    public class Program
    {
        static void Main(string[] args)
        {
            string gg = "";


            gg+=Reflector.GetInfo(typeof(Out));
            gg+=Reflector.GetInfo(typeof(Set));
            gg+=Reflector.GetInfo(typeof(Int32));
            gg+=Reflector.GetInfo(typeof(String));

            Reflector.writeInfo(gg);

            var parms = File.ReadLines("info.txt");
            bool flag = false;
            bool flag2 = false;
            string clas = "";
            string meth = "";

           //string[] parm=new string[1];
            string?[] parm=null;

            foreach (var i in parms)
            {
                if (flag==false) { flag=true; clas = i; }
                else
                if (flag==true&&flag2==false) {flag2=true; meth=i; }
                else

                //    parm[0]=Set.GenerateRandomString(4)+".txt";
                //Console.WriteLine(parm[0]);
                 parm=i.Split(',').Select(x => x.Trim()).ToArray();


            }

            Type? classType = Type.GetType(clas);
            MethodInfo method = classType.GetMethod(meth);
            Reflector.Invoke(new object(), parm, method);

            object[] parmetrs = {1};
            Set a=Reflector.Create<Set>(parmetrs);

        }
    }   
}