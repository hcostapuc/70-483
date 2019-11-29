using System;

namespace LISTING_1_67_Event_based_alarm
{
    class Alarm
    {
        //CTO: A solução para o problema 1-66 é simples basta utilizarmos o keyword event, que nao deixa codigos externos setar ou dar get na propriedade.
        //Outra dica é ja isntanciar o delegate, pois assim nao necessitamos verificar se o mesmo é nulo toda vez que formos invoca-lo

        // Delegate for the alarm event
        public event Action OnAlarmRaised = delegate { };

        // Called to raise an alarm
        public void RaiseAlarm()
        {
            OnAlarmRaised();
        }
    }

    class Program
    {
        // Method that must run when the alarm is raised
        static void AlarmListener1()
        {
            Console.WriteLine("Alarm listener 1 called");
        }

        // Method that must run when the alarm is raised
        static void AlarmListener2()
        {
            Console.WriteLine("Alarm listener 2 called");
        }

        static void Main(string[] args)
        {
            // Create a new alarm
            Alarm alarm = new Alarm();

            alarm.RaiseAlarm();

            // Connect the two listener methods
            alarm.OnAlarmRaised += AlarmListener1;
            alarm.OnAlarmRaised += AlarmListener2;

            alarm.RaiseAlarm();

            Console.WriteLine("Alarm raised");
            Console.ReadKey();
        }
    }
}
