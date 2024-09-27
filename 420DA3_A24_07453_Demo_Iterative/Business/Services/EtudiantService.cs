using _420DA3_Demo_Iterative.Business.Domain;
using _420DA3_Demo_Iterative.DataAccess.DAOs;

namespace _420DA3_Demo_Iterative.Business.Services;
internal class EtudiantService {
    private EtudiantDAO etudiantDAO;

    public EtudiantService() {
        this.etudiantDAO = new EtudiantDAO();
    }

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

}
