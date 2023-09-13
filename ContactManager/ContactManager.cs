using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ContactManager
{
    public class ContactManager
    {
        private readonly string connectionString;

        public ContactManager()
        {
            connectionString = ConfigurationManager.ConnectionStrings["ContactManagerDB"].ConnectionString;
        }

       public DataTable GetContacts()
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string query = "SELECT * FROM Contacts";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }
    }
}


        public void AddContact(string name, string email, string phone)
{
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        string query = "INSERT INTO Contacts (Name, Email, Phone) VALUES (@Name, @Email, @Phone)";
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            command.Parameters.AddWithValue("@Name", name);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Phone", phone);
            command.ExecuteNonQuery();
        }
    }
}


        // Implement other CRUD operations here (update, delete).
    }
}
