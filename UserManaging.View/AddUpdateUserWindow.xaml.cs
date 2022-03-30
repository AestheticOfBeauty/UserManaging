using System;
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
using System.Windows.Shapes;
using UserManaging.Model;

namespace UserManaging.View
{
    public partial class AddUpdateUserWindow : Window
    {
        private readonly User _user;
        UsersDAL dAL = new UsersDAL();
        UserManagingWindow mainWindow;

        public AddUpdateUserWindow(User user, UserManagingWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
            _user = InitializeUser(user);
          
        }

        /// <summary>
        /// Инициализирует пользователя
        /// </summary>
        private User InitializeUser(User user)
        {
            if (user is null)
            {
                InitializeButtonsVisibility(Visibility.Visible, 
                                            Visibility.Collapsed, 
                                            Visibility.Collapsed);
                return new User();
            }
            else
            {
                InitializeButtonsVisibility(Visibility.Collapsed,
                                            Visibility.Visible,
                                            Visibility.Visible);
                FirstName.Text = user.FirstName;
                MiddleName.Text = user.MiddleName;
                LastName.Text = user.LastName;
                Phone.Text = user.Phone;
                Email.Text = user.Email;
                return user;
            }
        }
        /// <summary>
        /// Инициализирует видимость кнопок
        /// </summary>
        private void InitializeButtonsVisibility(Visibility addButtonVisibility, Visibility updateButtonVisibility,
            Visibility deleteButtonVisibility)
        {
            AddUserButton.Visibility = addButtonVisibility;
            UpdateUserButton.Visibility = updateButtonVisibility;
            DeleteUserButton.Visibility = deleteButtonVisibility;
        }
        /// <summary>
        /// 
        /// </summary>
        private void UpdateUser(object sender, RoutedEventArgs e)
        {
            LoadUsersData(_user);
            try
            {
                dAL.Update(_user);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            mainWindow.UsersListView.ItemsSource = dAL.GetUsers();
            this.Close();
            
        }
        /// <summary>
        /// 
        /// </summary>
        private void AddUser(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadUsersData(_user);
                dAL.Insert(_user);
                mainWindow.UsersListView.ItemsSource = dAL.GetUsers();
                this.Close();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            LoadUsersData(_user);
            try
            {
                dAL.Delete((int)_user.Id);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,
                                "Error",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
            }
            mainWindow.UsersListView.ItemsSource = dAL.GetUsers();
            this.Close();
        }

        private void LoadUsersData(User user)
        {
            user.FirstName = FirstName.Text;
            user.MiddleName = MiddleName.Text;
            user.LastName = LastName.Text;
            user.Phone = Phone.Text;
            user.Email = Email.Text;
        }
    }
}
