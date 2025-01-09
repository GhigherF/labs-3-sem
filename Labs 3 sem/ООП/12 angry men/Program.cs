using System;
using System.IO;
using System.Text;
using System.IO.Compression;

namespace lab_12
{

    class DKDLog
    {
        public static string path = "Z:\\lab12_OOP\\DKDlogfile.txt";

        public static async Task WriteInLog(string data)
        {
            await File.AppendAllTextAsync(path, '\n' + data);
        }

        public static async Task ReadLog()
        {
            Console.WriteLine(await File.ReadAllTextAsync(path));
        }

        public static async Task CreateLogFile()
        {
            if (!File.Exists(path))
            {
                using (File.Create(path)) { }
            }
         
            await File.AppendAllTextAsync(path, "Протокол выполнения\n-----------------------------------------\n");
            await File.AppendAllTextAsync(path, "Дата:");
            await File.AppendAllTextAsync(path, DateTime.Now.ToShortDateString());
            await File.AppendAllTextAsync(path, "\nВремя:");
            await File.AppendAllTextAsync(path, DateTime.Now.ToShortTimeString());
            await File.AppendAllTextAsync(path, "\n\nИНФА:\n");
        }


        public static async Task FilterLogByCriteria(string keyword = null)
        {
            try
            {
                // Считываем все строки из файла
                var lines = await File.ReadAllLinesAsync(path);
                var filteredLines = new List<string>();
                int count = 0;

                // Текущий час
                int currentHour = DateTime.Now.Hour;

                foreach (var line in lines)
                {
                    bool matches = true;

                    // Фильтрация по ключевому слову
                    if (!string.IsNullOrEmpty(keyword) && !line.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                    {
                        matches = false;
                    }

                    // Фильтрация по текущему часу
                    if (line.Contains("Время:"))
                    {
                        var timePart = line.Split(':')[1].Trim(); // Берем часть после "Время:"
                        if (TimeSpan.TryParse(timePart, out var logTime))
                        {
                            if (logTime.Hours != currentHour) // Если час не совпадает с текущим
                            {
                                matches = false;
                            }
                        }
                        else
                        {
                            matches = false; // Если время не удалось распознать
                        }
                    }

                    if (matches)
                    {
                        filteredLines.Add(line);
                        count++;
                    }
                }

                Console.WriteLine($"Найдено записей: {count}");
                Console.WriteLine(string.Join("\n", filteredLines));


                Console.WriteLine("Лог-файл обновлен, оставлены записи только за текущий час.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при фильтрации логов: {ex.Message}");
            }
        }
    }




        class DKDDiskInfo
    {
        static public async Task FreeSpace(string drive)
        {
            long space;

            DriveInfo driveInfo = new DriveInfo(drive);
            space = driveInfo.AvailableFreeSpace / 1024 / 1024 / 1024;

            await DKDLog.WriteInLog($"Свободное место на диске {drive} {space} GB");
        }

        static public async Task FileSystem(string drive)
        {
            if (!Directory.Exists(drive)) throw new Exception("Пездец");
            await DKDLog.WriteInLog($"Файловая система на диске {drive} {new DriveInfo(drive).DriveFormat}");
        }

        public static async Task AllInfo()
        {
            foreach (var i in DriveInfo.GetDrives())
            {
                await DKDLog.WriteInLog("\n"+i.Name);
                await DKDLog.WriteInLog($"Тотал места:{new DriveInfo(i.Name).TotalSize/1024/1024/1024}" + " GB");
                await DKDDiskInfo.FreeSpace(i.Name);
                await DKDLog.WriteInLog($"Метка диска:{new DriveInfo(i.Name).VolumeLabel}");
                await DKDDiskInfo.FileSystem(i.Name);
                await DKDLog.WriteInLog("\n");
            }
        }


    }


    class DKDFileInfo
    {
       public static async Task GetInfo(string fileName)
        {
    await DKDLog.WriteInLog($"Инфа об файле  {new FileInfo(fileName).Name}");
            FileInfo fileInfo = new FileInfo(fileName);
            await DKDLog.WriteInLog($"Полный путь: {fileInfo.FullName}");
            await DKDLog.WriteInLog($"Размер: {fileInfo.Length / 1024} KB");
            await DKDLog.WriteInLog($"Расшиерение: {fileInfo.Extension}");
            await DKDLog.WriteInLog($"Имя: {fileInfo.Name}");
            await DKDLog.WriteInLog($"Дата создания: {fileInfo.CreationTime}");
            await DKDLog.WriteInLog($"Дата изменения: {fileInfo.LastWriteTime}");
            await DKDLog.WriteInLog("\n");
        }
            
    }

