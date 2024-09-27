using _420DA3_Demo_Iterative.DataAccess.DAOs;

namespace _420DA3_Demo_Iterative.Business.Services;
internal class CoursService {
    private CoursDAO coursesDAO;

    public CoursService() {
        this.coursesDAO = new CoursDAO();
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
