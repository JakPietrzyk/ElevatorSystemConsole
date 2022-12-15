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
            }
            else
            {
                floorDown.Add(pfr.destinationFloor);
            }
            isEmpty = false;
        }
        public async Task GiveOrdersToElevator()
        {
            while(isEmpty == false)
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
                            floorUp.Clear();
                        }
                            
                    }
                    else if (elevators[i].direction == "up")
                    {
                        if (!elevators[i].floorQueue.Contains(floorUp.First()))
                        {
                            elevators[i].floorQueue.AddRange(floorUp);
                            //elevators[i].direction = "up";
                            elevators[i].isRunning = true;
                            floorUp.Clear();
                        }
                           
                    }
                    else if (elevators[i].direction == "down")
                    {
                        if (!elevators[i].floorQueue.Contains(floorDown.First()))
                        {
                            elevators[i].floorQueue.AddRange(floorDown);
                            //elevators[i].direction = "down";
                            elevators[i].isRunning = true;
                            floorUp.Clear();
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
