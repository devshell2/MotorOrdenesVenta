using MotorOrdenesVenta;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MotorOrdenesVenta.Tests
{
    
    
    /// <summary>
    ///This is a test class for LogicIJTest and is intended
    ///to contain all LogicIJTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LogicIJTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion

        #region InventarioJac
        /// <summary>
        ///A test for GetInvJacList
        ///</summary>
        [TestMethod()]
        public void GetInvJacListTest()
        {
            LogicIJ target = new LogicIJ(); // TODO: Initialize to an appropriate value
            int expected = 4; // TODO: Initialize to an appropriate value
            int actual;
            actual = 0;// target.GetNewInvJacList().Count;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for InsertaVinesNuevos
        ///</summary>
        [TestMethod()]
        public void InsertaVinesNuevosTest()
        {
            LogicIJ target = new LogicIJ(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = "";// target.InsertaVinesNuevos();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreaArchivoVinesNuevos
        ///</summary>
        [TestMethod()]
        public void CreaArchivoVinesDTUNuevosTest_anterior()
        {
            //LogicIJ target = new LogicIJ(); // TODO: Initialize to an appropriate value
            //string expected = string.Empty; // TODO: Initialize to an appropriate value
            //string actual;
            ////actual = target.CreaArchivoVinesDTUNuevos();
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");

            //string vin = "3A91SAB2XEK218003";
            //string dealer = "930271";
            //string Locid = "4";
            //string nomcli = "Caminera del Centro Suc. Celaya";
            //string nomcon = "Adolfo Cano";
            //string dire = "Carr. Alterna Celaya-Villagran Km. 5.86";
            //string cp = "38110";
            //string codarea = "52";
            //string lada = "461";
            //string tel = "863932";//"6140786";
            //string codtel = "484";
            //string valodometro = "3582";
            //string codigofijo = "535000";
            //string fecha = "2014-03-13";
        }

        /// <summary>
        ///A test for GetNewInvJacLst
        ///</summary>
        [TestMethod()]
        public void GetNewInvJacLstTest()
        {
            LogicIJ target = new LogicIJ(); // TODO: Initialize to an appropriate value
            //List<vwInventarioJac> expected = null; // TODO: Initialize to an appropriate value
            //List<vwInventarioJac> actual;
            //actual = target.GetNewInvJacLst();
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreaArchivoVinesInventarioNuevos
        ///</summary>
        [TestMethod()]
        public void CreaArchivoVinesInventarioNuevosTest()
        {
            LogicIJ target = new LogicIJ(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            actual = "";// target.CreaArchivoVinesInventarioNuevos();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetNewInvJacLstArchivo
        ///</summary>
        [TestMethod()]
        public void GetNewInvJacLstArchivoTest()
        {
            //LogicIJ target = new LogicIJ(); // TODO: Initialize to an appropriate value
            //List<vwInventarioJac> expected = null; // TODO: Initialize to an appropriate value
            //List<vwInventarioJac> actual;
            //actual = target.GetNewInvJacLstArchivo();
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UploadCMDFTP
        ///</summary>
        [TestMethod()]
        public void UploadCMDFTPTest()
        {
            //LogicIJ target = new LogicIJ(); // TODO: Initialize to an appropriate value
            //string host = "brkmfprod.navistar.com"; // TODO: Initialize to an appropriate value
            //string user = "YYYD963"; // TODO: Initialize to an appropriate value
            //string pass = "DTUCHINA"; // TODO: Initialize to an appropriate value
            //string urlLocalFile = "JacInventory2014422.txt"; // TODO: Initialize to an appropriate value
            //string commands = "QUOTE SITE BL LR=100 BLK=27600 REC=FB PRI=10 SEC=10"; // TODO: Initialize to an appropriate value
            //string remotefile = "CVI.DATA.VIENG.J06.JACMVIN(+1)"; // TODO: Initialize to an appropriate value
            //string expected = "True:Archivo Cargado"; // TODO: Initialize to an appropriate value
            //string ruta = "c:/temp/Jac";

            /*
             Server name: brkmfniad.navistar.com
            IP address: 167.6.151.241
            File name to be used in FTP: TVI.DATA.VIENG.J06.JACMVIN(+1)
            User ID: YYYD963
            Password: DTUCHINA

             */
            //string actual = "";
            ////actual = target.UploadCMDFTP(host, user, pass, urlLocalFile, commands, remotefile,ruta);
            //Assert.AreEqual(expected, actual);
            //Assert.Inconclusive("Verify the correctness of this test method.");
        }
        #endregion

        #region DTU
        /// <summary>
        ///A test for CreaArchivoVinesDTUNuevos
        ///</summary>
        #endregion
    }
}
