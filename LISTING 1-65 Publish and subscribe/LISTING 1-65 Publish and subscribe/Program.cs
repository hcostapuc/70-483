using System;

namespace LISTING_1_65_Publish_and_subscribe
{
    class Alarm
    {
        // Delegate for the alarm event
        public Action OnAlarmRaised { get; set; }

        // Called to raise an alarm
        public void RaiseAlarm()
        {
            //CTO: o treicho de codigo abaixo pode ser simplificado e substituido por esse:
            //OnAlarmRaised?.Invoke();

            // Only raise the alarm if someone has
            // subscribed. 
            if (OnAlarmRaised != null)
            {
                OnAlarmRaised();
            }
        }
    }

    class Program
    {
        // Method that must run when the alarm is raised
        static void AlarmListener1()
        {
            Console.WriteLine("Alarm listener 1 ");
        }

        // Method that must run when the alarm is raised
        static void AlarmListener2()
        {
            Console.WriteLine("Alarm listener 2 ");
        }

        static void Main(string[] args)
        {
            // Create a new alarm
            Alarm alarm = new Alarm();

            // Connect the two listener methods

            //CTO: o delegate nao vai garantir a ordem de execução perante a ordem de adição dos eventos
            //o evento rodara na mesma thread do qual foi publicado, nesse cenario os eventos AlarmListener1 e AlarmListener2 publicados na thread principal
            //irao rodar o delegate na mesma thread se o AlarmListener2 fosse publicado em uma outra thread chamada como exemplo: Thread1, o cenario mudaria
            //fazendo com que o delegate do AlarmListener1 rodasse na thread principal (onde foi publicado) e o delegate do AlarmListener2 rodasse na Thread1 (onde foi publicado)
            alarm.OnAlarmRaised += AlarmListener1;
            alarm.OnAlarmRaised += AlarmListener2;

            alarm.RaiseAlarm();

            Console.WriteLine("Alarm raised");
            Console.ReadKey();
        }
    }
}
