using System;

namespace ClinicQueue
{
    internal class ClinicQueue
    {
        private Queue<Patient> regular;
        private Queue<Patient> urgent;

        public ClinicQueue()
        {
            this.regular = new Queue<Patient>();
            this.urgent = new Queue<Patient>();
        }

        public Queue<Patient> GetUrgentQueue()
        {
            return this.urgent;
        }
        public Queue<Patient> GetRegularQueue()
        {
            return this.regular;
        }

        public int Count()
        {
            return regular.GetSize() + urgent.GetSize();
        }

        public bool IsEmpty()
        {
            return regular.IsEmpty() && urgent.IsEmpty();
        }

        public void EnterToQueue(Patient p)
        {
            if(p.GetIsUrgent() == true)
            {
                this.urgent.Insert(p);
            }
            else
            {
                this.regular.Insert(p);
            }
        }

        public Patient DeleteFromQueue()
        {
            if(!this.urgent.IsEmpty())
            {
                return this.urgent.Remove();
            }
            if(!this.regular.IsEmpty())
            {
                return this.regular.Remove();
            }
            return null;
        }
    }
}