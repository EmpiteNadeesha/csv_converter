using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace csvConverter
{
    class Class1
    {
        public void test()
        {
            try
            {
                using (StreamReader streamReader = new StreamReader(@"C:\Users\NadeeshaN\Documents\CSV Converter\csvConvertor\test.csv"))
                {
                    string line;

                    while ((line = streamReader.ReadLine()) != null)
                    {
                        string[] lineArray = line.Split(',');

                        if (lineArray[1].Contains("Id") || lineArray[1].Contains("CssSelector"))
                        {
                            Match match = Regex.Match(lineArray[1], "\"\".*?\"\"");

                            string matchString = Convert.ToString(match);
                            string[] wordArray = matchString.Split('"');

                            string _2ndValue = "";

                            if (lineArray[1].Contains("Id"))
                            {
                                _2ndValue = "id";
                            }
                            else if (lineArray[1].Contains("CssSelector"))
                            {
                                _2ndValue = "css";
                            }

                            string[] newLineArray = { lineArray[0], _2ndValue, wordArray[2], lineArray[2] };

                            using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\NadeeshaN\Documents\CSV Converter\csvConvertor\testOut.csv", true))
                            {
                                foreach (string item in newLineArray)
                                {
                                    streamWriter.Write(item + ",");
                                }
                                streamWriter.WriteLine();
                            }
                        }
                        else
                        {
                            using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\NadeeshaN\Documents\CSV Converter\csvConvertor\testOut.csv", true))
                            {
                                streamWriter.WriteLine(line);
                            }
                        }

                    }
                }

                Console.WriteLine("Successfully Converted...");
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
            }

            Console.ReadKey();
        }
    }
}
