using System;
using System.Windows;
using System.Windows.Controls;
using LocalizedEnumBindingExample.Enums;

namespace LocalizedEnumBindingExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as ComboBox)?.SelectedItem is Language languageEnum)
            {
                RestartApp(languageEnum);
            }
        }

        private static void RestartApp(Language lang)
        {
            //You can get this one from installed cultures
            string ietfLangTag = lang switch
            {
                Enums.Language.Bg => "bg-Bg",
                Enums.Language.En => "en-En",
                _ => throw new ArgumentOutOfRangeException(nameof(lang), lang, null)
            };

            //This will work only in DEBUG mode!
            string exePath = Application.ResourceAssembly.Location.Replace("dll", "exe");

            //ietfLangTag passed here as an argument and will be used from App class to set new language after restaring the application with.
            System.Diagnostics.Process.Start(exePath, ietfLangTag);
            Application.Current.Shutdown();
        }
    }
}
