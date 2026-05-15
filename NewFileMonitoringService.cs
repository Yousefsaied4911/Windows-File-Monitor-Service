using System;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using System.Configuration;



namespace NewFileMonitoringService
{
    public partial class NewFileMonitoringService : ServiceBase
    {
        private FileSystemWatcher fileWatcher;
        private string sourceFolder;
        private string destinationFolder;
        private string logFolder;
        public NewFileMonitoringService()
        {
            InitializeComponent();

            sourceFolder = ConfigurationManager.AppSettings["SourceFolder"];
            destinationFolder = ConfigurationManager.AppSettings["DestinationFolder"];
            logFolder = ConfigurationManager.AppSettings["LogFolder"];

            if (string.IsNullOrWhiteSpace(sourceFolder)) {

                sourceFolder = "C:\\FileMonitor\\Source";
                Log("SourceFolder is missing in App.config. Using default: " + sourceFolder);


            }

            if (string.IsNullOrWhiteSpace(destinationFolder)) {
                destinationFolder = "C:\\FileMonitor\\Destination";
                Log("DestinationFolder is missing in App.config. Using default: " + destinationFolder);
            }

            if (string.IsNullOrWhiteSpace(logFolder)) {
                logFolder = "C:\\FileMonitor\\Log";
                Log("LogFolder is missing in App.config. Using default: " + logFolder);
            }


            Directory.CreateDirectory(sourceFolder);
            Directory.CreateDirectory(destinationFolder);
            Directory.CreateDirectory(logFolder);
        }

        protected override void OnStart(string[] args)
        {
            Log("Service started");
            fileWatcher = new FileSystemWatcher
            {

                Path = sourceFolder,
                Filter = "*.*",
                EnableRaisingEvents = true,
                IncludeSubdirectories = false

            };
            fileWatcher.Created += OnFileCreated;   
            Log ("Monitoring folder: " + sourceFolder);

        }

        protected override void OnStop()
        {
            fileWatcher.EnableRaisingEvents = false;
            fileWatcher.Dispose();
            Log("Service stopped");
        }

        private void OnFileCreated(object sender, FileSystemEventArgs e)
        {

            try
            {

                Log($"File detected:{e.FullPath}");
                string NewFileName = $"{Guid.NewGuid()}{Path.GetExtension(e.Name)}";
                string destinationFile = Path.Combine(destinationFolder, NewFileName);
                File.Move(e.FullPath, destinationFile);


                Log($"File moved: {e.FullPath} -> {destinationFile}");

            }


            catch (Exception ex)
            {
                Log($"Error processing file: {e.FullPath}. Exception: {ex.Message}");
            }
        }

            private void Log(string Message) {

            string logFilePath = Path.Combine(logFolder, "ServiceLog.txt"); 
            string logMessage = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {Message}";
             
            File.AppendAllText(logFilePath, logMessage );

            if (Environment.UserInteractive) { 
            
                Console.WriteLine(logMessage);

            }

        }
        public void StartInConsole()
        {
            OnStart(null);
            Console.WriteLine("Press Enter to stop the service...");
            Console.ReadLine();

            OnStop();

        }

    }
    }

