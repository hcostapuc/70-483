using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_68_EventHandler_alarm
{
    class Alarm
    {
         //Delegate for the alarm event
        public event EventHandler<AlarmEventArgs> OnAlarmRaised = delegate { };

         //Called to raise an alarm
         //Does not provide any event arguments
        public void RaiseAlarm(string location)
        {
             //Raises the alarm
             //The event handler receivers a reference to the alarm that is 
             //raising this event
            OnAlarmRaised(this, new AlarmEventArgs(location));
        }
    }
    //CTO: Objeto que representa o parametro de um Eventhandler
    class AlarmEventArgs : EventArgs
    {
        public string Location { get; set; }
        public AlarmEventArgs(string location)
        {
            Location = location;
        }
    }
    class Program
    {
        private static void AlarmListener1(object sender, AlarmEventArgs args)
        {
            // Only the sender is valid as this event doesn't have arguments
            Console.WriteLine("Alarm listener 1 called");
            Console.WriteLine("Alarm in {0}",args.Location);
        }

        private static void AlarmListener2(object sender, AlarmEventArgs args)
        {
            // Only the sender is valid as this event doesn't have arguments
            Console.WriteLine("Alarm listener 2 called");
            Console.WriteLine("Alarm in {0}", args.Location);
        }

        static void Main(string[] args)
        {
            // Create a new alarm
            Alarm alarm = new Alarm();

            // Connect the two listener methods
            alarm.OnAlarmRaised += AlarmListener1;
            alarm.OnAlarmRaised += AlarmListener2;

            alarm.RaiseAlarm("Brazil");
        }
    }
}
