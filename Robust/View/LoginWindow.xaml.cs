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
using System.Windows.Shapes;
using Robust.ViewModel.Login;

namespace Robust.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private void CreateShoppingCartImage()
        {
            Image image = new()
            {
                Width = 40,
                Height = 40
            };

            string imagePath = $"{AppDomain.CurrentDomain.BaseDirectory}/images/ShoppingCartWebShop.webp";
            image.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));

            ShoppingCartButton.Content = image;
        }

        private void CreateLoginCartImage()
        {
            Image image = new()
            {
                Width = 40,
                Height = 40
            };

            string imagePath = $"{AppDomain.CurrentDomain.BaseDirectory}/images/Login.webp";
            image.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));

            LoginWindowButton.Content = image;
        }


        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
            CreateLoginCartImage();
            CreateShoppingCartImage();
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            //According to https://stackoverflow.com/questions/1483892/how-to-bind-to-a-passwordbox-in-mvvm
            if (this.DataContext != null)
            {
                ((dynamic)this.DataContext).Password = ((PasswordBox)sender).Password;
            }
        }
    }
}
