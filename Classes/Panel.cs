using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class Panel
    {
        protected int width;
        protected int height;
        public int ofx,ofy=0;
        public Panel(int width,int height)
        {
            this.width = width;
            this.height = height;
        }
        public void DrawPanel()
        {
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Console.SetCursorPosition(x+ofx,y+ofy);
                    Console.Write(CharToDraw(x,y));
                }
            }
        }
        public virtual char  CharToDraw(int x,int y)
        {
            return '#';
        }
    }
}
