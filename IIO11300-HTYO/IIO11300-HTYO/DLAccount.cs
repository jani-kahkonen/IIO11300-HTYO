using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIO11300_HTYO
{
    class DLAccount
    {
        public static DataTable Select(int id, string email, string pword, string fname, string lname, string rdate, string queryString)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(IIO11300_HTYO.Properties.Settings.Default.Account))
            {
                try
                {
                    using (MySqlCommand sqlCommand = new MySqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddRange(new[] {
                            new MySqlParameter("@Id", id), new MySqlParameter("@Email", email),
                            new MySqlParameter("@Pword", pword), new MySqlParameter("@Fname", fname),
                            new MySqlParameter("@Lname", lname), new MySqlParameter("@Rdate", rdate)
                        });

                        MySqlDataAdapter sqlDataAdapter = new MySqlDataAdapter(sqlCommand);
                        DataTable dataTable = new DataTable();
                        sqlDataAdapter.Fill(dataTable);

                        return dataTable;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public static int Insert(int id, string email, string pword, string fname, string lname, string rdate, string queryString)
        {
            using (MySqlConnection sqlConnection = new MySqlConnection(IIO11300_HTYO.Properties.Settings.Default.Account))
            {
                try
                {
                    using (MySqlCommand sqlCommand = new MySqlCommand(queryString, sqlConnection))
                    {
                        sqlCommand.Parameters.AddRange(new[] {
                            new MySqlParameter("@Id", id), new MySqlParameter("@Email", email),
                            new MySqlParameter("@Pword", pword), new MySqlParameter("@Fname", fname),
                            new MySqlParameter("@Lname", lname), new MySqlParameter("@Rdate", rdate)
                        });

                        sqlConnection.Open();
                        sqlCommand.ExecuteNonQuery();

                        return (int)sqlCommand.LastInsertedId;
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
