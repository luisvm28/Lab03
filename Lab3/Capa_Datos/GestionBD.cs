using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //Controlador para pegarme a BD Microsoft SQL
using Capa_Datos.Entidades;
using System.Configuration;

namespace Capa_Datos
{
    public class GestionBD
    {
        //Declarando las variables
        SqlConnection conexion;
        SqlCommand comando;
        string cadenaConexion = "Data Source=DESKTOP-F1DRCDF;Initial Catalog=lab3;Integrated Security=True";  //String de Conexion
        //string cadenaConexion = ConfigurationManager.ConnectionStrings["conexionPruebas"].ConnectionString; //De una forma dinamica

        public List<Marca> listadoMarca()
        {
            SqlDataReader datosLeidos;
            List<Marca> listadoRentornar;

            //Paso#1 Crear la conexion
            conexion = new SqlConnection(); //Creamos el objeto en memoria 

            conexion.ConnectionString = cadenaConexion;

            //Paso#2 Configurar el comando
            comando = new SqlCommand();
            comando.Connection = conexion;  //Propiedas mas importantes, que conexion usa el comando??
            comando.CommandText = "Select * from Marca";
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandTimeout = 0;  //expresado en segundos

            //Paso#3 Ejecutar el comando
            conexion.Open();
            datosLeidos = comando.ExecuteReader(); //Es la que ejecuta la accion en base de datos


            //Paso#4 Configurar la estructura a retornar
            listadoRentornar = new List<Marca>();
            while (datosLeidos.Read())
            {

                Marca objMarca = new Marca(); //Creamo el objeto genero
                objMarca.idMarca = datosLeidos.GetInt32(0);
                objMarca.Nombre = datosLeidos.GetString(1);
                listadoRentornar.Add(objMarca);

            }

            return listadoRentornar;


        }

        public bool registrarHerrramientas(Herramientas objHerramientas)
        {
            int control = -1;
            bool respuesta = false;

            using (SqlConnection cnx = new SqlConnection(cadenaConexion))
            {
                comando = new SqlCommand();
                comando.Connection = cnx;
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "INSERT INTO [dbo].[Herramientas] ([Nombre],[Descripcion],[Tipo],[Marca],[Cant_Disponible])" +
                                      " Values (@Nombre,@Descripcion,@Tipo,@Marca,@Cant_Disponible)";

                //Definicion del parametro @Identificacion
                SqlParameter objParametro = new SqlParameter();
                objParametro.ParameterName = "@Identificacion";
                objParametro.SqlDbType = System.Data.SqlDbType.VarChar;
                objParametro.Size = 30;
                objParametro.Value = objHerramientas.idCodigo;

                comando.Parameters.Add(objParametro);

                comando.Parameters.Add(new SqlParameter("@Nombre", objHerramientas.Nombre));

                comando.Parameters.Add(new SqlParameter("@Descripcion", objHerramientas.Descripcion));

                comando.Parameters.Add(new SqlParameter("@Tipo", objHerramientas.Tipo));

                comando.Parameters.Add(new SqlParameter("@Marca", objHerramientas.Marca));

                comando.Parameters.Add(new SqlParameter("@Cant_Disponible", objHerramientas.Cant_Disponible));

                cnx.Open();

                control = comando.ExecuteNonQuery();  //ejecucion del comando en base de datos

            }

            if (control > 0)
            {
                respuesta = true;
            }

            return respuesta;


        }
    }
}

