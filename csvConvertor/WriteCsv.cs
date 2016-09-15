using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;

namespace csvConvertor
{
    class WriteCsv
    {
        public void writeToCsv(string Action, string _selector, string selectorValue, string Value)
        {
            ToCsv toCsv = new ToCsv();

            toCsv.Command = Action;
            toCsv.Selector = _selector;
            toCsv.SelectorValue = selectorValue;
            toCsv.Value = Value;

            using (StreamWriter streamWriter = new StreamWriter(@"C:\Users\NadeeshaN\Documents\CSV Converter\csvConverter\testOut2.csv", true))
            {
                var writer = new CsvWriter(streamWriter);

                //writer.WriteHeader<ToCsv>();
                writer.WriteField(toCsv.Command);
                writer.WriteField(toCsv.Selector);
                writer.WriteField(toCsv.SelectorValue);
                writer.WriteField(toCsv.Value);

                writer.NextRecord();
            }
        }
    }
}
