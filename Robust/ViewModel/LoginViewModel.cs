using Robust.MVVM.ViewModelBase;
using Robust.Repositories.Interface;
using Robust.Repositories.User;
using Robust.ViewModel.RelayCommands;
using Robust.ViewModel.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Robust.ViewModel.Login;

public class LoginViewModel : ViewModelBase
{
    private UserRepository _userRepository;

    public string Password { private get; set; }

	private string _email;

	public string Email
	{
		get { return _email; }
		set { 
			_email = value;
			OnPropertyChanged();
		}
	}


    public RelayCommand LoginToSiteCmd => new RelayCommand(LoginToSite, CanLogIn);

    private void LoginToSite()
    {
        int? customerId = _userRepository.Login(Email, Password);

        if (customerId != null && customerId > 0)
        {
            UserStore.username = Email;
            UserStore.password = Password;
            MessageBox.Show("Du er nu logget ind!");
        } else
        {
            MessageBox.Show("Forkert Email eller Adgangskode!");
        }
    }

    private bool CanLogIn() => !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(UserStore.password);


    public RelayCommand RegisterCmd => new RelayCommand(RegisterAccount, CanLogIn);

    private void RegisterAccount()
    {
        bool success = _userRepository.Register(Email, Password);

        if (success)
        {
            MessageBox.Show("Registrering fuldført!");
            UserStore.username = Email;
            UserStore.password = Password;
        }
        else
        {
            MessageBox.Show("Registrering mislykkedes. Brugeren findes allerede.");
        }
    }

    public LoginViewModel()
    {
        _userRepository = new UserRepository();
    }
}
