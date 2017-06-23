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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Password_Generator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            Random randIValue = new Random();
            string passwordCharacters = @"~!@#$%^&*_-+=`|\(){}[]:;'<>,.?/abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int t = 0;

            //Checks Size box
            if (length.Text != String.Empty)
            {
                t = int.Parse(length.Text);
            }
            else
            {
                t = randIValue.Next(6, 15);
            }

            //Checks Excluded Characters box
            if (excluded.Text != String.Empty)
            {
                foreach (char c in excluded.Text)
                {
                    if (passwordCharacters.Contains(c))
                    {
                        passwordCharacters = passwordCharacters.Replace(c.ToString(), "");
                    }
                }
            }

            for (int i = 0; i < t; i++)
            {
                int index = rand.Next(0, passwordCharacters.Length - 1);
                sb = sb.Append(passwordCharacters[index]);
            }
            passwordText.Text = sb.ToString();
        }
    }
}
