using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace lab_15
{
    
    }
    class Program
    {
        static async Task Main(string[] args)
        {
            //Stopwatch sw = new Stopwatch();
            //sw.Start();
            //Random rnd = new Random();
            //int[] arr = new int[100];
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    arr[i] = rnd.Next(0, 10000);
            //}


            //Task[] tasks = new Task[arr.Length];
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    int index = i;


            //    tasks[i] = Task.Run(() =>
            //    {
            //        Console.WriteLine($"Задача {Task.CurrentId} выполняется");
            //        arr[index] *= 8;
            //        Console.WriteLine($"Задача {Task.CurrentId} завершена");
            //    });
            //}
            //Task.WaitAll(tasks);
            //sw.Stop();
            //Console.WriteLine($"Время выполнения: {sw.ElapsedMilliseconds} mс");
            //Console.WriteLine("Все задачи завершены.");





            //    CancellationTokenSource cts = new CancellationTokenSource();
            //    CancellationToken token = cts.Token;

            //    // Запускаем задачу для отмены через 2 секунды
            //    Task.Run(() =>
            //    {

            //        cts.Cancel();
            //        Console.WriteLine("Отмена всех задач ");
            //    });

            //    Stopwatch sw = new Stopwatch();
            //    sw.Start();
            //    Random rnd = new Random();
            //    int[] arr = new int[100];

            //    for (int i = 0; i < arr.Length; i++)
            //    {
            //        arr[i] = rnd.Next(0, 10000);
            //    }

            //    Task[] tasks = new Task[arr.Length];

            //    for (int i = 0; i < arr.Length; i++)
            //    {
            //        int index = i; 

            //        tasks[i] = Task.Run(() =>
            //        {

            //            if (token.IsCancellationRequested)
            //            {
            //                Console.WriteLine($"Задача {Task.CurrentId} отменена");
            //                return;
            //            }

            //            Console.WriteLine($"Задача {Task.CurrentId} выполняется");
            //            arr[index] *= 8;



            //            Console.WriteLine($"Задача {Task.CurrentId} завершена");
            //        });
            //    }

            //    Task.WaitAll(tasks);
            //    sw.Stop();
            //    Console.WriteLine($"Время выполнения: {sw.ElapsedMilliseconds} мс");
            //    Console.WriteLine("Все задачи завершены.");


            //Task<int> task1 = Task.Run(() => 20);
            //Task<int> task2 = Task.Run(() => 30);
            //Task<int> task3 = Task.Run(() => 19);


            //Task<int> finalTask = Task.Run(async () =>
            //{
            //    int result1 = await task1;
            //    int result2 = await task2;
            //    int result3 = await task3;

            //    return result1 + result2 + result3;
            //});

            //finalTask.ContinueWith(t =>
            //{
            //    Console.WriteLine($"Сумма: {t.Result}");
            //});

            //finalTask.GetAwaiter().OnCompleted(() =>
            //{
            //    int sum = finalTask.GetAwaiter().GetResult();
            //    Console.WriteLine($"Сумма: {sum}");
            //});

            //Thread.Sleep(10);





            //int arraySize = 30000;
            //Random rnd = new Random();
            //Stopwatch sw = new Stopwatch();
            //int[] array = new int[arraySize];

            //for (int i = 0; i < arraySize; i++)
            //{
            //    array[i] = rnd.Next(0, 90000);
            //}   
            //sw.Start();
            //for (int i = 0; i<arraySize; i++)
            //{
            //    for (int j = 0; j<arraySize; j++)
            //    {
            //        if (array[i] != array[j])
            //        { 
            //            int temp = array[i];
            //            array[i] = array[j];
            //            array[j] = temp;
            //        }
            //    }
            //}
            //sw.Stop();
            //Console.WriteLine($"Нормис: {sw.ElapsedMilliseconds} мс");


            //array = new int[arraySize];
            //for (int i = 0; i < arraySize; i++)
            //{
            //    array[i] = rnd.Next(0, 90000);
            //}
            //sw.Restart();

            //Parallel.For(0, array.Length, i =>
            //{
            //    Parallel.For(0, array.Length, j =>
            //    {
            //        if (array[i] != array[j])
            //        {
            //            int temp = array[i];
            //            array[i] = array[j];
            //            array[j] = temp;
            //        }
            //    });
            //});
            //sw.Stop();
            //Console.WriteLine($"Нитакусик: {sw.ElapsedMilliseconds} мс");



            //        Parallel.Invoke(
            //() => Console.WriteLine("1 задача выполняется"),
            //() => Console.WriteLine("2 задача выполняется"),
            //() => Console.WriteLine("3 задача выполняется"),
            //() => Console.WriteLine("4 задача выполняется"),
            //() => Console.WriteLine("5 задача выполняется"),
            //() => Console.WriteLine("6 задача выполняется")
            //);



            //BlockingCollection<string> warehouse = new BlockingCollection<string>();
            //string[] suppliers = { "Микроволновка", "Холодильник", "Стиральная машина", "Телевизор", "Пылесос" };
            //string[] buyers = new string[10];

            //void Supplier(string item)
            //{
            //    while (true)
            //    {
            //        warehouse.Add(item);
            //        Console.WriteLine($"{item} добавлен на склад.");
            //        Thread.Sleep(new Random().Next(500, 1000));
            //    }
            //}

            //void Buyer()
            //{
            //    while (true)
            //    {
            //        if (warehouse.TryTake(out string item))
            //        {
            //            Console.WriteLine($"Покупатель купил: {item}");
            //        }
            //        else
            //        {
            //            Console.WriteLine("Склад пуст, покупатель уходит.");
            //        }
            //        Thread.Sleep(new Random().Next(200, 500));
            //    }
            //}


            //for (int i = 0; i < suppliers.Length; i++)
            //{
            //    string supplier = suppliers[i];
            //    Task.Run(() => Supplier(supplier));
            //}

            //for (int i = 0; i < buyers.Length; i++)
            //{
            //    Task.Run(() => Buyer());
            //}
            //Console.ReadLine();
        


        Task<int> downloading = DownloadDocsMainPageAsync();
        Console.WriteLine($"{nameof(Main)}: Launched downloading.");

        int bytesLoaded = await downloading;
        Console.WriteLine($"{nameof(Main)}: Downloaded {bytesLoaded} bytes.");
    }
    private static async Task<int> DownloadDocsMainPageAsync()
    {
        Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: About to start downloading.");

        var client = new HttpClient();
        byte[] content = await client.GetByteArrayAsync("https://learn.microsoft.com/en-us/");

        Console.WriteLine($"{nameof(DownloadDocsMainPageAsync)}: Finished downloading.");
        return content.Length;
    }

}
