namespace _420DA3_Demo_Iterative.Business.Domain;
public class Cours {
    public const int MAX_LENGTH_COURSECODE = 12;
    public const int MAX_LENGTH_TITLE = 128;

    private string codeCours;
    private string titre;

    public int Id { get; set; }
    public string CodeCours {
        get { return this.codeCours; }
        set {
            if (value.Length > MAX_LENGTH_COURSECODE) {
                throw new Exception($"Le code du cours ne peut pas dépasser {MAX_LENGTH_COURSECODE} caractères.");
            }
            this.codeCours = value;
        }
    }
    public string Titre {
        get { return this.titre; }
        set {
            if (value.Length > MAX_LENGTH_TITLE) {
                throw new Exception($"Le titre ne peut pas dépasser {MAX_LENGTH_TITLE} caractères.");
            }
            this.titre = value;
        }
    }

    public DateTime? DateCreation { get; set; }
    public DateTime? DateModification { get; set; }
    public DateTime? DateSuppression { get; set; }

    public List<Etudiant> Etudiants { get; set; } = new List<Etudiant>();


    public Cours(string codeCours, string titre) {
        this.CodeCours = codeCours;
        this.Titre = titre;
    }

    public Cours(int id,
        string codeCours,
        string titre,
        DateTime? dateCreation = null,
        DateTime? dateModification = null,
        DateTime? dateSuppression = null)
        : this(codeCours, titre) {

        this.Id = id;
        this.DateCreation = dateCreation;
        this.DateModification = dateModification;
        this.DateSuppression = dateSuppression;
    }

}
