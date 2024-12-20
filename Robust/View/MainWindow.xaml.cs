using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Robust.Service;
using Robust.ViewModel.ProductViewModel;

namespace Robust.View.MainWindow;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
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
    public MainWindow()
    {
        InitializeComponent();

        DataContext = new ProductViewModel();
        CreateShoppingCartImage();
        CreateLoginCartImage();
    }
}