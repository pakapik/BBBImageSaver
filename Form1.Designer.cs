namespace BBBImageSaver
{
    partial class BBBImageSaverForm
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
            this.tb_uri = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.lbl_descriptionUri = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_uri
            // 
            this.tb_uri.Location = new System.Drawing.Point(12, 26);
            this.tb_uri.Name = "tb_uri";
            this.tb_uri.Size = new System.Drawing.Size(406, 20);
            this.tb_uri.TabIndex = 0;
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(321, 63);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(91, 30);
            this.btn_save.TabIndex = 1;
            this.btn_save.Text = "Скачать";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // lbl_descriptionUri
            // 
            this.lbl_descriptionUri.AutoSize = true;
            this.lbl_descriptionUri.Location = new System.Drawing.Point(9, 9);
            this.lbl_descriptionUri.Name = "lbl_descriptionUri";
            this.lbl_descriptionUri.Size = new System.Drawing.Size(134, 13);
            this.lbl_descriptionUri.TabIndex = 2;
            this.lbl_descriptionUri.Text = "Ссылка на презентацию:";
            // 
            // BBBImageSaverForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 105);
            this.Controls.Add(this.lbl_descriptionUri);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.tb_uri);
            this.Name = "BBBImageSaverForm";
            this.Text = "BBBImageSaver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_uri;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Label lbl_descriptionUri;
    }
}

