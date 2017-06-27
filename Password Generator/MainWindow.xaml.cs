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


        private void generatePW(Random rand, int length, string passwordCharacters, StringBuilder sb)
        {
            bool flag = false;
            for (int i = 0; i < length; i++)
            {
                if (passwordCharacters.Length > 0)
                {
                    int index = rand.Next(0, passwordCharacters.Length);
                    if (chkSeq.IsChecked == true)
                    {
                        int ascii = (int)passwordCharacters[index];
                        int previousAscii = 0;
                        if (i != 0)
                        {
                            previousAscii = ((int)sb[i - 1]) + 1;
                        }
                        while (i != 0 && ascii == previousAscii)
                        {
                            index = rand.Next(0, passwordCharacters.Length);
                            if (passwordCharacters.Length == 1)
                            {
                                flag = true;
                                break;
                            }
                            ascii = (int)passwordCharacters[index];
                        }
                    }
                    if (flag == true)
                    {
                        sb = sb.Insert(i-1, passwordCharacters[index]);
                    }
                    else
                    {
                        sb = sb.Append(passwordCharacters[index]);
                    }
                    if (chkDups.IsChecked == true)
                    {
                        passwordCharacters = passwordCharacters.Replace(passwordCharacters[index].ToString(), "");
                    }
                }
            }
            passwordText.Text = sb.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            Random rand = new Random();
            Random randIValue = new Random();
            string passwordCharacters = @"~!@#$%^&*_-+=`|\(){}[]:;'<>,.?/abcdefghijklmnopqrstuvwxyz1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int t = 0;
            string temp = String.Empty;

            //Checks No Similar Checkbox
            if (chkSimilar.IsChecked == true)
            {
                passwordCharacters = @"!#$%&'()*+,-./23456789:;<=>?@ABCDEFGHJKLMNPRSTUVWXYZ[\]^_abcdefghjkmnpqrstuvwxyz{}~";
            }

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
            if (chkStartLetter.IsChecked == true && (chkUpper.IsChecked == true || chkLower.IsChecked == true))
            {
                temp = passwordCharacters;
                foreach (char c in temp)
                {
                    if (!Char.IsLetter(c))
                    {
                        temp = temp.Replace(c.ToString(), "");
                    }
                }
                int index = rand.Next(0, temp.Length);
                sb = sb.Append(temp[index]);
                t = t - 1;
                passwordCharacters = passwordCharacters.Replace(temp[index].ToString(), "");
            }

            generatePW(rand, t, passwordCharacters, sb);
        }
    }
}