    class DKDDirInfo
    {
        public static async Task GetInfo(string dir)
        {
            await DKDLog.WriteInLog($"Инфа об папке  {new DirectoryInfo(dir).Name}");
await DKDLog.WriteInLog($"Количество файлов: {new DirectoryInfo(dir).GetFiles().Length}");
await DKDLog.WriteInLog($"Время создания: {new DirectoryInfo(dir).CreationTime}");
await DKDLog.WriteInLog($"Количество поддиректориев: {new DirectoryInfo(dir).GetDirectories().Length}");
            await DKDLog.WriteInLog($"Список родительских директориев:{new DirectoryInfo(dir).Parent.FullName}");
            await DKDLog.WriteInLog("\n");

        }

    }


    class DKDFileManager
    {
        static async Task CopyFileAsync(string sourcePath, string destinationPath)
        {
            using (var sourceStream = new FileStream(sourcePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var destinationStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
            {
                await sourceStream.CopyToAsync(destinationStream);
            }
        }
        static async Task DeleteFileAsync(string filePath)
        {
            await Task.Run(() => File.Delete(filePath));
        }

        public static async Task MoveFileAsync(string sourcePath, string destinationPath)
        {
            await CopyFileAsync(sourcePath, destinationPath);
            await DeleteFileAsync(sourcePath);
        }




        static string path="Z:\\lab12_OOP\\DKDInspect";
    static string filePath = "Z:\\lab12_OOP\\DKDInspect\\DKDdirinfo.txt";
        public static async Task a(string inspectDir)
        {
            var dirs = Directory.GetDirectories(inspectDir);
            var files = Directory.GetFiles(inspectDir);


            if (!Directory.Exists(path)) Directory.CreateDirectory(path);

            if (!File.Exists(filePath)) using (File.Create(filePath)) ;
            else await File.WriteAllTextAsync(filePath, string.Empty);


            await File.AppendAllTextAsync(filePath, "Список папок:\n");
            foreach (var i in dirs)
            {
                await File.AppendAllTextAsync(filePath,i+"\n");
            }

            await File.AppendAllTextAsync(filePath, "\n\n\n\nСписок файлов:\n");
            foreach (var i in files)
            {
                await File.AppendAllTextAsync(filePath, i+"\n");
            }
            CopyFileAsync(filePath, "Z:\\DKDInspect\\COPY.txt");   
            await DeleteFileAsync(filePath);


        }


        public static async Task b(string dir)
        {

           
            if (!Directory.Exists("Z:\\DKDFiles")) Directory.CreateDirectory("Z:\\DKDFiles");
            var filter=Directory.GetFiles(dir,"*.mp3");
            foreach (var file in filter)    
            {
                await MoveFileAsync(file, "Z:\\DKDFiles\\"+file.Substring(file.LastIndexOf("\\")+1));
            }

           Directory.CreateDirectory("Z:\\lab12_OOP\\DKDInspect\\DKDFiles");
            filter=Directory.GetFiles("Z:\\DKDFiles");
            foreach (var file in filter)
            {
                await MoveFileAsync(file, "Z:\\lab12_OOP\\DKDInspect\\DKDFiles\\"+file.Substring(file.LastIndexOf("\\")+1));
            }
            Directory.Delete("Z:\\DKDFiles");
        }
        public static async Task c()
        {
            File.Delete ("Z:\\Archive.zip");
           ZipFile.CreateFromDirectory("Z:\\lab12_OOP\\DKDInspect\\DKDFiles", "Z:\\Archive.zip");
        ZipFile.ExtractToDirectory("Z:\\Archive.zip", "Z:\\lab12_OOP",true);
        }
    }

    class Acess
    {
        public static async Task ThisHour()
        {
            using (FileStream fstream = new FileStream("Z:\\lab12_OOP\\DKDlogfile.txt", FileMode.Open))
            {
                byte[] temp = new byte[16];
                await fstream.ReadAsync(temp, 0, temp.Length);
                string text = Encoding.Default.GetString(temp);
                Console.WriteLine(text);
            }
        }
    }

    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                if (!Directory.Exists("Z:\\lab12_OOP")) Directory.CreateDirectory("Z:\\lab12_OOP");
                await DKDLog.CreateLogFile();



                await DKDDiskInfo.AllInfo();
                await DKDFileInfo.GetInfo(@"Z:\MOON - Dust (slow_reverb).mp3");
                await DKDDirInfo.GetInfo("C:\\Users\\stude\\");
                await DKDFileManager.a("C:\\users\\stude");
                await DKDFileManager.b("Z:\\lab12_OOP\\Test");
                await DKDFileManager.c();
                await Acess.ThisHour();
                await DKDLog.FilterLogByCriteria(keyword: "Свободное место");




                await DKDLog.ReadLog();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                    Environment.Exit(69);
            }


        }
    }
}