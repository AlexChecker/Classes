using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    class BorderPanel : Panel
    {

        public BorderPanel(int width,int height):base(width,height)
        {

        }
        public int getHeight()
        {
            return height- 3;
        }
        public char? Border(int x, int y)
        {
            //if (x == 0 || x == width-1 || y == 0 || y == height-1)
            //{
            //    return '#';
            //}
            if (x == 0 && y == 0) return '╔';
            if ((x == 0 || x == width - 1) && y != 0 && y != height - 1) return '║';
            if (x == width - 1 && y == 0) return '╗';
            if (x == 0 && y == height - 1) return '╚';
            if (x == width - 1 && y == height - 1) return '╝';
            if ((y == 0 || y == height - 1) && x != 0 && x != width - 1) return '═';
            else
            {
                return getline(x - 1, y - 1);
            }
        }
        
        public virtual char getline(int x,int y)
        {
            return ' ';
        }
        public override char CharToDraw(int x, int y)
        {
            char? draw = Border(x,y);
            if (draw != null) return (char)draw;
            return ' ';
        }
    }
}
