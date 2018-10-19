using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using MySql.Data.MySqlClient;

namespace DAL
{
    public class DALClass
    {
        string cadenaconexion = "";
        MySqlConnection conexion;

        public DALClass(string server, string basededatos, string usuario, string clave)
        {
            cadenaconexion = "Server=" + server + "; Uid=" + usuario + "; Pwd=" + clave + "; Database=" + basededatos + ";";
            conexion = new MySqlConnection(cadenaconexion);
        }

        public DataTable ProcedimientoAlmacenado(string procedimiento, List<MySqlParameter> parametrosentrada, List<MySqlParameter> parametrossalida)
        {
            if (conexion != null)
            {
                DataTable resultado = new DataTable();
                MySqlDataAdapter adaptador;
                MySqlCommand comando = new MySqlCommand();
                try
                {
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandText = procedimiento;
                    comando.CommandType = CommandType.StoredProcedure;
                    foreach (MySqlParameter parametro in parametrosentrada)
                    {
                        parametro.Direction = ParameterDirection.Input;
                        comando.Parameters.Add(parametro);
                    }
                    foreach (MySqlParameter parametro in parametrossalida)
                    {
                        parametro.Direction = ParameterDirection.Output;
                        comando.Parameters.Add(parametro);
                    }
                    adaptador = new MySqlDataAdapter(comando);
                    adaptador.Fill(resultado);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    conexion.Close();
                }
                return resultado;
            }
            return new DataTable();
        }

        public DataTable Consulta(string procedimiento, List<MySqlParameter> parametrosentrada)
        {
            if (conexion != null)
            {
                DataTable resultado = new DataTable();
                MySqlDataAdapter adaptador;
                MySqlCommand comando = new MySqlCommand();
                try
                {
                    conexion.Open();
                    comando.Connection = conexion;
                    comando.CommandText = procedimiento;
                    comando.CommandType = CommandType.StoredProcedure;
                    foreach (MySqlParameter parametro in parametrosentrada)
                    {
                        parametro.Direction = ParameterDirection.Input;
                        comando.Parameters.Add(parametro);
                    }
                    adaptador = new MySqlDataAdapter(comando);
                    adaptador.Fill(resultado);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    conexion.Close();
                }
                return resultado;
            }
            return new DataTable();
        }


        public DataTable Sql(string comandotexto, string tabla, List<String> campos, string condicion)
        {
            if (conexion != null)
            {
                DataTable resultado = new DataTable();
                MySqlDataAdapter adaptador;
                MySqlCommand comando = new MySqlCommand();
                comando = new MySqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                try
                {
                    conexion.Open();
                    string sql;
                    switch (comandotexto)
                    {
                        case "insert":
                            sql = "insert into " + tabla + " values(";
                            SumarCampos(ref sql, campos);
                            sql += ")";
                            comando.CommandText = sql;
                            comando.Connection = conexion;
                            adaptador = new MySqlDataAdapter(comando);
                            adaptador.Fill(resultado);
                            break;
                        case "delete":
                            sql = "delete from " + tabla + " where " + condicion;
                            comando.CommandText = sql;
                            comando.Connection = conexion;
                            adaptador = new MySqlDataAdapter(comando);
                            adaptador.Fill(resultado);
                            break;
                        case "update":
                            sql = "update " + tabla + " set ";
                            SumarCampos(ref sql, campos);
                            sql += " where " + condicion;
                            comando.CommandText = sql;
                            comando.Connection = conexion;
                            adaptador = new MySqlDataAdapter(comando);
                            adaptador.Fill(resultado);
                            break;
                        case "select":
                            sql = "select ";
                            SumarCampos(ref sql, campos);
                            sql += " from " + tabla;
                            if (condicion != "")
                                sql += " where " + condicion;
                            comando.CommandText = sql;
                            adaptador = new MySqlDataAdapter(comando);
                            adaptador.Fill(resultado);
                            break;
                        case "select top":
                            sql = "select top 1";
                            SumarCampos(ref sql, campos);
                            sql += " from " + tabla;
                            if (condicion != "")
                                sql += " where " + condicion;
                            comando.CommandText = sql;
                            adaptador = new MySqlDataAdapter(comando);
                            adaptador.Fill(resultado);
                            break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    conexion.Close();
                }
                return resultado;
            }
            return new DataTable();
        }

        public DataTable Sql(string comandotexto, string tabla, string campos, string condicion)
        {
            if (conexion != null)
            {
                DataTable resultado = new DataTable();
                MySqlDataAdapter adaptador;
                MySqlCommand comando = new MySqlCommand();
                comando = new MySqlCommand();
                comando.Connection = conexion;
                comando.CommandType = CommandType.Text;
                try
                {
                    conexion.Open();
                    string sql;
                    switch (comandotexto)
                    {
                        case "select":
                            sql = "select " + campos;
                            sql += " from " + tabla;
                            if (condicion != "")
                                sql += " where " + condicion;
                            comando.CommandText = sql;
                            adaptador = new MySqlDataAdapter(comando);
                            adaptador.Fill(resultado);
                            break;
                        case "select top":
                            sql = "select " + campos;
                            sql += " from " + tabla;
                            if (condicion != "")
                                sql += " where " + condicion;
                            comando.CommandText = sql;
                            adaptador = new MySqlDataAdapter(comando);
                            adaptador.Fill(resultado);
                            break;
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    conexion.Close();
                }
                return resultado;
            }
            return new DataTable();
        }

        private void SumarCampos(ref string sql, List<string> campos)
        {
            int numerocampos = campos.Count;
            for (int x = 0; x < numerocampos - 1; x++)
            {
                sql += campos[x] + ",";
            }
            sql += campos[numerocampos - 1];
        }

        public DataTable EjecutarSql(string sql)
        {
            try
            {

                conexion.Open();
                MySqlCommand comando = new MySqlCommand(sql, conexion);
                comando.CommandType = CommandType.Text;
                MySqlDataAdapter adaptador = new MySqlDataAdapter(comando);
                DataTable resultado = new DataTable();
                adaptador.Fill(resultado);
                return resultado;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conexion.Close();
            }
        }


        ~DALClass()
        {
            if (conexion != null)
                conexion.Close();
        }
    }
}
