using System;
using System.IO;
using System.Collections;

namespace Classes
{
    class Program
    {
        static void Main(string[] args)
        {
            StringWrite list = new StringWrite(20, 20);
            list.ara.Add("..");
            list.ara.Add("asd");
            list.ara.Add("dsa");
            list.DrawPanel();
            bool close = false;
            bool fZ = false;
            string path = Directory.GetCurrentDirectory();
            
            StringWrite second = fileZ(path);
            while (!close)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (!fZ)
                        {
                            if (list.hilight == 0) list.hilight = list.ara.Count - 1;
                            else list.hilight--;
                            list.DrawPanel();
                        }
                        else 
                        {
                            if (second.hilight == 0) second.hilight = second.ara.Count - 1;
                            else if (second.hilight == second.fo)
                            {
                                second.fo--;
                                second.hilight--;
                            }
                            else second.hilight--;
                            second.DrawPanel();
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (!fZ)
                        {
                            if (list.hilight == list.ara.Count - 1) list.hilight = 0;
                            else list.hilight++;
                            list.DrawPanel();
                        }
                        else
                        {
                            if (second.hilight == second.ara.Count - 1) second.hilight = 0;
                            else if (second.hilight == second.getHeight()+second.fo)
                            {
                                second.fo++;
                                second.hilight++;
                            }
                            else second.hilight++;
                            second.DrawPanel();
                        }
                        break;
                    case ConsoleKey.Enter:
                        if (!fZ)
                        {
                            if (list.hilight == 0) close = true;
                            list.DrawPanel();
                        }
                        else
                        {
                            
                            if ((string)second.ara[second.hilight] == "..")
                            {
                                second.hilight = 0;
                                path = Directory.GetParent(path).FullName;
                                second.ara = updatedirs(path);
                            }
                            else
                            {
                                
                                path = (string)second.ara[second.hilight];
                                second.hilight = 0;
                                second.ara = updatedirs(path);
                            }
                            second.DrawPanel();
                        }
                        break;
                    case ConsoleKey.Tab:
                        fZ = !fZ;
                        break;
                }
            }
        }
        public static StringWrite fileZ(string path)
        {
            StringWrite fileManager = new StringWrite(40, 15);
            fileManager.ofx = 21;
            fileManager.ara.Clear();
            fileManager.ara.Add("..");
            fileManager.file = true;
            foreach (string dir in Directory.GetDirectories(path))
            {
                fileManager.ara.Add(dir);
            }
            foreach (string dir in Directory.GetFiles(path))
            {
                fileManager.ara.Add(dir);
            }
            fileManager.DrawPanel();
            return fileManager;
        }
        public static ArrayList updatedirs(string path)
        {
            ArrayList arr = new ArrayList();
            arr.Add("..");
            foreach (string dir in Directory.GetDirectories(path))
            {
               arr.Add(dir);
            }
            foreach (string dir in Directory.GetFiles(path))
            {
               arr.Add(dir);
            }
            return arr;
        }
    }
}
