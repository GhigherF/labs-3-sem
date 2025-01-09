using System;
using System.Collections.Generic;
using System.Text.Json;

namespace lab7
{
    interface ICustom<T>
    {
        void Add(T a);
        void Remove(T a);
        void Display();
    }
    public static class Out
    {
        public static void ReadFromFile(string fileName)
        {
            if (!File.Exists(fileName)) throw new Exception("ФАЙЛИКА НЕМАЕ");
            string gg = File.ReadAllText(fileName);
            Console.WriteLine(gg);

        }
    }     

    public class Flower : Plant
    {
        public int price;

        public override string ToString()
        {
            return $"Цветик: Name = {name}, Ценник = {price}";
        }
    }

    public class Bush : Plant
    {
        public int weight;

        public override string ToString()
        {
            return $"Кустек: Name = {name}, Вес = {weight}";
        }
    }

    public class Plant : IComparable<Plant>
    {
        public string name;

        public virtual string ToString()
        {
            return $"Растение:= {name}";
        }

        public int CompareTo(Plant gg)
        {
            return String.Compare(name, gg.name);
        }
    }

    public class CollectionType<T> : ICustom<T> where T : Plant, IComparable<T>
    {
        private SortedSet<T> set = new SortedSet<T>();
        public string ToString(SortedSet<T> setset)
        {
            string gg = "";
            foreach (T t in setset)
            {
                gg+= t.ToString() + "\n";
            }
            return gg;
        }

        public CollectionType(T[] temp)
        {
            if (temp == null) throw new Exception("Лееее, куда прёшь?");
            foreach (T t in temp)
            {
                set.Add(t);
            }
        }

        public void Add(T a)
        {
            set.Add(a);
        }

        public void Remove(T a)
        {
            if (!set.Contains(a)) throw new Exception("нема элемента");
            set.Remove(a);

        }

        public bool IsContains(T a)
        {
            return set.Contains(a);
        }
        
        public void Display()
        {
            foreach (T t in set)
            {
                Console.WriteLine(t.ToString());
            }
        }
      
        public void SaveToFile(string fileName)
        {
            if (!File.Exists(fileName)) File.Create(fileName);
            File.WriteAllText(fileName,ToString(set));
        }
        
    }



public static class Program
    {
        static void Main(string[] args)
        {
           
                int[] temp = new int[0];
                string[] gg = new string[] { "Rip", "And", "Tear" };
                double[] qq = new double[] { 1.2, 3.4, 5.6 };
                try
                {
                //CollectionType<int> set = new CollectionType<int>(temp);
                //CollectionType<double> set3 = new CollectionType<double>(qq);
                //set3.Display();
                //set.Display();
                ////set.Remove(1);
                //set.Display();
                //CollectionType<string> set2 = new CollectionType<string>(gg);
                //set2.Display();
                //Console.WriteLine(set2.IsContains("DOOM"));
                //Plant g = new Plant();
                //g.name = "Rose";
                //Plant b = new Plant();
                //b.name = "Cactus";
                //Plant[] a = { g, b };
                //CollectionType<Plant> gg2 = new CollectionType<Plant>(a);
                //gg2.Display();


                //Flower ZOV = new Flower { name = "52!!!!!!!", price = 999999999 };
                //Flower VOZ = new Flower { name = "VOZ", price = 15 };
                //Flower[] ZVO = { ZOV, VOZ };
                //CollectionType<Flower> qwerty = new CollectionType<Flower>(ZVO);
                //qwerty.Display();

                //Bush z = new Bush { name = "Z", weight = 999999999 };
                //Bush zz = new Bush { name = "ZZ", weight = 15 };
                //Bush[] zzz = { z, zz };
                //CollectionType<Bush> zzzz = new CollectionType<Bush>(zzz);
                //zzzz.Display();

                //string fileName = "flowers.json";
                //flowerCollection.SaveToFile(fileName);


                //CollectionType<Flower> loadedFlowerCollection = CollectionType<Flower>.LoadFromFile(fileName);
                //Console.WriteLine("Loaded collection from file:");
                //loadedFlowerCollection.Display();

                Flower ZOV = new Flower { name = "Goroh", price = 52};
                Flower VOZ = new Flower { name = "BoB", price = 152};
                Flower[] ZVO = { ZOV, VOZ };
                CollectionType<Flower> flowerCollection = new CollectionType<Flower>(ZVO);
                //flowerCollection.Display();

                // Save the flower collection to a JSON file
                string fileName = "gg.json";
                flowerCollection.SaveToFile(fileName);

                Out.ReadFromFile(fileName);
               
            }
                catch (Exception e) { Console.WriteLine(e.Message); }
            finally { Environment.Exit(0); }
        }
    }
}

