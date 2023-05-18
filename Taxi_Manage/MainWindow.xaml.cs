using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
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
using Oracle.ManagedDataAccess.Client;

namespace Taxi_Manage
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime currentDateTime = DateTime.Now;
        Rank rank = new Rank();
        public List<String> logs = new List<String>();
        public MainWindow()
        {
            InitializeComponent();
            taxis.Items.Add("Number" + "_" + "Location" + "_" + "Rank");

        }

        private void add_rank_Click(object sender, RoutedEventArgs e)
        {
            string inputText = taxi_number.Text;
            
            try
            {
                int taxiNumber = int.Parse(inputText);
                if (rank.taxis.ContainsKey(taxiNumber))
                {
                   
                    if (rank.rank.Contains(rank.taxis[taxiNumber])|| rank.taxis[taxiNumber].getDestination()!=null)
                    {
                        MessageBox.Show("Taxi is alerady in rank or in a running fare");
                    }
                    else
                    {
                        rank.taxis[taxiNumber].setinRank(rank.rank.Count);
                        rank.AddTaxi(rank.taxis[taxiNumber]);
                        MessageBox.Show("Taxi number : " + taxiNumber + " added to rank");

                        addData(taxiNumber, "Added to rank", currentDateTime.ToString(), 0, null);

                    }
                    
                }
                else
                {
                    taxi t = new taxi(taxiNumber);
                    rank.taxis.Add(taxiNumber, t);
                    rank.AddTaxi(t);
                    rank.taxis[taxiNumber].setinRank(rank.rank.Count);
                    MessageBox.Show("Taxi number : " + taxiNumber + " added to rank");
                    
                    string sql = "INSERT INTO log(TAXI_NUMBER,TR_TYPE, TIME_DATE, AMOUNT,DESTINATION) VALUES(:TAXI_NUMBER, :TR_TYPE, :TIME_DATE, :AMOUNT , :DESTINATION);";
                    addData(taxiNumber, "Added to rank", currentDateTime.ToString(), 0, null);
                    
                    
                }

                rank_box.Items.Clear();
                foreach (taxi item in rank.rank)
                {
                    rank_box.Items.Add(item.getNumber());
                }
            }
            catch
            {
                MessageBox.Show("Please enter a valid taxi number");
            }





        }

        private void leaveRank_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (rank.rank.Count > 0)
                {
                    string dest = destination.Text;
                    double Fare = double.Parse(fare.Text);
                    taxi t = rank.FrontTaxiTakesFare(dest, Fare);
                    MessageBox.Show("Taxi Number " + t.getNumber() + " Left For " + dest);
                    taxis.Items.Clear();
                    taxis.Items.Add("Number" + "_" + "Location" + "_" + "Rank");
                    
                    addData(t.getNumber(), "Left Rank", currentDateTime.ToString(), 0, dest);

                    foreach (taxi item in rank.taxis.Values)
                    {
                        if (item.getCurrentFare() > 0)
                        {
                            taxis.Items.Add(item.getNumber() + "_" + item.getDestination() + "_" + "On Road");
                        }
                        else if (rank.rank.IndexOf(item) >= 0)
                        {
                            int index = rank.rank.IndexOf(item);
                            taxis.Items.Add(item.getNumber() + "_" + "In Rank" + "_" + index);
                        }
                        else
                        {
                            taxis.Items.Add(item.getNumber() + "_" + "N/A" + "_" + "N/A");
                        }

                    }
                    rank_box.Items.Clear();
                    foreach (taxi item in rank.rank)
                    {
                        rank_box.Items.Add(item.getNumber());
                    }

                }
                else
                {
                    MessageBox.Show("There is no taxi in rank");
                }


            }
            catch
            {
                MessageBox.Show("Please enter valid fare and destination");
            }
            

        }

        private void dropFare_Click(object sender, RoutedEventArgs e)
        {

            int number = int.Parse(dropTaxiNum.Text);
            try
            {
                if (rank.taxis[number].getDestination() != null)
                {
                    double fare = rank.taxis[number].getCurrentFare();
                    rank.taxis[number].setTotalMoneyPaid(rank.taxis[number].getCurrentFare());
                    rank.taxis[number].setDestination(null);
                    rank.taxis[number].setCurrentFare(0);
                    MessageBox.Show("Taxi number " + number + " Dropped At Destionation and Fare was : " + fare);

                    
                    addData(number, "Dropped Fare", currentDateTime.ToString(),fare , null);

                }
                else
                {
                    MessageBox.Show("The taxi is not carrying a passanger");
                }
            }
            catch
            {
                MessageBox.Show("Taxi number invalid");
            }

            taxis.Items.Clear();
            taxis.Items.Add("Number" + "_" + "Location" + "_" + "Rank");

            foreach (taxi item in rank.taxis.Values)
            {
                if (item.getCurrentFare() > 0)
                {
                    taxis.Items.Add(item.getNumber() + "_" + item.getDestination() + "_" + "On Road");
                }
                else if (rank.rank.IndexOf(item) >= 0)
                {
                    int index = rank.rank.IndexOf(item);
                    taxis.Items.Add(item.getNumber() + "_" + "In Rank" + "_" + index);
                }
                else
                {
                    taxis.Items.Add(item.getNumber() + "_" + "N/A" + "_" + "N/A");
                }
            }
        }

        private void refresh_Click(object sender, RoutedEventArgs e)
        {
            taxis.Items.Clear();
            taxis.Items.Add("Number" + "_" + "Location" + "_" + "Rank");

            foreach (taxi item in rank.taxis.Values)
            {
                if (item.getCurrentFare() > 0)
                {
                    taxis.Items.Add(item.getNumber() + "_" + item.getDestination() + "_" + "On Road");
                }
                else if (rank.rank.IndexOf(item) >= 0)
                {
                    int index = rank.rank.IndexOf(item);
                    taxis.Items.Add(item.getNumber() + "_" + "In Rank" + "_" + index);
                }
                else
                {
                    taxis.Items.Add(item.getNumber() + "_" + "N/A" + "_" + "N/A");
                }

            }
        }

        private void transaction_Click(object sender, RoutedEventArgs e)
        {
            Window1 newWindow = new Window1();



            newWindow.Show();
        }

        public void addData(int num, string type, string time, double amount, string dest)
        {
            {
                try
                {

                    string connectionString = "DATA SOURCE=localhost:1521/ORCL;USER ID=SYSTEM;Password=2433;";
                    OracleConnection conn = new OracleConnection(connectionString);
                    conn.Open();

                    string sqlQuery = "INSERT INTO log (TAXI_NUMBER, TR_TYPE, TIME_DATE, AMOUNT , DESTINATION) VALUES (:taxiNumber, :trType, :timeDate, :amount , :destionation)";

                    using (OracleCommand cmd = new OracleCommand(sqlQuery, conn))
                    {
                        cmd.Parameters.Add(":taxiNumber", OracleDbType.Int32).Value = num;
                        cmd.Parameters.Add(":trType", OracleDbType.Varchar2).Value = type;
                        cmd.Parameters.Add(":timeDate", OracleDbType.Varchar2).Value = time;
                        cmd.Parameters.Add(":amount", OracleDbType.Decimal).Value = amount;
                        cmd.Parameters.Add(":destination", OracleDbType.Varchar2).Value = dest ;
                        try
                        {
                            int n = cmd.ExecuteNonQuery();
                            if (n > 0)
                            {
                                MessageBox.Show("adssad");

                            }
                        }
                        catch (Exception expe)
                        {
                            MessageBox.Show(expe.Message.ToString() + sqlQuery);
                        }



                    }








                }
                catch (Exception ex)
                {

                }


            }

        }

        public class taxi
        {
            int number;
            int inRank;
            string onRoad;
            double currentFare;
            string destination;
            string location;
            double totalMoneyPaid;
            double agreedPrice;
            public taxi(int number)
            {
                this.number = number;
            }
            public int getinRank()
            {
                return inRank;
            }
            public void setinRank(int rank)
            {
                this.inRank = rank;
            }

            public double getCurrentFare()
            {
                return currentFare;
            }
            public void setCurrentFare(double currentFare)
            {
                this.currentFare = currentFare;
            }

            public string getDestination()
            {
                return destination;
            }
            public void setDestination(string destination)
            {
                this.destination = destination;
            }
            public double getTotalMoneyPaid()
            {
                return totalMoneyPaid;
            }
            public void setTotalMoneyPaid(double TotalMoneyPaid)
            {
                this.totalMoneyPaid = this.totalMoneyPaid + TotalMoneyPaid;
            }
            public string getLocation()
            {
                return location;
            }
            public void setLocation(string Location)
            {
                this.location = Location;
            }

            public int getNumber()
            {
                return number;
            }
            public void addFare(string destination, double agreedPrice)
            {
                this.destination = destination;
                this.currentFare = agreedPrice;
            }
            public void dropFare()
            {
                totalMoneyPaid = totalMoneyPaid + currentFare;
                currentFare = 0;
            }

        }
        public class Rank
        {
            public int Id { get; }

            public Dictionary<int, taxi> taxis = new Dictionary<int, taxi>();
            public List<taxi> rank = new List<taxi>();


            public Rank()
            {


            }

            public bool AddTaxi(taxi t)
            {

                rank.Add(t);
                return true;
            }

            public taxi FrontTaxiTakesFare(string destination, double agreedPrice)
            {
                try
                {
                    DateTime currentDateTime = DateTime.Now;
                    taxi t = rank[0];
                    t.addFare(destination, agreedPrice);
                    rank.RemoveAt(0);
                    
                    
                    return t;
                }
                catch (ArgumentOutOfRangeException)
                {
                    return null;
                }
            }
        }

        private void taxi_number_TextChanged(object sender, TextChangedEventArgs e)
        {
            taxi_number.Text = string.Empty; 
        }

        private void taxi_number_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }
    }
}
