namespace UART_interface
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.richTextBoxMainOut = new System.Windows.Forms.RichTextBox();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.serialPortUART = new System.IO.Ports.SerialPort(this.components);
            this.buttonAbout = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonOpenClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxMainOut
            // 
            this.richTextBoxMainOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxMainOut.BackColor = System.Drawing.SystemColors.Window;
            this.richTextBoxMainOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxMainOut.Location = new System.Drawing.Point(12, 12);
            this.richTextBoxMainOut.MaxLength = 0;
            this.richTextBoxMainOut.Name = "richTextBoxMainOut";
            this.richTextBoxMainOut.ReadOnly = true;
            this.richTextBoxMainOut.Size = new System.Drawing.Size(620, 228);
            this.richTextBoxMainOut.TabIndex = 0;
            this.richTextBoxMainOut.Text = "";
            // 
            // buttonSettings
            // 
            this.buttonSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSettings.Location = new System.Drawing.Point(535, 246);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(97, 23);
            this.buttonSettings.TabIndex = 4;
            this.buttonSettings.Text = "Настройки";
            this.buttonSettings.UseVisualStyleBackColor = true;
            this.buttonSettings.Click += new System.EventHandler(this.buttonSettings_Click);
            // 
            // serialPortUART
            // 
            this.serialPortUART.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPortUART_DataReceived);
            // 
            // buttonAbout
            // 
            this.buttonAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAbout.Location = new System.Drawing.Point(432, 246);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(97, 23);
            this.buttonAbout.TabIndex = 5;
            this.buttonAbout.Text = "О программе...";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(12, 246);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(97, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить лог";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClear.Location = new System.Drawing.Point(115, 246);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(97, 23);
            this.buttonClear.TabIndex = 3;
            this.buttonClear.Text = "Очистить лог";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonOpenClose
            // 
            this.buttonOpenClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonOpenClose.Location = new System.Drawing.Point(276, 246);
            this.buttonOpenClose.Name = "buttonOpenClose";
            this.buttonOpenClose.Size = new System.Drawing.Size(97, 23);
            this.buttonOpenClose.TabIndex = 1;
            this.buttonOpenClose.Text = "button1";
            this.buttonOpenClose.UseVisualStyleBackColor = true;
            this.buttonOpenClose.Click += new System.EventHandler(this.buttonOpenClose_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 281);
            this.Controls.Add(this.buttonOpenClose);
            this.Controls.Add(this.buttonSettings);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.richTextBoxMainOut);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(660, 320);
            this.Name = "FormMain";
            this.Text = "UART-интерфейс для системы охраны периметра";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBoxMainOut;
        private System.Windows.Forms.Button buttonSettings;
        private System.IO.Ports.SerialPort serialPortUART;
        private System.Windows.Forms.Button buttonAbout;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonOpenClose;
    }
}

