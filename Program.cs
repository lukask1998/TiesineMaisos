namespace TiesineMaisos
{
    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {

            String[] text = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven" };

            HashTable hs = new HashTable();

            InsertText(hs, text);
            hs.print();

            //SpeedTest();
        }

        //private static void SpeedTest()
        //{
        //    Stopwatch stopWatch = new Stopwatch();

        //    HashTable hs;

        //    int seed = (int)DateTime.Now.Ticks & 0x0000FFFF;

        //    int[] numbers = { 100000 };

        //    Console.WriteLine("LINEAR PROBING HASH TABLE RETRIEVE");
        //    Console.WriteLine("|---------------------------|");
        //    Console.WriteLine("|  N          |  Run time   |");
        //    Console.WriteLine("|---------------------------|");
        //    foreach (int number in numbers)
        //    {
        //        //speed test for array
        //        hs = new HashTable();
        //        for (int i = 0; i < number; i++)
        //        {
        //            hs.insert(i, RandomString(5)); //inserting randomly generated string of '5' characters
        //        }

        //        stopWatch.Start();
        //        for (int i = 0; i < number; i++)
        //        {
        //            hs.retrieve(i);
        //        }
        //        stopWatch.Stop();

        //        Console.WriteLine("|  {0,-9}  |  {1}  |", number,
        //            stopWatch.Elapsed);

        //        //reseting stop watch
        //        stopWatch.Reset();
        //    }
        //    Console.WriteLine("|---------------------------|\n");
        //}

        private static void InsertText(HashTable hs, string[] text)
        {

            for (int i = 0; i < text.Length; i++)
            {

                hs.insert(i, text[i]);

            }

        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
