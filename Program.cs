using System;

namespace Mandelbrot
{
    /// <summary>
    /// This class generates Mandelbrot sets in the console window!
    /// </summary>


    class Class1
    {
        /// <summary>
        /// This is the Main() method for Class1 -
        /// this is where we call the Mandelbrot generator!
        /// </summary>
        /// <param name="args">
        /// The args parameter is used to read in
        /// arguments passed from the console window
        /// </param>

        [STAThread]
        static void Main(string[] args)
        {
            double startImagePoint = 0;
            double endImagePoint = 0;
            double startRealPoint = 0;
            double endRealPoint = 0;
            
            do
            {
                // Prompt the user for the begining image number
                Console.WriteLine("Please enter a value for the start image size\nThis value must be larger than the ending image value\nA recomended size is 1.2");
                // If the user didnt enter a number ask again
            } while (!Double.TryParse(Console.ReadLine(), out startImagePoint));
            do
            {
                // Prompt the user for the ending image number
                Console.WriteLine("Please enter a value for the end image size\nThis value must be smaller than the starting image value\nA recomended size is -1.2");
                // If the user didnt enter a number ask again
            } while (!(Double.TryParse(Console.ReadLine(), out endImagePoint) && (endImagePoint < startImagePoint)));
            do
            {
                // Prompt the user for the starting real number
                Console.WriteLine("Please enter a value for the start real size\nThis value mist be larger than the ending real point value\nA recomended size is -0.6");
                // If the user didnt enter a number ask again
            } while (!Double.TryParse(Console.ReadLine(), out startRealPoint));
            do
            {
                // Prompt the user for the ending real number
                Console.WriteLine("Please enter a value for the end real size\nThis Value must be smaller than the starting real point value\nA recomended size is 1.77");
                // If the user didnt enter a number ask again
            } while (!(Double.TryParse(Console.ReadLine(), out endRealPoint) && (endRealPoint > startRealPoint)));
            // Find the image scale
            double imageIncrament = (Math.Abs(startImagePoint) + Math.Abs(endImagePoint)) / 48;
            // Find the real scale
            double realIncrament = (Math.Abs(startRealPoint) + Math.Abs(endRealPoint)) / 80;
            // Display the Mandelbrot
            DisplayAMandelbrot(startImagePoint, endImagePoint, startRealPoint, endRealPoint, imageIncrament, realIncrament);
        }
        static void DisplayAMandelbrot(double startImagePoint, double endImagePoint, double startRealPoint, double endRealPoint, double imageIncrament, double realIncrament)
        {
            double realCoord, imagCoord;
            double realTemp, imagTemp, realTemp2, arg;
            int iterations;
            for (imagCoord = startImagePoint; imagCoord >= endImagePoint; imagCoord -= imageIncrament)
            {
                for (realCoord = startRealPoint; realCoord <= endRealPoint; realCoord += realIncrament)
                {
                    iterations = 0;
                    realTemp = realCoord;
                    imagTemp = imagCoord;
                    arg = (realCoord * realCoord) + (imagCoord * imagCoord);
                    while ((arg < 4) && (iterations < 40))
                    {
                        realTemp2 = (realTemp * realTemp) - (imagTemp * imagTemp)
                           - realCoord;
                        imagTemp = (2 * realTemp * imagTemp) - imagCoord;
                        realTemp = realTemp2;
                        arg = (realTemp * realTemp) + (imagTemp * imagTemp);
                        iterations += 1;
                    }
                    switch (iterations % 4)
                    {
                        case 0:
                            Console.Write(".");
                            break;
                        case 1:
                            Console.Write("o");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        case 3:
                            Console.Write("@");
                            break;
                    }
                }
                Console.Write("\n");
            }
        }
    }
}
