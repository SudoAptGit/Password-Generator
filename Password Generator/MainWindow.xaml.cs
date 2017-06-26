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
            string temp = String.Empty;

            //Checks Size box
            if (length.Text != String.Empty)
            {
                t = int.Parse(length.Text);
            }
            else
            {
                t = randIValue.Next(6, 15);
            }

            //Checks No Similar Checkbox
            if (chkSimilar.IsChecked == true)
            {
                passwordCharacters = @"!#$%&'()*+,-./23456789:;<=>?@ABCDEFGHJKLMNPRSTUVWXYZ[\]^_abcdefghjkmnpqrstuvwxyz{}~";
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

            //Checks Include Numbers Checkbox
            if (chkNum.IsChecked == false)
            {
                foreach (char c in passwordCharacters)
                {
                    if (Char.IsNumber(c))
                    {
                        passwordCharacters = passwordCharacters.Replace(c.ToString(), "");
                    }
                }
            }

            //Checks Include Symbols Checkbox
            if (chkSym.IsChecked == false)
            {
                foreach (char c in passwordCharacters)
                {
                    if (!char.IsLetterOrDigit(c))
                    {
                        passwordCharacters = passwordCharacters.Replace(c.ToString(), "");
                    }
                }
            }

            //Checks Include Lowercase Checkbox
            if (chkLower.IsChecked == false)
            {
                foreach (char c in passwordCharacters)
                {
                    if (Char.IsLower(c))
                    {
                        passwordCharacters = passwordCharacters.Replace(c.ToString(), "");
                    }
                }
            }

            //Checks Include Uppercase Checkbox
            if (chkUpper.IsChecked == false)
            {
                foreach (char c in passwordCharacters)
                {
                    if (Char.IsUpper(c))
                    {
                        passwordCharacters = passwordCharacters.Replace(c.ToString(), "");
                    }
                }
            }

            //Checks Begin with Letter Checkbox
            if (chkStartLetter.IsChecked == true)
            {
                temp = passwordCharacters;
                foreach (char c in passwordCharacters)
                {
                    if (!Char.IsLetter(c))
                    {
                        temp = temp.Replace(c.ToString(), "");
                    }
                }
            }

            //Generator Logic
            if (passwordCharacters.Length > 0)
            {
                if (chkStartLetter.IsChecked == true && (chkUpper.IsChecked == true || chkLower.IsChecked == true))
                {
                    int index = rand.Next(0, temp.Length);
                    sb = sb.Append(temp[index]);
                    for (int i = 0; i < t-1; i++)
                    {
                        index = rand.Next(0, passwordCharacters.Length);
                        sb = sb.Append(passwordCharacters[index]);
                    }
                }
                else if (chkDups.IsChecked == true)
                {
                    for (int i = 0; i < t; i++)
                    {
                        if (passwordCharacters.Length > 0)
                        {
                            int index = rand.Next(0, passwordCharacters.Length);
                            sb = sb.Append(passwordCharacters[index]);
                            passwordCharacters = passwordCharacters.Replace(passwordCharacters[index].ToString(), "");
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < t; i++)
                    {
                        int index = rand.Next(0, passwordCharacters.Length);
                        sb = sb.Append(passwordCharacters[index]);
                    }
                }
            }
            passwordText.Text = sb.ToString();
        }
    }
}
