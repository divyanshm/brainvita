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
    public partial class MainPage : PhoneApplicationPage
    {
        // isSelected is true when a Ball is currently selected, and false otherwise
        bool isSelected, mademove = false, movepos;
        Ellipse current;
        Ellipse[,] white = new Ellipse[7, 7];
        Ellipse[,] red = new Ellipse[7, 7];
        bool[,] grid = new bool[7, 7];
        int currx, curry, targetx, targety;
        public static int count = 32;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            current = ellipse63;
            grid[3, 3] = true;
            white[0, 2] = white02;
            white[0, 3] = white03;
            white[0, 4] = white04;
            white[1, 2] = white12;
            white[1, 3] = white13;
            white[1, 4] = white14;
            white[2, 0] = white20;
            white[2, 1] = white21;
            white[2, 2] = white22;
            white[2, 3] = white23;
            white[2, 4] = white24;
            white[2, 5] = white25;
            white[2, 6] = white26;
            white[3, 0] = white30;
            white[3, 1] = white31;
            white[3, 2] = white32;
            white[3, 3] = white33;
            white[3, 4] = white34;
            white[3, 5] = white35;
            white[3, 6] = white36;
            white[4, 0] = white40;
            white[4, 1] = white41;
            white[4, 2] = white42;
            white[4, 3] = white43;
            white[4, 4] = white44;
            white[4, 5] = white45;
            white[4, 6] = white46;
            white[5, 2] = white52;
            white[5, 3] = white53;
            white[5, 4] = white54;
            white[6, 2] = white62;
            white[6, 3] = white63;
            white[6, 4] = white64;
            red[0, 2] = red02;
            red[0, 3] = red03;
            red[0, 4] = red04;
            red[1, 2] = red12;
            red[1, 3] = red13;
            red[1, 4] = red14;
            red[2, 0] = red20;
            red[2, 1] = red21;
            red[2, 2] = red22;
            red[2, 3] = red23;
            red[2, 4] = red24;
            red[2, 5] = red25;
            red[2, 6] = red26;
            red[3, 0] = red30;
            red[3, 1] = red31;
            red[3, 2] = red32;
            red[3, 3] = red33;
            red[3, 4] = red34;
            red[3, 5] = red35;
            red[3, 6] = red36;
            red[4, 0] = red40;
            red[4, 1] = red41;
            red[4, 2] = red42;
            red[4, 3] = red43;
            red[4, 4] = red44;
            red[4, 5] = red45;
            red[4, 6] = red46;
            red[5, 2] = red52;
            red[5, 3] = red53;
            red[5, 4] = red54;
            red[6, 2] = red62;
            red[6, 3] = red63;
            red[6, 4] = red64;
        }

        /* This function verifies if any valid moves are left in the game or not. If not, then
           the final score is calculated and displayed. The game then ends. */
        private void routine()
        {
            int i, j;
            for (i = 0; i <= 6; i++)
            {
                for (j = 2; j <= 4; j++)
                {
                    movepos = verify(i, j);
                    if (movepos)
                        break;
                }
                if (movepos)
                    break;
            }
            if (!movepos)
            {
                for (i = 2; i <= 4; i++)
                {
                    for (j = 0; j <= 6; j++)
                    {
                        movepos = verify(i, j);
                        if (movepos)
                            break;
                    }
                    if (movepos)
                        break;
                }
            }
            if (!movepos)
            {
                System.Threading.Thread.Sleep(100);
                NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.Relative));
            }
        }

        /* This function checks if for a selected ball, any movement is possible 
           The board is seen as being made up of 5 parts - top, bottom, left, right and center */
        private bool verify(int x, int y)
        {
            if (grid[x, y] == false)        // implies there is a ball at location (X,Y)
            {
                // Center
                if (x >= 2 && x <= 4 && y >= 2 && y <= 4)
                {
                    if (grid[x - 2, y] == true && grid[x - 1, y] == false)
                        return true;
                    if (grid[x + 2, y] == true && grid[x + 1, y] == false)
                        return true;
                    if (grid[x, y - 2] == true && grid[x, y - 1] == false)
                        return true;
                    if (grid[x, y + 2] == true && grid[x, y + 1] == false)
                        return true;
                    return false;
                }
                // Top
                else if (x >= 2 && x <= 4 && y < 2)
                {
                    if (grid[x, y + 2] == true && grid[x, y + 1] == false)
                        return true;
                    if (grid[x - 2, y] == true && grid[x - 1, y] == false)
                        return true;
                    if (grid[x + 2, y] == true && grid[x + 1, y] == false)
                        return true;
                    return false;
                }
                // Bottom
                else if (x >= 2 && x <= 4 && y > 4)
                {
                    if (grid[x, y - 2] == true && grid[x, y - 1] == false)
                        return true;
                    if (grid[x - 2, y] == true && grid[x - 1, y] == false)
                        return true;
                    if (grid[x + 2, y] == true && grid[x + 1, y] == false)
                        return true;
                    return false;
                }
                // Left
                else if (x < 2 && y >= 2 && y <= 4)
                {
                    if (grid[x + 2, y] == true && grid[x + 1, y] == false)
                        return true;
                    if (grid[x, y - 2] == true && grid[x, y - 1] == false)
                        return true;
                    if (grid[x, y + 2] == true && grid[x, y + 1] == false)
                        return true;
                    return false;
                }
                // Right
                else if (x > 4 && y >= 2 && y <= 4)
                {
                    if (grid[x - 2, y] == true && grid[x - 1, y] == false)
                        return true;
                    if (grid[x, y - 2] == true && grid[x, y - 1] == false)
                        return true;
                    if (grid[x, y + 2] == true && grid[x, y + 1] == false)
                        return true;
                    return false;
                }
                return false;
            }
            return false;
        }

        /* This function deselects the balls once a move has been made. That is, the 
           blue and green stroke is removed from the hole and ball respectively. */
        private void lowlight()
        {
            int i, j;
            for (i = 0; i <= 6; i++)
            {
                for (j = 2; j <= 4; j++)
                {
                    white[i, j].StrokeThickness = 0;
                    red[i, j].StrokeThickness = 0;
                }
            }
            for (i = 2; i <= 4; i++)
            {
                for (j = 0; j <= 6; j++)
                {
                    white[i, j].StrokeThickness = 0;
                    red[i, j].StrokeThickness = 0;
                }
            }
            return;
        }

        private void ball_click(Ellipse ell, int x, int y)
        {
            if( count<= 26)
                routine();
            lowlight();

            if (isSelected)
                current.StrokeThickness = 0;
            if (current != ell)
            {
                ell.StrokeThickness = 3;
                current = ell;
                isSelected = true;
                check(x, y);
            }
            else
            {
                isSelected = false;
                current = ellipse63;
            }
        }

        /* For a selected Ball, this function checks the possible Holes where the ball can be moved.
           If current location is (x,y), this function checks the 4 points - 
           (x,y+2), (x,y-2), (x+2,y), (x-2,y)  */
        private void check(int x, int y)
        {
            currx = x;
            curry = y;
            if ( x >= 2 && grid[x - 2, y] == true && grid[x - 1, y] == false )
                {
                    white[x - 2, y].Stroke = new SolidColorBrush(Colors.Blue);
                    white[x - 2, y].StrokeThickness = 3;
                }
            if ( x < 5 && grid[x + 2, y] == true && grid[x + 1, y] == false )
                {
                    white[x + 2, y].Stroke = new SolidColorBrush(Colors.Blue);
                    white[x + 2, y].StrokeThickness = 3;
                }
            if ( y >= 2 && grid[x, y - 2] == true && grid[x, y - 1] == false )
                {
                    white[x, y - 2].Stroke = new SolidColorBrush(Colors.Blue);
                    white[x, y - 2].StrokeThickness = 3;
                }
            if ( y < 5 && grid[x, y + 2] == true && grid[x, y + 1] == false )
                {
                    white[x, y + 2].Stroke = new SolidColorBrush(Colors.Blue);
                    white[x, y + 2].StrokeThickness = 3;
                }
        }

        // This function simulates the ball movement.
        private void move(int x, int y)
        {
            if (isSelected)
            {
                targetx = x;
                targety = y;

                if (white[x, y].StrokeThickness == 3 && red[currx, curry].StrokeThickness == 3)
                {
                    mademove = true;
                    grid[x, y] = false;
                    red[x, y].Visibility = Visibility.Visible;
                    red[currx, curry].Visibility = Visibility.Collapsed;
                    if (currx == x && y - curry > 0)
                    {
                        red[currx, y - 1].Visibility = Visibility.Collapsed;
                        grid[currx, y - 1] = true;
                    }
                    else if (currx == x && y - curry < 0)
                    {
                        red[currx, y + 1].Visibility = Visibility.Collapsed;
                        grid[currx, y + 1] = true;
                    }
                    else if (curry == y && x - currx > 0)
                    {
                        red[x - 1, curry].Visibility = Visibility.Collapsed;
                        grid[x - 1, curry] = true;
                    }
                    else if (curry == y && x - currx < 0)
                    {
                        red[x + 1, curry].Visibility = Visibility.Collapsed;
                        grid[x + 1, curry] = true;
                    }
                    grid[currx, curry] = true;
                    lowlight();
                    SoundClip.Play();
                }
                else
                    lowlight();
                current = ellipse63;
                isSelected = false;
                --count;
            }
        }

        private void undo()
        {
            if (mademove)
            {
                grid[currx, curry] = false;
                red[currx, curry].Visibility = Visibility.Visible;
                red[targetx, targety].Visibility = Visibility.Collapsed;
                grid[targetx, targety] = true;
                if (currx == targetx && targety - curry > 0)
                {
                    red[currx, targety - 1].Visibility = Visibility.Visible;
                    grid[currx, targety - 1] = false;
                }
                else if (currx == targetx && targety - curry < 0)
                {
                    red[currx, targety + 1].Visibility = Visibility.Visible;
                    grid[currx, targety + 1] = false;
                }
                else if (curry == targety && targetx - currx > 0)
                {
                    red[targetx - 1, curry].Visibility = Visibility.Visible;
                    grid[targetx - 1, curry] = false;
                }
                else if (curry == targety && targetx - currx < 0)
                {
                    red[targetx + 1, curry].Visibility = Visibility.Visible;
                    grid[targetx + 1, curry] = false;
                }
                mademove = false;
                ++count;
                lowlight();
            }
        }

        // Resets the game, start afresh.
        private void reset()
        {
            lowlight();
            int i, j;
            for (i = 0; i <= 6; i++)
            {
                for (j = 2; j <= 4; j++)
                {
                    red[i, j].Visibility = Visibility.Visible;
                    red[i, j].StrokeThickness = 0;
                    grid[i, j] = false;
                }
            }
            for (i = 2; i <= 4; i++)
            {
                for (j = 0; j <= 6; j++)
                {
                    red[i, j].Visibility = Visibility.Visible;
                    red[i, j].StrokeThickness = 0;
                    grid[i, j] = false;
                }
            }
            red[3, 3].Visibility = Visibility.Collapsed;
            grid[3, 3] = true;
            mademove = false;
            count = 32;
        }

        // Balls Being Selected
        private void red02_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red02, 0, 2);

        }

        private void red03_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red03, 0, 3);
        }

        private void red04_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red04, 0, 4);
        }

        private void red12_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red12, 1, 2);
        }

        private void red13_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red13, 1, 3);
        }

        private void red14_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red14, 1, 4);
        }

        private void red20_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red20, 2, 0);
        }

        private void red21_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red21, 2, 1);
        }

        private void red22_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red22, 2, 2);
        }

        private void red23_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red23, 2, 3);

        }

        private void red24_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red24, 2, 4);

        }

        private void red25_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red25, 2, 5);

        }

        private void red26_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red26, 2, 6);

        }

        private void red30_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red30, 3, 0);

        }

        private void red31_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red31, 3, 1);

        }

        private void red32_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red32, 3, 2);
        }

        private void red34_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red34, 3, 4);
        }

        private void red35_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red35, 3, 5);
        }

        private void red36_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red36, 3, 6);
        }

        private void red40_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red40, 4, 0);
        }

        private void red41_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red41, 4, 1);
        }

        private void red42_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red42, 4, 2);
        }

        private void red43_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red43, 4, 3);
        }

        private void red44_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red44, 4, 4);
        }

        private void red45_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red45, 4, 5);
        }

        private void red46_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red46, 4, 6);
        }

        private void red52_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red52, 5, 2);
        }

        private void red53_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red53, 5, 3);
        }

        private void red54_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red54, 5, 4);
        }

        private void red62_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red62, 6, 2);
        }

        private void red63_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red63, 6, 3);
        }

        private void red64_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red64, 6, 4);
        }

        private void red33_Tap(object sender, GestureEventArgs e)
        {
            ball_click(red33, 3, 3);
        }

        private void white02_Tap(object sender, GestureEventArgs e)
        {
            move(0, 2);

        }

        private void white03_Tap(object sender, GestureEventArgs e)
        {
            move(0, 3);
        }

        private void white04_Tap(object sender, GestureEventArgs e)
        {
            move(0, 4);
        }

        private void white12_Tap(object sender, GestureEventArgs e)
        {
            move(1, 2);
        }

        private void white13_Tap(object sender, GestureEventArgs e)
        {
            move(1, 3);
        }

        private void white14_Tap(object sender, GestureEventArgs e)
        {
            move(1, 4);
        }

        private void white20_Tap(object sender, GestureEventArgs e)
        {
            move(2, 0);
        }

        private void white21_Tap(object sender, GestureEventArgs e)
        {
            move(2, 1);
        }

        private void white22_Tap(object sender, GestureEventArgs e)
        {
            move(2, 2);
        }

        private void white23_Tap(object sender, GestureEventArgs e)
        {
            move(2, 3);
        }

        private void white24_Tap(object sender, GestureEventArgs e)
        {
            move(2, 4);
        }

        private void white25_Tap(object sender, GestureEventArgs e)
        {
            move(2, 5);
        }

        private void white26_Tap(object sender, GestureEventArgs e)
        {
            move(2, 6);
        }

        private void white30_Tap(object sender, GestureEventArgs e)
        {
            move(3, 0);
        }

        private void white31_Tap(object sender, GestureEventArgs e)
        {
            move(3, 1);

        }

        private void white32_Tap(object sender, GestureEventArgs e)
        {
            move(3, 2);
        }

        private void white33_Tap(object sender, GestureEventArgs e)
        {
            move(3, 3);
        }

        private void white34_Tap(object sender, GestureEventArgs e)
        {
            move(3, 4);
        }

        private void white35_Tap(object sender, GestureEventArgs e)
        {
            move(3, 5);
        }

        private void white36_Tap(object sender, GestureEventArgs e)
        {
            move(3, 6);
        }

        private void white40_Tap(object sender, GestureEventArgs e)
        {
            move(4, 0);
        }

        private void white41_Tap(object sender, GestureEventArgs e)
        {
            move(4, 1);
        }

        private void white42_Tap(object sender, GestureEventArgs e)
        {
            move(4, 2);
        }

        private void white43_Tap(object sender, GestureEventArgs e)
        {
            move(4, 3);
        }

        private void white44_Tap(object sender, GestureEventArgs e)
        {
            move(4, 4);
        }

        private void white45_Tap(object sender, GestureEventArgs e)
        {
            move(4, 5);
        }

        private void white46_Tap(object sender, GestureEventArgs e)
        {
            move(4, 6);
        }

        private void white52_Tap(object sender, GestureEventArgs e)
        {
            move(5, 2);
        }

        private void white53_Tap(object sender, GestureEventArgs e)
        {
            move(5, 3);
        }

        private void white54_Tap(object sender, GestureEventArgs e)
        {
            move(5, 4);
        }

        private void white62_Tap(object sender, GestureEventArgs e)
        {
            move(6, 2);
        }

        private void white63_Tap(object sender, GestureEventArgs e)
        {
            move(6, 3);
        }

        private void white64_Tap(object sender, GestureEventArgs e)
        {
            move(6, 4);
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            undo();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            reset();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page1.xaml", UriKind.Relative));
        }
    }
}