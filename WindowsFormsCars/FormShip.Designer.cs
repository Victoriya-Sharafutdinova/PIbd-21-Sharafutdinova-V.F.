namespace WindowsFormsCars
{
    partial class FormShip
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
            this.buttonCreateShip = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.pictureBoxShip = new System.Windows.Forms.PictureBox();
            this.buttonCreateSimpleShip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShip)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonCreateShip
            // 
            this.buttonCreateShip.Location = new System.Drawing.Point(0, 0);
            this.buttonCreateShip.Name = "buttonCreateShip";
            this.buttonCreateShip.Size = new System.Drawing.Size(325, 25);
            this.buttonCreateShip.TabIndex = 1;
            this.buttonCreateShip.Text = "Создать корабль-контейнеровоз";
            this.buttonCreateShip.UseVisualStyleBackColor = true;
            this.buttonCreateShip.Click += new System.EventHandler(this.buttonCreateShip_Click);
            // 
            // buttonUp
            // 
            this.buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonUp.BackgroundImage = global::WindowsFormsCars.Properties.Resources.strelka_vpverh_jpg;
            this.buttonUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonUp.Location = new System.Drawing.Point(804, 375);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(30, 30);
            this.buttonUp.TabIndex = 2;
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonRight
            // 
            this.buttonRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRight.BackgroundImage = global::WindowsFormsCars.Properties.Resources.strelka_vpravo_jpg;
            this.buttonRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonRight.Location = new System.Drawing.Point(840, 411);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(30, 30);
            this.buttonRight.TabIndex = 5;
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonDown
            // 
            this.buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDown.BackgroundImage = global::WindowsFormsCars.Properties.Resources.strelka_vniz_jpg;
            this.buttonDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonDown.Location = new System.Drawing.Point(804, 411);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(30, 30);
            this.buttonDown.TabIndex = 4;
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLeft.BackgroundImage = global::WindowsFormsCars.Properties.Resources.strelka_vlevo_jpg;
            this.buttonLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonLeft.Location = new System.Drawing.Point(768, 411);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(30, 30);
            this.buttonLeft.TabIndex = 3;
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonMove_Click);
            // 
            // pictureBoxShip
            // 
            this.pictureBoxShip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxShip.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxShip.Name = "pictureBoxShip";
            this.pictureBoxShip.Size = new System.Drawing.Size(882, 453);
            this.pictureBoxShip.TabIndex = 0;
            this.pictureBoxShip.TabStop = false;
            // 
            // buttonCreateSimpleShip
            // 
            this.buttonCreateSimpleShip.Location = new System.Drawing.Point(363, 3);
            this.buttonCreateSimpleShip.Name = "buttonCreateSimpleShip";
            this.buttonCreateSimpleShip.Size = new System.Drawing.Size(292, 23);
            this.buttonCreateSimpleShip.TabIndex = 6;
            this.buttonCreateSimpleShip.Text = "Создать корабль";
            this.buttonCreateSimpleShip.UseVisualStyleBackColor = true;
            this.buttonCreateSimpleShip.Click += new System.EventHandler(this.buttonCreateSimpleShip_Click_1);
            // 
            // FormShip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 453);
            this.Controls.Add(this.buttonCreateSimpleShip);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.buttonDown);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonUp);
            this.Controls.Add(this.buttonCreateShip);
            this.Controls.Add(this.pictureBoxShip);
            this.Name = "FormShip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxShip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxShip;
        private System.Windows.Forms.Button buttonCreateShip;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonCreateSimpleShip;
    }
}

