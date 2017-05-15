namespace Region
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.factorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.outerPanel = new System.Windows.Forms.Panel();
            this.image = new System.Windows.Forms.PictureBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.factorValuelabel1 = new System.Windows.Forms.Label();
            this.factorNamelabel1 = new System.Windows.Forms.Label();
            this.trackBar0 = new System.Windows.Forms.TrackBar();
            this.factorValuelabel0 = new System.Windows.Forms.Label();
            this.factorNamelabel0 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.factorBindingSource)).BeginInit();
            this.outerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar0)).BeginInit();
            this.SuspendLayout();
            // 
            // outerPanel
            // 
            this.outerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outerPanel.AutoScroll = true;
            this.outerPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outerPanel.Controls.Add(this.image);
            this.outerPanel.Location = new System.Drawing.Point(12, 36);
            this.outerPanel.Name = "outerPanel";
            this.outerPanel.Size = new System.Drawing.Size(645, 365);
            this.outerPanel.TabIndex = 5;
            this.outerPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // image
            // 
            this.image.ErrorImage = ((System.Drawing.Image)(resources.GetObject("image.ErrorImage")));
            this.image.Image = ((System.Drawing.Image)(resources.GetObject("image.Image")));
            this.image.Location = new System.Drawing.Point(0, 0);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(850, 504);
            this.image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.image.TabIndex = 2;
            this.image.TabStop = false;
            this.image.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pBox_MouseMove);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(973, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.trackBar1);
            this.panel1.Controls.Add(this.factorValuelabel1);
            this.panel1.Controls.Add(this.factorNamelabel1);
            this.panel1.Controls.Add(this.trackBar0);
            this.panel1.Controls.Add(this.factorValuelabel0);
            this.panel1.Controls.Add(this.factorNamelabel0);
            this.panel1.Location = new System.Drawing.Point(678, 36);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 364);
            this.panel1.TabIndex = 7;
            // 
            // trackBar1
            // 
            this.trackBar1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.trackBar1.Location = new System.Drawing.Point(160, 51);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 5;
            this.trackBar1.Tag = "1";
            this.trackBar1.Value = 5;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            this.trackBar1.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // factorValuelabel1
            // 
            this.factorValuelabel1.AutoSize = true;
            this.factorValuelabel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.factorValuelabel1.Location = new System.Drawing.Point(82, 42);
            this.factorValuelabel1.Name = "factorValuelabel1";
            this.factorValuelabel1.Size = new System.Drawing.Size(35, 13);
            this.factorValuelabel1.TabIndex = 4;
            this.factorValuelabel1.Text = "label2";
            // 
            // factorNamelabel1
            // 
            this.factorNamelabel1.AutoSize = true;
            this.factorNamelabel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.factorNamelabel1.Location = new System.Drawing.Point(15, 42);
            this.factorNamelabel1.Name = "factorNamelabel1";
            this.factorNamelabel1.Size = new System.Drawing.Size(35, 13);
            this.factorNamelabel1.TabIndex = 3;
            this.factorNamelabel1.Text = "label1";
            // 
            // trackBar0
            // 
            this.trackBar0.Location = new System.Drawing.Point(160, 20);
            this.trackBar0.Name = "trackBar0";
            this.trackBar0.Size = new System.Drawing.Size(104, 45);
            this.trackBar0.TabIndex = 2;
            this.trackBar0.Tag = "0";
            this.trackBar0.Value = 5;
            this.trackBar0.ValueChanged += new System.EventHandler(this.trackBar_ValueChanged);
            // 
            // factorValuelabel0
            // 
            this.factorValuelabel0.AutoSize = true;
            this.factorValuelabel0.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.factorValuelabel0.Location = new System.Drawing.Point(82, 20);
            this.factorValuelabel0.Name = "factorValuelabel0";
            this.factorValuelabel0.Size = new System.Drawing.Size(35, 13);
            this.factorValuelabel0.TabIndex = 1;
            this.factorValuelabel0.Text = "label2";
            // 
            // factorNamelabel0
            // 
            this.factorNamelabel0.AutoSize = true;
            this.factorNamelabel0.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.factorNamelabel0.Location = new System.Drawing.Point(15, 20);
            this.factorNamelabel0.Name = "factorNamelabel0";
            this.factorNamelabel0.Size = new System.Drawing.Size(35, 13);
            this.factorNamelabel0.TabIndex = 0;
            this.factorNamelabel0.Text = "label1";
            this.factorNamelabel0.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(678, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(973, 413);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.outerPanel);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Investment regions";
            ((System.ComponentModel.ISupportInitialize)(this.factorBindingSource)).EndInit();
            this.outerPanel.ResumeLayout(false);
            this.outerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar0)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.BindingSource factorBindingSource;
        private System.Windows.Forms.Panel outerPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox image;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TrackBar trackBar0;
        private System.Windows.Forms.Label factorValuelabel0;
        private System.Windows.Forms.Label factorNamelabel0;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label factorValuelabel1;
        private System.Windows.Forms.Label factorNamelabel1;
        private System.Windows.Forms.Button button1;
    }
}

