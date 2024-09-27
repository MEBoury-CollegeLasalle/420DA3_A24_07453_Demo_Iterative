using _420DA3_Demo_Iterative.Business;

namespace _420DA3_Demo_Iterative.Presentation;
public partial class MainMenu : Form {
    private App application;
    public MainMenu(App application) {
        this.application = application;
        this.InitializeComponent();
    }

    private void BtnQuitter_Click(object sender, EventArgs e) {
        this.application.Stop();
    }

    private void BtnGestionCours_Click(object sender, EventArgs e) {

    }

    private void BtnGestionEtudiants_Click(object sender, EventArgs e) {
        this.application.EtudiantService.OpenEtudiantWindow();
    }
}
