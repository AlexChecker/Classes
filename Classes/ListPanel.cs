using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Classes
{
    class ListPanel : BorderPanel
    {
        public ArrayList ara = new ArrayList();
        public bool file = false;
        public int hilight;
        public int fo=0;
        public ListPanel(int width, int height) : base(width, height)
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
                
                if ((ara[y + fo].ToString().IndexOf('\\') > 0 || ara[y + fo].ToString().IndexOf('/') > 0))
                {
                    
                    l = ara[y + fo].ToString().Substring(ara[y+fo].ToString().LastIndexOf('\\'));
                }
                else
                {
                    l = (string)ara[y + fo];
                }
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
