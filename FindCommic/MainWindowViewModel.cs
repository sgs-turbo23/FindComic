using FindComic.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindComic
{
    public class MainWindowViewModel
    {
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public List<ViewSummaryComic> ViewSummaryComics { get; set; } = new List<ViewSummaryComic>();

        public MainWindowViewModel(string path)
        {
            foreach (var file in Directory.GetFiles(path).Select(f => new FileInfo(f)).ToList())
            {
                // [writer] title 第n巻.[zip|rar]
                Comics.Add(Comic.ConvertFromFileName(file.Name));
            }

            foreach (var group in Comics.GroupBy(c => new { c.Name, c.Writer }))
            {
                ViewSummaryComics.Add(new ViewSummaryComic(
                    group.Key.Writer, 
                    group.Key.Name, 
                    group.Where(g => g.RangeNumber.HasValue).Select(g => g.RangeNumber.Value).ToList(), 
                    group.Where(g => g.Number.HasValue).Select(g => g.Number.Value).ToList()));
            }
            ViewSummaryComics.OrderBy(vsc => vsc.Writer);
        }

        //public List<>

        public class ViewSummaryComic
        {
            public string Writer { get; set; }
            public string Title { get; set; }
            //public string Numbering { get; set; }

            public int LastNumber { get; set; }

            public string LostNumber { get; set; }

            public ViewSummaryComic(string writer, string title, List<Range> ranges, List<int> numbers)
            {
                this.Writer = writer;
                this.Title = title;

                if (!ranges.Any() && !numbers.Any()) return;

                var completeNumber = new List<int>(numbers);
                foreach (var range in ranges)
                {
                    completeNumber.AddRange(Enumerable.Range(range.Start.Value, range.End.Value - range.Start.Value + 1));
                }
                var ordered = completeNumber.OrderBy(x => x).ToList();
                LastNumber = ordered.Max();
                LostNumber = string.Join(",", Enumerable.Range(1, ordered.Max()).Except(ordered));
            }
        }

        public string Status { get { return $"ファイル数:{Comics.Count().ToString()}"; } }
    }
}
