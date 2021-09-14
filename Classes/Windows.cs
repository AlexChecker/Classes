using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Windows : Window
    {

        public Windows() : base(null)
        {
            
            
        }

        public ArrayList windows = new ArrayList();


        public void addWindow(Window w)
        {
            windows.Add(w);
        }

        public void putUpper(Window w)
        {
            windows.Remove(w);
            windows.Insert(windows.Count - 1, w);
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
