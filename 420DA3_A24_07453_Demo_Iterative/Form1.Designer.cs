namespace _420DA3_Demo_Iterative;

partial class Form1 {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
        if (disposing && (components != null)) {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        this.button1 = new Button();
        this.button2 = new Button();
        this.dataGridView1 = new DataGridView();
        ((System.ComponentModel.ISupportInitialize) this.dataGridView1).BeginInit();
        this.SuspendLayout();
        // 
        // button1
        // 
        this.button1.Location = new Point(397, 226);
        this.button1.Name = "button1";
        this.button1.Size = new Size(75, 23);
        this.button1.TabIndex = 0;
        this.button1.Text = "button1";
        this.button1.UseVisualStyleBackColor = true;
        // 
        // button2
        // 
        this.button2.Location = new Point(316, 226);
        this.button2.Name = "button2";
        this.button2.Size = new Size(75, 23);
        this.button2.TabIndex = 1;
        this.button2.Text = "button2";
        this.button2.UseVisualStyleBackColor = true;
        // 
        // dataGridView1
        // 
        this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridView1.Location = new Point(12, 12);
        this.dataGridView1.Name = "dataGridView1";
        this.dataGridView1.RowTemplate.Height = 25;
        this.dataGridView1.Size = new Size(460, 208);
        this.dataGridView1.TabIndex = 3;
        // 
        // Form1
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(484, 261);
        this.Controls.Add(this.dataGridView1);
        this.Controls.Add(this.button2);
        this.Controls.Add(this.button1);
        this.Name = "Form1";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Main Menu";
        ((System.ComponentModel.ISupportInitialize) this.dataGridView1).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private Button button1;
    private Button button2;
    private DataGridView dataGridView1;
}
