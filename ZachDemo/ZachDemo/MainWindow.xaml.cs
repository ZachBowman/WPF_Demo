using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ZachDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        byte red = 128;
        byte green = 128;
        byte blue = 128;
        Brush backgroundColor = Brushes.Black;
        double opacity = 1.0;
        string inputString = "";
        ////public List<string> entries;

        public byte BoundRed
        {
            get
            {
                return this.red;
            }

            set
            {
                this.red = value;
                this.BoundColor = new SolidColorBrush(Color.FromArgb(255, BoundRed, BoundGreen, BoundBlue));
                this.PropertyChanged(this, new PropertyChangedEventArgs("BoundRed"));
            }
        }

        public byte BoundGreen
        {
            get
            {
                return this.green;
            }

            set
            {
                this.green = value;
                this.BoundColor = new SolidColorBrush(Color.FromArgb(255, BoundRed, BoundGreen, BoundBlue));
                this.PropertyChanged(this, new PropertyChangedEventArgs("BoundGreen"));
            }
        }

        public byte BoundBlue
        {
            get
            {
                return this.blue;
            }

            set
            {
                this.blue = value;
                this.BoundColor = new SolidColorBrush(Color.FromArgb(255, BoundRed, BoundGreen, BoundBlue));
                this.PropertyChanged(this, new PropertyChangedEventArgs("BoundBlue"));
            }
        }

        public Brush BoundColor
        {
            get
            {
                return this.backgroundColor;
            }

            set
            {
                this.backgroundColor = value;
                this.PropertyChanged(this, new PropertyChangedEventArgs("BoundColor"));
            }
        }

        public double BoundOpacity
        {
            get
            {
                return this.opacity;
            }
            set
            {
                if (this.opacity != value)
                {
                    this.opacity = value;
                    this.PropertyChanged(this, new PropertyChangedEventArgs("BoundOpacity"));
                }
            }
        }

        public string BoundString
        {
            get
            {
                return this.inputString;
            }
            set
            {
                this.inputString = value;
                SaveBox.Items.Add(this.inputString);
                this.PropertyChanged(this, new PropertyChangedEventArgs("BoundString"));
            }
        }

        private void RandomColorButton_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            BoundRed = Convert.ToByte(rnd.Next(0, 256));
            BoundGreen = Convert.ToByte(rnd.Next(0, 256));
            BoundBlue = Convert.ToByte(rnd.Next(0, 256));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            BoundString = TypingArea.Text;
        }
    }
}
