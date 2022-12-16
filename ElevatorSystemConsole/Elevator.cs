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
        static int nextId;
        public int sleep = 250;

        public int Id { get; set; }
        public bool isRunning { get; set; }
        public string direction { get; set; }
        public int idleFloor { get; set; }
        public int currentFloor { get; set; }
        public int nextFloor { get; set; }
        public int maxFloor { get; set; }
        public int minFloor { get; set; }
        public List<int> floorQueue { get; set; }
        public List<PersonFloorRequest> floorRequests { get; set; }
        public List<int> floorUp { get; set; }
        public List<int> floorDown { get; set; }


        public Elevator() 
        {
            isRunning = false;
            maxFloor = 5;
            minFloor = 0;
            Id = Interlocked.Increment(ref nextId);
            currentFloor = 0;
            nextFloor = 0;
            floorQueue = new List<int>();
            floorRequests= new List<PersonFloorRequest>();
            floorUp = new List<int>();
            floorDown = new List<int>();
            if (Id % 2 != 0)
            {
                direction = "up";
                idleFloor = minFloor;
            }
            else
            {
                direction = "down";
                idleFloor = maxFloor; //max floor
            }
        }
        public void AddNewFloor(int floor)
        {
            floorQueue.Add(floor);
        }
        public void RemoveFloor(int floor) 
        {
            floorQueue.Remove(floor);
        }
        public async Task RunWithElevatorManager()
        {
            while (true)
            {
                if(direction == "up")
                {
                    while(floorQueue.Count>0)
                    {
                        nextFloor = floorQueue.First();
                        floorQueue.Remove(floorQueue.First());
                        Console.WriteLine("At {0} floor, next floor: {1} | direction {2}", currentFloor, nextFloor,direction);
                        while (currentFloor != nextFloor)
                        {
                            if (currentFloor > nextFloor)
                            {
                                currentFloor--;
                            }
                            else
                            {
                                currentFloor++;
                            }

                            Thread.Sleep(sleep);
                            Console.WriteLine("At {0} floor, next floor: {1} | direction {2}", currentFloor, nextFloor, direction);
                    }
                    Thread.Sleep(sleep);
                    if(floorQueue.Count==0)
                    {
                        direction = "down";
                    }
                        
                    }
                }

                if (direction == "down")
                {
                    while (floorQueue.Count > 0)
                    {
                        nextFloor = floorQueue.First();
                        floorQueue.Remove(floorQueue.First());
                        Console.WriteLine("At {0} floor, next floor: {1} | direction {2}", currentFloor, nextFloor, direction);
                        while (currentFloor != nextFloor)
                        {
                            if (currentFloor > nextFloor)
                            {
                                currentFloor--;
                            }
                            else
                            {
                                currentFloor++;
                            }

                            Thread.Sleep(sleep);
                            Console.WriteLine("At {0} floor, next floor: {1} | direction {2}", currentFloor, nextFloor, direction);
                        }
                        Thread.Sleep(sleep);
                        //currentFloor = nextFloor;
                        direction = "up";
                    }
                }
                //Thread.Sleep(sleep * 5);//winda powinna czekać aż dostanie nowa kolejke 
                //while (floorQueue.Count==0)
                //    {
                        
                //        isRunning= false;
                //        if(currentFloor!=nextFloor)
                //        {
                //            Console.WriteLine("Nothing to do going back to idle floor");
                //        }
                //        nextFloor = idleFloor;
                //        while(currentFloor!=nextFloor)
                //        {
                //            if(currentFloor>nextFloor)
                //            {
                //                currentFloor--;
                //            }
                //            else
                //            {
                //                currentFloor++;
                //            }
                //            Thread.Sleep(sleep);
                //            Console.WriteLine("At {0} floor, next floor: {1} | direction {2}", currentFloor, nextFloor, direction);
                //        }
                //    }
                ////}
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

                if(pfr.direction=="up")
                {
                    if(!floorUp.Contains(pfr.destinationFloor))
                    {
                        floorUp.Add(pfr.destinationFloor);
                    }
                    
                }
                else
                {
                    if(!floorDown.Contains(pfr.destinationFloor))
                    {
                        floorDown.Add(pfr.destinationFloor);
                    }
                    
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
                //if (!floorQueue.Contains(pfr.destinationFloor))
                //{
                //    if (pfr.direction == "up")
                //    {
                //        floorUp.Add(pfr.destinationFloor);
                //    }
                //    else
                //    {
                //        floorDown.Add(pfr.destinationFloor);
                //    }
                //    //floorQueue.Add(pfr.destinationFloor);
                //}

            }
        }








        public async Task InactiveRun()
        {
            while (true)
            {
                while (floorQueue.Count == 0 && currentFloor != 0)
                {
                    currentFloor--;
                    nextFloor = 0;
                    Console.WriteLine("Nothing to do At {0} floor, next floor: {1}", currentFloor, nextFloor);
                    Thread.Sleep(2000);
                }
                while (floorUp.Count > 0 && direction == "up")
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
                while (floorDown.Count > 0 && direction == "down")
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
        public void MakeStep()
        {

        }
    }

}
