using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FileLogger : ILogWriter, ILogReader
    {
        private const string _filePath = "Logs.txt";

        public void Log(string message)
        {
            using (var writer = File.AppendText(_filePath))
            {
                writer.WriteLine(message);
            }
        }

        public IEnumerable<string> GetLogs()
        {
            using (var reader = File.OpenText(_filePath))
            {
                while (!reader.EndOfStream)
                    yield return reader.ReadLine();
            }
        }
    }
}
