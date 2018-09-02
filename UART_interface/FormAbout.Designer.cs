namespace UART_interface
{
    partial class FormAbout
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
            this.buttonOk = new System.Windows.Forms.Button();
            this.labelTextAbout = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonOk.Location = new System.Drawing.Point(187, 241);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 0;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // labelTextAbout
            // 
            this.labelTextAbout.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTextAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTextAbout.Location = new System.Drawing.Point(13, 13);
            this.labelTextAbout.Name = "labelTextAbout";
            this.labelTextAbout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.labelTextAbout.Size = new System.Drawing.Size(422, 112);
            this.labelTextAbout.TabIndex = 1;
            this.labelTextAbout.Text = "Данное приложение применяется на АРМ начальника караула, с целью своевременного и" +
    " наглядного отображения информации поступающей от системы охраны перриметра по с" +
    "редствам протокола UART.";
            this.labelTextAbout.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelCopyright
            // 
            this.labelCopyright.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCopyright.Location = new System.Drawing.Point(14, 125);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(421, 113);
            this.labelCopyright.TabIndex = 2;
            this.labelCopyright.Text = "Приложение разработал оператор научной роты №2 \"ЭРА\": \r\nрядовой Тюньков Дмитрий А" +
    "лександрович.\r\nПо всем вопросам обращаться: dmitry.tyunkov@gmail.com\r\n\r\nCopyrigh" +
    "t © 2018, Dmitry Tyunkov";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // FormAbout
            // 
            this.AcceptButton = this.buttonOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 276);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelTextAbout);
            this.Controls.Add(this.buttonOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.Text = "О программе UART-интерфейс для системы охраны периметра";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label labelTextAbout;
        private System.Windows.Forms.Label labelCopyright;
    }
}