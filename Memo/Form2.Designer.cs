
namespace Memo
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtWord = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.rdb01 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdb02 = new System.Windows.Forms.RadioButton();
            this.cbOption = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "찾을 내용";
            // 
            // txtWord
            // 
            this.txtWord.BackColor = System.Drawing.SystemColors.Menu;
            this.txtWord.Location = new System.Drawing.Point(76, 8);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(336, 21);
            this.txtWord.TabIndex = 1;
            this.txtWord.TextChanged += new System.EventHandler(this.txtWord_TextChanged);
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnOk.Location = new System.Drawing.Point(427, 7);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "다음 찾기";
            this.btnOk.UseVisualStyleBackColor = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnCancel.Location = new System.Drawing.Point(427, 56);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "취 소";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // rdb01
            // 
            this.rdb01.AutoSize = true;
            this.rdb01.Location = new System.Drawing.Point(6, 28);
            this.rdb01.Name = "rdb01";
            this.rdb01.Size = new System.Drawing.Size(47, 16);
            this.rdb01.TabIndex = 4;
            this.rdb01.Text = "위쪽";
            this.rdb01.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.rdb02);
            this.groupBox1.Controls.Add(this.rdb01);
            this.groupBox1.Location = new System.Drawing.Point(212, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 76);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "방 향";
            // 
            // rdb02
            // 
            this.rdb02.AutoSize = true;
            this.rdb02.Checked = true;
            this.rdb02.Location = new System.Drawing.Point(102, 28);
            this.rdb02.Name = "rdb02";
            this.rdb02.Size = new System.Drawing.Size(59, 16);
            this.rdb02.TabIndex = 5;
            this.rdb02.TabStop = true;
            this.rdb02.Text = "아래쪽";
            this.rdb02.UseVisualStyleBackColor = true;
            // 
            // cbOption
            // 
            this.cbOption.AutoSize = true;
            this.cbOption.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.cbOption.Location = new System.Drawing.Point(45, 64);
            this.cbOption.Name = "cbOption";
            this.cbOption.Size = new System.Drawing.Size(106, 16);
            this.cbOption.TabIndex = 6;
            this.cbOption.Text = "대/소문자 구분";
            this.cbOption.UseVisualStyleBackColor = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(519, 123);
            this.Controls.Add(this.cbOption);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtWord);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "찾 기";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.TextBox txtWord;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.CheckBox cbOption;
        internal System.Windows.Forms.Button btnOk;
        internal System.Windows.Forms.RadioButton rdb01;
        internal System.Windows.Forms.RadioButton rdb02;
    }
}