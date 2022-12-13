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
        public int currentFloor;
        public int nextFloor;
        public List<int> floorQueue;
        public Elevator() 
        {
            currentFloor = 0;
            nextFloor = 0;
            floorQueue = new List<int>();
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
                    Console.WriteLine("At {0} floor, next floor: {1}", currentFloor, nextFloor);
                    Thread.Sleep(2000);
                }
            }
        }
        public async Task AddFloorsConst()
        {
            while(true)
            {
                string uinput = Console.ReadLine();
                int x = int.Parse(uinput);
                floorQueue.Add(x);
            }
        }
    }

}
