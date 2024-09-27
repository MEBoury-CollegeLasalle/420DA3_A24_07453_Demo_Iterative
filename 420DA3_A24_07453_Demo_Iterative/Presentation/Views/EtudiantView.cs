using _420DA3_Demo_Iterative.Business.Services;

namespace _420DA3_Demo_Iterative.Presentation.Views;
public partial class EtudiantView : Form {
    private EtudiantService service;

    public EtudiantView(EtudiantService service) {
        this.service = service;
        this.InitializeComponent();
        this.dataGridView1.DataSource = this.service.GetEtudiantDataTable();
    }

    private void BoutonQuitter_Click(object sender, EventArgs e) {
        this.DialogResult = DialogResult.OK;
    }

    private void ButtonSaveChanges_Click(object sender, EventArgs e) {
        this.service.SaveChanges();
    }

    private void ButtonReload_Click(object sender, EventArgs e) {
        this.service.ReloadTableData();
    }
}
