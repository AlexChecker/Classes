using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Classes
{
    class KeyController
    {

        private ArrayList listeners = new ArrayList();
        private ArrayList listenersOther = new ArrayList();

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

        public void addListenerOther(Action<ConsoleKey> onType)
        {
            listenersOther.Add(onType);
        }

        public void processor(ConsoleKey key)
        {
            KeyListener sel = getListener(key);
            if (sel != null)
            {
                sel.onClick();
            }
            else
            {
                foreach(Action<ConsoleKey> onType in listenersOther)
                {
                    onType.Invoke(key);
                }
            }
        }

        public void syncListen()
        {
            Boolean close = false;
            while (!close)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                processor(key.Key);
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
