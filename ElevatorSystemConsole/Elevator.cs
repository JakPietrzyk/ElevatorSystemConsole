using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystemConsole
{
    public class Elevator
    {
        public int Id { get; set; }
        static int nextId;
        public int currentFloor { get; set; }
        public int nextFloor { get; set; }
        public List<int> floorQueue { get; set; }
        public List<PersonFloorRequest> floorRequests { get; set; }
        public List<int> floorUp { get; set; }
        public List<int> floorDown { get; set; }


        public Elevator() 
        {
            Id = Interlocked.Increment(ref nextId);
            currentFloor = 0;
            nextFloor = 0;
            floorQueue = new List<int>();
            floorRequests= new List<PersonFloorRequest>();
            floorUp = new List<int>();
            floorDown = new List<int>();
        }
        public void AddNewFloor(int floor)
        {
            floorQueue.Add(floor);
        }
        public void RemoveFloor(int floor) 
        {
            floorQueue.Remove(floor);
        }
        public async Task Run()
        {
            while (true)
            {
                while (floorQueue.Count > 0)
                {
                    nextFloor = floorQueue.First();
                    floorQueue.Remove(floorQueue.First());
                    Console.WriteLine("At {0} floor, next floor: {1}", currentFloor, nextFloor);
                    while(currentFloor!=nextFloor)
                    {
                        if(currentFloor<nextFloor)
                        {
                            currentFloor++;
                        }
                        else
                        {
                            currentFloor--;
                        }
                        
                        Thread.Sleep(2000);
                        Console.WriteLine("At {0} floor, next floor: {1}", currentFloor, nextFloor);
                    }
                    Thread.Sleep(2000);
                    currentFloor = nextFloor;
                }
                while(floorQueue.Count == 0 && currentFloor!=0)
                {
                    currentFloor--;
                    nextFloor = 0;
                    Console.WriteLine("Nothing to do At {0} floor, next floor: {1}", currentFloor, nextFloor);
                    Thread.Sleep(2000);
                }
                while(floorUp.Count > 0) 
                {
                    nextFloor = floorUp.First();
                    floorUp.Remove(floorUp.First());
                    Console.WriteLine("At {0} floor, next floor: {1}", currentFloor, nextFloor);
                    while (currentFloor != nextFloor)
                    {
                        if (currentFloor < nextFloor)
                        {
                            currentFloor++;
                        }
                        else
                        {
                            currentFloor--;
                        }

                        Thread.Sleep(2000);
                        Console.WriteLine("At {0} floor, next floor: {1}", currentFloor, nextFloor);
                    }
                    Thread.Sleep(2000);
                    currentFloor = nextFloor;
                }
                while(floorDown.Count>0)
                {
                    nextFloor = floorDown.First();
                    floorDown.Remove(floorDown.First());
                    Console.WriteLine("At {0} floor, next floor: {1}", currentFloor, nextFloor);
                    while (currentFloor != nextFloor)
                    {
                        if (currentFloor < nextFloor)
                        {
                            currentFloor++;
                        }
                        else
                        {
                            currentFloor--;
                        }

                        Thread.Sleep(2000);
                        Console.WriteLine("At {0} floor, next floor: {1}", currentFloor, nextFloor);
                    }
                    Thread.Sleep(2000);
                    currentFloor = nextFloor;
                }
            }
        }
        public async Task AddFloorsAsync()
        {
            while(true)
            {
                string uinput = Console.ReadLine();
                int x = int.Parse(uinput);
                floorQueue.Add(x);
            }
        }
        public void AddPFR(PersonFloorRequest pfr)
        {
            if(!floorQueue.Contains(pfr.destinationFloor))
            {
                if(pfr.direction=="up")
                {
                    floorUp.Add(pfr.destinationFloor);
                }
                else
                {
                    floorDown.Add(pfr.destinationFloor);
                }
                //floorQueue.Add(pfr.destinationFloor);
            }
            
        }
        public async Task AddPFRAsync()
        {
            while(true)
            {
                string uinput = Console.ReadLine();
                int cur = int.Parse(uinput);
                uinput = Console.ReadLine();
                int dest = int.Parse(uinput);
                PersonFloorRequest pfr = new PersonFloorRequest(cur, dest);
                if (!floorQueue.Contains(pfr.destinationFloor))
                {
                    if (pfr.direction == "up")
                    {
                        floorUp.Add(pfr.destinationFloor);
                    }
                    else
                    {
                        floorDown.Add(pfr.destinationFloor);
                    }
                    //floorQueue.Add(pfr.destinationFloor);
                }
            }
        }
    }

}
