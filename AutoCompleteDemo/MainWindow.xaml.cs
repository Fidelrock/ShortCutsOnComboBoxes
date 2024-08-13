using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace AutoCompleteDemo
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private string _selectedTransactionType;

        public MainWindow()
        {
            InitializeComponent();

            // Sample data for AutoComplete
            var firstNames = new List<string> { "Alice", "Bob", "Charlie", "David", "Eve" };
            var lastNames = new List<string> { "Smith", "Johnson", "Williams", "Brown", "Jones" };
            var cities = new List<string> { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix" };
            var countries = new List<string> { "USA", "Canada", "UK", "Australia", "Germany" };

            // Assign the data to each ComboBox
            AutoCompleteBox1.ItemsSource = firstNames;
            AutoCompleteBox2.ItemsSource = lastNames;
            AutoCompleteBox3.ItemsSource = cities;
            AutoCompleteBox4.ItemsSource = countries;

            // Set DataContext for data binding
            DataContext = this;

            // Attach the KeyDown event handler
            this.KeyDown += MainWindow_KeyDown;
        }

        public string SelectedTransactionType
        {
            get { return _selectedTransactionType; }
            set
            {
                _selectedTransactionType = value;
                OnPropertyChanged();
            }
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if Ctrl + T is pressed
            if (e.Key == Key.T && Keyboard.Modifiers == ModifierKeys.Control)
            {
                // Focus on the TransactionTypeComboBox
                TransactionTypeComboBox.Focus();
            }
        }

        private void TransactionTypeComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Handle selection change if needed
        }

        // Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
