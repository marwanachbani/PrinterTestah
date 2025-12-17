using System.Windows.Input;
using UI.Commands;

namespace UI.ViewModels
{
    public class PrinterTestViewModel
    {
        private readonly MainViewModel _main;

        public ICommand BackCommand { get; }

        public PrinterTestViewModel(MainViewModel main)
        {
            _main = main;
            BackCommand = new RelayCommand(_ => _main.NavigateToPrinterList());
        }
    }
}
