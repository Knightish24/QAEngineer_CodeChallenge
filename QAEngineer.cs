
// C# program to count frequencies of array items
using System;
using System.IO;

class QAEngineer
{
    public static void countFreq(int[] arr, int n, string pathName)
    {
        bool[] visited = new bool[n];
        int minCount = Int32.MaxValue;
        int minNumber = Int32.MaxValue;
        //Go through array and count frequencies
        for (int i = 0; i < n; i++)
        {
            // Skip this element if already processed
            if (visited[i] == true)
                continue;

            // Count frequency
            int count = 1;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[i] == arr[j])
                {
                    visited[j] = true;
                    count++;
                }
            }
            //Check if frequency is lower than minimum recorded frequency
            if (count < minCount)
            {
                minCount = count;
                minNumber = arr[i];
            }
            //if frequency is the same check for which number is smaller
            else if (minCount == count)
            {
                if (arr[i] < minNumber)
                {
                    minNumber = arr[i];
                }
            }
        }
        string[] fileSplit = pathName.Split("src\\");
        string fileName = fileSplit[fileSplit.Length - 1];
        Console.WriteLine("File:" + fileName + ", Number:" + minNumber + ", Repeated:" + minCount + " times");
    }

    // Add numbers to array
    public static void Main(String[] args)
    {
        //Get all files storeed at filePath
        Console.WriteLine("Type your file path:  ");
        String userInputtedPath = (Console.ReadLine());
        string[] filePaths = Directory.GetFiles(userInputtedPath);
        //string[] filePaths = Directory.GetFiles(@"E:\_Work Stuff\QAEngineerChallenge-master\src\");
        //Looping through all retrieved filePaths       
        foreach (string pathName in filePaths)
        {
            string[] arr = System.IO.File.ReadAllLines(pathName);
            int[] arr2 = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                arr2[i] = Int32.Parse(arr[i]);
            }

            int n = arr.Length;
            countFreq(arr2, n, pathName);
        }
    }
}