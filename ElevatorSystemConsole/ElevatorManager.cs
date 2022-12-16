using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystemConsole
{
    public class ElevatorManager
    {
        public List<Elevator> elevators { get; set; }

        public List<int> floorUp { get; set; }
        public List<int> floorDown { get; set; }
        public bool isEmpty { get; set; }

        public ElevatorManager(int number) 
        {
            elevators = new();
            for (int i = 0; i < number; i++)
            {
                elevators.Add(new Elevator());
            }
            floorUp = new();
            floorDown = new();
            isEmpty = true;
        }
        public void AddFloor(PersonFloorRequest pfr)
        {
            if(pfr.direction=="up")
            {
                floorUp.Add(pfr.destinationFloor);
                floorUp.Add(pfr.currentFloor);
                floorUp.Sort();
            }
            else
            {
                floorDown.Add(pfr.destinationFloor);
                floorDown.Add(pfr.currentFloor);
                floorDown.Sort();
                floorDown.Reverse();
            }
            isEmpty = false;
        }
        public async Task AddRequestAsync()
        {
            while (true)
            {
                string uinput = Console.ReadLine();
                int cur = int.Parse(uinput);
                uinput = Console.ReadLine();
                int dest = int.Parse(uinput);
                PersonFloorRequest pfr = new PersonFloorRequest(cur, dest);
                AddFloor(pfr);

            }
        }



        public void AddFloorInt(int floor)
        {

        }
        public async Task GiveOrdersToElevator()
        {
            //while(isEmpty == false)
            while(true)
            {

                //można sprawdzać czy floorQueue jest puste czy nie i w oparciu o to dodawać zadania
                //trzeba sprawdzać, czy piętra zostały już dodane do kolejki bo pojawia się 60 000 000 zapytań
                for (int i = 0; i < elevators.Count; i++)
                {
                    if (elevators[i].isRunning == false && elevators[i].idleFloor == elevators[i].minFloor )
                    {
                        if (!elevators[i].floorQueue.Contains(floorUp.First()))
                        {
                            elevators[i].floorQueue.AddRange(floorUp);
                            elevators[i].direction = "up";
                            elevators[i].isRunning = true;
                            floorUp.Clear();
                        }
                        
                    }
                    else if (elevators[i].isRunning == false && elevators[i].idleFloor == elevators[i].maxFloor)
                    {
                        if (!elevators[i].floorQueue.Contains(floorDown.First()))
                        {
                            elevators[i].floorQueue.AddRange(floorDown);
                            elevators[i].direction = "down";
                            elevators[i].isRunning = true;
                            floorDown.Clear();
                        }
                            
                    }
                    else if (elevators[i].direction == "up" && floorUp.Count>0)
                    {
                        if (!elevators[i].floorQueue.Contains(floorUp.First()))
                        {
                            elevators[i].floorQueue.AddRange(floorUp);
                            //elevators[i].direction = "up";
                            elevators[i].isRunning = true;
                            floorUp.Clear();
                        }
                           
                    }
                    else if (elevators[i].direction == "down" && floorDown.Count>0)
                    {
                        if (!elevators[i].floorQueue.Contains(floorDown.First()))
                        {
                            elevators[i].floorQueue.AddRange(floorDown);
                            //elevators[i].direction = "down";
                            elevators[i].isRunning = true;
                            floorDown.Clear();
                        }
                            
                    }
                    if (floorUp.Count == 0 && floorDown.Count == 0)
                    {
                        isEmpty = true;
                    }
                }

            }
        }
        

    }
}
