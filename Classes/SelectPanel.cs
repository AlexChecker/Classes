using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace Classes
{
    class SelectPanel : BorderPanel
    {
        public ArrayList ara = new ArrayList();
        public bool file = false;
        public int hilight;
        public int fo=0;
        public SelectPanel(int width, int height) : base(width, height)
        {

        }

        public bool isFolder()
        {
            string current = ara[hilight] as string;
            FileAttributes attr = File.GetAttributes(current);

            //detect whether its a directory or file
            return (attr & FileAttributes.Directory) == FileAttributes.Directory;
        }

        public string getHighlighted()
        {
            return ara[hilight] as String;
        }

        public override char getline(int x, int y)
        {
            String l="";
            if (ara.Count > y+fo)
            {
                string[] args = ((string)ara[y + fo]).Split('\\');
                l = args[args.Length - 1];
                if (l.Length > x)
                {
                    if (y+fo == hilight )
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.BackgroundColor = ConsoleColor.White;
                    }
                    return l[x];
                }
            }
            Console.ResetColor();
            return base.getline(x,y);
        }
    }
}
