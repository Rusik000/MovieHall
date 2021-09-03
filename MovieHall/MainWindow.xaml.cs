using Newtonsoft.Json;
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

        public string NameMovie { get; set; }

        public string Ratings { get; set; }
        public dynamic Data { get; set; }
        public dynamic SingleData { get; set; }

        HttpClient httpClient = new HttpClient();
        public MainWindow()
        {
            InitializeComponent();
        }



        private void Search_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var name = MovieTextBox.Text;
            HttpResponseMessage response = new HttpResponseMessage();
            response = httpClient.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&s={name}&plot=full").Result;

            var str = response.Content.ReadAsStringAsync().Result;
            Data = JsonConvert.DeserializeObject(str);



            response = httpClient.GetAsync($@"http://www.omdbapi.com/?apikey=ddee1dae&t={Data.Search[0].Title}&plot=full").Result;

            str = response.Content.ReadAsStringAsync().Result;
            SingleData = JsonConvert.DeserializeObject(str);


            MovieImage.Source = SingleData.Poster;
            MovieImage2.Source = SingleData.Poster;
            Minute = SingleData.Runtime;
            Description = SingleData.Genre;
            NameMovie = SingleData.Title;
            Ratings = SingleData.imdbRating;


            string[] listDes = Description.Split(',');
            MovieLabel.Content = "Title :" + NameMovie;
            MovieLabel1.Content = "Description: " + listDes[0] + "/" + listDes[1] + "/" + listDes[2];
            MovieLabel2.Content = "Minute : " + Minute;
            MovieLabel3.Content = "Rating : " + Ratings;

            double rating = double.Parse(Ratings);

            if (rating>1)
            {
                StarImage1.Source = new BitmapImage(new Uri(@"Images/HalfStar.png"));

            }

            // Task For next 
            // Gelen kimi ulduzlari duzeldirsen 
            // Yumru button yazirsan sekilin ustune ve click edende youtube fragman cixmalidir
            // Asagida Director ve Writers de yazirsan tebii ki label olacaq
            
        }
    }
}
