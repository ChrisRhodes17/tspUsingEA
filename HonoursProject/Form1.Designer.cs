namespace HonoursProject
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxCrossover = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMutation = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxGenerations = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxPopulation = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxMutationRate = new System.Windows.Forms.ComboBox();
            this.btnInfoPop = new System.Windows.Forms.Button();
            this.btnInfoGen = new System.Windows.Forms.Button();
            this.btnInfoCross = new System.Windows.Forms.Button();
            this.btnInfoMuteOp = new System.Windows.Forms.Button();
            this.btnInfoMuteRate = new System.Windows.Forms.Button();
            this.lblFile = new System.Windows.Forms.Label();
            this.textBoxFile = new System.Windows.Forms.TextBox();
            this.btnInfoTourSize = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxTounamentSize = new System.Windows.Forms.ComboBox();
            this.lblMethod = new System.Windows.Forms.Label();
            this.comboBoxMethod = new System.Windows.Forms.ComboBox();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.textBoxBest = new System.Windows.Forms.TextBox();
            this.btnInfoNumRuns = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxNumRuns = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBoxCrossover
            // 
            this.comboBoxCrossover.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCrossover.FormattingEnabled = true;
            this.comboBoxCrossover.Items.AddRange(new object[] {
            "PmxCrossover",
            "Crossover",
            "OXcrossover"});
            this.comboBoxCrossover.Location = new System.Drawing.Point(12, 290);
            this.comboBoxCrossover.Name = "comboBoxCrossover";
            this.comboBoxCrossover.Size = new System.Drawing.Size(202, 28);
            this.comboBoxCrossover.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 264);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Crossover Operator";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mutation Operator";
            // 
            // comboBoxMutation
            // 
            this.comboBoxMutation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMutation.FormattingEnabled = true;
            this.comboBoxMutation.Items.AddRange(new object[] {
            "Mutate",
            "Mutate2Opt",
            "Scramble Mutation"});
            this.comboBoxMutation.Location = new System.Drawing.Point(12, 365);
            this.comboBoxMutation.Name = "comboBoxMutation";
            this.comboBoxMutation.Size = new System.Drawing.Size(202, 28);
            this.comboBoxMutation.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Generations";
            // 
            // comboBoxGenerations
            // 
            this.comboBoxGenerations.FormattingEnabled = true;
            this.comboBoxGenerations.Items.AddRange(new object[] {
            "10000",
            "50000",
            "100000",
            "500000"});
            this.comboBoxGenerations.Location = new System.Drawing.Point(12, 66);
            this.comboBoxGenerations.Name = "comboBoxGenerations";
            this.comboBoxGenerations.Size = new System.Drawing.Size(202, 28);
            this.comboBoxGenerations.TabIndex = 5;
            this.comboBoxGenerations.Text = "10000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Population";
            // 
            // comboBoxPopulation
            // 
            this.comboBoxPopulation.FormattingEnabled = true;
            this.comboBoxPopulation.Items.AddRange(new object[] {
            "100",
            "200",
            "300",
            "400",
            "500",
            "1000"});
            this.comboBoxPopulation.Location = new System.Drawing.Point(12, 142);
            this.comboBoxPopulation.Name = "comboBoxPopulation";
            this.comboBoxPopulation.Size = new System.Drawing.Size(202, 28);
            this.comboBoxPopulation.TabIndex = 7;
            this.comboBoxPopulation.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 412);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Mutation Rate";
            // 
            // comboBoxMutationRate
            // 
            this.comboBoxMutationRate.FormattingEnabled = true;
            this.comboBoxMutationRate.Items.AddRange(new object[] {
            "0.1",
            "0.2",
            "0.5",
            "0.7",
            "1"});
            this.comboBoxMutationRate.Location = new System.Drawing.Point(12, 438);
            this.comboBoxMutationRate.Name = "comboBoxMutationRate";
            this.comboBoxMutationRate.Size = new System.Drawing.Size(202, 28);
            this.comboBoxMutationRate.TabIndex = 9;
            this.comboBoxMutationRate.Text = "0.5";
            // 
            // btnInfoPop
            // 
            this.btnInfoPop.BackgroundImage = global::HonoursProject.Properties.Resources.infoBTN;
            this.btnInfoPop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInfoPop.Location = new System.Drawing.Point(93, 102);
            this.btnInfoPop.Name = "btnInfoPop";
            this.btnInfoPop.Size = new System.Drawing.Size(40, 34);
            this.btnInfoPop.TabIndex = 11;
            this.btnInfoPop.UseVisualStyleBackColor = true;
            this.btnInfoPop.Click += new System.EventHandler(this.btnInfoPop_Click);
            // 
            // btnInfoGen
            // 
            this.btnInfoGen.BackgroundImage = global::HonoursProject.Properties.Resources.infoBTN;
            this.btnInfoGen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInfoGen.Location = new System.Drawing.Point(115, 26);
            this.btnInfoGen.Name = "btnInfoGen";
            this.btnInfoGen.Size = new System.Drawing.Size(40, 34);
            this.btnInfoGen.TabIndex = 12;
            this.btnInfoGen.UseVisualStyleBackColor = true;
            this.btnInfoGen.Click += new System.EventHandler(this.btnInfoGen_Click);
            // 
            // btnInfoCross
            // 
            this.btnInfoCross.BackgroundImage = global::HonoursProject.Properties.Resources.infoBTN;
            this.btnInfoCross.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInfoCross.Location = new System.Drawing.Point(165, 250);
            this.btnInfoCross.Name = "btnInfoCross";
            this.btnInfoCross.Size = new System.Drawing.Size(40, 34);
            this.btnInfoCross.TabIndex = 13;
            this.btnInfoCross.UseVisualStyleBackColor = true;
            this.btnInfoCross.Click += new System.EventHandler(this.btnInfoCross_Click);
            // 
            // btnInfoMuteOp
            // 
            this.btnInfoMuteOp.BackgroundImage = global::HonoursProject.Properties.Resources.infoBTN;
            this.btnInfoMuteOp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInfoMuteOp.Location = new System.Drawing.Point(156, 325);
            this.btnInfoMuteOp.Name = "btnInfoMuteOp";
            this.btnInfoMuteOp.Size = new System.Drawing.Size(40, 34);
            this.btnInfoMuteOp.TabIndex = 14;
            this.btnInfoMuteOp.UseVisualStyleBackColor = true;
            this.btnInfoMuteOp.Click += new System.EventHandler(this.btnInfoMuteOp_Click);
            // 
            // btnInfoMuteRate
            // 
            this.btnInfoMuteRate.BackgroundImage = global::HonoursProject.Properties.Resources.infoBTN;
            this.btnInfoMuteRate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInfoMuteRate.Location = new System.Drawing.Point(128, 398);
            this.btnInfoMuteRate.Name = "btnInfoMuteRate";
            this.btnInfoMuteRate.Size = new System.Drawing.Size(40, 34);
            this.btnInfoMuteRate.TabIndex = 15;
            this.btnInfoMuteRate.UseVisualStyleBackColor = true;
            this.btnInfoMuteRate.Click += new System.EventHandler(this.btnInfoMuteRate_Click);
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(764, 26);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(377, 20);
            this.lblFile.TabIndex = 16;
            this.lblFile.Text = "The filepath of your selected file will be shown below:";
            // 
            // textBoxFile
            // 
            this.textBoxFile.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxFile.Location = new System.Drawing.Point(768, 49);
            this.textBoxFile.Multiline = true;
            this.textBoxFile.Name = "textBoxFile";
            this.textBoxFile.ReadOnly = true;
            this.textBoxFile.Size = new System.Drawing.Size(380, 67);
            this.textBoxFile.TabIndex = 17;
            // 
            // btnInfoTourSize
            // 
            this.btnInfoTourSize.BackgroundImage = global::HonoursProject.Properties.Resources.infoBTN;
            this.btnInfoTourSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInfoTourSize.Location = new System.Drawing.Point(167, 176);
            this.btnInfoTourSize.Name = "btnInfoTourSize";
            this.btnInfoTourSize.Size = new System.Drawing.Size(40, 34);
            this.btnInfoTourSize.TabIndex = 20;
            this.btnInfoTourSize.UseVisualStyleBackColor = true;
            this.btnInfoTourSize.Click += new System.EventHandler(this.btnInfoTourSize_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 190);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(130, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "Tournament Size";
            // 
            // comboBoxTounamentSize
            // 
            this.comboBoxTounamentSize.FormattingEnabled = true;
            this.comboBoxTounamentSize.Items.AddRange(new object[] {
            "2",
            "10",
            "20"});
            this.comboBoxTounamentSize.Location = new System.Drawing.Point(14, 216);
            this.comboBoxTounamentSize.Name = "comboBoxTounamentSize";
            this.comboBoxTounamentSize.Size = new System.Drawing.Size(202, 28);
            this.comboBoxTounamentSize.TabIndex = 18;
            this.comboBoxTounamentSize.Text = "10";
            // 
            // lblMethod
            // 
            this.lblMethod.AutoSize = true;
            this.lblMethod.Location = new System.Drawing.Point(304, 28);
            this.lblMethod.Name = "lblMethod";
            this.lblMethod.Size = new System.Drawing.Size(350, 20);
            this.lblMethod.TabIndex = 22;
            this.lblMethod.Text = "Select the method you would like to use to solve:";
            // 
            // comboBoxMethod
            // 
            this.comboBoxMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMethod.FormattingEnabled = true;
            this.comboBoxMethod.Items.AddRange(new object[] {
            "Evolutionary Algorithm",
            "Heuristic (Nearest Neighbour)"});
            this.comboBoxMethod.Location = new System.Drawing.Point(304, 49);
            this.comboBoxMethod.Name = "comboBoxMethod";
            this.comboBoxMethod.Size = new System.Drawing.Size(350, 28);
            this.comboBoxMethod.TabIndex = 21;
            // 
            // textBoxResult
            // 
            this.textBoxResult.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxResult.Location = new System.Drawing.Point(304, 159);
            this.textBoxResult.Multiline = true;
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.ReadOnly = true;
            this.textBoxResult.Size = new System.Drawing.Size(801, 323);
            this.textBoxResult.TabIndex = 23;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(1154, 66);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(112, 34);
            this.btnSelectFile.TabIndex = 26;
            this.btnSelectFile.Text = "Select File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // textBoxBest
            // 
            this.textBoxBest.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textBoxBest.Location = new System.Drawing.Point(1139, 159);
            this.textBoxBest.Multiline = true;
            this.textBoxBest.Name = "textBoxBest";
            this.textBoxBest.ReadOnly = true;
            this.textBoxBest.Size = new System.Drawing.Size(127, 323);
            this.textBoxBest.TabIndex = 27;
            // 
            // btnInfoNumRuns
            // 
            this.btnInfoNumRuns.BackgroundImage = global::HonoursProject.Properties.Resources.infoBTN;
            this.btnInfoNumRuns.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInfoNumRuns.Location = new System.Drawing.Point(128, 472);
            this.btnInfoNumRuns.Name = "btnInfoNumRuns";
            this.btnInfoNumRuns.Size = new System.Drawing.Size(40, 34);
            this.btnInfoNumRuns.TabIndex = 30;
            this.btnInfoNumRuns.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 486);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 20);
            this.label7.TabIndex = 29;
            this.label7.Text = "Number Of Runs";
            // 
            // comboBoxNumRuns
            // 
            this.comboBoxNumRuns.FormattingEnabled = true;
            this.comboBoxNumRuns.Items.AddRange(new object[] {
            "1",
            "5",
            "10",
            "20"});
            this.comboBoxNumRuns.Location = new System.Drawing.Point(12, 512);
            this.comboBoxNumRuns.Name = "comboBoxNumRuns";
            this.comboBoxNumRuns.Size = new System.Drawing.Size(202, 28);
            this.comboBoxNumRuns.TabIndex = 28;
            this.comboBoxNumRuns.Text = "1";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(1139, 512);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(127, 34);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save Results";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(993, 512);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(112, 34);
            this.btnClear.TabIndex = 32;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(304, 508);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(81, 34);
            this.btnRun.TabIndex = 33;
            this.btnRun.Text = "Run";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 595);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnInfoNumRuns);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBoxNumRuns);
            this.Controls.Add(this.textBoxBest);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.lblMethod);
            this.Controls.Add(this.comboBoxMethod);
            this.Controls.Add(this.btnInfoTourSize);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBoxTounamentSize);
            this.Controls.Add(this.textBoxFile);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.btnInfoMuteRate);
            this.Controls.Add(this.btnInfoMuteOp);
            this.Controls.Add(this.btnInfoCross);
            this.Controls.Add(this.btnInfoGen);
            this.Controls.Add(this.btnInfoPop);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBoxMutationRate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxPopulation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxGenerations);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxMutation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxCrossover);
            this.Name = "Form1";
            this.Text = "TSP Route Finder";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxCrossover;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMutation;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxGenerations;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxPopulation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxMutationRate;
        private System.Windows.Forms.Button btnInfoPop;
        private System.Windows.Forms.Button btnInfoGen;
        private System.Windows.Forms.Button btnInfoCross;
        private System.Windows.Forms.Button btnInfoMuteOp;
        private System.Windows.Forms.Button btnInfoMuteRate;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox textBoxFile;
        private System.Windows.Forms.Button btnInfoTourSize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxTounamentSize;
        private System.Windows.Forms.Label lblMethod;
        private System.Windows.Forms.ComboBox comboBoxMethod;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox textBoxBest;
        private System.Windows.Forms.Button btnInfoNumRuns;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxNumRuns;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnRun;
    }
}

