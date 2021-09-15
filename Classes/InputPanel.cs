using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    class InputPanel : BorderPanel
    {
        public char[,] ed;
        public int ox, oy = 0;
        
        public void oxx(int x)
        {
            if (x < 0) return;
            if(x < width-2)
            {
                this.ox = x;
            }
        }

        public void oyy(int y)
        {
            if (y < 0) return;
            if (y < height-2)
            {
                this.oy = y;
            }
        }

        public InputPanel(int w, int h) : base(w, h)
        {
            ed = new char[w, h];
        }

        public override char getline(int x, int y)
        {
            if(x == ox && y == oy)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ResetColor();
            }
            return ed[x, y];
        }
    }

    class InputWindow : Window
    {
        
        public InputWindow(int w, int h, int xo, int yo) : base(w, h, xo, yo, new InputPanel(w, h))
        {
            controller.addListenerOther((key)=>{
                int ox = getPanel().ox;
                int oy = getPanel().oy;
                getPanel().ed[ox, oy] = key.ToString()[0];
            });
            controller.addListener(new KeyListener(ConsoleKey.RightArrow, () =>
            {
                getPanel().oxx(getPanel().ox + 1);
            }));
            controller.addListener(new KeyListener(ConsoleKey.LeftArrow, () =>
            {
                getPanel().oxx(getPanel().ox - 1);
            }));
            controller.addListener(new KeyListener(ConsoleKey.UpArrow, () =>
            {
                getPanel().oyy(getPanel().oy - 1);
            }));
            controller.addListener(new KeyListener(ConsoleKey.DownArrow, () =>
            {
                getPanel().oyy(getPanel().oy + 1);
            }));
        }

        public InputPanel getPanel()
        {
            return panel as InputPanel;
        }

        public override void process(ConsoleKey key)
        {
            base.process(key);
        }

    }
}
