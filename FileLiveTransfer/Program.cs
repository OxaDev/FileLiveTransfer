namespace FileLiveTransfer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FileLiveTransfertForm());
        }

        
    }

    // Créez une classe pour représenter la structure de données de votre fichier JSON
    public class ConfigJsonFile
    {
        public int TimerValueTB { get; set; }
        public int TimerValueCB { get; set; }
        public string DossierSourceTB { get; set; }
        public string DossierLocalDestTB { get; set; }
        public string HostSFTPTB { get; set; }
        public string UsernameSFTPTB { get; set; }
        public string PasswordSFTPTB { get; set; }
        public string PortSFTPTB { get; set; }
        public string PathSFTPTB { get; set; }
        public int TypeRB { get; set; }
    }
}