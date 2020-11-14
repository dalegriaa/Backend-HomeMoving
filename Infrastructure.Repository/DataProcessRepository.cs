using Domain.Entity;
using Infrastructure.Interface;
using System.Data.SQLite;

using System.Collections.Generic;

using Transversal.common;
using System.IO;
using System;
using System.Data;

namespace Infrastructure.Repository
{
    public class DataProcessRepository : IDataProcessRepository
    {
        private readonly IconectionFactory _connectionFactory;
        public DataProcessRepository(IconectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public bool InserDataFile(DataFileUser dataFileUser)
        {
            using (var ctx = _connectionFactory.GetInstance)
            {
                var document = dataFileUser.DocumentNumber.ToString();
                var createDate = dataFileUser.CreateDate.ToString();

                var command = new SQLiteCommand((SQLiteConnection)ctx);

                command.CommandText = "INSERT INTO tableuser(DocumentNumber, CreateDate) VALUES(@DocumentNumber, @CreateDate)";

                command.Parameters.AddWithValue("@DocumentNumber", document);
                command.Parameters.AddWithValue("@CreateDate", createDate);
                command.Prepare();

                command.ExecuteNonQuery();

                return command.ExecuteNonQuery()>0;
            }
                
         }
    }
}
