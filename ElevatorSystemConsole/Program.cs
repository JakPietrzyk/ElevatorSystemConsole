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
            ElevatorManager elevatorManager = new ElevatorManager(1);


            QueueManager peopleFloors = new QueueManager();
            peopleFloors.AddSort(0, 2);
            peopleFloors.AddSort(1, 4);
            peopleFloors.AddSort(3, 1);

            //foreach (var x in peopleFloors.peopleFloors)
            //{
            //    //elevator.AddPFR(x);
            //    foreach(Elevator ele in elevatorManager.elevators)
            //    {
            //        ele.AddPFR(x);
            //    }
            //}
            foreach(var people in peopleFloors.peopleFloors)
            {
                elevatorManager.AddFloor(people);
            }
            //elevatorManager.GiveOrdersToElevator();
            var task2 = Task.Run(() =>
            {
                elevatorManager.GiveOrdersToElevator();

            });
            var task = Task.Run(() =>
            {
                elevatorManager.elevators[0].RunWithElevatorManager();
            });
            
            //var runElevator2 = Task.Run(() =>
            //{
            //    elevatorManager.elevators[1].Run();
            //});
            //var task2 = Task.Run(() => {
            //    elevator.AddFloorsAsync();
            //});
            //var task2 = Task.Run(()=>
            //{ 
            //    elevator.AddPFRAsync(); 
            
            //});

            ////elevator.AddNewFloor(5);
            task.Wait();
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