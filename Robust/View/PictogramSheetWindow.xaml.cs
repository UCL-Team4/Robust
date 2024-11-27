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
using Robust.Enums.Category;
using Robust.Model.Product;
using Robust.ViewModel;

namespace Robust.View
{
    /// <summary>
    /// Interaction logic for PictogramSheetWindow.xaml
    /// </summary>
    public partial class PictogramSheetWindow : Window
    {
        private PictogramSheetViewModel _pictogramSheetViewModel;
        
        public PictogramSheetWindow()
        {
            InitializeComponent();
            _pictogramSheetViewModel = new PictogramSheetViewModel();
            DataContext = _pictogramSheetViewModel;
        }

        private void DropPanel_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                Uri filepath = new Uri(files[0]);
                string filepathAsString = filepath.ToString();
                Product CustomImage = new Product() { ImagePath = filepathAsString, Category = Category.EgnePiktogrammer };

                _pictogramSheetViewModel.Products.Add(CustomImage);
            }
        }
    }
}
