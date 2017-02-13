using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco.AccesoDatos;
using Banco.EntitadadesNegocio;

namespace Banco.LogicaNegocio
{
    public class BLBanco
    {
        #region Banco
        public List<BEBanco> ConsultarBanco(BEBanco obeBanco)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.ConsultarBanco(obeBanco);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }

        public List<BEBanco> RegistrarBanco(BEBanco obeBanco)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.RegistrarBanco(obeBanco);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }
        }

        public List<BEBanco> ActualizarBanco(BEBanco obeBanco)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.ActualizarBanco(obeBanco);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }

        public List<BEBanco> EliminarBanco(BEBanco obeBanco)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.EliminarBanco(obeBanco);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }
        #endregion

        #region Sucursales

        public List<BESucursal> ConsultarSucursales(BESucursal obeSucursal)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.ConsultarSurcursal(obeSucursal);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }

        public List<BESucursal> RegistrarSucursal(BESucursal obeSucursal)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.RegistrarSucursal(obeSucursal);
            }

            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }
        public List<BESucursal> ActualizarSucursal(BESucursal obeSucursal)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.ActualizarSucursal(obeSucursal);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }

        public List<BESucursal> EliminarSucursal(BESucursal obeSucursal)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.EliminarSucursal(obeSucursal);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }

        #endregion

        #region OrdenPago

        public List<BEOrdenPago> ConsultarOrdenPago(BEOrdenPago oOrdenPago)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.ConsultarOrdenPago(oOrdenPago);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }

        public List<BEOrdenPago> RegistrarOrdenPago(BEOrdenPago oOrdenPago)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.RegistrarOrdenPago(oOrdenPago);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }

        public List<BEOrdenPago> ActualizarOrdenPago(BEOrdenPago oOrdenPago)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.ActualizarOrdenPago(oOrdenPago);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }

        public List<BEOrdenPago> EliminarOrdenPago(BEOrdenPago oOrdenPago)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.EliminarOrdenPago(oOrdenPago);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }
        #endregion

        #region Moneda
        public List<BEMoneda> ConsultarMoneda(BEMoneda ofiltro)
        {
            DABanco odaBanco = new DABanco();
            return odaBanco.ConsultarMoneda(ofiltro);
        }

        public List<BEMoneda> RegistrarMoneda(BEMoneda ofiltro)
        {
            DABanco odaBanco = new DABanco();
            return odaBanco.RegistrarMoneda(ofiltro);
        }

        public List<BEMoneda> ActualizarMoneda(BEMoneda ofiltro)
        {
            DABanco odaBanco = new DABanco();
            return odaBanco.ActualizarMoneda(ofiltro);
        }

        public List<BEMoneda> EliminarMoneda(BEMoneda ofiltro)
        {
            DABanco odaBanco = new DABanco();
            return odaBanco.EliminarMoneda(ofiltro);
        }
        #endregion


        #region EstadoOrdenPago
        public List<BEEstadoOrden> ConsultarEstadoOrden(BEEstadoOrden obeEstadoOrden)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.ConsultarEstadoOrden(obeEstadoOrden);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }

        public List<BEEstadoOrden> RegistrarEstadoOrden(BEEstadoOrden obeEstadoOrden)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.RegistrarEstadoOrden(obeEstadoOrden);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message.ToString());
            }

        }

        public List<BEEstadoOrden> ActualizarEstadoOrden(BEEstadoOrden obeEstadoOrden)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.ActualizarEstadoOrden(obeEstadoOrden);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message.ToString());
            }
           
        }

        public List<BEEstadoOrden> EliminarEstadoOrden(BEEstadoOrden obeEstadoOrden)
        {
            try
            {
                DABanco odaBanco = new DABanco();
                return odaBanco.EliminarEstadoOrden(obeEstadoOrden);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message.ToString());
            }
          
        }
        #endregion

    }
}
