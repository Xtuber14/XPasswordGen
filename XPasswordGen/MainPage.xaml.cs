using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using System.Windows;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation.Metadata;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PasswordGen
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        private string GenerateRandomPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()";
            Random random = new Random();

            char[] passwordChars = new char[length];
            for (int i = 0; i < length; i++)
            {
                passwordChars[i] = validChars[random.Next(validChars.Length)];
            }

            return new string(passwordChars);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton.Name == "Generate")
            {
                int passwordLength = 10;
                string password = GenerateRandomPassword(passwordLength);
                PasswordText.Text = password;
            }
            
            if (clickedButton.Name == "CopyButton")
            {
                string PasswordCopy = PasswordText.Text.ToString();
                DataPackage dataPackage = new DataPackage();
                dataPackage.SetText(PasswordCopy);
                Clipboard.SetContent(dataPackage);
            }
            
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {
            
        }
        public void CopyButton_Click(object sender, RoutedEventArgs e)
        {
            
            
        }
    }
}
