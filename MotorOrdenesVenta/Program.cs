using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dalCargasBaanCMI;
using System.Text.RegularExpressions;

[assembly: log4net.Config.XmlConfigurator(ConfigFileExtension = "config", Watch = true)]
namespace MotorOrdenesVenta
{
    class Program
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(typeof(Program));
        #region 

        static LogicIJ _logic = null;
        private dalLogProcess _oLog = new dalLogProcess();
        private string APP_NAME = "MotorOrdenesVenta.MotorOrdenesVenta";
        const string TerConError = "TCR";
        const string End = "TER";
        private int _iCurrentNumLog = 0;
        private string _ProcesoConErrores = "Proceso Terminado con errores";

        #endregion
        public void Inicializar()
        {
            //Probar con SQL
            try
            {
                _logic = new LogicIJ();
            }
            catch (Exception ex)
            {
                logger.Info("MotorOrdenesVenta.MotorOrdenesVenta ERROR INICIALIZAR:" + ex.Message + ". Inner:" + ex.InnerException + ". Source:" + ex.Source);
            }
        }
        static void Main(string[] args)
        {
            try
            {
                Program notif = new Program();
                //para pruebas
                //_logic = new LogicIJ();
                //string host = "brkmfprod.navistar.com"; // TODO: Initialize to an appropriate value
                //string user = "YYYD963"; // TODO: Initialize to an appropriate value
                //string pass = "DTUCHINA"; // TODO: Initialize to an appropriate value
                //string urlLocalFile = "InventarioJac.txt"; // TODO: Initialize to an appropriate value
                //string commands = "QUOTE SITE BL LR=100 BLK=27600 REC=FB PRI=10 SEC=10"; // TODO: Initialize to an appropriate value
                //string remotefile = "CVI.DATA.VIENG.J06.JACMVIN(+1)"; // TODO: Initialize to an appropriate value
                //var Result = _logic.UploadCMDFTP(host, user, pass, urlLocalFile, commands, remotefile);
                notif.MotorOrdenesVenta();
            }
            catch (Exception ex)
            {
                logger.Info("MotorOrdenesVenta.MotorOrdenesVenta ERROR GENERAL:" + ex.Message + ". Inner:" + ex.InnerException + ". Source:" + ex.Source);
            }
        }

