using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace AmorDoce.BancoDeDados
{
    public class BancoDeDados
    {
        private readonly MySqlConnection con;

        public BancoDeDados()
        {
            con = new MySqlConnection(ConfigurationManager.ConnectionStrings["BdConexao"].ConnectionString);
        
        }

    }
}