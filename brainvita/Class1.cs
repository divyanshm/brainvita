using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.IO.IsolatedStorage;
using System.IO;

namespace brainvita
{
    public class Class1
    {
        public static int[] high = new int[6] { 100, 100, 100, 100, 100, 100 };
        public static string[] names = new string[6] { "-", "-", "-", "-", "-", "-" };

        private static void init_arr()
        {
            for (int i = 0; i < 6; i++)
            {
                high[i] = 100;
                names[i] = "-";
            }

        }

        public static void write(String name, int score)
        {         
            String line;
            int count = 0;
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream file = store.OpenFile("high.txt", FileMode.Open, FileAccess.Read);
           
            using (StreamReader reader = new StreamReader(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] tok = line.Split();
                    names[count] = tok[0];
                    high[count++] = Convert.ToInt32(tok[1]);
                }
            }

            for (int i = 0; i <5; i++)
            {
                if (score <= high[i])
                {
                    for (int j = 5; j >i; j--)
                    {
                        high[j] = high[j - 1];
                        names[j] = names[j - 1];
                    }
                    high[i] = score;
                    names[i] = name;
                    break;
                }
            }
            file.Close();
            store.DeleteFile("high.txt");
            IsolatedStorageFileStream file1 = store.CreateFile("high.txt");
            file1.Close();

            using ( StreamWriter sw = new StreamWriter(store.OpenFile("high.txt", FileMode.Open, FileAccess.Write) ))
            {
                for(int i=0;i<5;i++)
                    sw.WriteLine(names[i]+" "+high[i].ToString());
            }
            init_arr();
        }

        public static void read()
        {
            init_arr();
            String line;
            int count = 0;
            IsolatedStorageFile store = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream file = store.OpenFile("high.txt", FileMode.Open, FileAccess.Read);

            using (StreamReader reader = new StreamReader(file))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    string[] tok = line.Split();
                    names[count] = tok[0];
                    high[count++] = Convert.ToInt32(tok[1]);
                }
            }
            file.Close();
        }
    }
}
