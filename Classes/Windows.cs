using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace Classes
{
    class Windows : Window
    {

        public Windows() : base(null)
        {
            
            
        }

        public ArrayList windows = new ArrayList();
        public Window focused = null;

        public void addWindow(Window w)
        {
            windows.Add(w);
            focused = w;
        }

        public void putUpper(Window w)
        {
            windows.Remove(w);
            windows.Insert(windows.Count - 1, w);
            focused = w;
        }

        public override void draw()
        {
            foreach(Window w in windows)
            {
                w.draw();
            }
        }
    }
}
