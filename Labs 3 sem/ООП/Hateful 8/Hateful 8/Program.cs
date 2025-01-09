using static lab_8.Zavod;

namespace lab_8
{
    public class StringEdit
    {
        public string str;
        public StringEdit(string stroka) => str=stroka;

        public void Remove()
        {
        foreach(var i in str)
            {
            if (i==','||i=='.'||i=='\'') str = str.Replace(i,'\0');
            }
        }

        public void AddClich()
        {
            str=str+'!';
        }
 public void ReplaceSpace()
        {
            foreach (var i in str)
            {
                if (i == ' ') str = str.Replace(i, '|');
            }
        }
        public void AddSpace()
        {
            str="_____________________"+str;
        }

       

        public string ToUpper()
        {
            return str.ToUpper();
        }

        public  bool IsNotEmpty(string str)
        {
            return str.Length!=0;
        }
    }

    class Zavod
    {            
        public class Principle
        {

            public event Action<int> RaiseSalary;
            public event Action<int> PenaltySalary;

            public  void DoRaise(int amount)=>RaiseSalary?.Invoke(amount);
           
            public void DoPenalty(int amount)=>PenaltySalary?.Invoke(amount);
        }

       public class Worker
        {
            public int salary = 800;
            public string name = "No Name";

            public void Raise(int amount) => salary += amount;


            public void Penalty(int amount) => salary -= amount;

            public override string ToString() => "Name:" + name + "\n" +"Salary:"+salary;
        }
    }


    class Program
    {
        static void Main()
        {
           Principle dirik = new Principle();

           Worker worker = new Worker();
            worker.name="ghigher";
            Worker worker2 = new Worker();
            worker2.name="Gigachad";
            dirik.RaiseSalary+=worker2.Raise;
            dirik.RaiseSalary+=worker.Raise;
            dirik.PenaltySalary+=worker.Penalty;
            dirik.RaiseSalary+=worker.Raise;

            dirik.DoRaise(1000);
            dirik.DoPenalty(300);
            Console.WriteLine(worker);
            Console.WriteLine();
            Console.WriteLine(worker2);
            Console.WriteLine();
            ////////////////////////////////////////////////////////////
            StringEdit test=new StringEdit("Time to party, like it's 2023.");
            Action action1=test.Remove;
            Action action2=test.AddClich;
            Action action4=test.ReplaceSpace;
            Action action3=test.AddSpace;
            
            Func<string> upper=test.ToUpper;

            Predicate<string> IsNotEmpty=test.IsNotEmpty;
          
            if (IsNotEmpty(test.str))
            {
                action1();
                action2();
                action3();
                action4();
                Console.WriteLine(upper());
            }


            }
    }
}