using HoangTranManhDungWPF.Views;
using HoangTranManhDungWPF.Views;
using System; // <-- Thêm
using System.Windows;

namespace HoangTranManhDungWPF
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            try
            {
                base.OnStartup(e);

                LoginWindow loginWindow = new LoginWindow();
                loginWindow.Show();
            }
            catch (Exception ex)
            {
                Application.Current.Shutdown();
            }
        }
    }
}