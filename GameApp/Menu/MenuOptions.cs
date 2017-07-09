
using System.Windows.Controls;
using System.Windows;

namespace GameApp
{
    class MenuOptions : Canvas
    {
        public MenuOptions()
        {
            this.SizeChanged += OnSizeChanged;   
        }

        private void OnSizeChanged(object sender, SizeChangedEventArgs args)
        {
            double dH, dW, dBorder, dX;
            const double dCenter = 0.325;
            Grid grid = MainWindow.last.optionsPanelGrid; ;

            dH = args.NewSize.Height;
            dW = MainWindow.last.expanderButton.GetWidth(dH);

            dBorder = args.NewSize.Width / 3.0;

            MainWindow.last.expanderButton.Width = dW;
            MainWindow.last.expanderButton.Height = dH;
            dX = dBorder - dW * dCenter;

            Canvas.SetLeft(MainWindow.last.expanderButton, dX);
            Canvas.SetTop(MainWindow.last.expanderButton, 0.0);

            grid.Width = dX;
            grid.Height = dH;

            grid.ColumnDefinitions[0].Width = grid.ColumnDefinitions[2].Width = grid.ColumnDefinitions[4].Width = grid.ColumnDefinitions[6].Width = new GridLength(1.0, GridUnitType.Star);
            grid.ColumnDefinitions[1].Width = grid.ColumnDefinitions[3].Width = grid.ColumnDefinitions[5].Width = new GridLength(dW);


            Canvas.SetLeft(grid, 0.0);
            Canvas.SetTop(grid, 0.0);
        }
    }
}
