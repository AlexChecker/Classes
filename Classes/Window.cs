using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    class Window : Drawable
    {

        public Panel panel;
        public int xo, yo = 0;
        public int w = 16, h = 16;
        public bool hidden = false;
        public KeyController controller;


        public Window(int w, int h, int xo, int yo, Panel panel) : this(panel)
        {
            this.w = w;
            this.h = h;
            this.xo = xo;
            this.yo = yo;
            this.controller = new KeyController();
        }

        public Window(Panel panel)
        {
            this.panel = panel;
        }

        public virtual void process(ConsoleKey key)
        {
            this.controller.processor(key);
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
