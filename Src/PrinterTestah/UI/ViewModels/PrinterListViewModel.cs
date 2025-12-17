using System.Windows.Input;
using UI.Commands;
using UI.Views;

namespace UI.ViewModels
{
    public class PrinterListViewModel
    {
        private readonly MainViewModel _main;

        public ICommand GoToTestCommand { get; }

        public PrinterListViewModel(MainViewModel main)
        {
            _main = main;
            GoToTestCommand = new RelayCommand(_ => _main.NavigateToPrinterTest());
        }
    }
}
