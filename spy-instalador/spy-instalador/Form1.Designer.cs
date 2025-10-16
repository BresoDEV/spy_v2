namespace spy_instalador
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            button1 = new Button();
            button2 = new Button();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            label1 = new Label();
            button3 = new Button();
            label2 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            groupBox2 = new GroupBox();
            button6 = new Button();
            button5 = new Button();
            textBox8 = new TextBox();
            textBox7 = new TextBox();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            textBox2 = new TextBox();
            comboBox1 = new ComboBox();
            label3 = new Label();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(128, 128, 255);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ButtonFace;
            button1.Location = new Point(6, 119);
            button1.Name = "button1";
            button1.Size = new Size(237, 23);
            button1.TabIndex = 0;
            button1.Text = "Criar cadastro local";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(128, 128, 255);
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(12, 166);
            button2.Name = "button2";
            button2.Size = new Size(249, 42);
            button2.TabIndex = 1;
            button2.Text = "Instalar no computador atual";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(button1);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(249, 148);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(255, 128, 128);
            textBox1.BorderStyle = BorderStyle.None;
            textBox1.Location = new Point(6, 90);
            textBox1.Name = "textBox1";
            textBox1.PlaceholderText = "Nome do usuario";
            textBox1.Size = new Size(237, 16);
            textBox1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(255, 128, 0);
            label1.Location = new Point(6, 19);
            label1.Name = "label1";
            label1.Size = new Size(45, 17);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(128, 128, 255);
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(12, 214);
            button3.Name = "button3";
            button3.Size = new Size(249, 42);
            button3.TabIndex = 5;
            button3.Text = "Desinstalar do computador atual";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.Cyan;
            label2.Location = new Point(12, 267);
            label2.Name = "label2";
            label2.Size = new Size(45, 17);
            label2.TabIndex = 6;
            label2.Text = "label2";
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button6);
            groupBox2.Controls.Add(button5);
            groupBox2.Controls.Add(textBox8);
            groupBox2.Controls.Add(textBox7);
            groupBox2.Controls.Add(textBox6);
            groupBox2.Controls.Add(textBox5);
            groupBox2.Controls.Add(textBox4);
            groupBox2.Controls.Add(textBox3);
            groupBox2.Controls.Add(textBox2);
            groupBox2.Controls.Add(comboBox1);
            groupBox2.ForeColor = Color.White;
            groupBox2.Location = new Point(267, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(262, 309);
            groupBox2.TabIndex = 7;
            groupBox2.TabStop = false;
            groupBox2.Text = "Usuarios";
            // 
            // button6
            // 
            button6.BackColor = Color.FromArgb(128, 128, 255);
            button6.FlatAppearance.BorderSize = 0;
            button6.FlatStyle = FlatStyle.Flat;
            button6.ForeColor = Color.White;
            button6.Location = new Point(200, 134);
            button6.Name = "button6";
            button6.Size = new Size(56, 23);
            button6.TabIndex = 11;
            button6.Text = "Ver";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click_1;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(128, 128, 255);
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.ForeColor = Color.White;
            button5.Location = new Point(6, 254);
            button5.Name = "button5";
            button5.Size = new Size(250, 23);
            button5.TabIndex = 5;
            button5.Text = "Salvar Dados";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // textBox8
            // 
            textBox8.BackColor = Color.FromArgb(192, 192, 255);
            textBox8.BorderStyle = BorderStyle.None;
            textBox8.ForeColor = Color.Black;
            textBox8.Location = new Point(6, 225);
            textBox8.Name = "textBox8";
            textBox8.PlaceholderText = "Palavras";
            textBox8.Size = new Size(250, 16);
            textBox8.TabIndex = 8;
            // 
            // textBox7
            // 
            textBox7.BackColor = Color.FromArgb(192, 192, 255);
            textBox7.BorderStyle = BorderStyle.None;
            textBox7.ForeColor = Color.Black;
            textBox7.Location = new Point(6, 196);
            textBox7.Name = "textBox7";
            textBox7.PlaceholderText = "Frase";
            textBox7.Size = new Size(250, 16);
            textBox7.TabIndex = 7;
            // 
            // textBox6
            // 
            textBox6.BackColor = Color.FromArgb(192, 192, 255);
            textBox6.BorderStyle = BorderStyle.None;
            textBox6.ForeColor = Color.Black;
            textBox6.Location = new Point(6, 167);
            textBox6.Name = "textBox6";
            textBox6.PlaceholderText = "Data";
            textBox6.Size = new Size(250, 16);
            textBox6.TabIndex = 6;
            // 
            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(192, 192, 255);
            textBox5.BorderStyle = BorderStyle.None;
            textBox5.ForeColor = Color.Black;
            textBox5.Location = new Point(6, 138);
            textBox5.Name = "textBox5";
            textBox5.PlaceholderText = "Acao";
            textBox5.Size = new Size(187, 16);
            textBox5.TabIndex = 5;
            // 
            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(192, 192, 255);
            textBox4.BorderStyle = BorderStyle.None;
            textBox4.Enabled = false;
            textBox4.ForeColor = Color.Black;
            textBox4.Location = new Point(6, 109);
            textBox4.Name = "textBox4";
            textBox4.PlaceholderText = "MAC";
            textBox4.ReadOnly = true;
            textBox4.Size = new Size(250, 16);
            textBox4.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(192, 192, 255);
            textBox3.BorderStyle = BorderStyle.None;
            textBox3.ForeColor = Color.Black;
            textBox3.Location = new Point(6, 80);
            textBox3.Name = "textBox3";
            textBox3.PlaceholderText = "Nome Fantasia";
            textBox3.Size = new Size(250, 16);
            textBox3.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(192, 192, 255);
            textBox2.BorderStyle = BorderStyle.None;
            textBox2.Enabled = false;
            textBox2.ForeColor = Color.Black;
            textBox2.Location = new Point(6, 51);
            textBox2.Name = "textBox2";
            textBox2.PlaceholderText = "Nome do Usuario";
            textBox2.Size = new Size(250, 16);
            textBox2.TabIndex = 2;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.Black;
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            comboBox1.ForeColor = Color.FromArgb(192, 192, 255);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(6, 22);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(250, 23);
            comboBox1.TabIndex = 1;
            comboBox1.Text = "Selecione o usuario";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Black", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.Lime;
            label3.Location = new Point(12, 332);
            label3.Name = "label3";
            label3.Size = new Size(15, 23);
            label3.TabIndex = 10;
            label3.Text = ".";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(539, 364);
            Controls.Add(groupBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button3);
            Controls.Add(groupBox1);
            Controls.Add(button2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            ShowIcon = false;
            Text = "Form1";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private GroupBox groupBox1;
        private Label label1;
        private Button button3;
        private Label label2;
        private System.Windows.Forms.Timer timer1;
        private TextBox textBox1;
        private GroupBox groupBox2;
        private ComboBox comboBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Button button5;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox8;
        private TextBox textBox7;
        private Label label3;
        private Button button6;
    }
}
