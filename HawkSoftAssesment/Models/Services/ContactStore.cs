using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HawkSoftAssesment.Models.Interfaces
{
    public class ContactStore : SqlStore<Contact>
    {
        public ContactStore(string connectionString) : base(connectionString)
        {
        }

        public async override Task<IEnumerable<Contact>> GetBy(int i)
        {
            var result = new List<Contact>();
            using var conn = new SqlConnection(ConnectionString);
            using var command = new SqlCommand(RawSql.GetContactsById, conn);
            command.Parameters.AddWithValue("UserId", i);
            await conn.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    result.Add(
                        new Contact()
                        {
                            FirstName = reader[0].ToString(),
                            LastName = reader[1].ToString(),
                            Email = reader[2].ToString(),
                            Address = reader[3].ToString(),
                            City = reader[4].ToString(),
                            State = reader[5].ToString(),
                            Zipcode = reader[6].ToString(),
                            IsActive = Convert.ToBoolean(reader[7]),
                            Id = Convert.ToInt32(reader[8])
                        }); ;
                }
            }
            return result;
        }

        public async override Task<int> Insert(Contact t)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var command = new SqlCommand(RawSql.InsertContact, conn);
            command.Parameters.AddWithValue("FirstName", t.FirstName);
            command.Parameters.AddWithValue("LastName", t.LastName);
            command.Parameters.AddWithValue("Email", t.Email);
            command.Parameters.AddWithValue("Address", t.Address);
            command.Parameters.AddWithValue("City", t.City);
            command.Parameters.AddWithValue("State", t.State);
            command.Parameters.AddWithValue("Zipcode", t.Zipcode);
            command.Parameters.AddWithValue("UserId", t.UserId);
            await conn.OpenAsync();
            return Convert.ToInt32(await command.ExecuteScalarAsync());
        }

        public async override Task Delete(int contactId)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var command = new SqlCommand(RawSql.DeleteContact, conn);
            command.Parameters.AddWithValue("ContactId", contactId);
            await conn.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }

        public async override Task Update(Contact t)
        {
            using var conn = new SqlConnection(ConnectionString);
            using var command = new SqlCommand(RawSql.UpdateContact, conn);
            command.Parameters.AddWithValue("FirstName", t.FirstName);
            command.Parameters.AddWithValue("LastName", t.LastName);
            command.Parameters.AddWithValue("Email", t.Email);
            command.Parameters.AddWithValue("Address", t.Address);
            command.Parameters.AddWithValue("City", t.City);
            command.Parameters.AddWithValue("State", t.State);
            command.Parameters.AddWithValue("Zipcode", t.Zipcode);
            command.Parameters.AddWithValue("ContactId", t.Id);
            await conn.OpenAsync();
            await command.ExecuteNonQueryAsync();
        }
    }
}
