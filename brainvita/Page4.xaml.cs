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
using System.IO.IsolatedStorage;
using System.IO;

namespace brainvita
{
    public partial class Page4 : PhoneApplicationPage
    {
        public Page4()
        {
            InitializeComponent();
            if (Class1.high[0] < 50)
            {
                name1.Text = Class1.names[0];
                score1.Text = Class1.high[0].ToString();
            }
            else
            {
                name1.Text = "-";
                score1.Text = "-";
            }

            if (Class1.high[1] < 50)
            {
                name2.Text = Class1.names[1];
                score2.Text = Class1.high[1].ToString();
            }
            else
            {
                name2.Text = "-";
                score2.Text = "-";
            }

            if (Class1.high[2] < 50)
            {
                name3.Text = Class1.names[2];
                score3.Text = Class1.high[2].ToString();
            }
            else
            {
                name3.Text = "-";
                score3.Text = "-";
            }

            if (Class1.high[3] < 50)
            {
                name4.Text = Class1.names[3];
                score4.Text = Class1.high[3].ToString();
            }
            else
            {
                name4.Text = "-";
                score4.Text = "-";
            }

            if (Class1.high[4] < 50)
            {
                name5.Text = Class1.names[4];
                score5.Text = Class1.high[4].ToString();
            }
            else
            {
                name5.Text = "-";
                score5.Text = "-";
            }
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            store.DeleteFile("high.txt");

            IsolatedStorageFileStream file = store.CreateFile("high.txt");
            file.Close();
            MessageBox.Show("The High Scores have been reset!");
            name1.Text = "-";
            score1.Text = "-";
            name2.Text = "-";
            score2.Text = "-";
            name3.Text = "-";
            score3.Text = "-";
            name4.Text = "-";
            score4.Text = "-";
            name5.Text = "-";
            score5.Text = "-";
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }
    }
}