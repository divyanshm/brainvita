using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace brainvita
{
    public partial class Page3 : PhoneApplicationPage
    {
        public Page3()
        {
            InitializeComponent();
            fill_value();
        }

        public void fill_value()
        {
            textBlock2.Text = MainPage.count.ToString();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            string str = textBox1.Text;
            MessageBox.Show("Your score has been registered, " + str + ".\n\nCheck the High Scores button in the home page to check if you've made it to the Top 5!");
            Class1.write(str, MainPage.count);
            MainPage.count = 32;
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }
    }
}