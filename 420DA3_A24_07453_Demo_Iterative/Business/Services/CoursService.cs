using _420DA3_Demo_Iterative.DataAccess.DAOs;
using _420DA3_Demo_Iterative.Presentation.Views;
using System.Data;

namespace _420DA3_Demo_Iterative.Business.Services;
public class CoursService {
    private CoursDAO coursesDAO;
    private CoursView coursView;

    public CoursService() {
        this.coursesDAO = new CoursDAO();
        this.coursView = new CoursView(this);
    }

    public void OpenCoursWindow() {
        _ = this.coursView.ShowDialog();
    }

    public DataTable GetCoursDataTable() {
        return this.coursesDAO.GetDataTable();
    }

    public void SaveChanges() {
        this.coursesDAO.SaveChanges();
    }

    public void ReloadTableData() {
        this.coursesDAO.LoadDataTable();
    }


    /*
    public Cours CreerCours(string codeCours, string titre) {
        Cours cours = new Cours(codeCours, titre);
        return this.coursesDAO.Create(cours);
    }

    public Cours GetCoursById(int id) {
        return this.coursesDAO.GetById(id);
    }

    public Cours SaveModifiedCours(Cours modifiedCours) {
        return this.coursesDAO.Update(modifiedCours);
    }

    public void SupprimerCours(Cours cours) {
        this.coursesDAO.Delete(cours);
    }

    public List<Cours> GetByEtudiantId(int etudiantId) {
        return this.coursesDAO.GetByEtudiantId(etudiantId);
    }
    */
}
