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
            //GiveOrdersToElevator poprawić bo dziwnie rozdaje zadania windzie 
            ElevatorManager elevatorManager = new ElevatorManager(1);


            QueueManager peopleFloors = new QueueManager();
            //peopleFloors.AddSort(0, 2);//up
            //peopleFloors.AddSort(1, 4);//up
            //peopleFloors.AddSort(3, 1);//down

            //0->1->2->4 | up
            //4->3->1->0 | down

            foreach(var people in peopleFloors.peopleFloors)
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

                //elevatorManager.elevators[0].Run();
                elevatorManager.MakeStep();
                //if (elevatorManager.isEmpty && elevatorManager.elevators[0].idleFloor == elevatorManager.elevators[0].currentFloor)
                //{
                //    elevatorManager.AddRequest();
                //}
            }






            //elevatorManager.GiveOrdersToElevator();
            //var task2 = Task.Run(() =>
            //{
            //    elevatorManager.GiveOrdersToElevator();

            //});
            //var task = Task.Run(() =>
            //{
            //    elevatorManager.elevators[0].RunWithElevatorManager();
            //});
            //var task3 = Task.Run(() =>
            //{
            //    elevatorManager.GiveOrdersToElevator();

            //});
            //var taskRequest = Task.Run(() =>
            //{

            //    elevatorManager.AddRequestAsync();
            //});
            //task.Wait();
            Console.ReadLine();
            
        }
    }
}




/* elevatorManager trzyma kolejke up i down i rodzdziela zadania do wind dodając elementy do kolejki floor
 * 
 * WARNINNG: ELEVATOR NIE UWZGLEDNIA CURRENFLOOR PERSON DO ZATRZYMANIA SIE  gdy jest (0,2) i (1,4) to sie nie zatrzymuje na 1 floor, a jedzie na 4
 * 
 * 
 * 
 * 
 * 
 * 
 */