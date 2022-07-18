using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Estatus
    {
            public static ML.Result GetAll()
            {
                ML.Result result = new ML.Result();

                try
                {
                    using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                    {
                        string query = "EstatusGetAll";
                        using (SqlCommand cmd = new SqlCommand())
                        {
                            cmd.Connection = context;
                            cmd.CommandText = query;
                            cmd.CommandType = CommandType.StoredProcedure;

                            DataTable tableEstatus = new DataTable();
                            SqlDataAdapter da = new SqlDataAdapter(cmd);

                            da.Fill(tableEstatus);

                            if (tableEstatus.Rows.Count > 0)
                            {
                                result.Objects = new List<object>();
                                foreach (DataRow row in tableEstatus.Rows)
                                {
                                    ML.Estatus estatus = new ML.Estatus();
                                    estatus.IdEstatus = int.Parse(row[0].ToString());
                                    estatus.Nombre = row[1].ToString();

                                    result.Objects.Add(estatus);

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
        }
}
