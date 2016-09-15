using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using csvConvertor;
using CsvHelper;

namespace csvConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            ToCsv toCsv = new ToCsv();
            WriteCsv writeCsv = new WriteCsv();

            using (var streamReader = new StreamReader(@"C:\Users\NadeeshaN\Documents\CSV Converter\csvConverter\test2.csv"))
            {
                using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\NadeeshaN\Documents\CSV Converter\csvConverter\testOut2.csv"))
                {
                    var writer = new CsvWriter(streamWriter);

                    writer.WriteHeader<ToCsv>();                  

                }

                var reader = new CsvReader(streamReader);
                IEnumerable<FromCsv> records = reader.GetRecords<FromCsv>();

                foreach (FromCsv record in records)
                {
                    if (record.Target.Contains("Id") || record.Target.Contains("CssSelector"))
                    {
                        string _selector= "";   

                        Match TargetSelector = Regex.Match(record.Target, @"\.(.*?)\(");
                        string targetSelector = TargetSelector.ToString().Substring(1, TargetSelector.ToString().Length - 2);

                        Match SelectorValue = Regex.Match(record.Target, "\".*?\"");
                        string selectorValue = SelectorValue.ToString().Substring(1, SelectorValue.ToString().Length - 2);

                        switch (targetSelector)
                        {
                            case "Id":
                                _selector = "id";
                                break;

                            case "CssSelector":
                                _selector = "css";
                                break;       
                              
                        }
                        
                        writeCsv.writeToCsv(record.Action, _selector, selectorValue, record.Value);
                        
                    }
                    else
                    {
                        writeCsv.writeToCsv(record.Action, record.Target, "" , record.Value);                        

                    }                   
                }
            }

            Console.WriteLine("Successfully Converted...");
            Console.ReadKey();
        }
    }
}
