using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Taxi_Manage
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            show();
            showtotal();

        }
        public void show()
        {
            try
            {
                string connectionString = "DATA SOURCE=localhost:1521/ORCL;USER ID=SYSTEM;Password=2433;";
                OracleConnection conn = new OracleConnection(connectionString);

                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM log";
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                transaction.ItemsSource = dt.DefaultView;
                dr.Close();







            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "DATA SOURCE=localhost:1521/ORCL;USER ID=SYSTEM;Password=2433;";
                OracleConnection conn = new OracleConnection(connectionString);
                int num = int.Parse(taxiNumber.Text);
                conn.Open();
                OracleCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM log where taxi_number="+num;
                cmd.CommandType = CommandType.Text;
                OracleDataReader dr = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(dr);
                transaction.ItemsSource = dt.DefaultView;
                dr.Close();
                showTaxiTotal(num);







            }
            catch (Exception ex)
            {
                MessageBox.Show("No taxi information found");
            }
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            show();
        }
        public void showtotal()
        {
            string connectionString = "DATA SOURCE=localhost:1521/ORCL;USER ID=SYSTEM;Password=2433;";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT SUM(amount) FROM log";

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        int count = Convert.ToInt32(result);
                        companyTotal.Content = count.ToString();
                    }
                }
            }

            
            
           
        
           


        }
        public void showTaxiTotal(int num)
        {
            tn_label1.Content = num.ToString();
            string connectionString = "DATA SOURCE=localhost:1521/ORCL;USER ID=SYSTEM;Password=2433;";

            using (OracleConnection connection = new OracleConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT SUM(amount) FROM log WHERE taxi_number="+num;

                using (OracleCommand command = new OracleCommand(query, connection))
                {
                    object result = command.ExecuteScalar();

                    if (result != null)
                    {
                        int count = Convert.ToInt32(result);
                        tp_label.Content = count.ToString();
                    }
                }
            }
        }
    }
}
