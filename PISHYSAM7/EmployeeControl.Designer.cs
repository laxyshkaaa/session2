namespace PISHYSAM7
{
    partial class EmployeeControl
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelFIO = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.labelPost = new System.Windows.Forms.Label();
            this.labelOffice = new System.Windows.Forms.Label();
            this.labelDep = new System.Windows.Forms.Label();
            this.button_fire = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelFIO
            // 
            this.labelFIO.AutoSize = true;
            this.labelFIO.Location = new System.Drawing.Point(16, 10);
            this.labelFIO.Name = "labelFIO";
            this.labelFIO.Size = new System.Drawing.Size(58, 16);
            this.labelFIO.TabIndex = 0;
            this.labelFIO.Text = "labelFIO";
            // 
            // labelPhone
            // 
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(16, 149);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(44, 16);
            this.labelPhone.TabIndex = 1;
            this.labelPhone.Text = "label2";
            // 
            // labelEmail
            // 
            this.labelEmail.AutoSize = true;
            this.labelEmail.Location = new System.Drawing.Point(16, 121);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(44, 16);
            this.labelEmail.TabIndex = 2;
            this.labelEmail.Text = "label3";
            // 
            // labelPost
            // 
            this.labelPost.AutoSize = true;
            this.labelPost.Location = new System.Drawing.Point(16, 95);
            this.labelPost.Name = "labelPost";
            this.labelPost.Size = new System.Drawing.Size(64, 16);
            this.labelPost.TabIndex = 3;
            this.labelPost.Text = "labelPost";
            // 
            // labelOffice
            // 
            this.labelOffice.AutoSize = true;
            this.labelOffice.Location = new System.Drawing.Point(16, 68);
            this.labelOffice.Name = "labelOffice";
            this.labelOffice.Size = new System.Drawing.Size(71, 16);
            this.labelOffice.TabIndex = 4;
            this.labelOffice.Text = "labelOffice";
            // 
            // labelDep
            // 
            this.labelDep.AutoSize = true;
            this.labelDep.Location = new System.Drawing.Point(16, 40);
            this.labelDep.Name = "labelDep";
            this.labelDep.Size = new System.Drawing.Size(78, 16);
            this.labelDep.TabIndex = 5;
            this.labelDep.Text = "labelDepart";
            // 
            // button_fire
            // 
            this.button_fire.Location = new System.Drawing.Point(206, 68);
            this.button_fire.Name = "button_fire";
            this.button_fire.Size = new System.Drawing.Size(110, 43);
            this.button_fire.TabIndex = 6;
            this.button_fire.Text = "Уволить";
            this.button_fire.UseVisualStyleBackColor = true;
            this.button_fire.Click += new System.EventHandler(this.button_fire_Click);
            // 
            // EmployeeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(252)))), ((int)(((byte)(67)))));
            this.Controls.Add(this.button_fire);
            this.Controls.Add(this.labelDep);
            this.Controls.Add(this.labelOffice);
            this.Controls.Add(this.labelPost);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelFIO);
            this.Name = "EmployeeControl";
            this.Size = new System.Drawing.Size(338, 174);
            this.Click += new System.EventHandler(this.EmployeeControl_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelFIO;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Label labelPost;
        private System.Windows.Forms.Label labelOffice;
        private System.Windows.Forms.Label labelDep;
        private System.Windows.Forms.Button button_fire;
    }
}
