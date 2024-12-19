using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Robust.Model.Product;
using Robust.MVVM.ViewModelBase;
using Robust.ViewModel.RelayCommands;
using Robust.Model.Customer;
using Robust.Model.CartItem;
using Robust.Repositories;
using Robust.Repositories.Interface;
using Microsoft.Data.SqlClient;
using Robust.Repositories.Database;
using System.Data;
using System.Security.AccessControl;
using System.Transactions;
using System.Data.Common;
using Microsoft.VisualBasic;
using Robust.Repositories.CheckoutRepository;
using Robust.ViewModel.User;

namespace Robust.ViewModel.CheckoutViewModel
{
    public class CheckoutViewModel : ViewModelBase
    {
        private CustomerRepository _customerRepository;
        private CartRepository _cartRepository;
        private CheckoutRepository _checkoutRepository;
        
        public decimal TotalPrice { get; set; }
        public Customer SelectedCustomer { get; set; }
        public ObservableCollection<CartItem> ShoppingCartList { get; set; }
        
        public CheckoutViewModel()
        {
            _customerRepository = new();
            _cartRepository = new();
            _checkoutRepository = new();
            //Check for security problems
            SelectedCustomer = _customerRepository.GetByID(UserStore.username, UserStore.password);
            ShoppingCartList = _cartRepository.GetAll(UserStore.username, UserStore.password);
            TotalPrice = 0;
            CalculateTotalPrice();
        }

        public void CalculateTotalPrice()
        {
            for (int i = 0; i < ShoppingCartList.Count; i++)
            {
                CartItem item = ShoppingCartList[i];
                TotalPrice += item.Price * item.Quantity;
            }
        }

        public RelayCommand CheckoutCmd => new RelayCommand(Checkout, CanCheckout);      

        private bool CanCheckout() => _cartRepository.GetAll(UserStore.username, UserStore.password).Count > 0;
        
        private void Checkout()
        {
            if (_checkoutRepository.Checkout())
            {
                MessageBox.Show("Tak for din ordre! Hav en god dag!");
            }
            else
            {
                MessageBox.Show("Der skete desværre en fejl - ordren blev ikke oprettet - kontakt venligst kundeservice!");
            }
        }
    }
}
