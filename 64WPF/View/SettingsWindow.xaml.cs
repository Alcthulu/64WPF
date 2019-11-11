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
using System.Windows.Shapes;

namespace _64WPF.View
{
    /// <summary>
    /// Lógica de interacción para Settings.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public event titleEventHandler newTitle;
        public event difficultyEventHandler newDifficulty;

        int condicion;

        void OnNewTitle(string s)
        {
            if (newTitle != null) newTitle(this, new titleEventsArgs(s));
        }

        void OnNewDifficulty()
        {
            if (newDifficulty != null) newDifficulty(this, new difficultyEventArgs(condicion));
        }

        public String title
        {
            get { return titleBox.Text; }
            set { titleBox.Text = value; }
        }

        public int winCondition
        {
            get { return condicion; }
            set { condicion = value; }
        }
        public SettingsWindow(int cond)
        {
            InitializeComponent();
            condicion = cond;
            switch (condicion)
            {
                case 64:
                    Easy.IsChecked = true;
                    break;
                case 2048:
                    Normal.IsChecked = true;
                    break;
                case 4096:
                    Hard.IsChecked = true;
                    break;
                default:
                    break;
            }
        }

        private void titleBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            OnNewTitle(titleBox.Text);
        }

        private void Easy_Checked(object sender, RoutedEventArgs e)
        {
            if (Normal.IsChecked == true)
            {
                Normal.IsChecked = false;
            }
            if (Hard.IsChecked == true)
            {
                Hard.IsChecked = false;
            }
            condicion = 64;
            OnNewDifficulty();
        }

        private void Normal_Checked(object sender, RoutedEventArgs e)
        {
            if (Easy.IsChecked == true)
            {
                Easy.IsChecked = false;
            }
            if (Hard.IsChecked == true)
            {
                Hard.IsChecked = false;
            }
            condicion = 2048;
            OnNewDifficulty();
        }

        private void Hard_Checked(object sender, RoutedEventArgs e)
        {
            if (Normal.IsChecked == true)
            {
                Normal.IsChecked = false;
            }
            if (Easy.IsChecked == true)
            {
                Easy.IsChecked = false;
            }
            condicion = 4096;
            OnNewDifficulty();
        }
    }

    //Clase Args para el cambio de titulo
    public class titleEventsArgs : EventArgs
    {
        public string title { get; set; }

        public titleEventsArgs(string s)
        {
            title = s;
        }
    }

    //Clase Args para el cambio de dificultad(win condition)
    public class difficultyEventArgs : EventArgs
    {
        public int winCondition { get; set; }

        public difficultyEventArgs(int i)
        {
            winCondition = i;
        }
    }

    public class fontSizeEventArgs : EventArgs
    {
        public int fontSize { get; set; }

        public fontSizeEventArgs(int i)
        {
            fontSize = i;
        }
    }

    public delegate void titleEventHandler(Object sender, titleEventsArgs e);
    public delegate void difficultyEventHandler(Object sender, difficultyEventArgs e);
    public delegate void fontSizeEventHandler(Object sender, fontSizeEventArgs e);
}
