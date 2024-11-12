using System.Windows.Input;

namespace Robust.ViewModel.RelayCommands;

public class RelayCommand : ICommand
{
    private readonly Action _EXECUTE;
    private readonly Func<bool> _CANEXECUTE;

    public event EventHandler? CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        _EXECUTE = execute;
        _CANEXECUTE = canExecute ?? (() => true);
    }

    public bool CanExecute(object? parameter)
    {
        return _CANEXECUTE();
    }

    public void Execute(object? parameter)
    {
        _EXECUTE();
    }
}