using academyApp2.ApplicationData;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace academyApp2.PageMain
{
    /// <summary>
    /// Логика взаимодействия для PageCreateAcc.xaml
    /// </summary>
    public partial class PageCreateAcc : Page
    {
        public PageCreateAcc()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AppFrame.frameMain.GoBack();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (AppConnect.model1db.User.Count(x => x.Login == txbLogin.Text) > 0)
            {
                MessageBox.Show("Пользователь с таким логином уже есть!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            try
            {
                User userObj = new User()
                {
                    Login = txbLogin.Text,
                    Name = txbName.Text,
                    Password = txbPass.Text,
                    IdRole = 2
                };
                AppConnect.model1db.User.Add(userObj);
                AppConnect.model1db.SaveChanges();
                MessageBox.Show("Данные успешно добавлены!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch
            {
                MessageBox.Show("Ошибка при регистрации!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (psbPass.Password != txbPass.Text)
            {
                btnCreate.IsEnabled = false;
                psbPass.Background = Brushes.LightCoral;
                psbPass.BorderBrush = Brushes.Red;
            }
            else
            {
                btnCreate.IsEnabled = true;
                psbPass.Background = Brushes.LightGreen;
                psbPass.BorderBrush = Brushes.Green;
            }
        }


    }
}
