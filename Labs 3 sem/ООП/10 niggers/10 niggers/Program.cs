
namespace lab_10
{

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
        public static void ToString(string a,string b)
        {
            Console.WriteLine(a+" "+b);
        }

        public static void ToString(ref int day, ref int month, ref int year, string phone, int curse, string name, string surName, string lastName, string adress, string faculty, int group, string speciality)
        {

            //Object.Hash=Object.GetHashCode(Student.birthDay.day, Student.birthDay.year);
            //Console.WriteLine("ID: {0}", Object.Hash);
            Console.WriteLine("-----------------INFO----------------");
            Console.WriteLine("ID:"+GetHashCode(day, year));
            Console.WriteLine("Имя: {0}", name);
            Console.WriteLine("Фамилия: {0}", surName);
            Console.WriteLine("Отчество: {0}", lastName);
            Console.WriteLine("Дата рождения: {0}.{1}.{2}", day, month, year);
            Console.WriteLine("Специальность:{0}", speciality);
            Console.WriteLine("Адрес: {0}", adress);
            Console.WriteLine("Моб.Телефон: {0}", phone);
            Console.WriteLine("Факультет: {0}", faculty);
            Console.WriteLine("Группа: {0}-{1}", curse, group);
        }

        public static int GetHashCode(int day, int year)
        {
            int gg = (((day%31)*year)-year%12*2);
            return gg;
        }


    }

    class Student
    {
        public string ToString()
        {
            return firstName + "\n" + surname + "\n" + lastName+"\n"+adress+"\n"+phoneNumber+"\n"+faculty+"\n"+curse+"\n"+group+"\n"+speciality+"\n\"Дата рождения:"+"\n"+day+"."+month+"."+year+"\n";
        }

        public static class now
        {
            public static int day=16;
            public static int month = 11;
            public static int year = 2024;
        }

        public static bool checkStatus;
        static Student()
        {
            checkStatus=true;
        }
        public  string firstName;//
        public  string surname;//
        public  string lastName;//

        public int day;
        public int month;
        public int year;

        public class Test
        {
            public  int temp;
            public  int a { get { return temp*2; } set { temp=value; } }
        }
        public static  class birthDay
        {
            //  private birthDay() {}
            static public int[] days = { 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        }
        public string adress;//
        public string phoneNumber;
        public string faculty;//
        public string speciality;
        public int curse;
        public int group;//
        public int count = 0;
        public int age;
        // private Student()
        private Student()
        {
            Console.WriteLine("Ошибка проверки информации");
        }
        private Student(int a)
        {
            Console.WriteLine("Ошибка проверки информации");
        }
        public Student (string name,string Surname)
        {
           firstName=name;
            surname=Surname;
            Object.ToString(name, surname);
        }

        private void Age()
        {

            int years = now.year - year;
            if (now.month < month || (now.month == month &&now.day < day))
            {
                years--;
            }

            int months = now.month - month;
            if (now.day < day)
            {
                months--;
                if (months < 0)
                {
                    months += 12;
                }
            }
            else if (months < 0)
            {
                months += 12;
            }

            int[] daysInMonths = birthDay.days;

            int days = now.day - day;
            if (days < 0)
            {
                int prevMonth = (now.month - 1 <= 0) ? 12 : now.month - 1;
                days += daysInMonths[prevMonth];
            }

           age=years*365+months*30+days;
           // Console.WriteLine(age);
        }

        public Student(int day, int month, int year, string phone, int curse, string name, string surname, string lastName, string adress, string faculty, int group,string speciality)
        {

            this.firstName = name;
            this.surname = surname;
            this.lastName = lastName;
            this.adress = adress;
            this.phoneNumber = phone;
            this.faculty = faculty;
            this.curse = curse;
            this.group = group;
            this.speciality = speciality;
            this.day = day;
            this.month = month;
            this.year = year;

            Age();
            //checkStatus=true;
            //count++;
            //if (year%100!=0&&year%4==0) birthDay.days[2]=29;
            //if (year<1900||year>2024) checkStatus=false;
            //if (month<0||month>12) checkStatus=false;
            //if (day<0||day>birthDay.days[month]) checkStatus=false;
            //if (curse<0||curse>5) checkStatus=false;
            //if (phone.Length!=13) checkStatus=false;
            //if (checkStatus==true)
            //{
            //    checkStatus=Object.Equals(phone, "+375");
            //}

            //if (checkStatus==false) { Console.WriteLine("Неверная информация"); }
            //else
            //{

            //    int age = 0;
            //    if (month>now.month||(month==now.month&&day<=now.day)) age=(now.year-year)+1;
            //    else
            //    {
            //        if (month==now.month&&day>now.day) age=now.year-year;
            //        else
            //        {
            //            age=now.year-year;
            //        }

            //    }

              // Object.ToString(ref day, ref month, ref year, phone, curse, name, surname, lastName, adress, faculty, group,speciality);
            }
        public static bool check()
        {
            return checkStatus;
        }


    }





    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];


            //IEnumerable<string> one = arr.Where(a => a.Length==4).Select(a => a);
            //foreach(string i in one )
            //{
            //    Console.WriteLine(i);
            //}



            //IEnumerable<string> two = arr.Take(2).Concat(arr.Skip(5).Take(3)).Concat(arr.Skip(11).Take(1));
            //foreach(string i in two)
            //{
            //    Console.WriteLine(i);
            //}



            //IEnumerable<string> three =arr.OrderBy(a=>a);
            //foreach(string i in three)
            //{
            //    Console.WriteLine(i);       
            //}

            //IEnumerable<string> four = arr.Select(a => a).Where(a => a.Contains('u')).Where(a=>a.Length>=4);
            //foreach (string s in four) 
            //{
            //    Console.WriteLine(s);
            //}

            List<Student> list = new List<Student>();
            list.Add(new Student(15, 3, 2005, "+375696667621", 2, "Кирилл", "Дмитроченко", "Батькович", "!", "ФИТ", 8, "ПИ"));
            list.Add(new Student(21, 7, 2004, "+375696667621", 2, "Диана", "Савич", "Батькович", "!", "ТОВ", 2, "ФУ"));
            list.Add(new Student(9, 1, 2005, "+375696667621", 2, "Яна", "ХЗ", "Батькович", "!", "ТОВ", 3, "ФУ"));
            list.Add(new Student(11, 8, 2005, "+375696667621", 2, "Глеб", "Куницкий", "Батькович", "!", "ФИТ", 1, "ИСИТ"));
            list.Add(new Student(19, 7, 2006, "+375696667621", 2, "Андрей", "БушидоЖо", "Батькович", "!", "ФИТ", 3, "ЦД"));
            list.Add(new Student(30, 6, 2005, "+375696667621", 2, "Арсений", "Шайба", "Батькович", "!", "ФИТ", 8, "ПИ"));
            list.Add(new Student(1, 1, 2006, "+375696667621", 2, "Арсений", "ПТУ", "Батькович", "!", "ФИТ", 2, "ИСИТ"));
            list.Add(new Student(11, 11, 2005, "+375696667621", 2, "Егор", "Фэндиглок", "Батькович", "!", "ФИТ", 4, "ЦД"));
            list.Add(new Student(13, 7, 2005, "+375696667621", 2, "Диана", "Подшиваленко", "Батькович", "!", "ФИТ", 6, "ПИ"));
            list.Add(new Student(9, 2, 2006, "+375696667621", 2, "Илья", "Павлович", "Батькович", "!", "ФИТ", 7, "ПИ"));

            Dictionary<string, int> gg = new Dictionary<string, int>();
            gg.Add("Арсений", 100);
            gg.Add("Кирилл", 9999);
            gg.Add("Егор", 300);

            var join = list.Join(gg,
                a => a.firstName,
                b => b.Key,
                (a, b) => new{ name=a.firstName,elo=b.Value});

            foreach (var i in join)
            {
                Console.WriteLine($"Name:{i.name}\nElo: {i.elo}");
                Console.WriteLine("\n---------------------\n");
            }

            //IEnumerable<Student> adin = from a in list where a.speciality=="ПИ" select a; 
            //foreach(Student i in adin)
            //{
            //    Console.WriteLine(i.ToString());
            //    Console.WriteLine("\n---------------------------------------\n");
            //}

            //IEnumerable<Student> dva = list.Select(a => a).Where(a => a.faculty=="ФИТ");
            //foreach (Student i in dva)
            //{
            //    Console.WriteLine(i.ToString());
            //    Console.WriteLine("\n---------------------------------------\n");
            //}


            //IEnumerable<Student> tri = list.Select(a => a).Where(a => a.group==8);
            //foreach (Student i in tri)
            //{
            //    Console.WriteLine(i.ToString());
            //    Console.WriteLine("\n---------------------------------------\n");
            //}


            //IEnumerable<Student> chetiri = list.Select(a => a).Where(a => a.group==8).OrderBy(a => a.surname);
            //foreach (Student i in chetiri)
            //{
            //    Console.WriteLine(i.ToString());
            //    Console.WriteLine("\n---------------------------------------\n");
            //}

            //Student pyat = list.First(a => a.firstName == "Арсений");
            //Console.WriteLine(pyat.ToString());

            //Student birth = list.OrderBy(a=>a.age).First();
            //Console.WriteLine(birth.ToString());

            //IEnumerable<Student> svayak = list.Skip(2).Select(a => a).Where(a => a.phoneNumber=="!").OrderByDescending(a => a.firstName).Concat(list.Where(a => a.surname=="Шайба"));

            //foreach (Student i in svayak)
            //{
            //    Console.WriteLine(i.ToString());
            //}







        }
    }
}