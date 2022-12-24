using academyApp2.ApplicationData;
using System.Windows;
using System.Windows.Controls;

namespace academyApp2.PageAdmin
{
    /// <summary>
    /// Логика взаимодействия для PageAdminMenu.xaml
    /// </summary>
    public partial class PageAdminMenu : Page
    {
        public PageAdminMenu()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }
    }
}
