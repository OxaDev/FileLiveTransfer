namespace FileLiveTransfer
{
    partial class FileLiveTransfertForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox1 = new GroupBox();
            TimerValueCB = new ComboBox();
            label3 = new Label();
            TimeTB = new TextBox();
            LocalRB = new RadioButton();
            NasDistanceRB = new RadioButton();
            label4 = new Label();
            CheminDestTB = new TextBox();
            CheminSourceTB = new TextBox();
            label2 = new Label();
            label1 = new Label();
            groupBox2 = new GroupBox();
            label9 = new Label();
            label5 = new Label();
            label8 = new Label();
            HostSFTPTB = new TextBox();
            label7 = new Label();
            PathSFTPTB = new TextBox();
            PortSFTPTB = new TextBox();
            label6 = new Label();
            UsernameSFTPTB = new TextBox();
            PasswordSFTPTB = new TextBox();
            StartButton = new Button();
            StopButton = new Button();
            SaveConfigButton = new Button();
            CleanMemoryButton = new Button();
            groupBox3 = new GroupBox();
            LoggerRTB = new RichTextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(TimerValueCB);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(TimeTB);
            groupBox1.Controls.Add(LocalRB);
            groupBox1.Controls.Add(NasDistanceRB);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(CheminDestTB);
            groupBox1.Controls.Add(CheminSourceTB);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(12, -1);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(791, 355);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // TimerValueCB
            // 
            TimerValueCB.DropDownStyle = ComboBoxStyle.DropDownList;
            TimerValueCB.FormattingEnabled = true;
            TimerValueCB.Items.AddRange(new object[] { "seconde(s)", "minute(s)", "heure(s)" });
            TimerValueCB.Location = new Point(405, 75);
            TimerValueCB.Name = "TimerValueCB";
            TimerValueCB.Size = new Size(99, 23);
            TimerValueCB.TabIndex = 15;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 78);
            label3.Name = "label3";
            label3.Size = new Size(347, 15);
            label3.TabIndex = 14;
            label3.Text = "Commencer le transfert après que le fichier ai été modifié depuis";
            // 
            // TimeTB
            // 
            TimeTB.Location = new Point(359, 75);
            TimeTB.Name = "TimeTB";
            TimeTB.Size = new Size(40, 23);
            TimeTB.TabIndex = 13;
            TimeTB.Text = "3";
            // 
            // LocalRB
            // 
            LocalRB.AutoSize = true;
            LocalRB.Location = new Point(130, 112);
            LocalRB.Name = "LocalRB";
            LocalRB.Size = new Size(59, 19);
            LocalRB.TabIndex = 4;
            LocalRB.Text = "Locale";
            LocalRB.UseVisualStyleBackColor = true;
            // 
            // NasDistanceRB
            // 
            NasDistanceRB.AutoSize = true;
            NasDistanceRB.Checked = true;
            NasDistanceRB.Location = new Point(195, 112);
            NasDistanceRB.Name = "NasDistanceRB";
            NasDistanceRB.Size = new Size(225, 19);
            NasDistanceRB.TabIndex = 5;
            NasDistanceRB.TabStop = true;
            NasDistanceRB.Text = "Dossier à distance (serveur NAS, etc...)";
            NasDistanceRB.UseVisualStyleBackColor = true;
            NasDistanceRB.CheckedChanged += NasDistanceRB_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 114);
            label4.Name = "label4";
            label4.Size = new Size(118, 15);
            label4.TabIndex = 12;
            label4.Text = "Type de destination : ";
            // 
            // CheminDestTB
            // 
            CheminDestTB.Location = new Point(6, 162);
            CheminDestTB.Name = "CheminDestTB";
            CheminDestTB.Size = new Size(558, 23);
            CheminDestTB.TabIndex = 4;
            // 
            // CheminSourceTB
            // 
            CheminSourceTB.Location = new Point(6, 37);
            CheminSourceTB.Name = "CheminSourceTB";
            CheminSourceTB.Size = new Size(558, 23);
            CheminSourceTB.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 144);
            label2.Name = "label2";
            label2.Size = new Size(140, 15);
            label2.TabIndex = 1;
            label2.Text = "Chemin du dossier locale";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(83, 15);
            label1.TabIndex = 0;
            label1.Text = "Dossier source";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label9);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label8);
            groupBox2.Controls.Add(HostSFTPTB);
            groupBox2.Controls.Add(label7);
            groupBox2.Controls.Add(PathSFTPTB);
            groupBox2.Controls.Add(PortSFTPTB);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(UsernameSFTPTB);
            groupBox2.Controls.Add(PasswordSFTPTB);
            groupBox2.Location = new Point(6, 200);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(779, 148);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Dossier à distance";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(51, 113);
            label9.Name = "label9";
            label9.Size = new Size(49, 15);
            label9.TabIndex = 17;
            label9.Text = "Chemin";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(52, 29);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 13;
            label5.Text = "Adresse";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(23, 84);
            label8.Name = "label8";
            label8.Size = new Size(77, 15);
            label8.TabIndex = 16;
            label8.Text = "Mot de passe";
            // 
            // HostSFTPTB
            // 
            HostSFTPTB.Location = new Point(106, 26);
            HostSFTPTB.Name = "HostSFTPTB";
            HostSFTPTB.Size = new Size(186, 23);
            HostSFTPTB.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(39, 55);
            label7.Name = "label7";
            label7.Size = new Size(61, 15);
            label7.TabIndex = 15;
            label7.Text = "Identifiant";
            // 
            // PathSFTPTB
            // 
            PathSFTPTB.Location = new Point(106, 110);
            PathSFTPTB.Name = "PathSFTPTB";
            PathSFTPTB.Size = new Size(503, 23);
            PathSFTPTB.TabIndex = 9;
            // 
            // PortSFTPTB
            // 
            PortSFTPTB.Location = new Point(333, 26);
            PortSFTPTB.Name = "PortSFTPTB";
            PortSFTPTB.Size = new Size(60, 23);
            PortSFTPTB.TabIndex = 6;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(298, 29);
            label6.Name = "label6";
            label6.Size = new Size(29, 15);
            label6.TabIndex = 14;
            label6.Text = "Port";
            // 
            // UsernameSFTPTB
            // 
            UsernameSFTPTB.Location = new Point(106, 52);
            UsernameSFTPTB.Name = "UsernameSFTPTB";
            UsernameSFTPTB.Size = new Size(186, 23);
            UsernameSFTPTB.TabIndex = 7;
            // 
            // PasswordSFTPTB
            // 
            PasswordSFTPTB.Location = new Point(106, 81);
            PasswordSFTPTB.Name = "PasswordSFTPTB";
            PasswordSFTPTB.Size = new Size(186, 23);
            PasswordSFTPTB.TabIndex = 8;
            // 
            // StartButton
            // 
            StartButton.Location = new Point(641, 360);
            StartButton.Name = "StartButton";
            StartButton.Size = new Size(162, 23);
            StartButton.TabIndex = 1;
            StartButton.Text = "Démarrer l'outil";
            StartButton.UseVisualStyleBackColor = true;
            StartButton.Click += StartButton_Click;
            // 
            // StopButton
            // 
            StopButton.Location = new Point(473, 360);
            StopButton.Name = "StopButton";
            StopButton.Size = new Size(162, 23);
            StopButton.TabIndex = 3;
            StopButton.Text = "Arrêter l'outil";
            StopButton.UseVisualStyleBackColor = true;
            StopButton.Click += StopButton_Click;
            // 
            // SaveConfigButton
            // 
            SaveConfigButton.Location = new Point(12, 360);
            SaveConfigButton.Name = "SaveConfigButton";
            SaveConfigButton.Size = new Size(208, 23);
            SaveConfigButton.TabIndex = 4;
            SaveConfigButton.Text = "Sauvegarder la configuration";
            SaveConfigButton.UseVisualStyleBackColor = true;
            SaveConfigButton.Click += SaveConfigButton_Click;
            // 
            // CleanMemoryButton
            // 
            CleanMemoryButton.Location = new Point(226, 360);
            CleanMemoryButton.Name = "CleanMemoryButton";
            CleanMemoryButton.Size = new Size(134, 23);
            CleanMemoryButton.TabIndex = 5;
            CleanMemoryButton.Text = "Nettoyer la mémoire";
            CleanMemoryButton.UseVisualStyleBackColor = true;
            CleanMemoryButton.Click += CleanMemoryButton_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(LoggerRTB);
            groupBox3.Location = new Point(12, 389);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(791, 319);
            groupBox3.TabIndex = 6;
            groupBox3.TabStop = false;
            groupBox3.Text = "Logger";
            // 
            // LoggerRTB
            // 
            LoggerRTB.BorderStyle = BorderStyle.FixedSingle;
            LoggerRTB.Location = new Point(6, 22);
            LoggerRTB.Name = "LoggerRTB";
            LoggerRTB.ReadOnly = true;
            LoggerRTB.Size = new Size(779, 291);
            LoggerRTB.TabIndex = 1;
            LoggerRTB.Text = "--- Début de la log ---";
            // 
            // FileLiveTransfertForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(815, 720);
            Controls.Add(groupBox3);
            Controls.Add(CleanMemoryButton);
            Controls.Add(SaveConfigButton);
            Controls.Add(StopButton);
            Controls.Add(StartButton);
            Controls.Add(groupBox1);
            Name = "FileLiveTransfertForm";
            Text = "File Live Transfert";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Label label1;
        private Label label2;
        private TextBox CheminSourceTB;
        private TextBox PathSFTPTB;
        private TextBox PasswordSFTPTB;
        private TextBox UsernameSFTPTB;
        private TextBox PortSFTPTB;
        private TextBox HostSFTPTB;
        private TextBox CheminDestTB;
        private Label label4;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label6;
        private Label label5;
        private Button StopButton;
        private Button StartButton;
        private GroupBox groupBox2;
        private RadioButton LocalRB;
        private RadioButton NasDistanceRB;
        private ComboBox TimerValueCB;
        private Label label3;
        private TextBox TimeTB;
        private Button SaveConfigButton;
        private Button CleanMemoryButton;
        private GroupBox groupBox3;
        private RichTextBox LoggerRTB;
    }
}