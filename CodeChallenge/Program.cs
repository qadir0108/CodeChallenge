using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeChallenge
{
    class Program
    {
        static void Main(string[] args)
        { 
            int Max = (int)Math.Floor((double)(Int32.MaxValue / 1000));
            string InputFile = args.Length > 0 ? args[0] : @"Data.txt";
            string OutputFile1 = @"Cities_By_Population.txt", OutputFile2 = @"Interstates_By_City.txt";

            string[] InputLines = new string[Max];
            List<DataLine> InputData = new List<DataLine>();

            // Read All lines and Parse to input data list
            InputLines = File.ReadAllLines(InputFile);
            Parallel.For(0, InputLines.Length, x =>
            {
                InputData.Add(DataLine.ReadLine(InputLines[x]));
            });

            GC.Collect();

            #region Output 1
            // Output1 - Processing
            string[] OutputData1 = new string[InputLines.Length];
            Parallel.For(0, InputLines.Length, x =>
            {
                OutputData1[x] = DataLine.WriteLine(InputData[x]);
            });

            // Output1 - Writing
            File.WriteAllLines(OutputFile1, OutputData1);
            Console.WriteLine("OutputFile1 Generated Successfully!");
            GC.Collect();
            #endregion

            #region Output 2
            // Output2 - Processing & Writing
            File.WriteAllLines(OutputFile2, ProcessOutput2(InputData));
            Console.WriteLine("OutputFile2 Generated Successfully!");
            GC.Collect();
            #endregion

            Console.ReadKey();
        }

        private static IEnumerable<string> ProcessOutput2(List<DataLine> InputData)
        {
            Dictionary<string, int> InterStateNumberOfCities = new Dictionary<string, int>();
            foreach (var interstates in InputData.Select(x => x.Interstates))
            {
                foreach (var interstate in interstates)
                {
                    if (InterStateNumberOfCities.ContainsKey(interstate))
                    {
                        InterStateNumberOfCities[interstate]++;
                    }
                    else
                        InterStateNumberOfCities.Add(interstate, 1);
                }
            }

            var InterStateNumberOfCitiesOrdered = InterStateNumberOfCities.OrderBy(x => Int32.Parse(x.Key.Substring(2)));
            return InterStateNumberOfCitiesOrdered.Select(x => x.Key + "\t" + x.Value);
        }

    } // End Main

    public class DataLine {

        public int Population { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public List<string> Interstates { get; set; }

        public static DataLine ReadLine(string line)
        {
            string[] RowData = line.Split("|".ToCharArray());
            return new DataLine()
            {
                Population = int.Parse(RowData[0]),
                City = RowData[1],
                State = RowData[2],
                Interstates = RowData[3].Split(";".ToCharArray()).ToList()
            };
        }

        public static string WriteLine(DataLine line)
        {
            line.Interstates.Sort();
            return line.Population 
                 + Environment.NewLine 
                 + line.City + "," + line.State
                 + Environment.NewLine
                 + string.Join(";",line.Interstates);
        }
    }
}
