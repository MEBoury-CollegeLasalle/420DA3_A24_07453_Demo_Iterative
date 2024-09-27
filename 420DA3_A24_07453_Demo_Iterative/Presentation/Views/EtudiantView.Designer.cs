namespace _420DA3_Demo_Iterative.Presentation.Views;

partial class EtudiantView {
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
        this.boutonQuitter = new Button();
        this.buttonSaveChanges = new Button();
        this.buttonReload = new Button();
        this.dataGridView1 = new DataGridView();
        ((System.ComponentModel.ISupportInitialize) this.dataGridView1).BeginInit();
        this.SuspendLayout();
        // 
        // boutonQuitter
        // 
        this.boutonQuitter.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
        this.boutonQuitter.Location = new Point(713, 415);
        this.boutonQuitter.Name = "boutonQuitter";
        this.boutonQuitter.Size = new Size(75, 23);
        this.boutonQuitter.TabIndex = 0;
        this.boutonQuitter.Text = "Quitter";
        this.boutonQuitter.UseVisualStyleBackColor = true;
        this.boutonQuitter.Click += this.BoutonQuitter_Click;
        // 
        // buttonSaveChanges
        // 
        this.buttonSaveChanges.Anchor =  AnchorStyles.Bottom | AnchorStyles.Right;
        this.buttonSaveChanges.Location = new Point(540, 415);
        this.buttonSaveChanges.Name = "buttonSaveChanges";
        this.buttonSaveChanges.Size = new Size(167, 23);
        this.buttonSaveChanges.TabIndex = 1;
        this.buttonSaveChanges.Text = "Enregistrer Changements";
        this.buttonSaveChanges.UseVisualStyleBackColor = true;
        this.buttonSaveChanges.Click += this.ButtonSaveChanges_Click;
        // 
        // buttonReload
        // 
        this.buttonReload.Location = new Point(389, 415);
        this.buttonReload.Name = "buttonReload";
        this.buttonReload.Size = new Size(145, 23);
        this.buttonReload.TabIndex = 2;
        this.buttonReload.Text = "Recharger Données";
        this.buttonReload.UseVisualStyleBackColor = true;
        this.buttonReload.Click += this.ButtonReload_Click;
        // 
        // dataGridView1
        // 
        this.dataGridView1.Anchor =  AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        this.dataGridView1.Location = new Point(12, 12);
        this.dataGridView1.Name = "dataGridView1";
        this.dataGridView1.RowTemplate.Height = 25;
        this.dataGridView1.Size = new Size(776, 397);
        this.dataGridView1.TabIndex = 3;
        // 
        // EtudiantView
        // 
        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(800, 450);
        this.Controls.Add(this.dataGridView1);
        this.Controls.Add(this.buttonReload);
        this.Controls.Add(this.buttonSaveChanges);
        this.Controls.Add(this.boutonQuitter);
        this.Name = "EtudiantView";
        this.Text = "EtudiantView";
        ((System.ComponentModel.ISupportInitialize) this.dataGridView1).EndInit();
        this.ResumeLayout(false);
    }

    #endregion

    private Button boutonQuitter;
    private Button buttonSaveChanges;
    private Button buttonReload;
    private DataGridView dataGridView1;
}