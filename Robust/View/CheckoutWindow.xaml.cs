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
using Robust.ViewModel.CheckoutViewModel;

namespace Robust.View
{
    /// <summary>
    /// Interaction logic for CheckoutWindow.xaml
    /// </summary>
    public partial class CheckoutWindow : Window
    {
        public CheckoutWindow()
        {
            InitializeComponent();
            DataContext = new CheckoutViewModel();

            string partialImagePath = $"{AppDomain.CurrentDomain.BaseDirectory}/images";

            AddDeliveryOption("GLS pakkeshop (28.00 DKK)", $"{partialImagePath}/GLS.webp", true);
            AddDeliveryOption("GLS erhverv (28.00 DKK)", $"{partialImagePath}/GLS.webp", false);
        }


        private void AddDeliveryOption(string text, string imagePath, bool isChecked)
        {
            WrapPanel wrapPanel = new WrapPanel();

            TextBlock textBlock = new TextBlock
            {
                Text = text
            };
            wrapPanel.Children.Add(textBlock);

            Image image = new Image
            {
                Width = 40,
                Margin = new Thickness(5, 0, 0, 0),
                Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute))
            };
            wrapPanel.Children.Add(image);

            RadioButton radioButton = new RadioButton
            {
                Margin = new Thickness(0, 0, 0, 5),
                GroupName = "Delivery",
                IsChecked = isChecked,
                Content = wrapPanel
            };

            DeliveryOptionsContainer.Children.Add(radioButton);
        }
    }
}
