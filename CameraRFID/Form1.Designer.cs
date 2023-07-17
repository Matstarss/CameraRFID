
namespace CameraRFID
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.input_wormWeight = new System.Windows.Forms.TextBox();
            this.selectInstarBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(391, 481);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CameraRFID.Properties.Resources.close;
            this.pictureBox1.Location = new System.Drawing.Point(350, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(25, 25);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // input_wormWeight
            // 
            this.input_wormWeight.Location = new System.Drawing.Point(32, 433);
            this.input_wormWeight.Name = "input_wormWeight";
            this.input_wormWeight.Size = new System.Drawing.Size(164, 21);
            this.input_wormWeight.TabIndex = 7;
            this.input_wormWeight.TextChanged += new System.EventHandler(this.updateWormWeight);
            this.input_wormWeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.WormWeightValidation);
            // 
            // selectInstarBox
            // 
            this.selectInstarBox.AutoCompleteCustomSource.AddRange(new string[] {
            "알",
            "유충",
            "번데기",
            "성충"});
            this.selectInstarBox.FormattingEnabled = true;
            this.selectInstarBox.Items.AddRange(new object[] {
            "알",
            "유충",
            "번데기",
            "성충"});
            this.selectInstarBox.Location = new System.Drawing.Point(32, 391);
            this.selectInstarBox.Name = "selectInstarBox";
            this.selectInstarBox.Size = new System.Drawing.Size(121, 20);
            this.selectInstarBox.TabIndex = 13;
            this.selectInstarBox.SelectedIndexChanged += new System.EventHandler(this.selectInstarName);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(391, 481);
            this.Controls.Add(this.selectInstarBox);
            this.Controls.Add(this.input_wormWeight);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(625, 143);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Form1";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox input_wormWeight;
        private System.Windows.Forms.ComboBox selectInstarBox;
    }
}

