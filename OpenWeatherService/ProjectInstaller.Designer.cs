namespace OpenWeatherService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.openWeatherServiceInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.getCurrentWeatherServiceInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // openWeatherServiceInstaller
            // 
            this.openWeatherServiceInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.openWeatherServiceInstaller.Password = null;
            this.openWeatherServiceInstaller.Username = null;
            // 
            // getCurrentWeatherServiceInstaller
            // 
            this.getCurrentWeatherServiceInstaller.Description = "Get current weather based on user\'s location and store it in a Sqlite db.";
            this.getCurrentWeatherServiceInstaller.ServiceName = "GetCurrentWeatherService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.openWeatherServiceInstaller,
            this.getCurrentWeatherServiceInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller openWeatherServiceInstaller;
        private System.ServiceProcess.ServiceInstaller getCurrentWeatherServiceInstaller;
    }
}