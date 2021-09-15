using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;
using System.Diagnostics;

namespace Classes
{
    class Xplore
    {


        private int width, height;
        private Windows windows;
        private SelectPanel left, right;
        private SelectPanel current; //Choosen panel <tab>
        private Window leftw, rightw;
        private Window currentw;
        private string path;

        private InputWindow pane;
        private int i = 0;

        public Xplore(int w, int h)
        {
            this.width = w;
            this.height = h;
            this.windows = new Windows();
            path = Directory.GetCurrentDirectory();
            left = fileZ(path);
            right = fileZ(path);
            Window leftw = new Window(w, h, 0, 0, left);
            Window rightw = new Window(w, h, w, 0, right);
            this.leftw = leftw;
            this.rightw = rightw;
            windows.addWindow(leftw);
            windows.addWindow(rightw);
            setupListener(leftw.controller);
            setupListener(rightw.controller);
            InputWindow win = new InputWindow(32, 8, w / 2 + 9, h / 2 - 4);
            this.pane = win;
            setupListener(win.controller);
            windows.addWindow(win);
            windows.focused = leftw;
            currentw = leftw;

            current = left;
        }

        private void setupListener(KeyController controller)
        {
            controller.addListener(new KeyListener(ConsoleKey.UpArrow, () =>
            {
                listUp();
            }));
            controller.addListener(new KeyListener(ConsoleKey.DownArrow, () =>
            {
                listDown();
            }));
            controller.addListener(new KeyListener(ConsoleKey.Enter, () =>
            {
                enter();
            }));
            controller.addListener(new KeyListener(ConsoleKey.K, () =>
            {
                windows.focused = pane;
                updateScreen();
            }));
            controller.addListener(new KeyListener(ConsoleKey.Tab, () =>
            {
                if (current == right)
                {
                    current = left;
                    currentw = leftw;
                }
                else
                {
                    current = right;
                    currentw = rightw;
                }
                windows.focused = currentw;
            }));

        }

        public void updateScreen()
        {
            windows.draw();
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
            updateScreen();
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
            updateScreen();
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
                if (filepath.Contains(".exe"))
                {
                    Process.Start(filepath);
                }
                else
                {
                    Process.Start("notepad.exe", filepath);
                }
                

            }
            else
            {
                path = current.getHighlighted();
                current.hilight = 0;
                current.ara = updatedirs(path);
            }
            updateScreen();
        }

        public void Xplorer()
        {
            path = Directory.GetCurrentDirectory();
            left.ofx = width;
            updateScreen();
            while (true)
            {
                Window focus = windows.focused;
                if (focus != null)
                {
                    ConsoleKeyInfo info = Console.ReadKey(true);
                    focus.process(info.Key);
                    updateScreen();
                }
            }
        }
        public SelectPanel fileZ(string path)
        {
            SelectPanel fileManager = new SelectPanel(width, height);
            fileManager.ara = updatedirs(path);
            updateScreen();
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
