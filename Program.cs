using System;

namespace ClinicQueue
{
    internal class Program
    {
        private static ClinicQueue clinic = new ClinicQueue();
        private static int[] stats = new int[24];
        static void Main(string[] args)
        {
            RunMenu();
        }

        private static void RunMenu()
        {
            while(true)
            {
                Console.WriteLine("===== Clinic Menu =====");
                Console.WriteLine("1. Add patient to queue");
                Console.WriteLine("2. Call next patient");
                Console.WriteLine("3. Show waiting list");
                Console.WriteLine("4. Statistics report");
                Console.WriteLine("5. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                switch(choice)
                {
                    case "1":
                        AddPatient();
                        break;
                    case "2":
                        NextPatient();
                        break;
                    case "3":
                        ShowQueue();
                        break;
                    case "4":
                        ShowReport();
                        break;
                    case "5":
                        ExitProgram();
                        return;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }   
            }
        }

        //----------------------------------------------------------------
        
        //העתקת התור
        public static Queue<T> CopyQueue<T>(Queue<T> Q)
        {
            Queue<T> CopyQ = new Queue<T>();
            Queue<T> Temp = new Queue<T>();
            while (!Q.IsEmpty())
            {
                CopyQ.Insert(Q.Head());
                Temp.Insert(Q.Remove());
            }
            while (!Temp.IsEmpty())
            {
                Q.Insert(Temp.Remove());
            }
            return CopyQ;
        }

        //הוספת פציינט
        private static void AddPatient()
        {
            Console.Write("Enter ID: ");
            string id = Console.ReadLine();
            
            Console.WriteLine();

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.WriteLine();

            Console.Write("Is urgent? Yes / No: ");
            bool urgent = false;
            string ItIsUrgent = Console.ReadLine();
            if(ItIsUrgent == "Yes")
            {
                urgent = true;
            }

            Console.WriteLine();

            Patient p = new Patient(id,name,urgent);
            clinic.EnterToQueue(p);

            Console.WriteLine("Patient added successfully.");
        }

        //קריאה לפציינט הבא ומחיקה מהתור
        private static void NextPatient()
        {
            if(clinic.IsEmpty())
            {
                Console.WriteLine("The queue is empty.");
                return;
            }

            Patient p = clinic.DeleteFromQueue();
            Console.WriteLine("==== Next in Line ====");
            Console.WriteLine(p);

            int hour = DateTime.Now.Hour;
            stats[hour]++;
        }

        //מראה את רשימת הפציינטים שבתור הדחופים קודם
        private static void ShowQueue()
        {
            if(clinic.IsEmpty() == true)
            {
                Console.WriteLine("No patients waiting.");
                return;
            }

            Console.WriteLine("===== Waiting List (urgent first) =====");

            //תור הדחופים
            PrintQueueByCopy(clinic.GetUrgentQueue());
            
            //תור הרגילים
            PrintQueueByCopy(clinic.GetRegularQueue());
        }
        private static void PrintQueueByCopy(Queue<Patient> source)
        {
            Queue<Patient> copy = CopyQueue(source);
            while(!copy.IsEmpty())
            {
                Console.WriteLine(copy.Remove());
            }
        }

        private static void ShowReport()
        {
            Console.WriteLine("===== Patients by Hour =====");
            for(int h = 0; h<24; h++)
            {
                Console.WriteLine($"Hour {h,2}: {stats[h]} patients");
            }
        }

        public static void ExitProgram()
        {
            Console.WriteLine("Goodbye!");
        }
    }
}