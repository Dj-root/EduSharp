using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduSharp.Troelsen.Unit20
{
    public static class FileWatcher
    {


        public static void Watcher()
        {
            Console.WriteLine("***** The Amazing File Watcher App *****\n");

            FileSystemWatcher watcher = new FileSystemWatcher();
            try
            {
                watcher.Path = @"C:\MyFolder";
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            // Set up the things to be on the lookout for.
            watcher.NotifyFilter = NotifyFilters.LastAccess
                                   | NotifyFilters.LastWrite
                                   | NotifyFilters.FileName
                                   | NotifyFilters.DirectoryName;
            // only watch text files
            watcher.Filter = "*.txt";

            //Add event handlers
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching the directory
            watcher.EnableRaisingEvents = true;
            Console.WriteLine(@"Press 'q' to quit app");
            while (Console.Read() != 'q')
            {
            }
        }

        static void OnChanged(object source, FileSystemEventArgs e)
        {
            Console.WriteLine("File: {0} {1}!", e.FullPath, e.ChangeType);
        }

        static void OnRenamed(object source, RenamedEventArgs e)
        {
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }
    }
}
