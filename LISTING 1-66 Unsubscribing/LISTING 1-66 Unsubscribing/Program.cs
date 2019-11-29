using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LISTING_1_66_Unsubscribing
{
    class Alarm
    {
        // Delegate for the alarm event
        public Action OnAlarmRaised { get; set; }

        // Called to raise an alarm
        public void RaiseAlarm()
        {
            // Only raise the alarm if someone has
            // subscribed. 
            OnAlarmRaised?.Invoke();
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

            // Connect the two listener methods
            alarm.OnAlarmRaised += AlarmListener1;
            alarm.OnAlarmRaised += AlarmListener2;

            alarm.RaiseAlarm();
            Console.WriteLine("Alarm raised");

            //CTO: aqui retiramos a publicação do metodo AlarmListener1, quando o delegate for invocado, o mesmo nao chamara mais o metodo AlarmListener1.
            //Se publicarmos o mesmo evento a um delegate mais de uma vez, ele executara a quantiadde de vezes que foi publicado.
            //Esse exemplo nao é um exemplo seguro de publicação de delegate, pois o OnAlarmRaised esta publico, ou seja, qualquer um que for usar a classe podera alterar o delegate
            //a boa pratica esta no exemplo 1-67
            alarm.OnAlarmRaised -= AlarmListener1;

            alarm.RaiseAlarm();
            Console.WriteLine("Alarm raised");

            Console.ReadKey();
        }
    }
}
