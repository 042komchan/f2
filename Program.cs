using System;

class Program
{
    static void Main(string[] args)
    {
        // Accept user inputs
        Console.Write("Enter the capacity of the water tank (in liters): ");
        double capacity = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the average volume of water consumed during each break (in liters): ");
        double averageVolumePerBreak = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the volume of water added in each refill cycle (in liters): ");
        double volumePerRefillCycle = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter the duration between breaks (in minutes): ");
        int intervalBetweenBreaks = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter the total duration of the activity from start to finish of the day (in hours): ");
        int totalActivityDuration = Convert.ToInt32(Console.ReadLine());

        // Convert totalActivityDuration to minutes
        totalActivityDuration *= 60;

        // Calculate the number of breaks and refill cycles
        int numberOfBreaks = totalActivityDuration / intervalBetweenBreaks;
        int numberOfRefillCycles = numberOfBreaks - 1;

        // Calculate the total volume of water consumed and added
        double totalWaterConsumed = numberOfBreaks * averageVolumePerBreak;
        double totalWaterAdded = numberOfRefillCycles * volumePerRefillCycle;

        // Calculate the remaining water in the tank
        double remainingWater = capacity - totalWaterConsumed;

        // Check if the remaining water exceeds the capacity
        if (remainingWater > capacity)
        {
            remainingWater = capacity;
        }

        // Check if the refill cycle coincides with a water break
        if (totalActivityDuration % intervalBetweenBreaks == 0)
        {
            remainingWater += volumePerRefillCycle;

            // Check if the remaining water exceeds the capacity
            if (remainingWater > capacity)
            {
                remainingWater = capacity;
            }
        }

        // Check if there is enough water for the participants throughout the event
        if (remainingWater >= totalWaterConsumed)
        {
            Console.WriteLine("Enough Water, {0} liters left", remainingWater.ToString("F2"));
        }
        else
        {
            Console.WriteLine("Not Enough Water");
        }

        // Check if there is an overflow during the refill cycle
        if (remainingWater + totalWaterAdded > capacity)
        {
            Console.WriteLine("Overflow Water");
        }
    }
}
