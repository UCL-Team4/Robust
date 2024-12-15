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
using System.IO;
using Robust.ViewModel.PictogramSheetViewModel;

namespace Robust.View;

/// <summary>
/// Interaction logic for PictogramSheetWindow.xaml
/// </summary>
public partial class PictogramSheetWindow : Window
{
    //private PictogramSheetViewModel _pictogramSheetViewModel;
    
    public PictogramSheetWindow()
    {
        InitializeComponent();
        //_pictogramSheetViewModel = new PictogramSheetViewModel();
        //DataContext = _pictogramSheetViewModel;
        DataContext = new PictogramSheetViewModel();
    }

    ////This event handler is used when the user drags and drops an image on the upload image.
    //private void UploadPictogram_Drop(object sender, DragEventArgs e)
    //{
    //    if (e.Data.GetDataPresent(DataFormats.FileDrop))
    //    {
    //        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

    //        Uri filepath = new Uri(files[0]);
    //        string filepathAsString = filepath.ToString();
    //        string ext = System.IO.Path.GetExtension(filepathAsString);

    //        //Checks that the file is an image before the Product object is created
    //        if (ext == ".jpg" || ext == ".jpeg" || ext == ".png")
    //        {
    //            Product CustomImage = new() { Name = "Custom", ImagePath = filepathAsString, Category = Category.EgnePiktogrammer, Price = 20.75M };

    //            //_pictogramSheetViewModel.Products.Add(CustomImage);
    //            //_pictogramSheetViewModel.SelectedCategory = Category.EgnePiktogrammer;
    //            _pictogramSheetViewModel.AddToDatabase(CustomImage);
    //        }
    //        else
    //        {
    //            MessageBox.Show("Du har desværre valgt et ugyldigt billedformat - du kan kun bruge .jpg, .jpeg og .png. Prøv igen!");
    //        }
    //    }
    //}
}
