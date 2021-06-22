namespace WindowsFormsApplication1
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.soltar_bomba = new System.Windows.Forms.Button();
            this.explotar_bomba = new System.Windows.Forms.Button();
            this.chat = new System.Windows.Forms.ListBox();
            this.chatbox = new System.Windows.Forms.TextBox();
            this.chatbutton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // soltar_bomba
            // 
            this.soltar_bomba.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.soltar_bomba.ForeColor = System.Drawing.Color.Black;
            this.soltar_bomba.Location = new System.Drawing.Point(820, 53);
            this.soltar_bomba.Margin = new System.Windows.Forms.Padding(2);
            this.soltar_bomba.Name = "soltar_bomba";
            this.soltar_bomba.Size = new System.Drawing.Size(225, 122);
            this.soltar_bomba.TabIndex = 101;
            this.soltar_bomba.Text = "Soltar bomba";
            this.soltar_bomba.UseVisualStyleBackColor = true;
            this.soltar_bomba.Click += new System.EventHandler(this.soltar_bomba_Click);
            // 
            // explotar_bomba
            // 
            this.explotar_bomba.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.explotar_bomba.Location = new System.Drawing.Point(820, 179);
            this.explotar_bomba.Margin = new System.Windows.Forms.Padding(2);
            this.explotar_bomba.Name = "explotar_bomba";
            this.explotar_bomba.Size = new System.Drawing.Size(225, 122);
            this.explotar_bomba.TabIndex = 102;
            this.explotar_bomba.Text = "Explotar bomba";
            this.explotar_bomba.UseVisualStyleBackColor = true;
            this.explotar_bomba.Click += new System.EventHandler(this.button101_Click);
            // 
            // chat
            // 
            this.chat.FormattingEnabled = true;
            this.chat.Location = new System.Drawing.Point(820, 358);
            this.chat.Margin = new System.Windows.Forms.Padding(2);
            this.chat.Name = "chat";
            this.chat.Size = new System.Drawing.Size(226, 225);
            this.chat.TabIndex = 103;
            // 
            // chatbox
            // 
            this.chatbox.Location = new System.Drawing.Point(821, 587);
            this.chatbox.Margin = new System.Windows.Forms.Padding(2);
            this.chatbox.Name = "chatbox";
            this.chatbox.Size = new System.Drawing.Size(224, 20);
            this.chatbox.TabIndex = 104;
            // 
            // chatbutton
            // 
            this.chatbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatbutton.Location = new System.Drawing.Point(890, 611);
            this.chatbutton.Margin = new System.Windows.Forms.Padding(2);
            this.chatbutton.Name = "chatbutton";
            this.chatbutton.Size = new System.Drawing.Size(94, 31);
            this.chatbutton.TabIndex = 105;
            this.chatbutton.Text = "Enviar";
            this.chatbutton.UseVisualStyleBackColor = true;
            this.chatbutton.Click += new System.EventHandler(this.chatbutton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(869, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 39);
            this.label1.TabIndex = 106;
            this.label1.Text = "label1";
            // 
            // panel
            // 
            this.panel.AutoSize = true;
            this.panel.Location = new System.Drawing.Point(20, 20);
            this.panel.Margin = new System.Windows.Forms.Padding(2);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(740, 740);
            this.panel.TabIndex = 107;
            this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(821, 730);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(225, 30);
            this.button1.TabIndex = 108;
            this.button1.Text = "Salir de la partida";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.FONDO_LADRILLOS;
            this.ClientSize = new System.Drawing.Size(1112, 781);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chatbutton);
            this.Controls.Add(this.chatbox);
            this.Controls.Add(this.chat);
            this.Controls.Add(this.explotar_bomba);
            this.Controls.Add(this.soltar_bomba);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button soltar_bomba;
        private System.Windows.Forms.Button explotar_bomba;
        private System.Windows.Forms.ListBox chat;
        private System.Windows.Forms.TextBox chatbox;
        private System.Windows.Forms.Button chatbutton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel;
        private System.Windows.Forms.Button button1;

    }
}