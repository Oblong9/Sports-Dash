using MongoDB.Driver;
using SportsDash.Models.UserPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
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

namespace SportsDash.View
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {

        
        public readonly static string connection = "mongodb+srv://Admin:4QkogfPCCsX@atlascluster.oszbuoa.mongodb.net/test";
        public readonly static string dbName = "sportsdash";
        public readonly static string collectionName = "user";

        // This is connected to database

        static MongoClient client = new MongoClient(connection);
        static IMongoDatabase db = client.GetDatabase(dbName);
        static IMongoCollection<Account> collection = db.GetCollection<Account>(collectionName);

        Account newAccount = new Account("User", "password", "email@email.com");
        public LoginView()
        {
            InitializeComponent();
        }

        private void SneakyButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Hide();
            _ = addUser(newAccount);
        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignupView signupView = new SignupView();
            signupView.Show();
            this.Hide();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public async Task addUser(Account user)
        {
            await collection.InsertOneAsync(user);
        }

    }
}
