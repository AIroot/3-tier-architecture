namespace KioskMonitoringService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.KioskMonitoringServiceInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.KioskMonitoringService = new System.ServiceProcess.ServiceInstaller();
            // 
            // KioskMonitoringServiceInstaller
            // 
            this.KioskMonitoringServiceInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.KioskMonitoringServiceInstaller.Password = null;
            this.KioskMonitoringServiceInstaller.Username = null;
            // 
            // KioskMonitoringService
            // 
            this.KioskMonitoringService.DisplayName = "Kiosk Monitoring Service";
            this.KioskMonitoringService.ServiceName = "MonitoringService";
            this.KioskMonitoringService.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.KioskMonitoringServiceInstaller,
            this.KioskMonitoringService});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller KioskMonitoringServiceInstaller;
        private System.ServiceProcess.ServiceInstaller KioskMonitoringService;
    }
}