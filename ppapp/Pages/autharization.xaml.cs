using ppapp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
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
using System.Data.SqlClient;

namespace ppapp.Pages
{
    /// <summary>
    /// Логика взаимодействия для autharization.xaml
    /// </summary>
    public partial class autharization : Page
    {
        public autharization()
        {
            InitializeComponent();
        }

        DB.AppContext appContext = new DB.AppContext();

        private void log_in_Load(object sender, RoutedEventArgs e)
        {
            //максимальное кол-во символов
            textbox_password.MaxLength = 50;
            textbox_login.MaxLength = 50;




        }
        private void admin_btn_Click(object sender, RoutedEventArgs e)
        {
            //событие при нажатии на кнопку Администратор. логин admin, пороль 1234


            var loginUser = textbox_login.Text;
            var passwordUser = textbox_password.Text;


            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            //строка запросa к БД
            string querystring = $"SELECT * FROM [User] WHERE login_user= '{loginUser}' and password= '{passwordUser}'";

            SqlCommand command = new SqlCommand(querystring, appContext.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {
                
                ClassFrame.authFrame.Navigate(new MainPage());


            }
            else
            {
                MessageBox.Show("Поля заполнены некорректно.", "Ошибка!", MessageBoxButton.OK);
            }



        }

        private void go_to_regist_btn_Click(object sender, RoutedEventArgs e)
        {
            ClassFrame.authFrame.Navigate(new Registration()); //отправляет на страницу регистрации
        }


        private void user_btn_Click(object sender, RoutedEventArgs e)//вход для зарегистрированного пользователя
        {
            
            var loginUser = textbox_login.Text;
            var passwordUser = textbox_password.Text;


            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();

            //строка запросa к БД
            string querystring = $"SELECT * FROM [User1] WHERE login_user= '{loginUser}' and password= '{passwordUser}'";

            SqlCommand command = new SqlCommand(querystring, appContext.GetConnection());

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count == 1)
            {

                ClassFrame.authFrame.Navigate(new MainPage());


            }
            else
            {
                MessageBox.Show("Поля заполнены некорректно.", "Ошибка!", MessageBoxButton.OK);
            }
        }

       
    }
}
