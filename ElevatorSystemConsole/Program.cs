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
            Elevator elevator = new Elevator();
           Elevator elevator1= new Elevator();
            QueueManager peopleFloors= new QueueManager();
            peopleFloors.AddSort(0, 2);
            peopleFloors.AddSort(1, 3);
            peopleFloors.AddSort(2, 0);

            foreach(var x in peopleFloors.peopleFloors)
            {
                elevator.AddPFR(x);
            }


            var task = Task.Run(() =>
            {
                elevator.Run();
            });
            //var task2 = Task.Run(() => {
            //    elevator.AddFloorsAsync();
            //});
            var task2 = Task.Run(()=>
            { 
                elevator.AddPFRAsync(); 
            
            });
            Console.WriteLine(elevator.Id);
            Console.WriteLine(elevator1.Id);

            ////elevator.AddNewFloor(5);
            task.Wait();
            Console.ReadLine();
            
        }
    }
}




/* todo:: elevator manager class to creaate multiple elevetors, but only one queue foreach
 * check if elevator will stop after getting request if has nothing to do
 * 
 * 
 * 
 */