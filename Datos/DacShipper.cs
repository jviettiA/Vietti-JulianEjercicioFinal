using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Data.SqlClient;
using Datos.Servidor;
using System.Data;

namespace Datos
{
    public static class DacShipper
    {
        static SqlCommand comando;
        static SqlDataReader reader;

        public static List<Shipper> Listar()
        {
            string consultaSQL = "SELECT ShipperID, CompanyName, Phone FROM Shippers";
            comando = new SqlCommand(consultaSQL, AdminDB.ConectarBaseDatos());
            reader = comando.ExecuteReader();

            List<Shipper> shippers = new List<Shipper>();
            while (reader.Read())
            {
                shippers.Add(
                    new Shipper()
                    {
                        ShipId = reader["ShipperID"].ToString(),
                        CompName = reader["CompanyName"].ToString(),
                        Phone = reader["Phone"].ToString(),
                    }
                    );
            }

            AdminDB.ConectarBaseDatos().Close();
            reader.Close();

            return shippers;

        }

        public static DataTable ListarDS()
        {

            string SQLSelect = "SELECT ShipperID, CompanyName, Phone FROM Shippers";

            SqlDataAdapter adapter = new SqlDataAdapter(SQLSelect, AdminDB.ConectarBaseDatos());

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Shippers");

            return ds.Tables["Shippers"];
        }

        public static DataTable ListarOrdenes(string id)
        {

            string SQLSelect = "SELECT [OrderID],[CustomerID],[EmployeeID],[OrderDate],[RequiredDate],[ShippedDate],[ShipVia],[Freight],[ShipName],[ShipAddress],[ShipCity],[ShipRegion],[ShipPostalCode],[ShipCountry]FROM[dbo].[Orders]WHERE ShipVia=@shipper";

            SqlDataAdapter adapter = new SqlDataAdapter(SQLSelect, AdminDB.ConectarBaseDatos());

            adapter.SelectCommand.Parameters.Add("@shipper", SqlDbType.Int).Value = id;

            DataSet ds = new DataSet();

            adapter.Fill(ds, "Shippers");

            return ds.Tables["Shippers"];
        }

        public static List<string> ListarCompany()
        {
            string SQLSelect = "SELECT DISTINCT CompanyName FROM Shippers";

            comando = new SqlCommand(SQLSelect, AdminDB.ConectarBaseDatos());
            reader = comando.ExecuteReader();

            List<string> companies = new List<string>();
            while (reader.Read())
            {
                companies.Add(reader["CompanyName"].ToString());
            }
            AdminDB.ConectarBaseDatos().Close();
            reader.Close();

            return companies;
        }

        public static DataTable TraerUno(string company)
        {
            string SQLSelect = "SELECT ShipperID, CompanyName, Phone FROM Shippers WHERE CompanyName = @company";
            SqlDataAdapter adapter = new SqlDataAdapter(SQLSelect, AdminDB.ConectarBaseDatos());
            adapter.SelectCommand.Parameters.Add("@company", SqlDbType.NVarChar, 40).Value = company;

            DataSet ds = new DataSet();
            adapter.Fill(ds, "Shipper");


            return ds.Tables["Shipper"];
        }

        public static int Insertar(Shipper shipper)
        {
            string consultaSQL = "INSERT INTO [dbo].[Shippers]([CompanyName],[Phone])VALUES(@company,@phone)";

            comando = new SqlCommand(consultaSQL, AdminDB.ConectarBaseDatos());

            comando.Parameters.Add("@company", System.Data.SqlDbType.NVarChar, 40).Value = shipper.CompName;
            comando.Parameters.Add("@phone", System.Data.SqlDbType.NVarChar, 24).Value = shipper.Phone;

            int filasAfectadas = comando.ExecuteNonQuery();

            AdminDB.ConectarBaseDatos().Close();
            return filasAfectadas;
        }

        public static int Actualizar(Shipper shipper)
        {
            string consultaSQL = "UPDATE [Shippers] SET [CompanyName]=@company ,[Phone]=@Phone WHERE ShipperID=@shipid";

            comando = new SqlCommand(consultaSQL, AdminDB.ConectarBaseDatos());

            comando.Parameters.Add("@shipid", System.Data.SqlDbType.Int).Value = shipper.ShipId;
            comando.Parameters.Add("@company", System.Data.SqlDbType.NVarChar, 40).Value = shipper.CompName;
            comando.Parameters.Add("@phone", System.Data.SqlDbType.NVarChar, 24).Value = shipper.Phone;

            int filasAfectadas = comando.ExecuteNonQuery();

            AdminDB.ConectarBaseDatos().Close();
            return filasAfectadas;
        }

        public static int Eliminar(string id)
        {
            string consultaSQL = "DELETE FROM [Shippers] WHERE ShipperID=@shipid";

            comando = new SqlCommand(consultaSQL, AdminDB.ConectarBaseDatos());

            comando.Parameters.Add("@shipid", System.Data.SqlDbType.Int).Value = id;

            int filasAfectadas = comando.ExecuteNonQuery();

            AdminDB.ConectarBaseDatos().Close();



            return filasAfectadas;




        }
    }
}
