using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _420DA3_Demo_Iterative.Business.Domain;

[Table("Courses", Schema = "dbo")]
public class Cours {
    public const int MAX_LENGTH_COURSECODE = 12;
    public const int MAX_LENGTH_TITLE = 128;

    private string codeCours = null!;
    private string titre = null!;

    [Key]
    [Column(nameof(Id), TypeName = "int", Order = 0)]
    public int Id { get; set; }
    [Column(nameof(CodeCours), TypeName = "nvarchar", Order = 1), MaxLength(MAX_LENGTH_COURSECODE), Required]
    public string CodeCours {
        get { return this.codeCours; }
        set {
            if (value.Length > MAX_LENGTH_COURSECODE) {
                throw new Exception($"Le code du cours ne peut pas dépasser {MAX_LENGTH_COURSECODE} caractères.");
            }
            this.codeCours = value;
        }
    }

    [Column(nameof(Titre), TypeName = "nvarchar", Order = 2), MaxLength(MAX_LENGTH_TITLE), Required]
    public string Titre {
        get { return this.titre; }
        set {
            if (value.Length > MAX_LENGTH_TITLE) {
                throw new Exception($"Le titre ne peut pas dépasser {MAX_LENGTH_TITLE} caractères.");
            }
            this.titre = value;
        }
    }


    [Column(nameof(DateCreation), TypeName = "datetime2", Order = 3)]
    [Precision(7)]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? DateCreation { get; set; }

    [Column(nameof(DateModification), TypeName = "datetime2", Order = 4)]
    [Precision(7)]
    public DateTime? DateModification { get; set; }

    [Column(nameof(DateModification), TypeName = "datetime2", Order = 5)]
    [Precision(7)]
    public DateTime? DateSuppression { get; set; }

    [Column(nameof(RowVersion), Order = 6)]
    [Timestamp]
    public byte[] RowVersion { get; set; }


    [InverseProperty("CoursInscrit")]
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
