using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Oracle.ManagedDataAccess.Client;

namespace DBSGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string user = "carhouseuser";
        public static string pwd = "strongPW123";

        //Set the net service name, Easy Connect, or connect descriptor of the pluggable DB, 
        // such as "localhost/XEPDB1" for 18c XE or higher
        public static string db = "<localhost/xe>";

        public MainWindow()
        {
            InitializeComponent();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string conStringUser = "User Id=" + user + ";Password=" + pwd + ";Data Source=" + db + ";";

            using (OracleConnection con = new OracleConnection("TNS_ADMIN=C:\\Users\\exploFH\\Oracle\\network\\admin;USER ID = CARHOUSEUSER;" + " Password = " + pwd + "; DATA SOURCE = localhost:11521/xe;PERSIST SECURITY INFO=True"))
            {
                using (OracleCommand cmd = con.CreateCommand())
                {

                        con.Open();
                        Console.WriteLine("Successfully connected to Oracle Database as " + user);
                        Console.WriteLine();

                        //Retrieve sample data
                        cmd.CommandText = "SELECT * FROM Auto";
                        OracleDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.GetBoolean(1))
                                Console.WriteLine(reader.GetString(0) + " is done.");
                            else
                                Console.WriteLine(reader.GetString(0) + " is NOT done.");
                        }


                        reader.Dispose();

                }
            }
        }
    }
}
