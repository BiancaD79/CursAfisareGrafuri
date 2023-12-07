using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BFS_DFS
{
    public abstract class GenericList<T>
    {
        protected T[] values;
        public GenericList()
        {
            values = new T[0];
        }

        public virtual void Push(T value) // buffer or double
        {
            T[] temp = new T[values.Length + 1];
            for (int i = 0; i < values.Length; i++)
            {
                temp[i + 1] = values[i];
            }
            temp[0] = value;
            values = temp;
        }

        public abstract T Pop();

        public virtual string View()
        {
            string temp = "";
            for (int i = 0; i < values.Length; i++)
            {
                temp += values[i].ToString() + " ";
            }
            return temp;
        }

        public virtual bool IsEmpty()
        {
            return values.Length == 0;
        }
    }
}
