using KioskMonitoringService.DomainObjects;
using KioskMonitoringService.Logics.Helper;
using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KioskMonitoringService.Logics
{
    public class ManageAppMonitor
    {
        private static readonly ILog Logger = LogManager.GetLogger("NotificationService");

        public static bool UpdateKIOSKStatusFrequently()
        {
            return true;
        }

        private ProcessCounter GetMachineProcessStatus()
        {
            ProcessCounter process = new ProcessCounter();
            ProcessCounterHelper processCounter = new ProcessCounterHelper();

            try
            {
                processCounter.StartProcess();

                process.CPUUsage = processCounter.getCurrentCpuUsage();
                process.RamUsage = processCounter.getAvailableRAM();
                process.DriverInfoList = new List<MachineDriveInfo>();

                DriveInfo[] drives = DriveInfo.GetDrives();
                foreach (DriveInfo drive in drives)
                {
                    MachineDriveInfo d = new MachineDriveInfo();
                    d.AvailableFreeSpace = drive.AvailableFreeSpace;
         
                    d.DriverName = drive.Name;
                    d.FreeSpace = drive.TotalFreeSpace.ToString();
                    d.TotalSize = drive.TotalSize.ToString();
                    d.DriverName = drive.VolumeLabel;
                    process.DriverInfoList.Add(d);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("GetMachineProcessStatus : ", ex);
            }
           

            return process;

        }

    }
}
