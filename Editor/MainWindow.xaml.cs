namespace Editor
{
    using Editor.Views;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var view = new MainView();
            this.MainFrame.Navigate(view);
        }
    }
}