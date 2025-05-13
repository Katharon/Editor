namespace Editor
{
    using Editor.Services;
    using Editor.ViewModels;
    using Editor.Views;
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IApplicationService applicationService = new ApplicationService();
        private readonly IDialogService dialogService = new DialogService();
        private readonly IExtensionService extensionService = new ExtensionService();

        public MainWindow()
        {
            InitializeComponent();

            var mainView = new MainView(this)
            {
                DataContext = new MainViewModel(this.applicationService, this.dialogService, this.extensionService)
            };

            this.MainFrame.Navigate(mainView);
        }
    }
}