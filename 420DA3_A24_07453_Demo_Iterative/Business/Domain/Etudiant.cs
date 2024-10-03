namespace _420DA3_Demo_Iterative.Business.Domain;
public class Etudiant {
    public const int MAX_LENGTH_NOM = 64;
    public const int MAX_LENGTH_PRENOM = 64;
    public const int MAX_LENGTH_CP = 12;

    private string nom = null!;
    private string prenom = null!;
    private string codePermanent = null!;

    public int Id { get; set; }
    public string Nom {
        get { return this.nom; }
        set {
            if (value.Length > MAX_LENGTH_NOM) {
                throw new Exception($"Le nom ne peut pas dépasser {MAX_LENGTH_NOM} caractères.");
            }
            this.nom = value;
        }
    }
    public string Prenom {
        get { return this.prenom; }
        set {
            if (value.Length > MAX_LENGTH_PRENOM) {
                throw new Exception($"Le prenom ne peut pas dépasser {MAX_LENGTH_PRENOM} caractères.");
            }
            this.prenom = value;
        }
    }
    public string CodePermanent {
        get { return this.codePermanent; }
        set {
            if (value.Length > MAX_LENGTH_CP) {
                throw new Exception($"Le code permanent ne peut pas dépasser {MAX_LENGTH_CP} caractères.");
            }
            this.codePermanent = value;
        }
    }
    public DateTime DateEnregistrement { get; set; }

    public DateTime? DateCreation { get; set; }
    public DateTime? DateModification { get; set; }
    public DateTime? DateSuppression { get; set; }
    /*
    public List<Cours> Cours {
        get {
            if (this.cours.Count == 0) {
                this.cours = new CoursService().GetByEtudiantId(this.Id);
            }
            return this.cours;
        }
        set {
            this.cours = value;
        }
    }
    */


    public Etudiant(string nom, string prenom, string codePermanent, DateTime dateEnregistrement) {
        this.Nom = nom;
        this.Prenom = prenom;
        this.CodePermanent = codePermanent;
        this.DateEnregistrement = dateEnregistrement;
    }

    public Etudiant(int id,
        string nom,
        string prenom,
        string codePermanent,
        DateTime dateEnregistrement,
        DateTime? dateCreatinon = null,
        DateTime? dateModification = null,
        DateTime? dateSuppression = null)
        : this(nom, prenom, codePermanent, dateEnregistrement) {

        this.Id = id;
        this.DateCreation = dateCreatinon;
        this.DateModification = dateModification;
        this.DateSuppression = dateSuppression;
    }

}
