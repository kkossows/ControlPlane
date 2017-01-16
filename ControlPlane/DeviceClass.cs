using System;
using System.IO;
using System.Linq;
using System.Threading;

/*
 * Klasa odpowiadająca za działanie całego urządzenia.
 * - instancja tej klasy jest tworzona w Program, nastepnie wszystko co się dzieje przechodzi tutaj
*/

namespace ControlPlane
{
    class DeviceClass
    {
        #region NewVariables
        private string _deviceName;
        private string _configurationConfigFilePath;
        #endregion

        #region TMPVariables
        private PC _pcModule;
        private CPCC _cpccModule;
        #endregion

        #region Variables
        private static string _fileLogPath;
        private static int _logID;

        private string _fileConfigurationPath;

        private static ReaderWriterLockSlim _writeLock = new ReaderWriterLockSlim();
        #endregion


        public DeviceClass()
        {
            _pcModule = new PC(_configurationConfigFilePath);
            _cpccModule = new CPCC(_configurationConfigFilePath, _pcModule);
        }


        private void ReadConfigFilePath()
        {
            
        }


        public static void MakeLog(string logDescription)
        {

            
        }



        public static void WriteToFileThreadSafe(string text, string path)
        {

        }


        private void InitializeLogLastIdNumber()
        {

        }


        private void StartWorking()
        {

        }


        public void StopWorking(string reason)
        {

        }
        
    }
}
