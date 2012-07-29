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
    public partial class Page1 : PhoneApplicationPage
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void image3_Tap(object sender, GestureEventArgs e)
        {
            MessageBox.Show("BrainVita v1.0\n\nDivyansh Manchanda\ndivyanshm@gmail.com\n\nArnav Sengupta\narnavsengupta@yahoo.in\n\nNational Institute of Technology, Trichy, India");
            //Class1.read();
        }

        private void image4_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.Relative));
        }

        private void image2_Tap(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void image5_Tap(object sender, GestureEventArgs e)
        {
            Class1.read();
            NavigationService.Navigate(new Uri("/Page4.xaml", UriKind.Relative));
        }
    }
}