using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindCommic
{
    public class MainWindowViewModel
    {
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public MainWindowViewModel(string path)
        {
            foreach (var file in Directory.GetFiles(path).Select(f => new FileInfo(f)).ToList())
            {
                // [writer] title 第n巻.[zip|rar]
                Comics.Add(Comic.ConvertFromFile(file));
            }
        }
    }
}
