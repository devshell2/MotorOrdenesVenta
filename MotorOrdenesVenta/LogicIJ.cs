using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.IO;
using System.Diagnostics;
using System.Transactions;

namespace MotorOrdenesVenta
{
    public class LogicIJ
    {
        Navimex_Mo2Entities _context = null;
        public LogicIJ()
        {
            _context = new Navimex_Mo2Entities();
        }
        ~LogicIJ()
        {
            _context = null;
        }

        #region Borrar_Metodos_Anteriores
        /*
        public List<vwInventario> GetNewInvJacList()
        {
            var Registros = this._context.TCDMC_NOTIFICACION_INVJAC
                //.Where(R => 
                //R.ST_NOTIFICACION == "SI"
                //)
                    .Select(q=> q.CD_VIN);
            return this._context.vwInventarios.Where(s => 
                this._context.vwInventarios.Where(q => 
                (q.vin.StartsWith("3A9") || q.vin.StartsWith("LJ1"))
                ).Select(r=>r.vin).Except(Registros).Contains(s.vin))
                .ToList();
                
        }

        public List<vwInventarioJac> GetNewInvJacLst()
        {
            var Registros = this._context.TCDMC_NOTIFICACION_INVJAC
                //.Where(R => 
                //R.ST_NOTIFICACION == "SI"
                //)
                    .Select(q => q.CD_VIN);
            return this._context.vwInventarioJacs.Where(s =>
                this._context.vwInventarioJacs.
                Select(r => r.vin).
                Except(Registros).
                Contains(s.vin))
                .ToList();

        }

        public List<vwInventarioJac> GetNewInvJacLstArchivo()
        {
            var Registros = this._context.TCDMC_NOTIFICACION_INVJAC
                .Where(R => 
                R.ST_NOTIFICACION == "SI"
                )
                    .Select(q => q.CD_VIN);
            return this._context.vwInventarioJacs.Where(s =>
                this._context.vwInventarioJacs.
                Select(r => r.vin).
                Except(Registros).
                Contains(s.vin))
                .ToList();

        }

        public string InsertaVinesNuevos()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {
                    List<TCDMC_NOTIFICACION_INVJAC> Registros = new List<TCDMC_NOTIFICACION_INVJAC>();
                    List<vwInventarioJac> VinesNuevos = this.GetNewInvJacLst();
                    TCDMC_NOTIFICACION_INVJAC NewReg;
                    foreach (string vin in VinesNuevos.Select(q => q.vin).Distinct())
                    {
                        NewReg = new TCDMC_NOTIFICACION_INVJAC
                        {
                            CD_VIN = vin,
                            FH_APLICACION = DateTime.Now,
                            ST_NOTIFICACION = "NO",
                            TX_OBSERVACIONES = "NO SE HA NOTIFICADO"
                        };
                        this._context.TCDMC_NOTIFICACION_INVJAC.Add(NewReg);
                    }
                    if (VinesNuevos.Count > 0)
                        this._context.SaveChanges();
                    scope.Complete();
                    return "True:Insertados " + VinesNuevos.Select(q => q.vin).Distinct().Count().ToString();
                }
                catch (Exception ex)
                {
                    return "False:" + ex.Message;
                }
            }
        }

        public string CreaArchivoVinesDTUNuevos(List<DTU> ODtus,string nomArchivo)
        {
            //falta crear el archivo dependiendo de lo que se necesite y dejarlo en ruta
            string all = "";
            foreach (var ODtu in ODtus)
            {
                string vin = ODtu.vin;
                string dealer = ODtu.dealer;
                string Locid = ODtu.Locid;
                string nomcli = ODtu.nomcli;
                string nomcon = ODtu.nomcon;
                string dire = ODtu.dire;
                string cp = ODtu.cp;
                string codarea = ODtu.codarea;
                string lada = ODtu.lada;
                string tel = ODtu.tel;//"6140786";
                string codtel = ODtu.codtel;
                string valodometro = ODtu.valodometro;
                string codigofijo = ODtu.codigofijo;
                string fecha = ODtu.fecha;

               
                    StringBuilder chasis = new StringBuilder(vin, 9, 8, 14);
                    all = all + chasis.ToString().PadRight(13);
                    StringBuilder jobdeal = new StringBuilder(vin, 11, 6, 14);
                    jobdeal.Append(dealer);
                    all = all + jobdeal.ToString().PadRight(14);
                    StringBuilder local = new StringBuilder(Locid, 16);
                    all = all + local.ToString().PadRight(16);
                    StringBuilder nomcl = new StringBuilder(nomcli, 70);
                    all = all + nomcl.ToString().PadRight(70);
                    StringBuilder nomcont = new StringBuilder(nomcon, 24);
                    all = all + nomcont.ToString().PadRight(24);
                    StringBuilder dir = new StringBuilder(dire, 223);
                    all = all + dir.ToString().PadRight(223);
                    StringBuilder cpos = new StringBuilder(cp, 6);
                    all = all + cpos.ToString().PadRight(6);
                    StringBuilder ca = new StringBuilder(codarea, 6);
                    all = all + ca.ToString().PadRight(6);
                    StringBuilder lad = new StringBuilder(lada, 6);
                    all = all + lad.ToString().PadRight(6);
                    StringBuilder ph = new StringBuilder(tel, 34);
                    ph.Append(codtel);
                    all = all + (ph.ToString().PadLeft(10)).PadRight(34);
                    StringBuilder odo = new StringBuilder(valodometro, 20);
                    all = all + odo.ToString().PadRight(20);
                    StringBuilder cf = new StringBuilder(codigofijo, 14);
                    all = all + cf.ToString().PadRight(14);
                    StringBuilder fh = new StringBuilder(fecha, 81);
                    all = all + fh.ToString().PadRight(81);
                    StringBuilder deal = new StringBuilder(dealer, 8);
                    all = all + deal.ToString().PadRight(8);
                    StringBuilder localidad = new StringBuilder(Locid, 27);
                    localidad.Append("".ToString().PadRight(27));
                    localidad.AppendLine();
                    //all = all + localidad.ToString().PadRight(27);
                    all = all + localidad;
                                
            }

                string FILE_NAME = nomArchivo;
                if (File.Exists(FILE_NAME))
                {
                    Console.WriteLine("{0} already exists!", FILE_NAME);
                    return "";
                }


                string encoding = "";
                Encoding enc = Encoding.ASCII;
                using (StreamWriter sw = new StreamWriter(FILE_NAME, false, enc))
                {
                    sw.Write(all);
                    encoding = sw.Encoding.ToString();//saber la codificacion
                }

            return "true";
        }

        public string CreaArchivoVinesInventarioNuevos()
        {

            //List<TCDMC_NOTIFICACION_INVJAC> InvJac = new List<TCDMC_NOTIFICACION_INVJAC>();
            //InvJac = this._context.TCDMC_NOTIFICACION_INVJAC.Where(q =>
            //    q.ST_NOTIFICACION == "NO").ToList();
            using (TransactionScope scope = new TransactionScope())
            {
                try
                {

                    List<vwInventarioJac> VinsJac = new List<vwInventarioJac>();
                    VinsJac = GetNewInvJacLstArchivo();
                    string constante = "JA1";
                    string FILE_NAME = @ConfigurationManager.AppSettings["rutaFile"] + @"\" + 
                        ConfigurationManager.AppSettings["urlLocalFileFTP"] + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + ".txt";
                    //string FILE_NAME = "InventarioJac.txt";
                    if (File.Exists(FILE_NAME))
                    {
                        //hacer que borre el archivo
                        Console.WriteLine("{0} already exists!", FILE_NAME);
                        return "False:Ya existe el archivo";
                    }
                    Encoding enc = Encoding.ASCII;
                    StringBuilder all = new StringBuilder();

                    List<string> vines = new List<string>();

                    if (VinsJac.Count == 0)
                    {
                        using (StreamWriter sw = new StreamWriter(FILE_NAME, false, enc))
                        {
                            sw.Write(all);
                            //encoding = sw.Encoding.ToString();//saber la codificacion
                        }
                        return "True 0:No hay nuevas unidades para registrar";
                    }

                    foreach (var vin in VinsJac)
                    {
                        StringBuilder vinengine = new StringBuilder(vin.vin, 31);
                        vinengine.Append(vin.Engine.PadRight(14));
                        vinengine.Append(vin.receipt_date.ToString().PadRight(28));
                        vinengine.Append(constante.PadRight(101));
                        vinengine.AppendLine();
                        all.Append(vinengine);
                        vines.Add(vin.vin);
                        TCDMC_NOTIFICACION_INVJAC RegActualizar = this._context.TCDMC_NOTIFICACION_INVJAC.Where(q =>
                            q.CD_VIN == vin.vin).SingleOrDefault();
                        RegActualizar.ST_NOTIFICACION = "SI";
                        RegActualizar.TX_OBSERVACIONES = "YA SE INCLUYO AL ARCHIVO ENVIADO";
                        RegActualizar.FH_APLICACION = DateTime.Now;

                    }


                    //string encoding = "";
                    using (StreamWriter sw = new StreamWriter(FILE_NAME, false, enc))
                    {
                        sw.Write(all);
                        //encoding = sw.Encoding.ToString();//saber la codificacion
                    }

                    this._context.SaveChanges();
                    scope.Complete();
                    return "True:";
                }
                catch (Exception ex)
                {
                    return "Error:" + ex.Message;
                }
            }
        }

        public string SubirArchivoFTP()
        {
            //falta leer valores desde config
            string host = ConfigurationManager.AppSettings["hostFTP"];
            string user = ConfigurationManager.AppSettings["userFTP"];
            string pass = ConfigurationManager.AppSettings["passFTP"];
            string urlLocalFile = ConfigurationManager.AppSettings["urlLocalFileFTP"] + DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString()+".txt";
            string commands = ConfigurationManager.AppSettings["commandsFTP"];
            string remotefile = ConfigurationManager.AppSettings["remotefileFTP"];
            string ruta = ConfigurationManager.AppSettings["rutaFile"]; 

            //solo para pruebas
            //host= "brkmfniad.navistar.com";
            //remotefile = "TVI.DATA.VIENG.J06.JACMVIN(+1)";
            
            //prod
            //brkmfprod.navistar.com
            //CVI.DATA.VIENG.J06.JACMVIN(+1)

            return UploadCMDFTP(host, user, pass,
                        urlLocalFile, commands,
                        remotefile,ruta);
        }

        public string UploadCMDFTP(string host, string user, string pass, string urlLocalFile, string commands, string remotefile,string ruta)
        {
            //using (TransactionScope scope = new TransactionScope())
            //{
                try
                {
                    var cmd = new Process();

                    cmd.StartInfo.FileName = "cmd.exe";
                    cmd.StartInfo.UseShellExecute = false;
                    cmd.StartInfo.RedirectStandardInput = true;
                    //cmd.StartInfo.CreateNoWindow = true;
                    var com = new StringBuilder();
                    var comandPut = string.Concat("PUT ", urlLocalFile, " '", remotefile, "'");
                    com.Append(@comandPut);

                    cmd.Start();

                    using (var stdin = cmd.StandardInput)
                    {
                        stdin.WriteLine("ftp -n");
                        stdin.WriteLine("verbose ON");
                        stdin.WriteLine("Open " + host);
                        stdin.WriteLine("user " + user + " " + pass);
                        //stdin.WriteLine(stdin.NewLine);
                        //stdin.WriteLine("DTUCHINA");
                        //stdin.WriteLine(stdin.NewLine);
                        //stdin.WriteLine("EOF");
                        stdin.WriteLine(@"lcd " + ruta);
                        stdin.WriteLine(commands);
                        stdin.WriteLine(com);
                        //stdin.WriteLine("PUT " + urlLocalFile + " '" + remotefile + "'");
                    }

                    cmd.WaitForExit();
                    cmd.Close();
                    //scope.Complete();
                    return "True:Archivo Cargado";
                }
                catch (Exception ex)
                {
                    return "False:" + ex.Message;
                }
           //}

        }
        */
        #endregion

    }

}
