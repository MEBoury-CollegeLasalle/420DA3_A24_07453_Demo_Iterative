using _420DA3_Demo_Iterative.DataAccess.DAOs;
using _420DA3_Demo_Iterative.Presentation.Views;
using System.Data;

namespace _420DA3_Demo_Iterative.Business.Services;
public class EtudiantService {
    private EtudiantDAO etudiantDAO;
    private EtudiantView etudiantWindow;

    public EtudiantService() {
        this.etudiantDAO = new EtudiantDAO();
        this.etudiantWindow = new EtudiantView(this);
    }

    public void OpenEtudiantWindow() {
        this.etudiantWindow.ShowDialog();
    }

    public DataTable GetEtudiantDataTable() {
        return this.etudiantDAO.GetDataTable();
    }

    public void SaveChanges() {
        this.etudiantDAO.SaveChanges();
    }

    public void ReloadTableData() {
        this.etudiantDAO.LoadDataTable();
    }

    /*
    public Etudiant CreerEtudiant(string nom, string prenom, string codePermanent, DateTime dateEnregistrement) {
        Etudiant etudiant = new Etudiant(nom, prenom, codePermanent, dateEnregistrement);
        return this.etudiantDAO.Create(etudiant);
    }

    public Etudiant GetCoursById(int id) {
        return this.etudiantDAO.GetById(id);
    }

    public Etudiant SaveModifiedCours(Etudiant etudiant) {
        return this.etudiantDAO.Update(etudiant);
    }

    public void SupprimerCours(Etudiant etudiant) {
        this.etudiantDAO.Delete(etudiant);
    }

    public List<Etudiant> GetByCoursId(int coursId) {
        return this.etudiantDAO.GetByCoursId(coursId);
    }
    */
}
