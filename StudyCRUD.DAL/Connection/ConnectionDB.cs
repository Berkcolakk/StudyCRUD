using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyCRUD.DAL.Connection
{
    public class ConnectionDB
    {

        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Brkco\source\repos\StudyCRUD\StudyCRUD.DAL\DB\Database1.mdf;Integrated Security=True");
        SqlCommand sqlCommand;
        SqlDataReader sqlDataReader;
        SqlDataAdapter dataAdapter;

        public DataTable GetAllUsers()
        {
            try
            {
                ConnectionOpen();
                sqlCommand = new SqlCommand("SELECT ID SICIL_NO, NAME_SURNAME AS AD_SOYAD,PHONE AS TELEFON_NUMARASI,ADDRESS AS ADRES,BIRTH_DATE AS DOGUM_TARIHI FROM STUDENT", sqlConnection);
                dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                ConnectionClose();
            }

        }
        public DataTable GetUserByID(string Id)
        {
            try
            {
                ConnectionOpen();
                sqlCommand = new SqlCommand("SELECT ID SICIL_NO, NAME_SURNAME AS AD_SOYAD,PHONE AS TELEFON_NUMARASI,ADDRESS AS ADRES,BIRTH_DATE AS DOGUM_TARIHI FROM STUDENT WHERE ID = '" + Id + "'", sqlConnection);
                dataAdapter = new SqlDataAdapter(sqlCommand);
                DataTable dt = new DataTable();
                dataAdapter.Fill(dt);
                return dt;
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                ConnectionClose();
            }

        }
        public void ConnectionOpen()
        {
            try
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception e)
            {

                throw e;
            }

        }
        public void ConnectionClose()
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                    sqlCommand.Dispose();
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public void Insert(string nameSurname, string phone, string address, string birthdate)
        {
            try
            {
                sqlCommand = new SqlCommand("INSERT INTO STUDENT(NAME_SURNAME,BIRTH_DATE,PHONE,ADDRESS) values(@nameSurname,@birthdate,@phone,@address)", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nameSurname", nameSurname);
                sqlCommand.Parameters.AddWithValue("@phone", phone);
                sqlCommand.Parameters.AddWithValue("@birthdate", birthdate);
                sqlCommand.Parameters.AddWithValue("@address", address);
                ConnectionOpen();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                ConnectionClose();
            }
        }

        public void Update(string nameSurname, string phone, string address, string birthdate,string id)
        {
            try
            {
                sqlCommand = new SqlCommand("UPDATE  STUDENT SET NAME_SURNAME = @nameSurname,BIRTH_DATE = @birthdate,PHONE = @phone,ADDRESS = @address WHERE ID = @id", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@nameSurname", nameSurname);
                sqlCommand.Parameters.AddWithValue("@phone", phone);
                sqlCommand.Parameters.AddWithValue("@birthdate", birthdate);
                sqlCommand.Parameters.AddWithValue("@address", address);
                sqlCommand.Parameters.AddWithValue("@id", id);
                ConnectionOpen();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                ConnectionClose();
            }
        }

        public void Delete(string id)
        {
            try
            {
                sqlCommand = new SqlCommand("DELETE FROM STUDENT WHERE ID = " + id, sqlConnection);
                ConnectionOpen();
                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                ConnectionClose();
            }
        }
    }
}
