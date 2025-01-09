using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Loader;
using System.Threading;
using System.IO;
using System.Text;

namespace lab_14
{

    class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null; 
        }
    }


    class main
    {
    
       public static void Cool(object obj)
        {
            Console.WriteLine("ПЕЗДЕЦ\n\n");
        }

        public static bool Simple(int a)
        {
            int counter = 0;
            for (int i=1;i<=a;i++)  
            {
                if (a%i==0)counter++;
            }
            return counter==2 ? true : false;
        }
   
         static void Main(string[] args)
        {
            File.Delete("file.txt");

            int N;
            void DO()
            {
                Console.WriteLine($"Текущий поток:{Thread.CurrentThread.Name}\n priority:{Thread.CurrentThread.Priority}\n" +
                    $"id:{Thread.CurrentThread.ManagedThreadId}\n");
                string line="";
                int a;
                Console.WriteLine("N:");
               a=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("--------------------");
                for (int i = 1; i <=a; i++)
                {
                    if (Simple(i))
                    {

                        Console.WriteLine(i);
                        line+=i;
                        line+='\n';
                    }
                }

               }

                void CHET()
                    {
                int i = 0;
                string line = "";
                while (i<=N)
                {
                    Console.WriteLine("Чёт:"+i);
                    line="Чёт:"+i;
                    i+=2;
                   // Thread.Sleep(49);
                }
                    }
                void NECHET()
                {
                int j = 1;
                while (j<=N)
                {
                    Console.WriteLine("Нечёт:"+j); ;
                    j+=2;
                    //Thread.Sleep(51);
                }
            }




            //var stat = Process.GetCurrentProcess();
            //Console.WriteLine($"id:{stat.Id}\n" +
            //    $"name:{stat.ProcessName}\n"+
            //    $"priority:{stat.PriorityClass}\n" +
            //    $"time of запуск:{stat.StartTime}\n" +
            //    $"кондиции:{stat.Responding}\n" +
            //    $"время использования CPU:{stat.TotalProcessorTime}\n");




            //var domStat = AppDomain.CurrentDomain;
            //Console.WriteLine($"Domain name:{domStat.FriendlyName}\n" +
            //    $"configuration детальки:\n{domStat.SetupInformation.ApplicationBase}\n" +
            //    "all сборки:");
            //var asm=domStat.GetAssemblies();
            //foreach(var i in asm)
            //{
            //    Console.WriteLine(i);
            //}
            //var loadContext = new CustomAssemblyLoadContext();
            //string assemblyPath = @"C:\Users\stude\OneDrive\Рабочий стол\Labs\labs\Labs 3 sem\ООП\l4u\bin\Debug\net8.0\l4u.dll";
            //Assembly loadedAssembly = loadContext.LoadFromAssemblyPath(assemblyPath);
            //Console.WriteLine("Загруженная сборка: " + loadedAssembly.FullName);


            //Thread potok = new Thread(DO);
            //potok.Name="Hi-hi ha-ha";
            //potok.Start();
            //Thread.Sleep(100);
            //potok.Join();

            //Console.WriteLine("N:");
            //N=Convert.ToInt32(Console.ReadLine());

            //Thread potok2 = new Thread(CHET);
            //Thread potok3 = new Thread(NECHET);
            //potok2.Start();
            //potok3.Start();
            //Thread.Sleep(51*N);
            //potok2.Join();
            //potok3.Join();


            Console.WriteLine("N:");
            N=Convert.ToInt32(Console.ReadLine());

            Thread potok22 = new Thread(CHET);
            Thread potok33 = new Thread(NECHET);
            potok33.Priority = ThreadPriority.Lowest;
            potok22.Start();
            potok33.Start();

            //TimerCallback tm = new TimerCallback(Cool);

            //Timer timer = new Timer(tm,null,0,100);
            //Console.ReadLine();
        }
    }
}