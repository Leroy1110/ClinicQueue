using System;
namespace ClinicQueue
{
	class Node<T>
	{
		private T Value;
		private Node<T> Next;

		public Node(T value)
		{
			this.Value = value;
			this.Next = null;
		}
		public Node(T value,Node<T> Next)
		{
			this.Value = value;
			this.Next = Next;
		}

		public T GetValue()
		{
			return this.Value;
		}

		public Node<T> GetNext()
		{
			return this.Next;
		}

		public void SetValue(T Value)
		{
			this.Value = Value;
		}

		public void SetNext(Node<T> Next)
		{
			this.Next = Next;
		}

		public bool HasNext()
		{
			return this.GetNext() != null;
		}

        public override string ToString()
        {
			return "" + this.Value;
        }
    }
}

