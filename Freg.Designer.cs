namespace flowers_Ermoshina
{
    partial class Freg
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
        	this.label1 = new System.Windows.Forms.Label();
        	this.cb_woker = new System.Windows.Forms.ComboBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.textBox1 = new System.Windows.Forms.TextBox();
        	this.button1 = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(47, 82);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(101, 17);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Пользователь";
        	// 
        	// cb_woker
        	// 
        	this.cb_woker.FormattingEnabled = true;
        	this.cb_woker.Items.AddRange(new object[] {
        	        	        	"Сотрудник",
        	        	        	"Директор"});
        	this.cb_woker.Location = new System.Drawing.Point(236, 75);
        	this.cb_woker.Name = "cb_woker";
        	this.cb_woker.Size = new System.Drawing.Size(331, 24);
        	this.cb_woker.TabIndex = 1;
        	this.cb_woker.SelectedIndexChanged += new System.EventHandler(this.cb_woker_SelectedIndexChanged);
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(58, 161);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(57, 17);
        	this.label2.TabIndex = 2;
        	this.label2.Text = "Пароль";
        	// 
        	// textBox1
        	// 
        	this.textBox1.Location = new System.Drawing.Point(236, 158);
        	this.textBox1.Name = "textBox1";
        	this.textBox1.PasswordChar = '*';
        	this.textBox1.Size = new System.Drawing.Size(331, 23);
        	this.textBox1.TabIndex = 3;
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(285, 251);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(131, 49);
        	this.button1.TabIndex = 4;
        	this.button1.Text = "Войти";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// Freg
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.Color.LightCyan;
        	this.ClientSize = new System.Drawing.Size(627, 324);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.textBox1);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.cb_woker);
        	this.Controls.Add(this.label1);
        	this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.Margin = new System.Windows.Forms.Padding(4);
        	this.Name = "Freg";
        	this.Text = "Регистрация";
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_woker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}

