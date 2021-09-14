using System;
using System.IO;
using System.Collections;

namespace Classes
{
    class Program
    {

        static ListPanel c()
        {
            ListPanel l = new ListPanel(16, 16);
            l.ara.Add("Test");
            l.ara.Add("Test");
            l.ara.Add("Test");
            return l;
        }

        static void Main(string[] args)
        {
           //Xplore explorer = new Xplore(60,25);
           //explorer.Xplorer();
           while(!false && true)
            {
                Windows main = new Windows();
                Window test = new Window(c());
                Window test2 = new Window(c());
                test.xo = 10;
                test.yo = 10;
                main.addWindow(test);
                main.addWindow(test2);
                main.draw();
            }
           
        }

    }
}
