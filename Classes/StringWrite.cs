using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class StringWrite : InternalSpace
    {
        public ArrayList ara = new ArrayList();
        public bool file = false;
        public int hilight;
        public int fo=0;
        public StringWrite(int width,int height):base(width,height)
        {
       
        }
        public override char getline(int x, int y)
        {
            String l="";
            if (ara.Count > y+fo)
            {

                if (file && (ara[y + fo].ToString().IndexOf('\\') > 0 || ara[y + fo].ToString().IndexOf('/') > 0))
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
