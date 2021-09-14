using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Window : Drawable
    {

        Panel panel;
        public int xo, yo = 0;
        public int w = 16, h = 16;
        public bool hidden = false;


        public Window(Panel panel)
        {
            this.panel = panel;
        }

        public void syncPosition()
        {
            panel.ofx = xo;
            panel.ofy = yo;
            panel.width = w;
            panel.height = h;
        }

        public virtual void draw()
        {
            syncPosition();
            if (hidden) return;
            panel.draw();
        }
    }
}
