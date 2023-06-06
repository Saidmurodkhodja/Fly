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

            Bird bird = new Bird(initialPosition, 13560);
            bird.FlyTo(new Coordinate { X = 100, Y = 100, Z = 100 });

            Airplane airplane = new Airplane(initialPosition);
            airplane.FlyTo(new Coordinate { X = 500, Y = 500, Z = 500 });

            Drone drone = new Drone(initialPosition, 1000, 10);
            drone.FlyTo(new Coordinate { X = 200, Y = 200, Z = 200 });
        }
    }
}
