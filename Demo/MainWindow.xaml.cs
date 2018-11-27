using Serilog;
using System.Windows;

namespace Demo
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //const string customTemplate = "Not Logged {Timestamp: yyyy-MM-dd HH:mm:ss.ff zzz} [{Level}] {Message}{NewLine}{Exception}";

            ILogger logger = new LoggerConfiguration()
                                    .WriteTo.Console()
                                    .CreateLogger();

            //Static property to save configured logger instance
            Log.Logger = logger;
        }

        private void AddUser_OnClick(object sender, RoutedEventArgs e)
        {            
            // add user to database            
            MessageBox.Show("User added");

            string name = Name.Text;
            int age = int.Parse(Age.Text);

            // log some information        
            Log.Information("Added User {UserName}, Age {UserAge}", name, age);
            
        }
    }
}
