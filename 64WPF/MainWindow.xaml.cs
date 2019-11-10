using _64WPF.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace _64WPF
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GameController GC;
        int[][] boardMapping;
        int size = 4;
        DispatcherTimer timer;
       

        public MainWindow()
        {
            InitializeComponent();
            SetGame();
            timer = new DispatcherTimer();
            timer.Tick += OnTick;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);

        }

        private void OnTick(object sender, EventArgs e)
        {
            
        }

        private void SetGame()
        { 
            GC = new GameController();
            boardMapping = new int[4][];
            for (int i = 0; i < size; i++)
            {
                boardMapping[i] = new int[4];
                for (int j = 0; j < size; j++)
                {
                    boardMapping[i][j] = 0;
                }
            }

        }

        private void Play_Click(object sender, RoutedEventArgs e){


            if (timer.IsEnabled)
            {
                timer.Stop();
                if (GAMEOVER.Visibility == Visibility.Hidden) GAMEOVER.Visibility = Visibility.Visible;
                ((Button)sender).Content = "Play";
            }
            else
            {
                timer.Start();
                ((Button)sender).Content = "Surrender";
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        DrawChip(i, j, boardMapping[i][j]);
                    }
                }
                if (GAMEOVER.Visibility == Visibility.Visible) GAMEOVER.Visibility = Visibility.Hidden;
                ResetBoard();
                AddChip();
            }
            
        }

        private void AddChip()
        {   
            int row=-1, column=-1, value=-1;
            GC.newChip(ref row, ref column, ref value);
            boardMapping[row][column] = value;
            DrawChip(row, column, value);
        }

        private void UpdateBoardDrawing()
        {
            for(int i = 0; i<size; i++)
            {
                for(int j = 0; j<size; j++)
                {
                    DrawChip(i, j, boardMapping[i][j]);
                }
            }
        }
        private void DrawChip(int row, int column, int value)
        {
            switch (row)
            {
                case 0:
                    switch (column)
                    {
                        case 0:
                            switch (value)
                            {
                                case 2:
                                    L0x0.Content = value.ToString();
                                    L0x0.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L0x0.Content = value.ToString();
                                    L0x0.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L0x0.Content = value.ToString();
                                    L0x0.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L0x0.Content = value.ToString();
                                    L0x0.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L0x0.Content = value.ToString();
                                    L0x0.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L0x0.Content = value.ToString();
                                    L0x0.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L0x0.Content = "";
                                    break;

                            }
                            break;
                        case 1:
                            switch (value)
                            {
                                case 2:
                                    L0x1.Content = value.ToString();
                                    L0x1.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L0x1.Content = value.ToString();
                                    L0x1.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L0x1.Content = value.ToString();
                                    L0x1.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L0x1.Content = value.ToString();
                                    L0x1.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L0x1.Content = value.ToString();
                                    L0x1.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L0x1.Content = value.ToString();
                                    L0x1.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L0x1.Content = "";
                                    break;

                            }
                            break;
                        case 2:
                            switch (value)
                            {
                                case 2:
                                    L0x2.Content = value.ToString();
                                    L0x2.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L0x2.Content = value.ToString();
                                    L0x2.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L0x2.Content = value.ToString();
                                    L0x2.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L0x2.Content = value.ToString();
                                    L0x2.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L0x2.Content = value.ToString();
                                    L0x2.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L0x2.Content = value.ToString();
                                    L0x2.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L0x2.Content = "";
                                    break;

                            }
                            break;
                        case 3:
                            switch (value)
                            {
                                case 2:
                                    L0x3.Content = value.ToString();
                                    L0x3.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L0x3.Content = value.ToString();
                                    L0x3.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L0x3.Content = value.ToString();
                                    L0x3.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L0x3.Content = value.ToString();
                                    L0x3.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L0x3.Content = value.ToString();
                                    L0x3.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L0x3.Content = value.ToString();
                                    L0x3.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L0x3.Content = "";
                                    break;

                            }
                            break;
                    }
                    break;
                case 1:
                    switch (column)
                    {
                        case 0:
                            switch (value)
                            {
                                case 2:
                                    L1x0.Content = value.ToString();
                                    L1x0.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L1x0.Content = value.ToString();
                                    L1x0.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L1x0.Content = value.ToString();
                                    L1x0.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L1x0.Content = value.ToString();
                                    L1x0.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L1x0.Content = value.ToString();
                                    L1x0.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L1x0.Content = value.ToString();
                                    L1x0.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L1x0.Content = "";
                                    break;

                            }
                            break;
                        case 1:
                            switch (value)
                            {
                                case 2:
                                    L1x1.Content = value.ToString();
                                    L1x1.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L1x1.Content = value.ToString();
                                    L1x1.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L1x1.Content = value.ToString();
                                    L1x1.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L1x1.Content = value.ToString();
                                    L1x1.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L1x1.Content = value.ToString();
                                    L1x1.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L1x1.Content = value.ToString();
                                    L1x1.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L1x1.Content = "";
                                    break;

                            }
                            break;
                        case 2:
                            switch (value)
                            {
                                case 2:
                                    L1x2.Content = value.ToString();
                                    L1x2.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L1x2.Content = value.ToString();
                                    L1x2.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L1x2.Content = value.ToString();
                                    L1x2.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L1x2.Content = value.ToString();
                                    L1x2.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L1x2.Content = value.ToString();
                                    L1x2.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L1x2.Content = value.ToString();
                                    L1x2.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L1x2.Content = "";
                                    break;

                            }
                            break;
                        case 3:
                            switch (value)
                            {
                                case 2:
                                    L1x3.Content = value.ToString();
                                    L1x3.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L1x3.Content = value.ToString();
                                    L1x3.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L1x3.Content = value.ToString();
                                    L1x3.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L1x3.Content = value.ToString();
                                    L1x3.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L1x3.Content = value.ToString();
                                    L1x3.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L1x3.Content = value.ToString();
                                    L1x3.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L1x3.Content = "";
                                    break;

                            }
                            break;
                    }
                    break;
                case 2:
                    switch (column)
                    {
                        case 0:
                            switch (value)
                            {
                                case 2:
                                    L2x0.Content = value.ToString();
                                    L2x0.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L2x0.Content = value.ToString();
                                    L2x0.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L2x0.Content = value.ToString();
                                    L2x0.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L2x0.Content = value.ToString();
                                    L2x0.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L2x0.Content = value.ToString();
                                    L2x0.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L2x0.Content = value.ToString();
                                    L2x0.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L2x0.Content = "";
                                    break;

                            }
                            break;
                        case 1:
                            switch (value)
                            {
                                case 2:
                                    L2x1.Content = value.ToString();
                                    L2x1.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L2x1.Content = value.ToString();
                                    L2x1.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L2x1.Content = value.ToString();
                                    L2x1.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L2x1.Content = value.ToString();
                                    L2x1.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L2x1.Content = value.ToString();
                                    L2x1.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L2x1.Content = value.ToString();
                                    L2x1.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L2x1.Content = "";
                                    break;

                            }
                            break;
                        case 2:
                            switch (value)
                            {
                                case 2:
                                    L2x2.Content = value.ToString();
                                    L2x2.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L2x2.Content = value.ToString();
                                    L2x2.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L2x2.Content = value.ToString();
                                    L2x2.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L2x2.Content = value.ToString();
                                    L2x2.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L2x2.Content = value.ToString();
                                    L2x2.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L2x2.Content = value.ToString();
                                    L2x2.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L2x2.Content = "";
                                    break;

                            }
                            break;
                        case 3:
                            switch (value)
                            {
                                case 2:
                                    L2x3.Content = value.ToString();
                                    L2x3.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L2x3.Content = value.ToString();
                                    L2x3.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L2x3.Content = value.ToString();
                                    L2x3.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L2x3.Content = value.ToString();
                                    L2x3.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L2x3.Content = value.ToString();
                                    L2x3.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L2x3.Content = value.ToString();
                                    L2x3.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L2x3.Content = "";
                                    break;

                            }
                            break;

                    }
                    break;
                case 3:
                    switch (column)
                    {
                        case 0:
                            switch (value)
                            {
                                case 2:
                                    L3x0.Content = value.ToString();
                                    L3x0.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L3x0.Content = value.ToString();
                                    L3x0.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L3x0.Content = value.ToString();
                                    L3x0.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L3x0.Content = value.ToString();
                                    L3x0.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L3x0.Content = value.ToString();
                                    L3x0.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L3x0.Content = value.ToString();
                                    L3x0.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L3x0.Content = "";
                                    break;

                            }
                            break;
                        case 1:
                            switch (value)
                            {
                                case 2:
                                    L3x1.Content = value.ToString();
                                    L3x1.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L3x1.Content = value.ToString();
                                    L3x1.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L3x1.Content = value.ToString();
                                    L3x1.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L3x1.Content = value.ToString();
                                    L3x1.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L3x1.Content = value.ToString();
                                    L3x1.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L3x1.Content = value.ToString();
                                    L3x1.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L3x1.Content = "";
                                    break;

                            }
                            break;
                        case 2:
                            switch (value)
                            {
                                case 2:
                                    L3x2.Content = value.ToString();
                                    L3x2.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L3x2.Content = value.ToString();
                                    L3x2.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L3x2.Content = value.ToString();
                                    L3x2.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L3x2.Content = value.ToString();
                                    L3x2.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L3x2.Content = value.ToString();
                                    L3x2.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L3x2.Content = value.ToString();
                                    L3x2.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L3x2.Content = "";
                                    break;

                            }
                            break;
                        case 3:
                            switch (value)
                            {
                                case 2:
                                    L3x3.Content = value.ToString();
                                    L3x3.Foreground = new SolidColorBrush(Colors.Red);
                                    break;
                                case 4:
                                    L3x3.Content = value.ToString();
                                    L3x3.Foreground = new SolidColorBrush(Colors.Blue);
                                    break;
                                case 8:
                                    L3x3.Content = value.ToString();
                                    L3x3.Foreground = new SolidColorBrush(Colors.Yellow);
                                    break;
                                case 16:
                                    L3x3.Content = value.ToString();
                                    L3x3.Foreground = new SolidColorBrush(Colors.Green);
                                    break;
                                case 32:
                                    L3x3.Content = value.ToString();
                                    L3x3.Foreground = new SolidColorBrush(Colors.Brown);
                                    break;
                                case 64:
                                    L3x3.Content = value.ToString();
                                    L3x3.Foreground = new SolidColorBrush(Colors.Purple);
                                    break;
                                default:
                                    L3x3.Content = "";
                                    break;

                            }
                            break;
                    }
                    break;
            }
        }

        private void ResetBoard()
        {
            GC.Reset();
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    boardMapping[i][j] = 0;
                }
            }
            UpdateBoardDrawing();
        }
    }


}
