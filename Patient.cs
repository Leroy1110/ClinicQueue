using System;

namespace ClinicQueue
{
    internal class Patient
	{
        private string id; // תעודת זהות
        private string name; //שם
        private DateTime ArrivalTime; // שעת הגעה
        private bool IsUrgent; //האם דחוף

        //פעולה בונה
        public Patient(string id, string name, bool IsUrgent)
        {
            this.id = id;
            this.name = name;
            this.ArrivalTime = DateTime.Now;
            this.IsUrgent = IsUrgent;
        }

        public string GetId()
        {
            return this.id;
        }
        public string GetName()
        {
            return this.name;
        }
        public DateTime GetArrivalTime()
        {
            return this.ArrivalTime;
        }
        public bool GetIsUrgent()
        {
            return this.IsUrgent;
        }

        public override string ToString()
        {
            return $"Id: {this.id} , Name: {this.name} , ArrivalTime: {this.ArrivalTime} ,IsUrgent: {this.IsUrgent}";
        }
    }
}