using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIO11300_HTYO
{
    class Item
    {
        #region PROPERTIES
        public string Id { get; set; }

        public string Iname { get; set; }

        public string Rdate { get; set; }
        #endregion

        #region CONSTUCTORS
        public Item(string id, string iname, string rdate)
        {
            this.Id = id;
            this.Iname = iname;
            this.Rdate = rdate;
        }
        #endregion
    }

    class Account
    {
        #region PROPERTIES
        public string Id { get; set; }

        public string Email { get; set; }

        public string Pword { get; set; }

        public string Fname { get; set; }

        public string Lname { get; set; }

        public string Rdate { get; set; }

        #endregion

        #region CONSTUCTORS
        public Account(string id, string email, string pword, string fname, string lname, string rdate)
        {
            this.Id = id;
            this.Email = email;
            this.Pword = pword;
            this.Fname = fname;
            this.Lname = lname;
            this.Rdate = rdate;
        }
        #endregion
    }

    class BLAccount
    {
        public static bool IsAccountExist(string email, string pword)
        {
            try
            {
                // Get accountId dataTable from DL.
                DataTable dataTable = DLAccount.Select(0, email, pword, null, null, null, "SELECT id FROM account WHERE email=@Email AND pword=@Pword");

                // Return bool if account exist. (Conditional operator)
                return (dataTable.Rows.Count > 0) ? true : false;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static int GetAccountId(string email, string pword)
        {
            try
            {
                // Get accountId dataTable from DL.
                DataTable dataTable = DLAccount.Select(0, email, pword, null, null, null, "SELECT id FROM account WHERE email=@Email AND pword=@Pword");

                // Return accountId if account exist. (Conditional operator)
                return (dataTable.Rows.Count > 0) ? Convert.ToInt32(dataTable.Rows[0][0]) : 0;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static Account GetAccount(int id)
        {
            try
            {
                // Get account dataTable from DL.
                DataTable dataTable = DLAccount.Select(id, null, null, null, null, null, "SELECT * FROM account WHERE id=@Id");

                // Return account.
                return new Account(dataTable.Rows[0][0].ToString(), dataTable.Rows[0][1].ToString(), dataTable.Rows[0][2].ToString(), dataTable.Rows[0][3].ToString(), dataTable.Rows[0][4].ToString(), dataTable.Rows[0][5].ToString());
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static int SetAccount(string email, string pword, string fname, string lname)
        {
            try
            {
                // Return inserted accountId from DL.
                return DLAccount.Insert(0, email, pword, fname, lname, DateTime.Now.ToString("yyyy.MM.dd H:mm:ss"), "INSERT INTO account VALUES (@Id, @Email, @Pword, @Fname, @Lname, @Rdate)");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static List<Item> GetItems(int id)
        {
            try
            {
                List<Item> items = new List<Item>();

                // Get items dataTable from DL.
                DataTable dataTable = DLAccount.Select(id, null, null, null, null, null, "SELECT * FROM item");

                foreach (DataRow dataRow in dataTable.Rows)
                {
                    items.Add(new Item(dataRow[0].ToString(), dataRow[1].ToString(), dataRow[2].ToString()));
                }

                return items;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void InsertItem(string iname)
        {
            try
            {
                // Insert item.
                DLAccount.Insert(0, null, null, iname, null, DateTime.Now.ToString("yyyy.MM.dd H:mm:ss"), "INSERT INTO item VALUES (@Id, @Fname, @Rdate)");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public static void DeleteItem(int id)
        {
            try
            {
                // Delete item.
                DLAccount.Select(id, null, null, null, null, null, "DELETE FROM item WHERE id=@Id");
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
