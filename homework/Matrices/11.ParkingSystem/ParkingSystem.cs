using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ParkingSystem
{
    class ParkingSystem
    {
        static void Main(string[] args)
        {
            List<string> steps = new List<string>();
            string[] inputDimensions = Console.ReadLine().Split(' ');
            int[] matrixDimensions = new int[2];
            for (int i = 0; i < inputDimensions.Length; i++)
            {
                matrixDimensions[i] = int.Parse(inputDimensions[i]);
            }

            Dictionary<int, HashSet<int>> parkingMatrix = new Dictionary<int, HashSet<int>>();
            for (int i = 0; i < matrixDimensions[0]; i++)
            {
                parkingMatrix.Add(i, new HashSet<int>());
            }

            string inputLine = Console.ReadLine();
            while (!inputLine.Equals("stop"))
            {
                string[] indexes = inputLine.Split(' ');
                int enteringRow = int.Parse(indexes[0]);
                int desiredRow = int.Parse(indexes[1]);
                int desiredCol = int.Parse(indexes[2]);

                bool hasParked = false;

                int initialSteps = 1 + Math.Abs(desiredRow - enteringRow) + desiredCol;
                int currentSteps = initialSteps;
                int finalCol = -1;

                if (parkingMatrix[desiredRow].Contains(desiredCol))
                {
                    for (int i = desiredCol - 1; i >= 1; i--)
                    {
                        if (!parkingMatrix[desiredRow].Contains(i))
                        {
                            finalCol = i;
                            currentSteps = initialSteps - (desiredCol - i);
                            hasParked = true;
                            break;
                        }
                    }

                    if (hasParked)
                    {
                        int distanceTraveled = desiredCol + (desiredCol - finalCol);
                        if (distanceTraveled >= matrixDimensions[1])
                        {
                            distanceTraveled = matrixDimensions[1];
                        }
                        for (int i = desiredCol + 1; i < distanceTraveled; i++)
                        {
                            if (!parkingMatrix[desiredRow].Contains(i))
                            {
                                finalCol = i;
                                currentSteps = initialSteps + (i - desiredCol);
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = desiredCol + 1; i < matrixDimensions[1]; i++)
                        {
                            if (!parkingMatrix[desiredRow].Contains(i))
                            {
                                finalCol = i;
                                currentSteps = initialSteps + (i - desiredCol);
                                hasParked = true;
                                break;
                            }
                        }
                    }
                }
                else
                {
                    finalCol = desiredCol;
                    hasParked = true;
                }

                if (hasParked)
                {
                    parkingMatrix[desiredRow].Add(finalCol);
                    steps.Add(currentSteps.ToString());
                }
                else
                {
                    steps.Add(string.Format($"Row {desiredRow} full"));
                }

                inputLine = Console.ReadLine();
            }

            Console.WriteLine(string.Join("\n", steps));
        }
    }
}

//4 4
//1 2 2
//2 2 2
//2 2 2
//3 2 2
//stop
