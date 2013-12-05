namespace FingerHandGesture
{
    partial class MainWindow
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
            this.trackingImage = new System.Windows.Forms.PictureBox();
            this.colorButton = new System.Windows.Forms.Button();
            this.depthButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.colorImage = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mImage = new System.Windows.Forms.PictureBox();
            this.mRatio = new System.Windows.Forms.Label();
            this.mRatioValue = new System.Windows.Forms.TextBox();
            this.mChooseImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackingImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mImage)).BeginInit();
            this.SuspendLayout();
            // 
            // trackingImage
            // 
            this.trackingImage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.trackingImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.trackingImage.Location = new System.Drawing.Point(427, 59);
            this.trackingImage.Name = "trackingImage";
            this.trackingImage.Size = new System.Drawing.Size(411, 377);
            this.trackingImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.trackingImage.TabIndex = 0;
            this.trackingImage.TabStop = false;
            // 
            // colorButton
            // 
            this.colorButton.AutoSize = true;
            this.colorButton.Enabled = false;
            this.colorButton.Location = new System.Drawing.Point(111, 212);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(75, 23);
            this.colorButton.TabIndex = 1;
            this.colorButton.Text = "Color";
            this.colorButton.UseVisualStyleBackColor = true;
            this.colorButton.Visible = false;
            // 
            // depthButton
            // 
            this.depthButton.Enabled = false;
            this.depthButton.Location = new System.Drawing.Point(32, 257);
            this.depthButton.Name = "depthButton";
            this.depthButton.Size = new System.Drawing.Size(75, 23);
            this.depthButton.TabIndex = 2;
            this.depthButton.Text = "Depth";
            this.depthButton.UseVisualStyleBackColor = true;
            this.depthButton.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Image mode";
            this.label3.Visible = false;
            // 
            // colorImage
            // 
            this.colorImage.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.colorImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorImage.Location = new System.Drawing.Point(12, 59);
            this.colorImage.Name = "colorImage";
            this.colorImage.Size = new System.Drawing.Size(409, 377);
            this.colorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.colorImage.TabIndex = 16;
            this.colorImage.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(514, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(337, 26);
            this.label6.TabIndex = 17;
            this.label6.Text = "Finger Hand Gesture & Tracking";
            // 
            // mImage
            // 
            this.mImage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.mImage.Location = new System.Drawing.Point(844, 39);
            this.mImage.Name = "mImage";
            this.mImage.Size = new System.Drawing.Size(435, 419);
            this.mImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.mImage.TabIndex = 18;
            this.mImage.TabStop = false;
            // 
            // mRatio
            // 
            this.mRatio.AutoSize = true;
            this.mRatio.Location = new System.Drawing.Point(557, 445);
            this.mRatio.Name = "mRatio";
            this.mRatio.Size = new System.Drawing.Size(77, 13);
            this.mRatio.TabIndex = 19;
            this.mRatio.Text = "Distance Ratio";
            // 
            // mRatioValue
            // 
            this.mRatioValue.Location = new System.Drawing.Point(640, 442);
            this.mRatioValue.Name = "mRatioValue";
            this.mRatioValue.Size = new System.Drawing.Size(55, 20);
            this.mRatioValue.TabIndex = 20;
            // 
            // mChooseImage
            // 
            this.mChooseImage.Location = new System.Drawing.Point(1021, 236);
            this.mChooseImage.Name = "mChooseImage";
            this.mChooseImage.Size = new System.Drawing.Size(85, 23);
            this.mChooseImage.TabIndex = 21;
            this.mChooseImage.Text = "Choose Image";
            this.mChooseImage.UseVisualStyleBackColor = true;
            this.mChooseImage.Click += new System.EventHandler(this.mChooseImage_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 519);
            this.Controls.Add(this.mChooseImage);
            this.Controls.Add(this.mRatioValue);
            this.Controls.Add(this.mRatio);
            this.Controls.Add(this.mImage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.colorImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.depthButton);
            this.Controls.Add(this.colorButton);
            this.Controls.Add(this.trackingImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainWindow";
            this.Text = "Finger Hand Gesture & Tracking";
            ((System.ComponentModel.ISupportInitialize)(this.trackingImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Button depthButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox colorImage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox trackingImage;
        private System.Windows.Forms.PictureBox mImage;
        private System.Windows.Forms.Label mRatio;
        private System.Windows.Forms.TextBox mRatioValue;
        private System.Windows.Forms.Button mChooseImage;
    }
}

