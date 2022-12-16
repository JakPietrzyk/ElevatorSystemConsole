using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorSystemConsole
{
    public class QueueManager
    {
        public List<PersonFloorRequest> peopleFloors { get; set; }
        public List<int> peopleFloorsInt { get; set; }



        public QueueManager() {
            peopleFloors = new();
            peopleFloorsInt = new();
        }
        private static int CompareDest(PersonFloorRequest x,PersonFloorRequest y)
        {
            if (x.destinationFloor > y.destinationFloor)
            {
                return 1;
            }
            else if (x.destinationFloor < y.destinationFloor)
            {
                return -1;
            }
            return 0;
        }

        public void AddSort(int cur, int dest)
        {
            peopleFloors.Add(new PersonFloorRequest(cur, dest));
            //peopleFloors.Sort(CompareDest);
        }


        public void AddSortTuple(int cur, int dest)
        {
            peopleFloorsInt.Add(cur);
            peopleFloorsInt.Add(dest);
            peopleFloorsInt.Sort();
        }
    }
}
