using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class Drone : IFlyable
    {
        public Coordinate CurrentPosition { get; private set; }
        private double maxDistance;
        private double maxFlightTime;
        private double hoverTime = 1; // Time the drone hovers in minutes
        private double hoverInterval = 10; // Interval between hover periods in minutes

        public Drone(Coordinate initialPosition, double maxDistance, double maxFlightTime)
        {
            CurrentPosition = initialPosition;
            this.maxDistance = maxDistance;
            this.maxFlightTime = maxFlightTime;
        }

        public void FlyTo(Coordinate newPosition)
        {
            double distance = CalculateDistance(CurrentPosition, newPosition);

            // Check if distance is within drone's maximum range
            if (distance > maxDistance || distance > 1000)
            {
                Console.WriteLine("The drone cannot fly that far.");
                return;
            }

            double flyTime = CalculateFlyTime(distance);
            Console.WriteLine($"Flying to new position of a drone: {newPosition.X}, {newPosition.Y}, {newPosition.Z}");
            Console.WriteLine($"Estimated fly time of a drone: {Math.Ceiling(flyTime)} minutes");
            CurrentPosition = newPosition;
        }

        public double GetFlyTime(Coordinate newPosition)
        {
            double distance = CalculateDistance(CurrentPosition, newPosition);

            // Check if distance is within drone's maximum range
            if (distance > maxDistance || distance > 1000)
            {
                Console.WriteLine("The drone cannot fly that far.");
                return 0;
            }

            return CalculateFlyTime(distance);
        }

        private double CalculateFlyTime(double distance)
        {
            double flyTime = 0;
            double remainingDistance = distance;
            while (remainingDistance > 0)
            {
                if (remainingDistance <= maxFlightTime)
                {
                    // Reached the destination without hovering
                    flyTime += remainingDistance;
                    break;
                }
                else
                {
                    // Reached maximum flight time before reaching the destination
                    flyTime += maxFlightTime;
                    remainingDistance -= maxFlightTime;
                    flyTime += hoverTime; // Hovering time
                    remainingDistance -= hoverInterval;
                }
            }

            return flyTime;
        }

        private double CalculateDistance(Coordinate from, Coordinate to)
        {
            double deltaX = to.X - from.X;
            double deltaY = to.Y - from.Y;
            double deltaZ = to.Z - from.Z;
            return Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        }

    }
}
