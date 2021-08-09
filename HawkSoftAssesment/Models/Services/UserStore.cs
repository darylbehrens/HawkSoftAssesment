using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace HawkSoftAssesment.Models.Interfaces
{
    public class UserStore : SqlStore<User>
    {
        public UserStore(string connectionString) : base(connectionString)
        {
        }

        public async override Task<IEnumerable<User>> Get()
        {
            var result = new List<User>();
            using var conn = new SqlConnection(ConnectionString);
            using var command = new SqlCommand(RawSql.GetUsers, conn);
            await conn.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            if (reader.HasRows)
            {
                while (await reader.ReadAsync())
                {
                    result.Add(
                        new User()
                        {
                            Id = Convert.ToInt32(reader[0]),
                            UserName = reader[1].ToString()
                        });
                }
            }
            return result;
        }
    }
}
