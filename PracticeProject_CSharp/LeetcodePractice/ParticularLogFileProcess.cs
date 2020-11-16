using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace LeetcodePractice
{
    public class ParticularLogFileProcess
    {
        private List<string> logs;

        public ParticularLogFileProcess()
        {
            logs = new List<string>();
        }

        public void Read()
        {
            string line;
            var folderPath = @"xxx\Desktop\log\Filter\Overdue\OverTime";

            foreach (string file in Directory.EnumerateFiles(folderPath, "*.log"))
            {
                var filteredLines = new List<string>();
                var contents = File.OpenText(file);
                var fileName = Path.GetFileName(file);

                while ((line = contents.ReadLine()) != null)
                {
                    logs.Add(line);                    
                    var rangeHigh = 10000.00;
                    var rangeLow = 3000.00;

                    if (line.Contains("--")
                           && line.Contains("LineID"))
                    {
                        filteredLines.Add(line);
                        continue;
                    }

                    if (line.Contains("--")
                        && line.Contains("Elapsed"))
                    {

                        string[] words = line.Split('|');
                        if (words.Length != 3 || !double.TryParse(words[1], out double ms))
                        {
                            continue;
                        }

                        if (ms > rangeLow)
                        {
                            filteredLines.Add(line);
                        }
                    }
                }
                contents.Close();
                Write(ProcessFile(logs), fileName);
                Write(filteredLines, fileName);
                logs = new List<string>();
            }
        }

        public void Write(List<string> lines, string name)
        {
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter($@"xxx\Desktop\log\Filter\Overdue\OverTime\Map\Mapped_{name}", true))
            {
                foreach(var line in lines)
                    file.WriteLine(line);
            }
        }

        public class LogInfo
        {
            public string Time { get; set; }
            public string Ori { get; set; }
            public string Line { get; set; }
            public string User { get; set; }
            public string So { get; set; }
        }


        public List<string> ProcessFile(List<string> logs)
        {
            var costLogs = logs.Where(log => log.Contains("Elapsed"));
            var timingLogs = logs.Where(log => !log.Contains("Elapsed"));
            var timing = new List<DateTime>();
            var mappedLogs = new List<string>();

            costLogs.ToList().ForEach(log =>
            {
                var words = log.Split('|');
                var splitForTime = log.Split(' ');
                var eventTime = splitForTime[0] + " " + splitForTime[1];

                if (DateTime.TryParse(eventTime, out DateTime date) 
                && double.TryParse(words[1], out double costTime))
                {
                    timing.Add(date.AddMilliseconds(-costTime));
                }
            });

            var logInfo = GetLogInfo(timingLogs.ToList());
            timing.ForEach(time =>
            {
                var find = logInfo.Find(info => time.Subtract(DateTime.TryParse(info.Time, out DateTime t)? t : DateTime.Now ).TotalMilliseconds < 150);
                if (find != null)
                {
                    mappedLogs.Add($"{find.Time} {find.Ori}");
                }
            });

            return mappedLogs.Union(costLogs).ToList();
        }

        public List<LogInfo> GetLogInfo(List<string>logs)
        {
            var logInfo = new List<LogInfo>();
            logs.ForEach(log =>
            {
                var pattern = @"\d{4}-\d{2}-\d{2} (?:[01]\d|2[0-3]):(?:[0-5]\d):(?:[0-5]\d).\d{4}";
                var match = Regex.Match(log, pattern);
                var eventTime = string.Empty;
                if(match.Success)
                {
                    eventTime = match.Value;
                }

                var splitForInfo = log.Split(',');
                var splitForTime = log.Split(' ');

                logInfo.Add(new LogInfo()
                {
                    Time = eventTime,
                    Ori = log
                });
            });

            return logInfo;
        }
    }
}
