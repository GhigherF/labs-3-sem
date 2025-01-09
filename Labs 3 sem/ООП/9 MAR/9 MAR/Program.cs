using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Specialized;
using System.Collections.ObjectModel;

namespace lab_09
{
        class Item
    {
        public string name;
        public int price;

        public Item(string name, int price)
        {
            this.name = name;
            this.price = price;
        }

        public override string ToString()
        {
            return this.name + " -- " + this.price+" BYN";
        }
    }

    class Collection : IOrderedDictionary
    {
        public Collection()
        {
            obser.CollectionChanged += Meth;
        }

        private ConcurrentBag<Item> kal/*типа КАЛекция*/= new ConcurrentBag<Item>();
        private ObservableCollection<Item> obser = new ObservableCollection<Item>(); 
        
        public void Meth(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!\n");
        }
        

        public void Out()
        {
            Console.WriteLine("\n\n---------------------------------------------------\n");
            foreach (var i in kal)
            {
                Console.WriteLine(i.ToString());
            }
        }

        public void Add(Item item)
        {
            
            kal.Add(item);
            obser.Add(item);
        }
        public void Clear()
        {
           
            kal.Clear();
            obser.Clear();
        }


        public bool Contains(Item item)
        {
            return kal.Contains(item);
        }

        public void Remove(string item)
        {
           
            ConcurrentBag<Item> temp = new ConcurrentBag<Item>();
            foreach (var i in kal)
            {
                if (!i.name.Equals(item)) temp.Add(i);
            }
            kal.Clear();
            obser.Clear();
            kal=temp;
        }

        public Item Find(string name)
        {
            foreach (var product in kal)
            {
                if (product.name == name) return product;
            }
            return null;
        }

        ////////////////////////////////////////////////////////////////////////////////////////
        //////////////////////////////////////////////////////////////////////////////////
        /////////////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////////////

        private readonly object syncRoot = new object();

        public bool IsSynchronized => true;

        public object SyncRoot => syncRoot;

        public void CopyTo(Array array, int index)
        {
            lock (syncRoot)
            {
                foreach (var product in kal)
                {
                    array.SetValue(product, index++);
                }
            }
        }

        public void Add(object key, object value)
        {
            kal.Add((Item)value);
        }

        public bool Contains(object key)
        {
            return Find((string)key) != null;
        }

        public void Remove(object key)
        {
            var product = Find((string)key);
            if (product != null) Remove(product);
        }


        public object this[int index]
        {
            get => throw new Exception("Анлак");
            set => throw new Exception("Анлак");
        }

        public object this[object key]
        {
            get => throw new Exception("Анлак");
            set => throw new Exception("Анлак");
        }

        public IDictionaryEnumerator GetEnumerator()
        {
            throw new Exception("Анлак");
        }

        public void Insert(int index, object key, object value)
        {
            throw new Exception("Анлак");
        }

        public void RemoveAt(int index)
        {
            throw new Exception("Анлак");
        }
        public int Count => kal.Count;
        public bool IsFixedSize => false;
        public bool IsReadOnly => false;
        public ICollection Keys => throw new Exception("Анлак");
        public ICollection Values => throw new Exception("Анлак");

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return kal.GetEnumerator();
        }



    }

    namespace main
    {
        class Program
        {
            static void Main(string[] args)
            {
                //try
                //{
                    Item guitar = new Item("guitar", 700);
                    Item laptop = new Item("laptop", 3000);
                    Item beer = new Item("beer", 5);

                    Collection bag = new Collection();
                    bag.Add(guitar);
                    bag.Add(laptop);
                    bag.Add(beer);
                    bag.Clear();

                //    //bag.GetEnumerator();


                //    bag.Add(guitar);
                //    bag.Add(beer);
                //    bag.Remove("beer");
                //    bag.Add(laptop);
                //    bag.Add(laptop);
                //    bag.Out();


                //} catch(Exception e) { Console.WriteLine(e.Message);


                //ConcurrentBag<int> Z2 = new ConcurrentBag<int>();
                //Z2.Add(1);
                //Z2.Add(2);
                //Z2.Add(3);
                //Z2.Add(4);
                //Z2.Add(5);
                //Z2.Add(6);
                //Z2.Add(7);
                //Z2.Add(8);
                //Z2.Add(9);
                //Z2.Add(10);



                //ConcurrentBag<int> temp = new ConcurrentBag<int>();

                //foreach (var j in Z2)
                //{
                //    if (j>3&&j<7) continue;
                //    temp.Add(j);
                //}
                //Z2.Clear();
                //Z2=temp;


                //foreach (var i in Z2)
                //{
                //    Console.WriteLine(i);
                //}

                //Console.WriteLine("\n------------------------------\n");
                //ArrayList Z2l = new ArrayList();
                //Z2l.Add(1);
                //Z2l.Add(2);
                //Z2l.Add(3);
                //Z2l.Add(4);
                //Z2l.Add(5);
                //Z2l.Add(6);
                //Z2l.Add(7);
                //Z2l.Add(8);
                //Z2l.Add(9);
                //Z2l.Add(10);


                //Console.WriteLine(Z2l[Z2l.BinarySearch(7)]);

               

            }
        }
    }
}
