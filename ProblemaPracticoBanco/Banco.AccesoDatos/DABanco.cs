using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Banco.AccesoDatos;
using Banco.EntitadadesNegocio;
using System.Data.SqlClient;

namespace Banco.AccesoDatos
{
    public class DABanco
    {

        #region Banco

        public List<BEBanco> ConsultarBanco(BEBanco obeBanco)
        {

            
            List<BEBanco> oResultado = new List<BEBanco>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_ConsultarBanco", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_Banco_ID", obeBanco.Banco_ID ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@pi_Banco_Nombre", obeBanco.Banco_Nombre ?? (object)DBNull.Value);
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            oResultado.Add(new BEBanco()
                            {
                                Banco_ID = dr.GetInt32(dr.GetOrdinal("Banco_ID")),
                                Banco_Nombre = dr.GetString(dr.GetOrdinal("Banco_Nombre")),
                                Banco_Direccion = dr.GetString(dr.GetOrdinal("Banco_Direccion")),
                                Banco_FechaRegistro = dr.GetDateTime(dr.GetOrdinal("Banco_FechaRegistro"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;

        }
        public List<BEBanco> RegistrarBanco(BEBanco obeBanco)
        {
            List<BEBanco> oResultado = new List<BEBanco>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_InsertarBanco", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_Banco_Nombre", obeBanco.Banco_Nombre);
                        cmd.Parameters.AddWithValue("@pi_Banco_Direccion", obeBanco.Banco_Direccion);
                      
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;

        }

        public List<BEBanco> ActualizarBanco(BEBanco obeBanco)
        {
            List<BEBanco> oResultado = new List<BEBanco>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_ActualizarBanco", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_Banco_ID", obeBanco.Banco_ID);
                        cmd.Parameters.AddWithValue("@pi_Banco_Nombre", obeBanco.Banco_Nombre);
                        cmd.Parameters.AddWithValue("@pi_Banco_Direccion", obeBanco.Banco_Direccion);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;
        }

        public List<BEBanco> EliminarBanco(BEBanco obeBanco)
        {
            List<BEBanco> oResultado = new List<BEBanco>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_EliminarBanco", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_Banco_ID", obeBanco.Banco_ID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;
        }

        #endregion

        #region Sucursales
        public List<BESucursal> ConsultarSurcursal(BESucursal obeSucursal)
        {

            List<BESucursal> oResultado = new List<BESucursal>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_ConsultarSucursal", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_Sucursal_ID", obeSucursal.Sucursal_ID ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@pi_Banco_ID", obeSucursal.Banco_ID ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@pi_Sucursal_Nombre", obeSucursal.Sucursal_Nombre ?? (object)DBNull.Value);

                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            oResultado.Add(new BESucursal
                            {
                                Sucursal_ID = dr.GetInt32(dr.GetOrdinal("Sucursal_ID")),
                                Banco = new BEBanco()
                                {
                                    Banco_ID = dr.GetInt32(dr.GetOrdinal("Banco_ID")),
                                    Banco_Nombre = dr.GetString(dr.GetOrdinal("Banco_Nombre"))
                                },
                                Banco_ID = dr.GetInt32(dr.GetOrdinal("Banco_ID")),
                                Sucursal_Nombre = dr.GetString(dr.GetOrdinal("Sucursal_Nombre")),
                                Sucursal_Direccion = dr.GetString(dr.GetOrdinal("Sucursal_Direccion")),
                                Sucursal_FechaRegistro = dr.GetDateTime(dr.GetOrdinal("Sucursal_FechaRegistro"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;

        }
        public List<BESucursal> RegistrarSucursal(BESucursal obeSucursal)
        {
            List<BESucursal> oResultado = new List<BESucursal>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_InsertarSucursal", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_Banco_ID", obeSucursal.Banco_ID);
                        cmd.Parameters.AddWithValue("@pi_Sucursal_Nombre", obeSucursal.Sucursal_Nombre);
                        cmd.Parameters.AddWithValue("@pi_Sucursal_Direccion", obeSucursal.Sucursal_Direccion);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;
        }


        public List<BESucursal> ActualizarSucursal(BESucursal obeSucursal)
        {
            List<BESucursal> oResultado = new List<BESucursal>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_ActualizarSucursal", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_Sucursal_ID", obeSucursal.Sucursal_ID);
                        cmd.Parameters.AddWithValue("@pi_Banco_ID", obeSucursal.Banco_ID);
                        cmd.Parameters.AddWithValue("@pi_Sucursal_Nombre", obeSucursal.Sucursal_Nombre);
                        cmd.Parameters.AddWithValue("@pi_Sucursal_Direccion", obeSucursal.Sucursal_Direccion);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;
        }

        public List<BESucursal> EliminarSucursal(BESucursal obeSucursal)
        {
            List<BESucursal> oResultado = new List<BESucursal>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_EliminarSucursal", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_Sucursal_ID", obeSucursal.Sucursal_ID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;
        }
        #endregion

        #region OrdenPago
        public List<BEOrdenPago> ConsultarOrdenPago(BEOrdenPago obeOrdenPago)
        {

            List<BEOrdenPago> oResultado = new List<BEOrdenPago>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_ConsultarOrdenPago", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_OrdenPago_ID", obeOrdenPago.OrdenPago_ID ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@pi_Sucursal_ID", obeOrdenPago.Sucursal_ID ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@pi_Moneda_ID", obeOrdenPago.Moneda_ID ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@pi_EstadoOrden_ID", obeOrdenPago.EstadoOrden_ID ?? (object)DBNull.Value);
 
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            oResultado.Add(new BEOrdenPago
                            {
                                OrdenPago_ID = dr.GetInt32(dr.GetOrdinal("OrdenPago_ID")),
                                Sucursal = new BESucursal()
                                {
                                    Sucursal_ID = dr.GetInt32(dr.GetOrdinal("Sucursal_ID")),
                                    Sucursal_Nombre = dr.GetString(dr.GetOrdinal("Sucursal_Nombre"))
                                },
                                Sucursal_ID = dr.GetInt32(dr.GetOrdinal("Sucursal_ID")),
                                    Sucursal_Nombre = dr.GetString(dr.GetOrdinal("Sucursal_Nombre")),
                                Moneda = new BEMoneda()
                                {
                                    Moneda_ID = dr.GetInt32(dr.GetOrdinal("Moneda_ID")),
                                    Moneda_Abreviatura = dr.GetString(dr.GetOrdinal("Moneda_Abreviatura"))
                                },
                                Moneda_ID = dr.GetInt32(dr.GetOrdinal("Moneda_ID")),
                                    Moneda_Abreviatura = dr.GetString(dr.GetOrdinal("Moneda_Abreviatura")),
                                     Moneda_Nombre = dr.GetString(dr.GetOrdinal("Moneda_Nombre")),
                                EstadoOrden = new BEEstadoOrden() { EstadoOrden_ID = dr.GetInt32(dr.GetOrdinal("EstadoOrden_ID")) ,
                                EstadoOrden_Nombre = dr.GetString(dr.GetOrdinal("EstadoOrden_Nombre"))},
                                EstadoOrden_ID = dr.GetInt32(dr.GetOrdinal("EstadoOrden_ID")) ,
                                EstadoOrden_Nombre = dr.GetString(dr.GetOrdinal("EstadoOrden_Nombre")),
                                OrdenPago_Monto = dr.GetDecimal(dr.GetOrdinal("OrdenPago_Monto")),
                                OrdenPago_FechaPago = dr.GetDateTime(dr.GetOrdinal("OrdenPago_FechaPago"))
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;

        }
        public List<BEOrdenPago> RegistrarOrdenPago(BEOrdenPago obeOrdenPago)
        {
            List<BEOrdenPago> oResultado = new List<BEOrdenPago>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_InsertarOrdenPago", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_Sucursal_ID", obeOrdenPago.Sucursal_ID);
                        cmd.Parameters.AddWithValue("@pi_Moneda_ID", obeOrdenPago.Moneda_ID);
                        cmd.Parameters.AddWithValue("@pi_EstadoOrden_ID", obeOrdenPago.EstadoOrden_ID);
                        cmd.Parameters.AddWithValue("@pi_OrdenPago_Monto", obeOrdenPago.OrdenPago_Monto);
                        cmd.Parameters.AddWithValue("@pi_OrdenPago_FechaPago", obeOrdenPago.OrdenPago_FechaPago);
                        
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;
        }

        public List<BEOrdenPago> ActualizarOrdenPago(BEOrdenPago obeOrdenPago)
        {
            List<BEOrdenPago> oResultado = new List<BEOrdenPago>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_ActualizarOrdenPago", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_OrdenPago_ID", obeOrdenPago.OrdenPago_ID);
                        cmd.Parameters.AddWithValue("@pi_Sucursal_ID", obeOrdenPago.Sucursal_ID);
                        cmd.Parameters.AddWithValue("@pi_Moneda_ID", obeOrdenPago.Moneda_ID);
                        cmd.Parameters.AddWithValue("@pi_EstadoOrden_ID", obeOrdenPago.EstadoOrden_ID);
                        cmd.Parameters.AddWithValue("@pi_OrdenPago_Monto", obeOrdenPago.OrdenPago_Monto);
                        cmd.Parameters.AddWithValue("@pi_OrdenPago_FechaPago", obeOrdenPago.OrdenPago_FechaPago);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;
        }

        public List<BEOrdenPago> EliminarOrdenPago(BEOrdenPago obeOrdenPago)
        {
            List<BEOrdenPago> oResultado = new List<BEOrdenPago>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_EliminarOrdenPago", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_OrdenPago_ID", obeOrdenPago.OrdenPago_ID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;
        }
        #endregion

        #region Moneda
        public List<BEMoneda> ConsultarMoneda(BEMoneda obeMoneda)
        {

            List<BEMoneda> oResultado = new List<BEMoneda>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_ConsultarMoneda", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_Moneda_ID", obeMoneda.Moneda_ID ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@pi_Moneda_Nombre", obeMoneda.Moneda_Nombre ?? (object)DBNull.Value);
                       SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            oResultado.Add(new BEMoneda
                            {
                                Moneda_ID = dr.GetInt32(dr.GetOrdinal("Moneda_ID")),
                                Moneda_Nombre = dr.GetString(dr.GetOrdinal("Moneda_Nombre")),
                                Moneda_Abreviatura = dr.GetString(dr.GetOrdinal("Moneda_Abreviatura")),

                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;

        }
        public List<BEMoneda> RegistrarMoneda(BEMoneda obeMoneda)
        {
            List<BEMoneda> oResultado = new List<BEMoneda>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_InsertarMoneda", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                         cmd.Parameters.AddWithValue("@pi_Moneda_Nombre", obeMoneda.Moneda_Nombre);
                        cmd.Parameters.AddWithValue("@pi_Moneda_Abreviatura", obeMoneda.Moneda_Abreviatura);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;

        }

        public List<BEMoneda> ActualizarMoneda(BEMoneda obeMoneda)
        {
            List<BEMoneda> oResultado = new List<BEMoneda>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_ActualizarMoneda", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_Moneda_ID", obeMoneda.Moneda_ID);
                        cmd.Parameters.AddWithValue("@pi_Moneda_Nombre", obeMoneda.Moneda_Nombre);
                        cmd.Parameters.AddWithValue("@pi_Moneda_Abreviatura", obeMoneda.Moneda_Abreviatura);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;
        }

        public List<BEMoneda> EliminarMoneda(BEMoneda obeMoneda)
        {
            List<BEMoneda> oResulatdo = new List<BEMoneda>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_EliminarMoneda", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_Moneda_ID", obeMoneda.Moneda_ID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResulatdo;
        }
        #endregion

        #region EstadoOrdenPago
        public List<BEEstadoOrden> ConsultarEstadoOrden(BEEstadoOrden obeEstadoOrden)
        {

            List<BEEstadoOrden> oResultado = new List<BEEstadoOrden>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_ConsultarEstadoOrden", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_EstadoOrden_ID", obeEstadoOrden.EstadoOrden_ID ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@pi_EstadoOrden_Nombre", obeEstadoOrden.EstadoOrden_Nombre ?? (object)DBNull.Value);
                        SqlDataReader dr = cmd.ExecuteReader();

                        while (dr.Read())
                        {
                            oResultado.Add(new BEEstadoOrden
                            {
                                EstadoOrden_ID = dr.GetInt32(dr.GetOrdinal("EstadoOrden_ID")),
                                EstadoOrden_Nombre = dr.GetString(dr.GetOrdinal("EstadoOrden_Nombre")),

                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;

        }
        public List<BEEstadoOrden> RegistrarEstadoOrden(BEEstadoOrden obeEstadoOrden)
        {
            List<BEEstadoOrden> oResultado = new List<BEEstadoOrden>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_InsertarEstadoOrden", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_EstadoOrden_Nombre", obeEstadoOrden.EstadoOrden_Nombre ?? (object)DBNull.Value);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;
        }


        public List<BEEstadoOrden> ActualizarEstadoOrden(BEEstadoOrden obeEstadoOrden)
        {
            List<BEEstadoOrden> oResultado = new List<BEEstadoOrden>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("usp_ActualizarEstadoOrden", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_EstadoOrden_ID", obeEstadoOrden.EstadoOrden_ID ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@pi_EstadoOrden_Nombre", obeEstadoOrden.EstadoOrden_Nombre ?? (object)DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;
        }

        public List<BEEstadoOrden> EliminarEstadoOrden(BEEstadoOrden obeEstadoOrden)
        {
            List<BEEstadoOrden> oResultado = new List<BEEstadoOrden>();

            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionSQL.ConnectionString()))
                {

                    oConexion.Open();

                    using (SqlCommand cmd = new SqlCommand("USP_EliminarEstadoOrden", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@pi_EstadoOrden_ID", obeEstadoOrden.EstadoOrden_ID);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
            return oResultado;
        }
        #endregion





    }
}
