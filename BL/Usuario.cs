using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UsuarioGetAll";
                    using (SqlCommand cmd = new SqlCommand())
                     {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable tableUsuario = new DataTable();
                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in tableUsuario.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();
                                usuario.IdUsuario = int.Parse(row[0].ToString());
                                usuario.Nombre = row[1].ToString();
                                usuario.ApellidoPaterno = row[2].ToString();
                                usuario.ApellidoPaterno = row[3].ToString();
                                usuario.Email = row[4].ToString();
                                usuario.Contraseña = row[5].ToString();
                                if (row[6].ToString() != "")
                                {
                                    usuario.Imagen = new byte[0];
                                }
                                else
                                {
                                    usuario.Imagen = (byte[])row[6];
                                }
                                usuario.UserName = row[7].ToString();
                                usuario.Estado = new ML.Estado();
                                usuario.Estado.IdEstado = int.Parse(row[8].ToString());
                                usuario.Estado.Nombre = row[9].ToString();
                                usuario.Estatus = new ML.Estatus();
                                usuario.Estatus.IdEstatus = int.Parse(row[10].ToString());
                                usuario.Estatus.Nombre = row[11].ToString();

                                result.Objects.Add(usuario);

                            }
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UsuarioAdd"; //Nombre SP

                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[9];

                        collection[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        collection[0].Value = usuario.Nombre;

                        collection[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        collection[1].Value = usuario.ApellidoPaterno;

                        collection[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        collection[2].Value = usuario.ApellidoMaterno;

                        collection[3] = new SqlParameter("Email", SqlDbType.VarChar);
                        collection[3].Value = usuario.Email;

                        collection[4] = new SqlParameter("Contraseña", SqlDbType.VarChar);
                        collection[4].Value = usuario.Contraseña;

                        collection[5] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[5].Value = usuario.UserName;

                        collection[6] = new SqlParameter("Imagen", SqlDbType.VarBinary);
                        if (usuario.Imagen != null)
                        {
                            collection[6].Value = usuario.Imagen;
                        }
                        else
                        {
                            collection[6].Value = new byte[0];
                        }

                        collection[7] = new SqlParameter("IdEstado", SqlDbType.Int);
                        collection[7].Value = 1;

                        collection[8] = new SqlParameter("IdEstatus", SqlDbType.Int);
                        collection[8].Value = 1;

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();
                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }

                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }
        public static ML.Result UpdateEstatus(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UsuarioUpdateEstatus";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[2];

                        collection[0] = new SqlParameter("UserName", SqlDbType.VarChar);
                        collection[0].Value = usuario.UserName;

                        collection[1] = new SqlParameter("IdEstatus", SqlDbType.VarChar);
                        collection[1].Value = usuario.Estatus.IdEstatus;


                        cmd.Parameters.AddRange(collection);

                        cmd.Connection.Open();

                        int RowsAffected = cmd.ExecuteNonQuery();

                        cmd.Connection.Close();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
        public static ML.Result GetById(int idUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "UsuarioGetById"; //Nombre SP
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = context;
                        cmd.CommandText = query;
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlParameter[] collection = new SqlParameter[1];

                        collection[0] = new SqlParameter("IdUsuario", SqlDbType.Int);
                        collection[0].Value = idUsuario;


                        DataTable tableUsuario = new DataTable();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);

                        cmd.Parameters.AddRange(collection);
                        cmd.Connection.Open();

                        da.Fill(tableUsuario);

                        if (tableUsuario.Rows.Count > 0)
                        {
                            DataRow row = tableUsuario.Rows[0];

                            ML.Usuario usuario = new ML.Usuario();
                            usuario.IdUsuario = int.Parse(row[0].ToString());

                            usuario.Nombre = row[1].ToString();
                            usuario.ApellidoPaterno = row[2].ToString();
                            usuario.ApellidoMaterno = row[3].ToString();
                            usuario.UserName = row[4].ToString();

                            result.Object = usuario;

                            result.Correct = true;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;

            }
            return result;
        }
    }
}
