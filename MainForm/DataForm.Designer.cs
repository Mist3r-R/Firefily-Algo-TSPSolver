namespace MainForm
{
    partial class DataForm
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
            this.cancel_button = new System.Windows.Forms.Button();
            this.accept_button = new System.Windows.Forms.Button();
            this.NameTxt = new System.Windows.Forms.TextBox();
            this.CommentTxt_1 = new System.Windows.Forms.TextBox();
            this.CommentTxt_2 = new System.Windows.Forms.TextBox();
            this.CommentTxt_3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dim_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancel_button
            // 
            this.cancel_button.Location = new System.Drawing.Point(297, 176);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(75, 23);
            this.cancel_button.TabIndex = 0;
            this.cancel_button.Text = "Отмена";
            this.cancel_button.UseVisualStyleBackColor = true;
            this.cancel_button.Click += new System.EventHandler(this.cancel_button_Click);
            // 
            // accept_button
            // 
            this.accept_button.Location = new System.Drawing.Point(216, 176);
            this.accept_button.Name = "accept_button";
            this.accept_button.Size = new System.Drawing.Size(75, 23);
            this.accept_button.TabIndex = 1;
            this.accept_button.Text = "Принять";
            this.accept_button.UseVisualStyleBackColor = true;
            this.accept_button.Click += new System.EventHandler(this.accept_button_Click);
            // 
            // NameTxt
            // 
            this.NameTxt.Location = new System.Drawing.Point(83, 41);
            this.NameTxt.Name = "NameTxt";
            this.NameTxt.Size = new System.Drawing.Size(287, 20);
            this.NameTxt.TabIndex = 2;
            // 
            // CommentTxt_1
            // 
            this.CommentTxt_1.Location = new System.Drawing.Point(83, 71);
            this.CommentTxt_1.Name = "CommentTxt_1";
            this.CommentTxt_1.Size = new System.Drawing.Size(287, 20);
            this.CommentTxt_1.TabIndex = 3;
            // 
            // CommentTxt_2
            // 
            this.CommentTxt_2.Location = new System.Drawing.Point(83, 95);
            this.CommentTxt_2.Name = "CommentTxt_2";
            this.CommentTxt_2.Size = new System.Drawing.Size(288, 20);
            this.CommentTxt_2.TabIndex = 4;
            // 
            // CommentTxt_3
            // 
            this.CommentTxt_3.Location = new System.Drawing.Point(83, 122);
            this.CommentTxt_3.Name = "CommentTxt_3";
            this.CommentTxt_3.Size = new System.Drawing.Size(288, 20);
            this.CommentTxt_3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "NAME:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "COMMENT:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "COMMENT:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "COMMENT:";
            // 
            // dim_label
            // 
            this.dim_label.AutoSize = true;
            this.dim_label.Location = new System.Drawing.Point(13, 154);
            this.dim_label.Name = "dim_label";
            this.dim_label.Size = new System.Drawing.Size(77, 13);
            this.dim_label.TabIndex = 11;
            this.dim_label.Text = "DIMENSION:  ";
            // 
            // DataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.dim_label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CommentTxt_3);
            this.Controls.Add(this.CommentTxt_2);
            this.Controls.Add(this.CommentTxt_1);
            this.Controls.Add(this.NameTxt);
            this.Controls.Add(this.accept_button);
            this.Controls.Add(this.cancel_button);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 250);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "DataForm";
            this.Text = "TSP Info";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button accept_button;
        private System.Windows.Forms.TextBox NameTxt;
        private System.Windows.Forms.TextBox CommentTxt_1;
        private System.Windows.Forms.TextBox CommentTxt_2;
        private System.Windows.Forms.TextBox CommentTxt_3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label dim_label;
    }
}