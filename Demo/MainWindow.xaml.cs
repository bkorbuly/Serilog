using Demo.Properties;
using Serilog;
using System;
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
                                    .Destructure.ByTransforming<Color>(x => new { x.Red, x.Green })
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
            DateTime dateAdded = DateTime.Now;

            Color favColor = new Color
                {
                    Red = 122,
                    Green = 24,
                    Blue = 19
                };
            // log some information        
            Log.Information("Added User {UserName:l}, Age {UserAge}. Favourite {@Color} Added on {Created} - {ID}",  name, age, favColor, dateAdded, Guid.NewGuid());
            
        }
    }
}
