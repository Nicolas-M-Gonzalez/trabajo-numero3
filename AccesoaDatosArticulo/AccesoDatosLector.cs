using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominios;
using System.Data.SqlClient;
using System.Configuration;


namespace AccesoaDatosArticulo
{
    public class AccesoDatosLector
    {
        public List<Articulo> Listar(string id = "") //le digo que si viene un id como parametro lo guarde sino quede vacio.
        {                                           // es un parametro opcional.

            //creamos un metodo/funcion que va a ser una lista de pokemon llamada listar
            // que lea de la base de datos.


            List<Articulo> Lista = new List<Articulo>();
            //creamos la lista.



            SqlCommand Comando = new SqlCommand();
            //se crea el objeto para realizar comandos.

            SqlDataReader Lector;
            //para leer los datos se crea esta variable.




            try
            {

                SqlConnection Conexion = new SqlConnection(ConfigurationManager.AppSettings["CadenaConexion"]);
                //nombre de tu base de datos./de la tabla / seguridad integrada.objeto

                Comando.CommandType = System.Data.CommandType.Text;
                //como voy a inyectar la consulta.objeto



                Comando.CommandText = "select Codigo,Nombre,A.Descripcion,ImagenUrl,M.Descripcion Marca,C.Descripcion Categoria,A.IdMarca,A.IdCategoria,Precio,A.Id from ARTICULOS A,MARCAS M,CATEGORIAS C where M.Id = A.IdMarca and C.Id = A.IdCategoria ";
                //consulta con relaciones. objeto

                if (id != "")//si el id es distinto que vacio.
                    Comando.CommandText += " and A.Id = " + id; // si hay un id te devuelva solo el id de la lista el commandtext.

                Comando.Connection = Conexion;
                //todo el comando anterior se va a establecer con la palabra conexion.objeto

                Conexion.Open();
                //abro la conexion.

                Lector = Comando.ExecuteReader();
                //realizo la lectura en la variable lector.

                while (Lector.Read())
                {
                    //se va a fijar si hay una lectura; si la hay ? te posiciona en la primera fila.

                    Articulo aux = new Articulo();
                    //creamos el objeto y lo cargamos.
                    aux.Id = (int)Lector["Id"];

                    aux.Codigo = (string)Lector["Codigo"];
                    aux.Nombre = (string)Lector["Nombre"];
                    aux.Precio = (decimal)Lector["Precio"];

                    if (!(Lector["ImagenUrl"] is DBNull))
                        aux.Imagen = (string)Lector["ImagenUrl"];

                    aux.Descripcion = (string)Lector["Descripcion"];

                    aux.Marca = new Elemento();
                    //creamos el objeto tipo de tipo elemento.
                    aux.Marca.Id = (int)Lector["IdMarca"];

                    aux.Marca.Descripcion = (string)Lector["Marca"];
                    //le pedimos estos datos

                    aux.Categoria = new Elemento();
                    //creamos el objeto debilidad de tipo elemento.
                    aux.Categoria.Id = (int)Lector["IdCategoria"];
                    aux.Categoria.Descripcion = (string)Lector["Categoria"];



                    //le pedimos estos datos.


                    //carga los datos de la base de datos




                    Lista.Add(aux);
                }

                Conexion.Close();
                //cierro la conexion.
                return Lista;
                //devuelve una lista.
            }

            catch (Exception ex)
            {

                throw ex;

            }


        }

    }
}
