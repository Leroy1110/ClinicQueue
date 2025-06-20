using System;
namespace ClinicQueue
{
	internal class Queue<T>
	{
        private Node<T> first;

        private Node<T> last;

        private int size; //גודל התור

        public Queue()
        {
            this.first = null;

            this.last = null;
            this.size = 0;
        }
        public bool IsEmpty()
        {
            return (this.first == null);
        }
        public void Insert(T x)
        {
            Node<T> temp = new Node<T>(x);

            if (this.first == null)

                this.first = temp;
            else

                this.last.SetNext(temp);

            this.last = temp;
            this.size++;
        }
        public T Remove()
        {
            T x = this.first.GetValue();

            first = first.GetNext();

            if (this.first == null)

                this.last = null;
            this.size--;
            return (x);
        }
        public T Head()
        {
            return (this.first.GetValue());
        }

        public int GetSize()
        {
            return this.size;
        }
        public override string ToString()
        {
            string st = "[";

            Node<T> pos = this.first;

            while (pos != null)
            {
                st += pos.GetValue();

                if (pos.GetNext() != null)

                    st += ",";

                pos = pos.GetNext();
            }
            st += "]";
            return (st);
        }
        

    }
}

