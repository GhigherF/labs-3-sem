using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace SerializationDemo
{
    public interface ISerializer
    {
        void Serialize<T>(T obj, FileStream stream);
        T Deserialize<T>(FileStream stream);
    }

    public class BinarySerializer : ISerializer
    {
        public void Serialize<T>(T obj, FileStream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, obj);
        }

        public T Deserialize<T>(FileStream stream)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            return (T)formatter.Deserialize(stream);
        }
    }

    public class SoapSerializer : ISerializer
    {
        public void Serialize<T>(T obj, FileStream stream)
        {
            SoapFormatter formatter = new SoapFormatter();
            formatter.Serialize(stream, obj);
        }

        public T Deserialize<T>(FileStream stream)
        {
            SoapFormatter formatter = new SoapFormatter();
            return (T)formatter.Deserialize(stream);
        }
    }

    public class JsonSerializerWrapper : ISerializer
    {
        public void Serialize<T>(T obj, FileStream stream)
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                WriteIndented = true
            };
            JsonSerializer.Serialize(stream, obj, options);
        }

        public T Deserialize<T>(FileStream stream)
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                WriteIndented = true
            };
            return JsonSerializer.Deserialize<T>(stream, options);
        }
    }

    public class XmlSerializerWrapper : ISerializer
    {
        public void Serialize<T>(T obj, FileStream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            serializer.Serialize(stream, obj);
        }

        public T Deserialize<T>(FileStream stream)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            return (T)serializer.Deserialize(stream);
        }
    }

    [Serializable]
    public abstract class Need
    {
        public int a = -1;
    }

    [Serializable]
    public class Cactus : Need
    {
        public Cactus() { }

        public Cactus(int price, int beauty, string color, int a)
        {
            this.price = price;
            this.beauty = beauty;
            this.color = color;
            this.a = a;
        }

        [NonSerialized]
        [SoapIgnore]
        [JsonIgnore]
        [XmlIgnore]
        public int price = 0;

        public int beauty = -1;
        public string color = "";
        public string name { get; set; } = "Kakaktus";

        public override string ToString()
        {
            return $"Name: {name}, Color: {color}, Price: {price}, Beauty: {beauty}";
        }
    }

    class Program
    {
        static void TestSerialization(ISerializer serializer, Cactus cactus, string fileName)
        {
            Console.WriteLine($"Testing {serializer.GetType().Name}...");

            using (var fileStream = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(cactus, fileStream);
            }

            using (var fileStream = new FileStream(fileName, FileMode.Open))
            {
                var deserializedCactus = serializer.Deserialize<Cactus>(fileStream);
                Console.WriteLine(deserializedCactus.ToString());
            }

            Console.WriteLine($"Serialized data saved to {fileName}.\n");
        }

        static void SerializeArray<T>(string fileName, T obj, ISerializer serializer)
        {
            Console.WriteLine($"Serializing array with {serializer.GetType().Name}...");

            using (var file = File.Open(fileName, FileMode.Create))
            {
                serializer.Serialize(obj, file);
            }

            using (var file = File.Open(fileName, FileMode.Open))
            {
                var deserializedObj = serializer.Deserialize<T>(file);
                if (deserializedObj is Array array)
                {
                    foreach (var item in array)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
        }

        static void Main()
        {
            Cactus cactus1 = new Cactus(100, 200, "Green", 5);
            Cactus cactus2 = new Cactus(200, 300, "Red", 6);
            Cactus cactus3 = new Cactus(300, 400, "Blue", 7);


            Cactus[] cactiArray = { cactus1, cactus2, cactus3 };

            SerializeArray("Cacti.bin", cactiArray, new BinarySerializer());
            SerializeArray("Cacti.soap", cactiArray, new SoapSerializer());
            SerializeArray("Cacti.json", cactiArray, new JsonSerializerWrapper());
            SerializeArray("Cacti.xml", cactiArray, new XmlSerializerWrapper());

            TestSerialization(new BinarySerializer(), cactus1, "Cactus.bin");
            TestSerialization(new SoapSerializer(), cactus1, "Cactus.soap");
            TestSerialization(new JsonSerializerWrapper(), cactus1, "Cactus.json");
            TestSerialization(new XmlSerializerWrapper(), cactus1, "Cactus.xml");


            XElement cactiXml = new XElement("Cacti",
                new XElement("Cactus",
                    new XElement("Name", "Cactus1"),
                    new XElement("Price", 100),
                    new XElement("Beauty", 200),
                    new XElement("Color", "Green")
                ),
                new XElement("Cactus",
                    new XElement("Name", "Cactus2"),
                    new XElement("Price", 200),
                    new XElement("Beauty", 300),
                    new XElement("Color", "Red")
                ),
                new XElement("Cactus",
                    new XElement("Name", "Cactus3"),
                    new XElement("Price", 300),
                    new XElement("Beauty", 400),
                    new XElement("Color", "Blue")
                )
            );

            cactiXml.Save("CactiLinq.xml");

            Console.WriteLine("Все кактусы из XML:");
            var allCacti = cactiXml.Elements("Cactus");
            foreach (var cactus in allCacti)
            {
                Console.WriteLine(cactus.Element("Name")?.Value);
            }

            Console.WriteLine("\nКактусы с ценой больше 150 из XML:");
            var expensiveCacti = cactiXml.Elements("Cactus")
                                         .Where(c => (int)c.Element("Price") > 150);
            foreach (var cactus in expensiveCacti)
            {
                Console.WriteLine(cactus.Element("Name")?.Value);
            }
        }
    }
}
