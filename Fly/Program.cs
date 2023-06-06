using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public struct Coordinate
    {
        public double X {  get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

    }
    public class Program
    {

        static void Main(string[] args)
        {
            Coordinate initialPosition = new Coordinate { X = 0, Y = 0, Z = 0 };

            Bird bird = new Bird(initialPosition, 13560); // the longest flight in history was 13560 km
            bird.FlyTo(new Coordinate { X = 100, Y = 100, Z = 100 }); // Flying to random place

            Airplane airplane = new Airplane(initialPosition);
            airplane.FlyTo(new Coordinate { X = 500, Y = 500, Z = 500 }); // Flying to random place

            Drone drone = new Drone(initialPosition, 1000, 10); // according to task drone can not exceed 1000 km
            drone.FlyTo(new Coordinate { X = 1000, Y = 1000, Z = 1000 });
        }
    }
}
