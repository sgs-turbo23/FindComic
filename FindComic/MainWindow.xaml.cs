﻿using static FindComic.MainWindowViewModel;

namespace FindComic
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new MainWindowViewModel(Config.RootPath);
        }

        private void DataGrid_CurrentCellChanged(object sender, System.EventArgs e)
        {
            var currentItem = (ViewSummaryComic)dataGrid.CurrentItem;
            if (currentItem != null)
            {
                // 選択行のOriginNameをクリップボードに格納
                Clipboard.SetText(currentItem.OriginName);
            }
        }

        private void clipboardPasteButton_Click(object sender, RoutedEventArgs e)
        {
            var context = (MainWindowViewModel)this.DataContext;
            context.SearchValue = Clipboard.GetText();
        }
    }
}
