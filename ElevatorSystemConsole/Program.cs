using ElevatorSystemConsole;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    public class Program
    {
        static void Main(string[] args)
        {
            //TODO::dodać dwie osobne klassy dla przycisku wewnatrz windy i przed winda

            ElevatorManager elevatorManager = new ElevatorManager(1);


            QueueManager peopleFloors = new QueueManager();
            //peopleFloors.AddSort(0, 2);//up
            //peopleFloors.AddSort(1, 4);//up
            //peopleFloors.AddSort(3, 1);//down

            //0->1->2->4 | up
            //4->3->1->0 | down

            foreach (var people in peopleFloors.peopleFloors)
            {
                elevatorManager.AddFloor(people);
            }
            var task = Task.Run(() =>
            {
                elevatorManager.AddRequestAsync();
            });
            while(true)
            {
                Thread.Sleep(500);
                elevatorManager.MakeStep();
            }
            Console.ReadLine();
            
        }
    }
}


