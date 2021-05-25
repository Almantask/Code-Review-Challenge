using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace TaxesCalculator
{
    public class RepositoryOfAllThePeople : IDisposable
    {
        private static SqlConnection conn;

        public RepositoryOfAllThePeople(string connectionString)
        {
            conn = new SqlConnection(connectionString);
        }

        public async Task<List<Person>> getData()
        {
            var sql = "SELECT * FROM People";
            var query = new SqlCommand(sql);
            var reader = query.ExecuteReaderAsync().Result;
            var people = new List<Person>();
            while (reader.Read())
            {
                var name = reader.GetString(0);
                var born = reader.GetDateTime(1);
                var salary = reader.GetFloat(2);
                var secretIdentifier = reader.GetInt64(3);
                var person = new Person()
                {
                    Birthday = born,
                    Name = name,
                    SalaryBeforeTaxes = salary,
                    SecretId = secretIdentifier
                };

                people.Add(person);
            }

            return people;
        }

        public void Dispose() => conn.Dispose();
    }
}