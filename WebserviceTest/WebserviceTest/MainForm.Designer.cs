namespace CallWebService
{
    partial class MainForm
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
            this.btnWebApi = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblLoginID = new System.Windows.Forms.Label();
            this.btnGet = new System.Windows.Forms.Button();
            this.btnPost = new System.Windows.Forms.Button();
            this.txtServerUrl = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnWebApi
            // 
            this.btnWebApi.Location = new System.Drawing.Point(25, 11);
            this.btnWebApi.Name = "btnWebApi";
            this.btnWebApi.Size = new System.Drawing.Size(262, 23);
            this.btnWebApi.TabIndex = 16;
            this.btnWebApi.Text = "GetAllEmployee";
            this.btnWebApi.UseVisualStyleBackColor = true;
            this.btnWebApi.Click += new System.EventHandler(this.btnWebApi_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(305, 78);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(100, 20);
            this.txtUser.TabIndex = 17;
            this.txtUser.Text = "Saiful";
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(305, 130);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(100, 20);
            this.txtPass.TabIndex = 18;
            this.txtPass.Text = "1111";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(305, 167);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(100, 23);
            this.btnLogin.TabIndex = 19;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(25, 56);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(262, 134);
            this.listBox1.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(304, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "UserID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(304, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Password";
            // 
            // lblLoginID
            // 
            this.lblLoginID.AutoSize = true;
            this.lblLoginID.BackColor = System.Drawing.Color.White;
            this.lblLoginID.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoginID.ForeColor = System.Drawing.SystemColors.Highlight;
            this.lblLoginID.Location = new System.Drawing.Point(29, 197);
            this.lblLoginID.Name = "lblLoginID";
            this.lblLoginID.Size = new System.Drawing.Size(116, 25);
            this.lblLoginID.TabIndex = 23;
            this.lblLoginID.Text = "Login as: ";
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(305, 12);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(100, 22);
            this.btnGet.TabIndex = 24;
            this.btnGet.Text = "GET";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnPost
            // 
            this.btnPost.Location = new System.Drawing.Point(307, 35);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(98, 23);
            this.btnPost.TabIndex = 25;
            this.btnPost.Text = "POST";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // txtServerUrl
            // 
            this.txtServerUrl.Location = new System.Drawing.Point(32, 244);
            this.txtServerUrl.Name = "txtServerUrl";
            this.txtServerUrl.Size = new System.Drawing.Size(372, 20);
            this.txtServerUrl.TabIndex = 26;
            this.txtServerUrl.Text = "http://localhost/Webservice/api/";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 282);
            this.Controls.Add(this.txtServerUrl);
            this.Controls.Add(this.btnPost);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.lblLoginID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnWebApi);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Downloader(saiful.alam@bjirgroup.com)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnWebApi;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblLoginID;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Button btnPost;
        private System.Windows.Forms.TextBox txtServerUrl;
    }
}

