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

    //Test
    private readonly Predicate<object> _canExecute;
    private readonly Action<object> _action;
    public RelayCommand(Action<object> action) { _action = action; _canExecute = null; }
    public RelayCommand(Action<object> action, Predicate<object> canExecute) { _action = action; _canExecute = canExecute; }
    public void Execute(object? o) => _action(o);
    public bool CanExecute(object? o) => _canExecute == null ? true : _canExecute(o);
    //

    //public bool CanExecute(object? parameter)
    //{
    //    return _CANEXECUTE();
    //}

    //public void Execute(object? parameter)
    //{
    //    _EXECUTE();
    //}
}