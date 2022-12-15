using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystemConsole
{
    public class PersonFloorRequest
    {
        public int currentFloor { get; set; }
        public int destinationFloor { get; set; }
        public string direction { get; set; }


        public PersonFloorRequest(int cur,int dest)
        {
            currentFloor = cur;
            destinationFloor = dest;
            if(cur>dest)
            {
                direction = "down";
            }
            else
            {
                direction = "up";
            }
        }

        public void AddAndSortRequests(int cur,int dest)
        {

        }
    }
}
