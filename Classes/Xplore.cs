using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace Classes
{
    class Xplore
    {


        private int width, height;
        private KeyController keyController;
        private ListPanel left, right;
        private ListPanel current; //Choosen panel <tab>
        private string path;

        public Xplore(int w, int h)
        {
            this.width = w;
            this.height = h;
            this.keyController = new KeyController();
            path = Directory.GetCurrentDirectory();
            left = fileZ(path);
            right = fileZ(path);
            current = left;
            setupListener();
        }

        private void setupListener()
        {
            keyController.addListener(new KeyListener(ConsoleKey.UpArrow, () =>
            {
                listUp();
            }));
            keyController.addListener(new KeyListener(ConsoleKey.DownArrow, () =>
            {
                listDown();
            }));
            keyController.addListener(new KeyListener(ConsoleKey.Enter, () =>
            {
                enter();
            })); 
            keyController.addListener(new KeyListener(ConsoleKey.Tab, () =>
            {
                if (current == right)
                {
                    current = left;
                }
                else
                {
                    current = right;
                }
            }));

        }

        private void listUp()
        {
            if (current.hilight == 0) current.hilight = current.ara.Count - 1;
            else if (current.hilight == current.fo)
            {
                current.fo--;
                current.hilight--;
            }
            else current.hilight--;
            current.DrawPanel();
        }

        private void listDown()
        {
            if (current.hilight == current.ara.Count - 1) current.hilight = 0;
            else if (current.hilight == current.getHeight() + current.fo)
            {
                current.fo++;
                current.hilight++;
            }
            else current.hilight++;
            current.DrawPanel();
        }

        private void enter()
        {
            if (current.getHighlighted() == "..")
            {
                current.hilight = 0;
                path = Directory.GetParent(path).FullName;
                current.ara = updatedirs(path);
            }
            else if (!current.isFolder())
            {
                string filepath = (string)current.ara[current.hilight + current.fo];
                if (!filepath.Contains(".exe"))
                {
                    Process.Start("notepad.exe", filepath);
                }
                else
                {
                    Process.Start(filepath);
                }
                

            }
            else
            {
                path = current.getHighlighted();
                current.hilight = 0;
                current.ara = updatedirs(path);
            }
            current.DrawPanel();
        }

        public void Xplorer()
        {
            path = Directory.GetCurrentDirectory();
            left.ofx = width;
            left.DrawPanel();
            right.DrawPanel();
            keyController.syncListen();
        }
        public ListPanel fileZ(string path)
        {
            ListPanel fileManager = new ListPanel(width, height);
            fileManager.ara = updatedirs(path);
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
