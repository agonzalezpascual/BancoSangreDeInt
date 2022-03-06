using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BancoSangre
{
    public class CRUD
    {
        private String conexion = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bancosangre;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public List<Donante> listPer { get; set; }

        // Método abre conexion
        public int AbreConexion() {
            SqlConnection con = new SqlConnection(conexion);
            con.Open();
            ConnectionState s = con.State;
            
            return (int)s;

        }

        // Método insertar
        public void insertar(string tabla, string textoNom, string textoApe, string textoDNI, string textoDirec, string textoTelf, string textoNac, string textoEma, string textoGru, string textoRh)
        {

            // Creamos la conexión y hacemos la consulta
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO "+tabla+"(DNI, nombre, apellido, direccion, telefono, nacimiento, email, grupo, rh) " +
                    "VALUES ('" + textoDNI + "', '" + textoNom + "', '" + textoApe + "', '" + textoDirec + "', '" + textoTelf + "', '" + textoNac + "', '" + textoEma + "', '" + textoGru + "', '" + textoRh + "');", con);
                command.ExecuteNonQuery();
                MessageBox.Show("Insertado correctamente.");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message, "Error al insertar los datos.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        // Método actualizar
        public void actualizar(string tabla, string textoNom, string textoApe, string textoDNI, string textoDirec, string textoTelf, string textoNac, string textoEma, string textoGru, string textoRh)
        {
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE "+tabla+" SET " +
                    "nombre = '" + textoNom + "', apellido = '" + textoApe + "', direccion = '" + textoDirec + "', telefono = '" + textoTelf + "', nacimiento = '" + textoNac + "', email = '" + textoEma + "', grupo = '" + textoGru + "', rh = '" + textoRh + "' WHERE DNI = '" + textoDNI + "';", con);
                command.ExecuteNonQuery();
                MessageBox.Show("Insertado correctamente.");
                con.Close();

            }
            // Creamos la conexión y hacemos la consulta
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message, "Error al insertar los datos.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void insertarDonac(string tabla, string textoDNI, string textoSan, string textoFec, string textoCan, string textoCen)
        {

            // Creamos la conexión y hacemos la consulta
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand command = new SqlCommand("INSERT INTO " + tabla + "(DNI, CodSanitario, centro, fecha, cantidad) " +
                    "VALUES ('" + textoDNI + "', '" + textoSan + "', '" + textoCen + "', '" + textoFec + "', '" + textoCan + "');", con);
                command.ExecuteNonQuery();
                MessageBox.Show("Insertado correctamente.");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message, "Error al insertar los datos.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        // Método actualizar
        public void actualizarDonac(string tabla, string textoNom, string textoApe, string textoDNI, string textoDirec, string textoTelf, string textoNac, string textoEma, string textoGru, string textoRh)
        {
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand command = new SqlCommand("UPDATE " + tabla + " SET " +
                    "nombre = '" + textoNom + "', apellido = '" + textoApe + "', direccion = '" + textoDirec + "', telefono = '" + textoTelf + "', nacimiento = '" + textoNac + "', email = '" + textoEma + "', grupo = '" + textoGru + "', rh = '" + textoRh + "' WHERE DNI = '" + textoDNI + "';", con);
                command.ExecuteNonQuery();
                MessageBox.Show("Insertado correctamente.");
                con.Close();

            }
            // Creamos la conexión y hacemos la consulta
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message, "Error al insertar los datos.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        // Método borrar
        public void borrar(string DNI)
        {
            try
            {
                // Creamos la conexión y hacemos la consulta
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Donante WHERE DNI = '" + DNI + "';", con);
                command.ExecuteNonQuery();
                MessageBox.Show("Insertado correctamente.");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message, "Error al insertar los datos.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public void borrarDonac(string DNI)
        {
            try
            {
                // Creamos la conexión y hacemos la consulta
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Donacion WHERE DNI = '" + DNI + "';", con);
                command.ExecuteNonQuery();
                MessageBox.Show("Insertado correctamente.");
                con.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message, "Error al insertar los datos.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }


        // Método buscar
        public DataTable buscar(string textoBuscar)
        {
            DataTable dt = null;
            // Creamos la conexión y hacemos la consulta
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM Personas WHERE nombre = '" + textoBuscar + "';", con);
                SqlDataAdapter sda = new SqlDataAdapter(command);
                dt = new DataTable("PersonaSelect");
                sda.Fill(dt);
                // Retornamos un dataset
                return dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message, "Error al insertar los datos.", MessageBoxButton.OK, MessageBoxImage.Error);
                // Retornamos un dataset
                return dt;
            }

        }
        public double RellenarRosco(string tiposangre)
        {

            //he parido esta mierda luego de 2 putos dias jodeeeer siiiii ostiaaaaaa
            int je = 0;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Donante WHERE grupo = '" + tiposangre + "';", con);
               
                je = (Int32)command.ExecuteScalar();

                return je;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message, "Error al consultar el rosco", MessageBoxButton.OK, MessageBoxImage.Error);

                return je;
            }


        }
        public int cantidadDonaciones() {
            int cantidad = 0;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Donacion;", con);
                cantidad = (Int32)command.ExecuteScalar();
                return cantidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message, "Error al consultar el rosco", MessageBoxButton.OK, MessageBoxImage.Error);

                return cantidad;
            }
        }
        public int cantidadDonantes()
        {
            int cantidad = 0;
            try
            {
                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Donante;", con);
                cantidad = (Int32)command.ExecuteScalar(); 
                return cantidad;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message, "Error al consultar el rosco", MessageBoxButton.OK, MessageBoxImage.Error);

                return cantidad;
            }
        }

        internal double RellenarPalitos(string tiposangre, string tiporh)
        {
            //he parido esta mierda luego de 2 putos dias jodeeeer siiiii ostiaaaaaa
            int je = 0;
            try
            {

                SqlConnection con = new SqlConnection(conexion);
                con.Open();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Donante WHERE grupo = '" + tiposangre + "' AND rh= '"+tiporh+"';", con);

                je = (Int32)command.ExecuteScalar();

                return je;

            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR " + ex.Message, "Error al consultar el palito", MessageBoxButton.OK, MessageBoxImage.Error);

                return je;
            }
        }
    }
}

