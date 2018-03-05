using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Troelsen.Unit20
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Caution! All work will be done in C:\\MyFolder!\nChange sources, if needed");
            Console.WriteLine("I have red and understood");
            //            Console.ReadLine();

            Console.WriteLine("***** Fun with Directory(Info) *****\n");
            ShowWindowsDirectoryInfo();
            DisplayImageFiles();
            //            ModifyAppDirectory();

            Console.WriteLine("***** Fun with Directory *****\n");
            FunWithDirectoryType();

            Console.WriteLine("***** Fun with DriveInfo *****\n");
            FunWithDriveInfo();
            FunWithFileInfo();

            SimpleIOWithFileType();


            FunWithFileStreams();

            FunWithStreamWriter();
            FunWithStreamReader();

            FunWithStringWriter();

            FunWithBinWriter();


            FileWatcher.Watcher();

            Console.ReadLine();
        }





        

        static void FunWithBinWriter()
        {
            Console.WriteLine(" * **** Fun with Binary Writers / Readers *****\n");

            FileInfo f = new FileInfo(@"C:\MyFolder\BinFile.dat");

            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                Console.WriteLine("Base stream is: {0}", bw.BaseStream);

                double aDouble = 1234.567;
                int anInt = 345678;
                string aString = "A, B, C";

                bw.Write(aDouble);
                bw.Write(anInt);
                bw.Write(aString);
            }

            Console.WriteLine("Writing Done!\n");

            using (BinaryReader br = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }

            Console.WriteLine("All data red!");
        }

        static void FunWithStringWriter()
        {
            Console.WriteLine("***** Fun with StringWriter *****\n");

            using (StringWriter strWriter = new StringWriter())
            {
                strWriter.WriteLine("Don't forget Mother's Day this year...");
                Console.WriteLine("Contents of StringWriter: \n{0}", strWriter);

                StringBuilder sb = strWriter.GetStringBuilder();
                sb.Insert(0, "Hey!! ");
                Console.WriteLine("-> {0}", sb.ToString());
                sb.Remove(0, "Hey!! ".Length);
                Console.WriteLine("-> {0}", sb.ToString());

                using (StringReader strReader = new StringReader(strWriter.ToString()))
                {
                    Console.WriteLine("=== StringReader ===");
                    string input = null;
                    while ((input = strReader.ReadLine()) != null)
                    {
                        Console.WriteLine(input);
                    }
                }

            }
        }

        static void FunWithStreamReader()
        {
            Console.WriteLine("***** Fun with StreamReader *****\n");

            Console.WriteLine("Here are your thoughts: \n");
            using (StreamReader sr = File.OpenText(@"C:\MyFolder\reminders.txt"))
            {
                string input = null;
                while ((input = sr.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
        }

        static void FunWithStreamWriter()
        {
            Console.WriteLine("***** Fun with StreamWriter *****\n");

            using (StreamWriter writer = File.CreateText(@"C:\MyFolder\reminders.txt"))
            {
                writer.WriteLine("Don't forget Mother's Day this year...");
                writer.WriteLine("Don't forget Father's Day this year...");
                writer.WriteLine("Don't forget these numbers:");

                for (int i = 0; i < 10; i++)
                {
                    writer.Write(i + " ");
                }
                writer.Write(writer.NewLine);
            }

            Console.WriteLine("Created file and wrote some thoughts...");
        }

        static void FunWithFileStreams()
        {
            Console.WriteLine(" * **** Fun With FileStreams *****\n");

            using (FileStream fStream = File.Open(@"C:\MyFolder\myMessage.dat", FileMode.Create))
            {
                string msg = "Hello!";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);

                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);
                fStream.Position = 0;

                Console.WriteLine("Your message as an array of bytes: ");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];
                for (int i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte)fStream.ReadByte();
                    Console.WriteLine(bytesFromFile[i]);
                }

                Console.WriteLine("\nDecoded Message: ");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }

        }

        static void SimpleIOWithFileType()
        {
            Console.WriteLine("***** Simple I/O with the File Type *****\n");

            string[] myTasks = { "Fix bathroom sink", "Call Dave", "Call Mom and Dad", "Play XBox One" };

            File.WriteAllLines(@"C:\MyFolder\tasks.txt", myTasks);

            foreach (string task in File.ReadAllLines(@"C:\MyFolder\tasks.txt"))
            {
                Console.WriteLine("TODO: {0}", task);
            }
        }

        static void FunWithFileInfo()
        {
            Console.WriteLine("***** Fun with FileInfo *****\n");

            FileInfo f = new FileInfo(@"C:\MyFolder\Test.dat");
            using (FileStream fs = f.Create())
            {
            }

            FileInfo f2 = new FileInfo(@"C:\MyFolder\Test2.dat");
            using (FileStream fs2 = f2.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
            }

            FileInfo f3 = new FileInfo(@"C:\MyFolder\Test2.dat");
            using (FileStream readOnlyStream = f3.OpenRead()) { }

            FileInfo f4 = new FileInfo(@"C:\MyFolder\Test2.dat");
            using (FileStream writeOnlyStream = f4.OpenWrite()) { }


        }

        static void FunWithDriveInfo()
        {
            DriveInfo[] myDrives = DriveInfo.GetDrives();

            foreach (DriveInfo d in myDrives)
            {
                Console.WriteLine("Name: {0}", d.Name);
                Console.WriteLine("Type: {0}", d.DriveType);

                if (d.IsReady)
                {
                    Console.WriteLine("Free space: {0}", d.TotalFreeSpace);
                    Console.WriteLine("Format: {0}", d.DriveFormat);
                    Console.WriteLine("Label: {0}", d.VolumeLabel);
                }

                Console.WriteLine();
            }
        }

        static void FunWithDirectoryType()
        {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here is your drives:");
            foreach (string s in drives)
            {
                Console.WriteLine("--> {0}", s);
            }

            Console.WriteLine("Press Enter to delete directories");
            //            Console.ReadLine();

            try
            {
                Directory.Delete(@"C:\MyFolder");
                Directory.Delete(@"C:\MyFolder2", true);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
                //                throw;
            }

        }

        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\");
            dir.CreateSubdirectory("MyFolder");

            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFolder\Data");
            Console.WriteLine("New folder is: {0}", myDataFolder);

        }

        static void DisplayImageFiles()
        {
            Console.WriteLine("\n=== Get all images from C:\\Windows\\Web\\Wallpaper ===");
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows\Web\Wallpaper");

            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);
            Console.WriteLine("Found {0} *.jpg files\n", imageFiles.Length);

            foreach (FileInfo fi in imageFiles)
            {
                Console.WriteLine("=================================");
                Console.WriteLine("File name: {0}", fi.Name);
                Console.WriteLine("File size: {0}", fi.Length);
                Console.WriteLine("Creation: {0}", fi.CreationTime);
                Console.WriteLine("Attributes: {0}", fi.Attributes);
                Console.WriteLine("=================================");
            }
        }

        static void ShowWindowsDirectoryInfo()
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("=== Directory Info ===");
            Console.WriteLine("FullName: {0}", dir.FullName);
            Console.WriteLine("Name: {0}", dir.Name);
            Console.WriteLine("Parent: {0}", dir.Parent);
            Console.WriteLine("Creation: {0}", dir.CreationTime);
            Console.WriteLine("Attributes: {0}", dir.Attributes);
            Console.WriteLine("Root: {0}", dir.Root);
            Console.WriteLine("==================================\n");
        }

    }
}
