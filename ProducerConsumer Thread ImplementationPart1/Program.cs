using System;

//ref link:https://www.youtube.com/watch?v=6XV7o2VsMiI&list=PLRwVmtr-pp06KcX24ycbC-KkmAISAFKV5&index=12
//

class MainClass
{
    static Queue<int> numbers = new Queue<int>(); // Queue Structure -- requires knowledge in data structures
    static Random rand = new Random();
    const int NumThreads = 3;
    static int[] sums = new int[NumThreads];
    static void ProduceNumbers()
    {
        for (int i = 0; i < 10; i++)
        {
            numbers.Enqueue(rand.Next(10));
            Thread.Sleep(rand.Next(1000));
        }
    }
    static void SumNumbers(object threadNumber)   // Consuming Method
    {   //---------poorman's method of synchronization technique---------- needs improvements
        DateTime startTime = DateTime.Now;
        int mySum = 0;
        while((DateTime.Now - startTime).Seconds < 11)
        {
            if(numbers.Count != 0)
            {
                mySum += numbers.Dequeue();
            }
        }
        sums[(int)threadNumber] = mySum;
    }
    static void Main()
    {

    }
}