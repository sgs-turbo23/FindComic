using System.Text;
using System.Text.RegularExpressions;

namespace FindComic.Model
{
    public class Comic
    {
        public string Writer { get; set; }
        public string Name { get; set; }
        public Range? RangeNumber { get; set; }
        public int? Number { get; set; }
        public string Extension { get; set; }

        public static Comic ConvertFromFileName(string fileName)
        {
            var c = new Comic()
            {
                Name = MakeName(fileName),
                Writer = MakeWriter(fileName),
                //Extension = fileExtension,
                Number = MakeNumber(fileName),
                RangeNumber = MakeNumberRange(fileName)
            };
            return c;
        }

        private static string MakeName(string fileName)
        {
            var nameStartIndex = fileName.IndexOf("] ");
            var nameEndIndex = fileName.LastIndexOf(" ");
            if (!Regex.Match(fileName, @"[0-9]{2}").Success)
            {
                nameEndIndex = fileName.LastIndexOf(".");
            }

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

        private static int? MakeNumber(string fileName)
        {
            var numberString = GetNumberString(fileName);
            
            if (numberString.Length == 0)
            {
                return null;
            }

            if (new[] { '-', '～' }.ToList().Any(c => numberString.Contains(c)))
            {
                return null;
            }

            return int.Parse(numberString);
        }

        private static Range? MakeNumberRange(string fileName)
        {
            var numberString = GetNumberString(fileName);

            if (numberString.Length == 0)
            {
                return null;
            }

            if (!new[] { '-', '～' }.ToList().Any(c => numberString.Contains(c)))
            {
                return null;
            }
            var splitted = numberString.Split('-', '～');
            return new Range(int.Parse(splitted[0]), int.Parse(splitted[1]));
        }

        private static string GetNumberString(string fileName)
        {
            var matchValue = new StringBuilder(Regex.Match(fileName, @"第?[0-9]{2}(巻|s|b|e|卷)*((-|～|-)第?[0-9]{2})?(巻|s|b|e|卷)* ?\.").Value);
            var replace = new[] { "第", "巻", ".", "s", "b", "e", "卷", " " };
            replace.ToList().ForEach(r => matchValue = matchValue.Replace(r, string.Empty));
            return matchValue.ToString();
        }
    }
}
