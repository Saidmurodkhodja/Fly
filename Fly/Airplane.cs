using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fly
{
    public class Airplane : IFlyable
    {
        public Coordinate CurrentPosition { get; private set; }
        private double currentSpeed;

        public Airplane(Coordinate initialPosition)
        {
            CurrentPosition = initialPosition;
            currentSpeed = 200; // Initial speed of 200 km/h
        }

        public void FlyTo(Coordinate newPosition)
        {
            double distance = CalculateDistance(CurrentPosition, newPosition);

            // Check if airplane can reach the destination, the airplane can not go faster than 1020 km/h
            if (distance > (1020 - currentSpeed) * 10)
            {
                Console.WriteLine("The airplane cannot reach that destination.");
                return;
            }

            double flyTime = 0;
            double remainingDistance = distance;
            while (remainingDistance > 0)
            {
                double timeToAccelerate = (1020 - currentSpeed) / 10; // Time to increase speed by 10 km/h
                if (timeToAccelerate >= remainingDistance / currentSpeed)
                {
                    // Reached maximum speed before reaching the destination
                    flyTime += remainingDistance / currentSpeed;
                    break;
                }
                else
                {
                    // Reached maximum speed during the flight segment
                    flyTime += timeToAccelerate;
                    currentSpeed += 10;
                    remainingDistance -= currentSpeed * timeToAccelerate;
                }
            }

            Console.WriteLine($"Flying to new position of an airplane: {newPosition.X}, {newPosition.Y}, {newPosition.Z}");
            Console.WriteLine($"Estimated fly time: {Math.Round(flyTime, 2)} hours");
            CurrentPosition = newPosition;
        }

        public double GetFlyTime(Coordinate newPosition)
        {
            double distance = CalculateDistance(CurrentPosition, newPosition);

            // Check if airplane can reach the destination
            if (distance > (1020 - currentSpeed) * 10)
            {
                Console.WriteLine("The airplane cannot reach that destination.");
                return 0;
            }

            double flyTime = 0;
            double remainingDistance = distance;
            while (remainingDistance > 0)
            {
                double timeToAccelerate = (1020 - currentSpeed) / 10; // Time to increase speed by 10 km/h
                if (timeToAccelerate >= remainingDistance / currentSpeed)
                {
                    // Reached maximum speed before reaching the destination
                    flyTime += remainingDistance / currentSpeed;
                    break;
                }
                else
                {
                    // Reached maximum speed during the flight segment
                    flyTime += timeToAccelerate;
                    currentSpeed += 10;
                    remainingDistance -= currentSpeed * timeToAccelerate;
                }
            }

            return flyTime;
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
