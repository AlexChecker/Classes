using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Classes
{
    class KeyController
    {

        private ArrayList listeners = new ArrayList();

        public KeyListener getListener(ConsoleKey key)
        {
            foreach(KeyListener l in listeners)
            {
                if(l.key.Equals(key))
                {
                    return l;
                }
            }
            return null;
        }

        public void addListener(KeyListener listen)
        {
            listeners.Add(listen);
        }

        public void syncListen()
        {
            Boolean close = false;
            while (!close)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                KeyListener sel = getListener(key.Key);
                if(sel != null)
                {
                    sel.onClick();
                }
            }
        }
    }

    class KeyListener
    {

        public ConsoleKey key;
        private Action act;

        public KeyListener(ConsoleKey key, Action action)
        {
            this.key = key;
            this.act = action;
        }

        public void onClick()
        {
            act.Invoke();
        }
    }
}
