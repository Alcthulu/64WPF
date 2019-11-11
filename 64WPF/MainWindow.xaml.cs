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
                LoseGame();
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
                if (YOUWIN.Visibility == Visibility.Visible) YOUWIN.Visibility = Visibility.Hidden;

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
                            DrawIt(L0x0, value); 
                            break;
                        case 1:
                            DrawIt(L0x1, value);
                            break;
                        case 2:
                            DrawIt(L0x2, value);
                            break;
                        case 3:
                            DrawIt(L0x3, value);
                            break;
                    }
                    break;
                case 1:
                    switch (column)
                    {
                        case 0:
                            DrawIt(L1x0, value);
                            break;
                        case 1:
                            DrawIt(L1x1, value);
                            break;
                        case 2:
                            DrawIt(L1x2, value);
                            break;
                        case 3:
                            DrawIt(L1x3, value);
                            break;
                    }
                    break;
                case 2:
                    switch (column)
                    {
                        case 0:
                            DrawIt(L2x0, value);
                            break;
                        case 1:
                            DrawIt(L2x1, value);
                            break;
                        case 2:
                            DrawIt(L2x2, value);
                            break;
                        case 3:
                            DrawIt(L2x3, value);
                            break;

                    }
                    break;
                case 3:
                    switch (column)
                    {
                        case 0:
                            DrawIt(L3x0, value);
                            break;
                        case 1:
                            DrawIt(L3x1, value);
                            break;
                        case 2:
                            DrawIt(L3x2, value);
                            break;
                        case 3:
                            DrawIt(L3x3, value);
                            break;
                    }
                    break;
            }
        }

        private void DrawIt(Label l, int value)
        {
            switch (value)
            {
                case 2:
                    l.Content = value.ToString();
                    l.Foreground = new SolidColorBrush(Colors.Red);
                    break;
                case 4:
                    l.Content = value.ToString();
                    l.Foreground = new SolidColorBrush(Colors.Blue);
                    break;
                case 8:
                    l.Content = value.ToString();
                    l.Foreground = new SolidColorBrush(Colors.Yellow);
                    break;
                case 16:
                    l.Content = value.ToString();
                    l.Foreground = new SolidColorBrush(Colors.Green);
                    break;
                case 32:
                    l.Content = value.ToString();
                    l.Foreground = new SolidColorBrush(Colors.Brown);
                    break;
                case 64:
                    l.Content = value.ToString();
                    l.Foreground = new SolidColorBrush(Colors.Purple);
                    break;
                case 128:
                    l.Content = value.ToString();
                    l.Foreground = new SolidColorBrush(Colors.Cyan);
                    break;
                case 256:
                    l.Content = value.ToString();
                    l.Foreground = new SolidColorBrush(Colors.DarkGoldenrod);
                    break;
                case 512:
                    l.Content = value.ToString();
                    l.Foreground = new SolidColorBrush(Colors.Indigo);
                    break;
                case 1024:
                    l.Content = value.ToString();
                    l.Foreground = new SolidColorBrush(Colors.SpringGreen);
                    break;
                case 2048:
                    l.Content = value.ToString();
                    l.Foreground = new SolidColorBrush(Colors.Plum);
                    break;
                case 4096:
                    l.Content = value.ToString();
                    l.Foreground = new SolidColorBrush(Colors.Silver);
                    break;
                default:
                    l.Content = "";
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

        private void UpdateBoardMapping()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    boardMapping[i][j] = GC.getBoardPosition(i, j);
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            bool movimiento = false, hayHueco = true, win = false;
            if (timer.IsEnabled)
            {
                switch (e.Key)
                {
                    case Key.Left:
                        movimiento = GC.MoveLeft();
                        hayHueco = !GC.IsFull();
                        win = GC.getWin();
                        UpdateBoardMapping();
                        UpdateBoardDrawing();
                        if (movimiento && hayHueco && !win) AddChip();
                        else if (win) WinGame();
                        else if (!hayHueco) LoseGame();
                        break;

                    case Key.Right:
                        movimiento = GC.MoveRight();
                        hayHueco = !GC.IsFull();
                        win = GC.getWin();
                        UpdateBoardMapping();
                        UpdateBoardDrawing();
                        if (movimiento && hayHueco && !win) AddChip();
                        else if (win) WinGame();
                        else if (!hayHueco) LoseGame();
                        break;

                    case Key.Up:
                        movimiento = GC.MoveUp();
                        hayHueco = !GC.IsFull();
                        win = GC.getWin();
                        UpdateBoardMapping();
                        UpdateBoardDrawing();
                        if (movimiento && hayHueco && !win) AddChip();
                        else if (win) WinGame();
                        else if (!hayHueco) LoseGame();
                        break;

                    case Key.Down:
                        
                        movimiento = GC.MoveDown();
                        hayHueco = !GC.IsFull();
                        win = GC.getWin();
                        UpdateBoardMapping();
                        UpdateBoardDrawing();
                        if (movimiento && hayHueco && !win) AddChip();
                        else if (win) WinGame();
                        else if (!hayHueco) LoseGame();
                        break;
                        
                }
            }
        }

        private void WinGame()
        {
            timer.Stop();
            if (YOUWIN.Visibility == Visibility.Hidden) YOUWIN.Visibility = Visibility.Visible;
            Play.Content = "Play again";
        }

        private void LoseGame()
        {
            timer.Stop();
            if (GAMEOVER.Visibility == Visibility.Hidden) GAMEOVER.Visibility = Visibility.Visible;
            Play.Content = "Play again";
        }
    }


}
