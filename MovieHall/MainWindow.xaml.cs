using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace MovieHall
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string ImagePath { get; set; }
        public string Minute { get; set; }
        public string Description { get; set; }


        public dynamic Data { get; set; }
        public dynamic SingleData { get; set; }

        HttpClient httpClient = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
