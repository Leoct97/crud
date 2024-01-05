using testweb_crud.Models;
using System.Data.SqlClient;
using System.Data;
using testweb_crud.Datos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace testweb_crud.Datos
{
    public class ContactoDatos
    {
        public List<Contactomodel> Listar()
        {
            var olista = new List<Contactomodel>();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new Contactomodel() {
                            Id = Convert.ToInt32(dr["id"]),
                            nombre = dr["nombre"].ToString(),
                            telefono = dr["telefono"].ToString(),
                            correo = dr["correo"].ToString()
                        });
                    }
                }
            }
            return olista;
        }
        public Contactomodel Obtener(int Id)
        {
            var oContacto = new Contactomodel();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener", conexion);
                cmd.Parameters.AddWithValue("id", Id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oContacto.Id = Convert.ToInt32(dr["id"]);
                        oContacto.nombre = dr["nombre"].ToString();
                        oContacto.telefono = dr["telefono"].ToString();
                        oContacto.correo = dr["correo"].ToString();
                    };
                }
            }
            return oContacto;
        }
        public bool Guardar(Contactomodel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_guardar", conexion);
                    cmd.Parameters.AddWithValue("nombre", ocontacto.nombre);
                    cmd.Parameters.AddWithValue("telefono", ocontacto.telefono);
                    cmd.Parameters.AddWithValue("correo", ocontacto.correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }

            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Editar(Contactomodel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_editar", conexion);
                    cmd.Parameters.AddWithValue("id", ocontacto.Id);
                    cmd.Parameters.AddWithValue("nombre", ocontacto.nombre);
                    cmd.Parameters.AddWithValue("telefono", ocontacto.telefono);
                    cmd.Parameters.AddWithValue("correo", ocontacto.correo);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }

            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;

        }
        public bool eliminar(Contactomodel ocontacto)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.GetCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_eliminar", conexion);
                    cmd.Parameters.AddWithValue("id", ocontacto.Id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;

            }

            catch (Exception ex)
            {
                string error = ex.Message;
                rpta = false;
            }
            return rpta;
        }

    }
}