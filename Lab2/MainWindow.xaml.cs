using System.Windows;
using System.Windows.Input;

namespace Lab2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            CommandBindings.Add(new CommandBinding(ApplicationCommands.Save,
                Execute_Save, CanExecute_Save));

            CommandBindings.Add(new CommandBinding(ApplicationCommands.Open,
                Execute_Open, CanExecute_Always));

            CommandBindings.Add(new CommandBinding(ApplicationCommands.Delete,
                Execute_Clear, CanExecute_Always));
        }

        // --- Save ---
        private void CanExecute_Save(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = txtDocument.Text.Trim().Length > 0;

        private void Execute_Save(object sender, ExecutedRoutedEventArgs e)
        {
            System.IO.File.WriteAllText("myFile.txt", txtDocument.Text);
            MessageBox.Show("Файл збережено!");
        }

        // --- Open ---
        private void CanExecute_Always(object sender, CanExecuteRoutedEventArgs e)
            => e.CanExecute = true;

        private void Execute_Open(object sender, ExecutedRoutedEventArgs e)
        {
            var dlg = new Microsoft.Win32.OpenFileDialog { Filter = "Text files|*.txt|All|*.*" };
            if (dlg.ShowDialog() == true)
                txtDocument.Text = System.IO.File.ReadAllText(dlg.FileName);
        }

        // --- Clear ---
        private void Execute_Clear(object sender, ExecutedRoutedEventArgs e)
            => txtDocument.Clear();
    }
}
