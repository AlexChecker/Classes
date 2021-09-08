using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    class InternalSpace : Panel
    {

        public InternalSpace(int width,int height):base(width,height)
        {

        }
        public int getHeight()
        {
            return height- 3;
        }
        public char? Border(int x, int y)
        {
            if (x == 0 || x == width-1 || y == 0 || y == height-1)
            {
                return '#';
            }
            else
            {
                return getline(x-1,y-1);
            }
            return null;
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
