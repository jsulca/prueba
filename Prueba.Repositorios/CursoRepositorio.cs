using Prueba.Entidades;
using Prueba.Repositorios.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Repositorios
{
    public class CursoRepositorio : BaseRepositorio
    {
        #region Contructores

        public CursoRepositorio(SqlConnection cn) : base(cn) { }
        public CursoRepositorio(SqlConnection cn, SqlTransaction trx) : base(cn, trx) { }

        #endregion

        public Curso BuscarPorId(int id)
        {
            Curso entidad = null;
            try
            {
                //SqlCommand https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand?view=netframework-4.5
                using (var cmd = CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_Curso_BuscarPorId";

                    cmd.Parameters.AddWithValue("@id", id);

                    //SqlDataReader https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqldatareader?view=netframework-4.5
                    using (var rd = cmd.ExecuteReader())
                    {
                        while (rd.Read())
                        {
                            entidad = new Curso
                            {
                                Id = id,
                                Descripcion = rd.GetString(0),
                                Activo = rd.GetBoolean(1),
                                Credito = rd.GetInt32(2),
                                FechaRegistro = rd.GetDateTime(3)
                            };
                        }
                        rd.Close();
                    }

                }
                return entidad;
            }
            catch (Exception)
            {
                throw new Exception("Error al buscar por id.");
            }
        }

        public List<Curso> Listar()
        {
            List<Curso> lista = null;
            try
            {
                //SqlCommand https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqlcommand?view=netframework-4.5
                using (var cmd = CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_Curso_Listar";

                    //SqlDataReader https://docs.microsoft.com/en-us/dotnet/api/system.data.sqlclient.sqldatareader?view=netframework-4.5
                    using (var rd = cmd.ExecuteReader())
                    {
                        lista = new List<Curso>();
                        while (rd.Read())
                        {
                            lista.Add(new Curso
                            {
                                Id = rd.GetInt32(0),
                                Descripcion = rd.GetString(1),
                                Activo = rd.GetBoolean(2),
                                Credito = rd.GetInt32(3),
                                FechaRegistro = rd.GetDateTime(4)
                            });
                        }
                        rd.Close();
                    }
                }
                return lista;
            }
            catch (Exception)
            {
                throw new Exception("Error al listar.");
            }
        }

        public bool Actualizar(Curso entidad)
        {
            bool respuesta = false;
            try
            {
                using (var cmd = CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_Curso_Actualizar";

                    cmd.Parameters.AddWithValue("@id", entidad.Id);
                    cmd.Parameters.AddWithValue("@descripcion", entidad.Descripcion);
                    cmd.Parameters.AddWithValue("@activo", entidad.Activo);
                    cmd.Parameters.AddWithValue("@credito", entidad.Credito);

                    //ExecuteNonQuery devuelve la cantidad de registros actualizados
                    respuesta = cmd.ExecuteNonQuery() == 1;
                }
                return respuesta;
            }
            catch (Exception)
            {
                throw new Exception("Error al actualizar el curso");
            }
        }

        public bool Guardar(Curso entidad)
        {
            bool respuesta = false;
            try
            {
                using (var cmd = CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_Curso_Guardar";

                    cmd.Parameters.AddWithValue("@descripcion", entidad.Descripcion);
                    cmd.Parameters.AddWithValue("@activo", entidad.Activo);
                    cmd.Parameters.AddWithValue("@credito", entidad.Credito);

                    //ExecuteScalar devuelve el valor de la primera fila y primera columna
                    entidad.Id = int.Parse(cmd.ExecuteScalar().ToString());

                    respuesta = entidad.Id > 0;
                }
                return respuesta;
            }
            catch (Exception)
            {
                throw new Exception("Error al guardar el curso");
            }
        }

        public bool Eliminar(int id)
        {
            bool respuesta = false;
            try
            {
                using (var cmd = CreateCommand())
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "usp_Curso_Eliminar";

                    cmd.Parameters.AddWithValue("@id", id);

                    //ExecuteNonQuery devuelve la cantidad de registros actualizados
                    respuesta = cmd.ExecuteNonQuery() == 1;
                }
                return respuesta;
            }
            catch (Exception)
            {
                throw new Exception("Error al eliminar el curso");
            }
        }
    }
}
