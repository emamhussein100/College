using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace College
{
    class Function
    {
        private SqlConnection _connection;
        private SqlCommand _sqlCommond;
        private DataTable _dt;
        private SqlDataAdapter _adapter;
        private string _conStr;
        public Function() 
        {
            _conStr = @"Data Source=DESKTOP-8L032L1\SQLEXPRESS;Initial Catalog=CollegeDb;Integrated Security=True;Trust Server Certificate=True";
            _connection = new SqlConnection(_conStr);
            _sqlCommond = new SqlCommand();
            _sqlCommond.Connection = _connection;
        }
        public DataTable GetData(string Query)
        {
            _dt = new DataTable();
            _adapter = new SqlDataAdapter(Query, _conStr);
            _adapter.Fill(_dt);
            return _dt;
        }
        public int SetData(string Query)
        {
            int Ctn = 0;
            if(_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            } 
            _sqlCommond.CommandText = Query;
             Ctn = _sqlCommond.ExecuteNonQuery();
            _connection.Close();
            return Ctn;

        }

    }
}
