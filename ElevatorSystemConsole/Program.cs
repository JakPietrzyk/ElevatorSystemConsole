using ElevatorSystemConsole;

namespace Program
{
    public class Program
    {
        static void Main(string[] args) 
        { 
            Elevator elevator = new Elevator();
            elevator.AddNewFloor(2);
            //elevator.AddNewFloor(4);
            //elevator.AddNewFloor(5);
            //elevator.AddNewFloor(3);


            var task = Task.Run(() =>
            {
                elevator.Run();
            });
            var task2 = Task.Run(() => { 
                elevator.AddFloorsConst(); 
            });

            elevator.AddNewFloor(5);
            task.Wait();
            Console.ReadLine();
            

        }
    }
}