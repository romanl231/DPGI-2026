using System.Windows;

namespace Lab3
{
    public partial class MainWindow : Window
    {
        private static readonly string[] Answers = { "Так", "Ні", "Скоріше так", "Скоріше ні" };
        private static readonly Random Rng = new();
        private const string Placeholder = "Введіть ваше запитання...";

        public MainWindow() => InitializeComponent();

        private void BtnAsk_Click(object sender, RoutedEventArgs e)
            => lblAnswer.Text = Answers[Rng.Next(Answers.Length)];

        private void TxtQuestion_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txtQuestion.Text == Placeholder)
                txtQuestion.Text = "";
        }

        private void TxtQuestion_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtQuestion.Text.Trim().Length == 0)
                txtQuestion.Text = Placeholder;
        }
    }
}
