using Microsoft.VisualBasic;
using System;
using System.Security.Cryptography.X509Certificates;


namespace lab02
{
    public partial class GG
    {
        public static string s1 = "Первая часть частичного класса";
    }
    public partial class GG
    {
        public static string s2 = "Вторая часть класса";
    }

    class Object
    {
        
        public static bool Equals(string a, string b)
        {
            bool flag = true;
            for (int i = 0; i<b.Length; i++)
            {
                if (b[i] != a[i]) flag = false;
            }
            return flag;

        }
        public static void ToString(ref int day,ref int month,ref int year,string phone,int curse,string name,string surName, string lastName,string adress,string faculty,int group,int age)
        {
           
            //Object.Hash=Object.GetHashCode(Student.birthDay.day, Student.birthDay.year);
            //Console.WriteLine("ID: {0}", Object.Hash);
            Console.WriteLine("-----------------INFO----------------");
            Console.WriteLine("ID:"+GetHashCode(day,year));
            Console.WriteLine("Имя: {0}",name);
            Console.WriteLine("Фамилия: {0}", surName);
            Console.WriteLine("Отчество: {0}", lastName);
            Console.WriteLine("Дата рождения: {0}.{1}.{2}", day,month,year);
            Console.WriteLine("Возраст:{0}",age);
            Console.WriteLine("Адрес: {0}",adress);
            Console.WriteLine("Моб.Телефон: {0}",phone);
            Console.WriteLine("Факультет: {0}",faculty);
            Console.WriteLine("Группа: {0}-{1}", curse, group);
        }
      
        public static int GetHashCode(int day, int year)
        {   
           int gg=(((day%31)*year)-year%12*2);
            return gg;
        }
  

    }


    class Student
    {
       public static class now
        {
            public static int day;
            public static int month = 9;
           public static int year = 2024;
        }

        public static bool checkStatus;
        static Student()
        {
            checkStatus=true;
        }
        public static string firstName;//
        public static string surname;//
        public static string lastName;//
        public class Test
        {
            public static int temp;
            public static int a { get { return temp*2; } set { temp=value; } }
        } 
        public class birthDay
        {
            //  private birthDay() {}
            public static int[] days = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            public static int day;
            public static int month;
            public static int year;
        }
        public static readonly int ID= Object.GetHashCode(birthDay.day,birthDay.year);
        public static string adress;//
        public static string phoneNumber;
        public static string faculty;//
        public static int curse;
        public static int group;//
        public static int count = 0;
        // private Student()
        private Student()
        {
            Console.WriteLine("Ошибка проверки информации");
        }
        private Student(int a)
        {
            Console.WriteLine("Ошибка проверки информации");
        }
        public Student(int day,int month,int year,string phone, int curse,string name,string surname,string lastName,string adress,string faculty,int group)
        {
 
        checkStatus=true;
            count++;
            if (birthDay.year%100!=0&&birthDay.year%4==0) birthDay.days[2]=29;
            if (year<1900||year>2024) checkStatus=false;
            if (month<0||month>12) checkStatus=false;
            if (day<0||day>birthDay.days[month]) checkStatus=false;
            if (curse<0||curse>5) checkStatus=false;
            if (phone.Length!=13) checkStatus=false;
            if (checkStatus==true)
            {
                checkStatus=Object.Equals(phone, "+375");
            }

            if (checkStatus==false) { Console.WriteLine("Неверная информация"); }
            else
            {
                
                int age=0;
                if (month>now.month||(month==now.month&&day<=now.day)) age=(now.year-year)+1;
                else
                {
                    if (month==now.month&&day>now.day) age=now.year-year;
                    else
                    {
                        age=now.year-year;
                    }

                }
                
                Object.ToString(ref day, ref month, ref year, phone, curse, name, surname, lastName, adress, faculty, group,age);
            }

            }
            public static bool check()
        {
            return checkStatus;
        }
    }
    class main
    {

        static void Main(string[] args)
        {
            var deAnon = new { firstName = "Кирилл", surname = "Дмитроченко", lastName = "Денисович" };
            Console.WriteLine(deAnon.firstName +' '+deAnon.lastName);

            Console.WriteLine(GG.s1+'\n'+GG.s2);

            //Student[] gag = new Student[5];
           

                const string useless = "БЕСПОЛЕЗНО";
            // Student.birthDay gg = new Student.birthDay();

            //Student test = new Student();
         //   ref int day, ref int month, ref int year, ref string phone, ref int curse,string name,string surname,string lastName,string adress,string faculty,int group
            Student[] test = { new Student(15, 3, 2005, "+375292708723", 2, "Кирилл", "Дмитроченко", "Денисович", "Мусорка", "ФИТ", 8) ,new Student(17, 2, 6, "+375292708723", 2, "Кирилл", "Lol", "Денисович", "Мусорка", "ФИТ", 8),new Student(27, 2, 2006, "+375292708723", 2, "Кирилл", "Дмитроченко", "Денисович", "Мусорка", "ФИТ", 8) };

        }
       
    }
}