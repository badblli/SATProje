using MySql.Data.MySqlClient;
using System;

namespace SATProje.Forms
{
    public class MySqlconnection
    {
        private string v;

        public MySqlconnection(string v)
        {
            this.v = v;
        }

        public static implicit operator MySqlconnection(MySqlConnection v)
        {
            throw new NotImplementedException();
        }
    }
}