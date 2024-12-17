using Robust.MVVM.ViewModelBase;
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
        // Paste this shit in and make it bounce

        if (Email != null)
        {
            int? customerId = _userRepository.Login(Email, Password);

            if (customerId != null && customerId > 0)
            {
                UserStore.username = Email;
                UserStore.password = Password;
            }
        }
    }

    private bool CanLogIn() => !string.IsNullOrEmpty( Password ) && !string.IsNullOrEmpty(Email);

    public LoginViewModel()
    {
        _userRepository = new UserRepository();
    }
}
