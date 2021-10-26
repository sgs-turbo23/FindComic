using FindComic.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FindComic
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged実装

        /// <summary>
        /// プロパティ変更時ハンドラー
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティ変更イベントを発火します
        /// </summary>
        /// <param name="propertyName"></param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null) return;

            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="path">情報を収集するディレクトリ</param>
        public MainWindowViewModel(string path)
        {
            var comics = new List<Comic>();

            foreach (var file in Directory.GetFiles(path).Select(f => new FileInfo(f)).ToList())
            {
                comics.Add(Comic.ConvertFromFileName(file.Name));
            }

            foreach (var group in comics.GroupBy(c => new { c.Name, c.Writer }))
            {
                originSummaryComics.Add(new ViewSummaryComic(
                    group.Key.Writer,
                    group.Key.Name,
                    group.Where(g => g.RangeNumber.HasValue).Select(g => g.RangeNumber.Value).ToList(),
                    group.Where(g => g.Number.HasValue).Select(g => g.Number.Value).ToList()));
            }

            // origin~ は全件の内容を保持する
            originSummaryComics = originSummaryComics.OrderBy(vsc => vsc.Writer).ToList();
        }

        #region メンバー
        /// <summary>
        /// 初期値保持用
        /// </summary>
        private List<ViewSummaryComic> originSummaryComics { get; set; } = new List<ViewSummaryComic>();

        /// <summary>
        /// 画面表示用（インクリメンタルサーチ用）
        /// Modelに値を渡すものはpublic
        /// </summary>
        public List<ViewSummaryComic> ViewSummaryComics 
        { 
            get
            {
                return originSummaryComics.Where(x => x.Title.Contains(_SearchValue)).ToList();
            }
        }
        #endregion

        #region バインドプロパティ

        private string _SearchValue = string.Empty;
        public string SearchValue 
        {
            get
            {
                return _SearchValue;
            }
            set
            {
                _SearchValue = value;
                NotifyPropertyChanged();
                //ViewSummaryComics = originSummaryComics.Where(x => x.Title.Contains(value)).ToList();
                NotifyPropertyChanged(nameof(ViewSummaryComics));
            } 
        }

        public string Status { get { return $"シリーズ数:{ViewSummaryComics.Count().ToString()}"; } }

        #endregion


        public class ViewSummaryComic
        {
            public string Writer { get; }
            public string Title { get; }

            public string LastNumber { get; }

            public string LostNumber { get; }

            public string OriginName { get { return $"[{Writer}] {Title} "; } }

            public ViewSummaryComic(string writer, string title, List<Range> ranges, List<int> numbers)
            {
                this.Writer = writer;
                this.Title = title;

                if (!ranges.Any() && !numbers.Any())
                {
                    LastNumber = "読切";
                    return;
                }

                var completeNumber = new List<int>(numbers);
                foreach (var range in ranges)
                {
                    completeNumber.AddRange(Enumerable.Range(range.Start.Value, range.End.Value - range.Start.Value + 1));
                }
                var ordered = completeNumber.OrderBy(x => x).ToList();
                LastNumber = ordered.Max().ToString();
                LostNumber = string.Join(",", Enumerable.Range(1, ordered.Max()).Except(ordered));
            }
        }
   }
}
