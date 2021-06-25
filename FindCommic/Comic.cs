using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindCommic
{
    public class Comic
    {
        public string Writer { get; set; }
        public string Name { get; set; }
        public int? StartNumber { get; set; }
        public int? EndNumber { get; set; }
        public string Extension { get; set; }

        public static Comic ConvertFromFile(FileInfo file)
        {
            var c = new Comic()
            {
                Name = MakeName(file.Name),
                Writer = MakeWriter(file.Name),
                Extension = file.Extension
            };
            MakeNumber(c, file.Name);
            return c;
        }

        private static string MakeName(string fileName)
        {
            var nameStartIndex = fileName.IndexOf("] ");
            var nameEndIndex = fileName.LastIndexOf(" ");
            if (nameStartIndex + 1 == nameEndIndex)
            {
                return fileName.Substring(nameStartIndex + 2);
            }
            return fileName.Substring(nameStartIndex + 2, nameEndIndex - nameStartIndex - 2);
        }

        private static string MakeWriter(string fileName)
        {
            var matchValue = new StringBuilder(Regex.Match(fileName, @"\[.*\]").Value);
            matchValue.Remove(0, 1);
            matchValue.Remove(matchValue.Length - 1, 1);
            return matchValue.ToString();
        }

        private static void MakeNumber(Comic c, string fileName)
        {
            var matchValue = new StringBuilder(Regex.Match(fileName, "第?[0-9]{2}-?[0-9]{2}?巻?s?b?\\.").Value);
            var replace = new[] { "第", "巻", ".", "s", "b" };
            replace.ToList().ForEach(r => matchValue = matchValue.Replace(r, string.Empty));

            if (matchValue.Length == 0)
            {
                return;
            }

            var numbers = matchValue.ToString();
            var splitted = numbers.Split('-', '～');
            if (splitted.Length > 1)
            {
                c.EndNumber = int.Parse(splitted[1]);
            }
            c.StartNumber = int.Parse(splitted[0]);
        }
    }
}
