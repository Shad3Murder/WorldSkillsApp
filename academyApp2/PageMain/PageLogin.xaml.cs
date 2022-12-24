using academyApp2.ApplicationData;
using System;
using academyApp2.PageAdmin;
using academyApp2.PageStudent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace academyApp2.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                var userObj = AppConnect.model1db.User.FirstOrDefault(x => x.Login == txbLogin.Text && x.Password == psbPassword.Password);
                if (userObj == null)
                {
                    MessageBox.Show("Такого пользователя нет!", "Ошибка при авторизации!", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                else
                {
                    switch (userObj.IdRole)
                    {
                        case 1:
                            AppFrame.frameMain.Navigate(new PageAdminMenu());
                            MessageBox.Show("Здравствуйте, администратор " + userObj.Name + "!",
                         "Уведомение", MessageBoxButton.OK, MessageBoxImage.Information);
                            
                            break;
                        case 2:
                            AppFrame.frameMain.Navigate(new PageAccountStudent());
                            MessageBox.Show("Здравствуйте, ученик " + userObj.Name + "!",
                         "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                            
                            break;
                        default:
                            MessageBox.Show("Данные не обнаружены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                    }
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show("Ошибка" + Ex.Message.ToString() + "Критическая ошибка приложения!",
                    "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void reg_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.Navigate(new PageCreateAcc());
        }


    }
    
}
