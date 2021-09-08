using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;

namespace Classes
{
    class Xplore:StringWrite
    {
        public Xplore(int width,int height):base(width,height)
        {
        
        }

        public void Xplorer()
        {
            bool close = false;
            bool fZ = false;
            string path = Directory.GetCurrentDirectory();
            StringWrite first = fileZ(path);
            StringWrite second = fileZ(path);
            second.ofx = width;
            first.DrawPanel();
            second.DrawPanel();
            while (!close)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (!fZ)
                        {
                            if (first.hilight == 0) first.hilight = first.ara.Count - 1;
                            else if (first.hilight == first.fo)
                            {
                                first.fo--;
                                first.hilight--;
                            }
                            else first.hilight--;
                            first.DrawPanel();
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
                            if (first.hilight == first.ara.Count - 1) first.hilight = 0;
                            else if (first.hilight == first.getHeight() + first.fo)
                            {
                                first.fo++;
                                first.hilight++;
                            }
                            else first.hilight++;
                            first.DrawPanel();
                        }
                        else
                        {
                            if (second.hilight == second.ara.Count - 1) second.hilight = 0;
                            else if (second.hilight == second.getHeight() + second.fo)
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
                            if ((string)first.ara[first.hilight] == "..")
                            {
                                first.hilight = 0;
                                path = Directory.GetParent(path).FullName;
                                first.ara = updatedirs(path);
                            }
                            else
                            {
                                path = (string)first.ara[first.hilight];
                                first.hilight = 0;
                                first.ara = updatedirs(path);
                            }
                            first.DrawPanel();
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
        public StringWrite fileZ(string path)
        {
            StringWrite fileManager = new StringWrite(width, height);
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
