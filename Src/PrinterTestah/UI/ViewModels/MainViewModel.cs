using Business.Models;
using Business.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using UI.Commands;
using UI.Views;

namespace UI.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private UserControl _currentView;
        public UserControl CurrentView
        {
            get => _currentView;
            set
            {
                if (_currentView != value)
                {
                    _currentView = value;
                    OnPropertyChanged(nameof(CurrentView));
                }
            }
        }

        public ObservableCollection<PrinterInfo> Printers { get; }

        private PrinterInfo _selectedPrinter;
        public PrinterInfo SelectedPrinter
        {
            get => _selectedPrinter;
            set
            {
                if (_selectedPrinter != value)
                {
                    _selectedPrinter = value;
                    OnPropertyChanged(nameof(SelectedPrinter));
                    OnPropertyChanged(nameof(CurrentPrinter));
                }
            }
        }

        public PrinterInfo CurrentPrinter => SelectedPrinter;

        private string _testResult;
        public string TestResult
        {
            get => _testResult;
            set
            {
                if (_testResult != value)
                {
                    _testResult = value;
                    OnPropertyChanged(nameof(TestResult));
                }
            }
        }

        // Commands
        public ICommand RefreshCommand { get; }
        public ICommand GoToTestCommand { get; }
        public ICommand BackCommand { get; }
        public ICommand RunTestCommand { get; }
        public ICommand PrintCommand { get; }

        // Views
        public PrinterListView PrinterListView { get; }
        public PrinterTestView PrinterTestView { get; }

        public MainViewModel()
        {
            Printers = new ObservableCollection<PrinterInfo>();

            PrinterListView = new PrinterListView();
            PrinterTestView = new PrinterTestView();

            CurrentView = PrinterListView;

            // Commands
            RefreshCommand = new RelayCommand(RefreshPrinters);
            RefreshCommand.Execute(null); // Initial load
            GoToTestCommand = new RelayCommand(_ => NavigateToPrinterTest());
            BackCommand = new RelayCommand(_ => NavigateToPrinterList());
            RunTestCommand = new RelayCommand(_ => RunTest());
            PrintCommand = new RelayCommand(_ => PrintTestPage());
        }

        private void RefreshPrinters(object parameter)
        {
            var manager = new TestManager();
            manager.RefreshPrinters();

            Printers.Clear();
            foreach (var p in manager.Printers)
                Printers.Add(p);
        }

        private void RunTest()
        {
            if (SelectedPrinter == null) return;

            // Example logic: test printer (fake for demo)
            TestResult = "PASS"; // or "FAIL" based on logic
        }

        private void PrintTestPage()
        {
            if (SelectedPrinter == null) return;

            var manager = new TestManager();
            manager.PrintTestPage(SelectedPrinter.Name);
            TestResult = "Printed Test Page";
        }

        public void NavigateToPrinterTest()
        {
            CurrentView = PrinterTestView;
        }

        public void NavigateToPrinterList()
        {
            CurrentView = PrinterListView;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