        public void MotorOrdenesVenta()
        {
            Inicializar();
            string clase = "";
            string metodo = "";
            string tabla = "";
            string descripcion = "";
            //inicio
            try
            {
                this._iCurrentNumLog = this._oLog.InsertEvent(APP_NAME, DateTime.Now);
                logger.Info("Inicio de proceso MotorOrdenesVenta.MotorOrdenesVenta ");

                var Insertando = "";// _logic.InsertaVinesNuevos();
                Inicializar();//se inicializa de nuevo para que pueda guardar que ya se notifico, sino marca error.
                if (Insertando.StartsWith("True"))
                {
                    descripcion = "Se insertaron los registros nuevos en la tabla TCDMC_NOTIFICACION_INVJAC";
                    this._oLog.InsertEventDetalle(this._iCurrentNumLog, APP_NAME, clase, metodo, "", tabla,
                        0, 0, 0, 0, 0,
                        descripcion, "", "", "");
                    logger.Info("MotorOrdenesVenta.Cargar :" + descripcion);
                    var Notificando = "";// _logic.CreaArchivoVinesInventarioNuevos();
                    if (Notificando.StartsWith("False"))
                    {
                        descripcion = "Existio un problema:" + Notificando + ".No se genero el archivo ni se modificaron los estatus de unidades";
                        this._oLog.InsertEventDetalle(this._iCurrentNumLog, APP_NAME, clase, metodo, "", tabla,
                            0, 0, 0, 0, 0,
                            descripcion, "", "", "");
                        logger.Info("MotorOrdenesVenta.Cargar :" + descripcion);

                        this._oLog.UpdEvent(this._iCurrentNumLog, DateTime.Now, "Fin de Proceso exitoso", Program.End);
                        logger.Info("MotorOrdenesVenta.Cargar: Fin de proceso exitoso");
                    }
                    else if (Notificando.StartsWith("True"))
                    {
                        descripcion = "Se genero el archivo y se actualizaron los registros de la tabla TCDMC_NOTIFICACION_INVJAC";
                        this._oLog.InsertEventDetalle(this._iCurrentNumLog, APP_NAME, clase, metodo, "", tabla,
                            0, 0, 0, 0, 0,
                            descripcion, "", "", "");
                        logger.Info("MotorOrdenesVenta.Cargar :" + descripcion);

                        this._oLog.UpdEvent(this._iCurrentNumLog, DateTime.Now, "Fin de Proceso exitoso", Program.End);
                        logger.Info("MotorOrdenesVenta.Cargar: Fin de proceso exitoso");

                        var CargaArchivoFTP = "";// _logic.SubirArchivoFTP();
                        if (CargaArchivoFTP.StartsWith("True"))
                        {
                            descripcion = "Se cargo el archivo al FTP correctamente";
                            this._oLog.InsertEventDetalle(this._iCurrentNumLog, APP_NAME, clase, metodo, "", tabla,
                                0, 0, 0, 0, 0,
                                descripcion, "", "", "");
                            logger.Info("MotorOrdenesVenta.Cargar :" + descripcion);

                            this._oLog.UpdEvent(this._iCurrentNumLog, DateTime.Now, "Fin de Proceso exitoso", Program.End);
                            logger.Info("MotorOrdenesVenta.Cargar: Fin de proceso exitoso");
                        }
                        else
                        {
                            clase = "CargaVentas.Logic";
                            metodo = "UploadCMDFTP";
                            tabla = "FTP";
                            Notificando = "Ocurrio un error al cargar el archivo al FTP:" + CargaArchivoFTP;
                            descripcion = Notificando;
                            this._oLog.InsertEventDetalle(this._iCurrentNumLog, APP_NAME, clase, metodo, "", tabla, 0, 0, 0, 0, 0,
                                        descripcion, "", "", "");
                            this._oLog.UpdEvent(this._iCurrentNumLog, DateTime.Now, this._ProcesoConErrores, Program.TerConError);

                            logger.Info("MotorOrdenesVenta.Cargar error: " + descripcion);
                            return;
                        }
                        //Notificando = "Se notifico al Distribuidor";
                    }
                    else if (Notificando.StartsWith("Success 0"))
                    {
                        descripcion = "No hay Vines nuevos para generar el archivo";
                        this._oLog.InsertEventDetalle(this._iCurrentNumLog, APP_NAME, clase, metodo, "", tabla,
                            0, 0, 0, 0, 0,
                            descripcion, "", "", "");
                        logger.Info("MotorOrdenesVenta.Cargar :" + descripcion);
                        this._oLog.UpdEvent(this._iCurrentNumLog, DateTime.Now, "Fin de Proceso exitoso", Program.End);
                        logger.Info("MotorOrdenesVenta.Cargar: Fin de proceso exitoso");
                        //Notificando = "No hay vines para notificar";
                    }
                    else
                    {
                        clase = "CargaVentas.Logic";
                        metodo = "CreaArchivoVinesInventarioNuevos";
                        tabla = "TCDMC_NOTIFICACION_INVJAC - FILE_NAME";
                        Notificando = "Ocurrio un error al generar archivo y/o actualizar registros:" + Notificando;
                        descripcion = Notificando;
                        this._oLog.InsertEventDetalle(this._iCurrentNumLog, APP_NAME, clase, metodo, "", tabla, 0, 0, 0, 0, 0,
                                    descripcion, "", "", "");
                        this._oLog.UpdEvent(this._iCurrentNumLog, DateTime.Now, this._ProcesoConErrores, Program.TerConError);

                        logger.Info("MotorOrdenesVenta.Cargar error: " + descripcion);
                        return;

                    }
                }
                else
                {
                    clase = "MotorOrdenesVenta.Logic";
                    metodo = "InsertaVinesNuevos";
                    tabla = "TCDMC_NOTIFICACION_INVJAC";
                    Insertando = "Ocurrio un error al insertar:" + Insertando;
                    descripcion = Insertando;
                    this._oLog.InsertEventDetalle(this._iCurrentNumLog, APP_NAME, clase, metodo, "", tabla, 0, 0, 0, 0, 0,
                                    descripcion, "", "", "");
                    this._oLog.UpdEvent(this._iCurrentNumLog, DateTime.Now, this._ProcesoConErrores, Program.TerConError);

                    logger.Info("MotorOrdenesVenta.MotorOrdenesVenta error: " + descripcion);

                    return;
                }
            }
            catch (Exception ex)
            {
                logger.Info("MotorOrdenesVenta.MotorOrdenesVenta ERROR INTERNO:" + ex.Message + ". Inner:" + ex.InnerException + ". Source:" + ex.Source);
                throw new System.Exception("_Olog:" + _oLog.ToString());
            }

        }


    }
}