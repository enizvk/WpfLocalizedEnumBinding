using System.Globalization;
using System.Threading;
using System.Windows;

namespace LocalizedEnumBindingExample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            //We expect ietfLanguage tag which is passed as an argument on program close
            if (e.Args.Length > 0)
                SetApplicationGlobalCultureInfo(e.Args[0]);

            base.OnStartup(e);
        }

        /// <summary>
        /// Changes application culture globally
        /// </summary>
        /// <param name="ietfLanguageTag">iso standart language tag</param>
        private static void SetApplicationGlobalCultureInfo(string ietfLanguageTag)
        {

            CultureInfo cultureInfo = new(ietfLanguageTag);

            //Change app culture
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}
