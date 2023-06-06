using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class Bird : IFlyable
    {
        public Coordinate CurrentPosition { get; private set; }
        private double maxDistance;
        private double maxSpeed;

        public Bird(Coordinate initialPosition, double maxDistance)
        {
            CurrentPosition = initialPosition;
            this.maxDistance = maxDistance;
            Random random = new Random();
            maxSpeed = random.Next(0, 21); // Random speed between 0 and 20 km/h
        }

        public void FlyTo(Coordinate newPosition)
        {
            // Check if distance is within bird's maximum range
            double distance = CalculateDistance(CurrentPosition, newPosition);
            if (distance > maxDistance)
            {
                Console.WriteLine("The bird cannot fly that far.");
                return;
            }

            double flyTime = distance / maxSpeed;
            Console.WriteLine($"Flying to new position of a bird: {newPosition.X}, {newPosition.Y}, {newPosition.Z}");
            Console.WriteLine($"Estimated fly time of a bird: {Math.Round(flyTime, 2)} hours"); // rounds up results to 2 decimals
            CurrentPosition = newPosition;
        }

        public double GetFlyTime(Coordinate newPosition)
        {
            double distance = CalculateDistance(CurrentPosition, newPosition);
            return distance / maxSpeed;
        }
        // Calculate the Euclidean distance between two points in 3D space
        private double CalculateDistance(Coordinate from, Coordinate to)
        {
            double deltaX = to.X - from.X;
            double deltaY = to.Y - from.Y;
            double deltaZ = to.Z - from.Z;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }
    }

}

