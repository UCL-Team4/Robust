using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Robust.MVVM.ViewModelBase;

public class ViewModelBase
{
    public event PropertyChangedEventHandler? PropertyChanged;

    /// <summary>
    /// Notifies WPF when properties change
    /// </summary>
    /// <param name="propertyName"></param>
    protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
