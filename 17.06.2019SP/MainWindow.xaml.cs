using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace _17._06._2019SP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void CheckingButtonClick(object sender, RoutedEventArgs e)
        {
            var example = await LoadBody(firstNameTextBox.Text, secondNameTextBox.Text);

            percentageTextBlock.Text = example.percentage + "%";
            resultTextBlock.Text = example.result;
        }

        private Task<Body> LoadBody(string firstName, string secondName)
        {
            return Task.Run(() =>
            {
                WebClient client = new WebClient();
                client.Headers.Add("X-RapidAPI-Host", "love-calculator.p.rapidapi.com");
                client.Headers.Add("X-RapidAPI-Key", "3ef32f4b0cmsh9e73eff5f258946p1a3a7ajsn94dc434d6f67");

                string json = client.DownloadString("https://love-calculator.p.rapidapi.com/getPercentage?fname=" + firstName + "&sname=" + secondName);

                return JsonConvert.DeserializeObject<Body>(json);
            });
        }
    }
}
