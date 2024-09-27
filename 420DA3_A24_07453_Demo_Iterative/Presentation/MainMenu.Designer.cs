namespace _420DA3_Demo_Iterative.Presentation;

partial class MainMenu {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
        this.btnGestionEtudiants = new Button();
        this.btnGestionCours = new Button();
        this.btnQuitter = new Button();
        this.SuspendLayout();
        // 
        // btnGestionEtudiants
        // 
        this.btnGestionEtudiants.Location = new Point(53, 51);
        this.btnGestionEtudiants.Name = "btnGestionEtudiants";
        this.btnGestionEtudiants.Size = new Size(172, 23);
        this.btnGestionEtudiants.TabIndex = 0;
        this.btnGestionEtudiants.Text = "Gérer les étudiants";
        this.btnGestionEtudiants.UseVisualStyleBackColor = true;
        this.btnGestionEtudiants.Click += this.BtnGestionEtudiants_Click;
        // 
        // btnGestionCours
        // 
        this.btnGestionCours.Location = new Point(53, 80);
        this.btnGestionCours.Name = "btnGestionCours";
        this.btnGestionCours.Size = new Size(172, 23);
        this.btnGestionCours.TabIndex = 1;
        this.btnGestionCours.Text = "Gérer les cours";
        this.btnGestionCours.UseVisualStyleBackColor = true;
        this.btnGestionCours.Click += this.BtnGestionCours_Click;
        // 
        // btnQuitter
        // 
        this.btnQuitter.Location = new Point(53, 149);
        this.btnQuitter.Name = "btnQuitter";
        this.btnQuitter.Size = new Size(172, 23);
        this.btnQuitter.TabIndex = 2;
        this.btnQuitter.Text = "Quitter";
        this.btnQuitter.UseVisualStyleBackColor = true;
        this.btnQuitter.Click += this.BtnQuitter_Click;
        // 
        // MainMenu
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(284, 261);
        this.Controls.Add(this.btnQuitter);
        this.Controls.Add(this.btnGestionCours);
        this.Controls.Add(this.btnGestionEtudiants);
        this.Name = "MainMenu";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Menu Principal";
        this.ResumeLayout(false);
    }

    #endregion

    private Button btnGestionEtudiants;
    private Button btnGestionCours;
    private Button btnQuitter;
}