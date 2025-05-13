namespace Editor.Views
{
    using Editor.Models;
    using Editor.ViewModels;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;

    /// <summary>
    /// Interaktionslogik für MainView.xaml
    /// </summary>
    public partial class MainView : Page
    {
        private readonly Window window;

        public MainView(Window window)
        {
            InitializeComponent();
            this.window = window;
        }

        private void Editor_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is Document document)
            {
            }

            MessageBox.Show("ned so lol");
        }

        private void Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is TextBox document)
            {
            }
        }

        private static readonly HashSet<string> Keywords =
        [
            "abstract","as","base","bool","break","byte","case","catch","char","checked",
            "class","const","continue","decimal","default","delegate","do","double","else",
            "enum","event","explicit","extern","false","finally","fixed","float","for",
            "foreach","goto","if","implicit","in","int","interface","internal","is","lock",
            "long","namespace","new","null","object","operator","out","override","params",
            "private","protected","public","readonly","ref","return","sbyte","sealed",
            "short","sizeof","stackalloc","static","string","struct","switch","this",
            "throw","true","try","typeof","uint","ulong","unchecked","unsafe","ushort",
            "using","virtual","void","volatile","while"
        ];

        private void Minimize_Click(object sender, RoutedEventArgs e)
        {
            this.window.WindowState = WindowState.Minimized;
        }

        private void Maximize_Click(object sender, RoutedEventArgs e)
        {
            this.window.WindowState = (this.window.WindowState == WindowState.Maximized) ? WindowState.Normal : WindowState.Maximized;
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            this.window.Close();
        }
    }
}
