using System.Reflection;
using System;
using System.IO;
using System.Text.Json;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using Renci.SshNet;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FileLiveTransfer
{
    public partial class FileLiveTransfertForm : Form
    {
        private System.Windows.Forms.Timer timerCheckFile;
        private int deltaTimeInFormInSec;
        private List<String> alreadySentFiles;
        private String currentEXEPath;

        public void DebugLog(string message)
        {
            Debug.WriteLine(message);
            UpdateLogger(message);
        }

        public void UpdateLogger(string message)
        {
            if (LoggerRTB.InvokeRequired)
            {
                // Utilisez Invoke pour invoquer la mise à jour sur le thread de l'interface utilisateur
                LoggerRTB.Invoke(new Action(() => UpdateLogger(message)));
            }
            else
            {
                // Mettez à jour la RichTextBox avec le message
                LoggerRTB.AppendText(Environment.NewLine + message);
            }
        }

        public FileLiveTransfertForm()
        {
            InitializeComponent();
            // Initialisation
            changeTextBoxNAS(true);
            changeTextBoxLocal(false);
            StopButton.Enabled = false;
            TimerValueCB.SelectedIndex = 1;
            this.alreadySentFiles = new List<String>();

            // Timer pour le check constant de fichier
            timerCheckFile = new System.Windows.Forms.Timer();
            timerCheckFile.Interval = 10000; // Intervalle de 10 secondes
            timerCheckFile.Tick += CheckFiles;

            this.currentEXEPath = AppDomain.CurrentDomain.BaseDirectory;
            //DebugLog("- Chemin de l'exécutable : " + this.currentEXEPath);
            getConfiguration(this.currentEXEPath + "\\Data\\saveConfigJson.json");
        }

        private void saveConfiguration(string pathJson)
        {
            int TypeRBJson = 0;
            if (NasDistanceRB.Checked)
            {
                TypeRBJson = 1;
            }

            string jsonString = "{\n";
            jsonString += $"\"TimerValueTB\":{TimeTB.Text},\n";
            jsonString += $"\"TimerValueCB\":{TimerValueCB.SelectedIndex},\n";
            jsonString += $"\"DossierSourceTB\":\"{CheminSourceTB.Text.Replace("\\", "\\\\")}\",\n";
            jsonString += $"\"DossierLocalDestTB\":\"{CheminDestTB.Text.Replace("\\", "\\\\")}\",\n";
            jsonString += $"\"HostSFTPTB\":\"{HostSFTPTB.Text}\",\n";
            jsonString += $"\"UsernameSFTPTB\":\"{UsernameSFTPTB.Text}\",\n";
            jsonString += $"\"PasswordSFTPTB\":\"{PasswordSFTPTB.Text}\",\n";
            jsonString += $"\"PortSFTPTB\":\"{PortSFTPTB.Text}\",\n";
            jsonString += $"\"PathSFTPTB\":\"{PathSFTPTB.Text.Replace("\\", "\\\\")}\",\n";
            jsonString += $"\"TypeRB\":{TypeRBJson}\n";
            jsonString += "}";

            try
            {
                // Écrivez la chaîne dans le fichier en utilisant la méthode File.WriteAllText
                File.WriteAllText(pathJson, jsonString);

                DebugLog("La chaîne a été enregistrée dans le fichier avec succès.");
            }
            catch (IOException ex)
            {
                DebugLog("Une erreur s'est produite lors de la sauvegarde du fichier : " + ex.Message);
            }

        }

        private void getConfiguration(string pathJson)
        {
            try
            {
                DebugLog("- Chemin de configuration JSON : " + pathJson);
                // Lisez le contenu du fichier JSON en tant que chaîne
                string jsonString = File.ReadAllText(pathJson);

                // Désérialisez la chaîne JSON en un objet C#
                var jsonData = JsonSerializer.Deserialize<ConfigJsonFile>(jsonString);

                // Utilisez les données lues du fichier JSON comme vous le souhaitez
                /*DebugLog("- Données lues du fichier JSON ");
                DebugLog($" Duration : {jsonData.TimerValueTB}");
                DebugLog($" Unity of duration ( 0-seconds, 1-minutes, 2-hours) : {jsonData.TimerValueCB}");
                DebugLog($" Source : {jsonData.DossierSourceTB}");
                DebugLog($" Type of dest ( 0-Local, 1-Remote ) : {jsonData.TypeRB}");
                DebugLog($" Local - Path : {jsonData.DossierLocalDestTB}");
                DebugLog($" SFTP - Hostname : {jsonData.HostSFTPTB}");
                DebugLog($" SFTP - Port : {jsonData.PortSFTPTB}");
                DebugLog($" SFTP - Username : {jsonData.UsernameSFTPTB}");
                DebugLog($" SFTP - Password : <on va pas l'afficher quand même>");
                DebugLog($" SFTP - Path : {jsonData.PathSFTPTB}");*/

                TimeTB.Text = "" + jsonData.TimerValueTB;
                TimerValueCB.SelectedIndex = jsonData.TimerValueCB;
                CheminSourceTB.Text = jsonData.DossierSourceTB;
                CheminDestTB.Text = jsonData.DossierLocalDestTB;
                HostSFTPTB.Text = jsonData.HostSFTPTB;
                UsernameSFTPTB.Text = jsonData.UsernameSFTPTB;
                PasswordSFTPTB.Text = jsonData.PasswordSFTPTB;
                PortSFTPTB.Text = jsonData.PortSFTPTB;
                PathSFTPTB.Text = jsonData.PathSFTPTB;

                LocalRB.Checked = jsonData.TypeRB == 0;
                NasDistanceRB.Checked = jsonData.TypeRB == 1;
                if (NasDistanceRB.Checked) // Si l'utilisateur souhaite envoyer les fichiers dans un NAS
                {
                    LocalRB.Checked = false;
                    // Griser le local
                    changeTextBoxLocal(false);

                    //Degriser le NAS
                    changeTextBoxNAS(true);
                }
                else // Si l'utilisateur souhaite envoyer les fichiers dans un dossier local
                {
                    LocalRB.Checked = true;

                    // Degriser le local
                    changeTextBoxLocal(true);

                    // Griser le NAS
                    changeTextBoxNAS(false);
                }

                DebugLog("- Dernière configuration reprise");


            }
            catch (FileNotFoundException)
            {
                DebugLog("Le fichier JSON spécifié n'a pas été trouvé.");
            }
            catch (JsonException)
            {
                DebugLog("Erreur de désérialisation JSON. Assurez-vous que le fichier JSON est valide.");
            }
        }

        private void changeTextBoxNAS(bool state)
        {
            HostSFTPTB.Enabled = state;
            PasswordSFTPTB.Enabled = state;
            PathSFTPTB.Enabled = state;
            PortSFTPTB.Enabled = state;
            UsernameSFTPTB.Enabled = state;
        }

        private void changeTextBoxLocal(bool state)
        {
            CheminDestTB.Enabled = state;
        }

        private void switchMode()
        {
            if (NasDistanceRB.Checked) // Si l'utilisateur souhaite envoyer les fichiers dans un NAS
            {
                LocalRB.Checked = false;
                // Griser le local
                changeTextBoxLocal(false);

                //Degriser le NAS
                changeTextBoxNAS(true);
            }
            else // Si l'utilisateur souhaite envoyer les fichiers dans un dossier local
            {
                LocalRB.Checked = true;

                // Degriser le local
                changeTextBoxLocal(true);

                // Griser le NAS
                changeTextBoxNAS(false);
            }
        }

        private void NasDistanceRB_CheckedChanged(object sender, EventArgs e)
        {
            switchMode();
        }

        private void SaveConfigButton_Click(object sender, EventArgs e)
        {
            string executablePath = AppDomain.CurrentDomain.BaseDirectory;
            saveConfiguration(executablePath + "\\Data\\saveConfigJson.json");
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            StopButton.Enabled = true;
            StartButton.Enabled = false;
            StartCheckingFiles();

            changeTextBoxLocal(false);
            changeTextBoxNAS(false);

            NasDistanceRB.Enabled = false;
            LocalRB.Enabled = false;
            TimerValueCB.Enabled = false;
            TimeTB.Enabled = false;
            CheminSourceTB.Enabled = false;
        }

        private void StartCheckingFiles()
        {

            // Calcul du temps de delta de fichiers
            int coef = 1;
            if (TimerValueCB.SelectedIndex == 1)
            {
                coef = 60;
            }
            if (TimerValueCB.SelectedIndex == 2)
            {
                coef = 3600;
            }
            this.deltaTimeInFormInSec = Int32.Parse(TimeTB.Text) * coef;


            // On démarre la fonction qui va se faire appeler toute les 10 secondes pour check les fichiers
            this.timerCheckFile.Start();
        }

        private void CheckFiles(object sender, EventArgs e)
        {
            // Check si les fichiers doivent être envoyés dans la destination
            String[] files = Directory.GetFiles(CheminSourceTB.Text);

            DateTime currentTime = DateTime.Now;
            DateTime lastModified;
            double deltaTimeInSec;

            foreach (String file in files)
            {
                String fileName = Path.GetFileName(file);

                if (alreadySentFiles.Contains(fileName)) { continue; }
                lastModified = File.GetLastWriteTime(file);
                deltaTimeInSec = (currentTime - lastModified).TotalSeconds;
                if (deltaTimeInSec > deltaTimeInFormInSec)
                {
                    // On rajoute le fichier qu'on vient d'envoyer dans une liste pour ne pas le renvoyer au prochain check
                    this.alreadySentFiles.Add(fileName);
                    String destinationPath;
                    if (LocalRB.Checked)
                    {
                        destinationPath = Path.Combine(CheminDestTB.Text, fileName); // Créer le chemin de destination complet
                    }
                    else
                    {
                        destinationPath = Path.Combine(PathSFTPTB.Text, fileName);
                    }
                    // On démarre un Thread pour que la copie se fasse sur le côté
                    Thread thread = new Thread(() => sendFile(fileName, file, destinationPath));
                    thread.Start();
                }
            }
        }

        private void sendFile(String fileName, String pathFile, String destinationPath)
        {
            DebugLog("-- Début de la copie de '" + fileName + "'");
            // Envoie des fichiers dans la destination
            if (LocalRB.Checked) // Si on doit envoyer le fichier dans un autre répertoire en local
            {
                DebugLog("--- Copie en local");
                File.Copy(pathFile, destinationPath, true);
            }
            else
            {
                DebugLog("--- Copie sur serveur distant");

                string host = HostSFTPTB.Text;
                int port = Int32.Parse(PortSFTPTB.Text);
                string username = UsernameSFTPTB.Text;
                string password = PasswordSFTPTB.Text;


                // Chemin sur le serveur distant où vous souhaitez déposer le fichier
                string remoteDirectory = PathSFTPTB.Text;

                try
                {
                    using (var client = new SftpClient(host, port, username, password))
                    {
                        client.Connect();

                        // Assurez-vous que le répertoire de destination existe sur le serveur distant
                        if (!client.Exists(remoteDirectory))
                        {
                            client.CreateDirectory(remoteDirectory);
                        }

                        // Verification si le fichier que l'on souhaite copier est déjà dans le NAS
                        var files = client.ListDirectory(remoteDirectory);
                        bool fileExists = false;
                        foreach (var file in files)
                        {
                            if (file.Name == fileName)
                            {
                                fileExists = true;
                                break;
                            }
                        }

                        if (fileExists)
                        {
                            DebugLog("--- Le fichier '" + fileName + "' existe déjà sur le répertoire distant");
                        }
                        else
                        {
                            DebugLog("---- Fichier non présent sur le serveur distant, début de la copie");
                            using (var fileStream = new FileStream(pathFile, FileMode.Open))
                            {
                                // Copiez le fichier local sur le serveur distant
                                client.UploadFile(fileStream, destinationPath);
                            }
                        }
                        client.Disconnect();
                    }

                    DebugLog("Le fichier '" + fileName + "'a été copié avec succès sur le serveur SFTP.");
                }
                catch (Exception ex)
                {
                    DebugLog("Une erreur avec le fichier '" + fileName + "' s'est produite : " + ex.Message);
                }
            }
            DebugLog("-- Fin de la copie du fichier '" + fileName + "'");
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            StopButton.Enabled = false;
            StartButton.Enabled = true;
            this.timerCheckFile.Stop();

            NasDistanceRB.Enabled = true;
            LocalRB.Enabled = true;
            TimerValueCB.Enabled = true;
            TimeTB.Enabled = true;
            CheminSourceTB.Enabled = true;
            switchMode();

        }

        private void CleanMemoryButton_Click(object sender, EventArgs e)
        {
            this.alreadySentFiles.Clear();
        }


    }



}