using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _420DA3_Demo_Iterative.Business.Domain;

[Table("Students", Schema = "dbo")]
public class Etudiant {
    public const int MAX_LENGTH_NOM = 64;
    public const int MAX_LENGTH_PRENOM = 64;
    public const int MAX_LENGTH_CP = 12;

    private string nom = null!;
    private string prenom = null!;
    private string codePermanent = null!;

    [Key]
    [Column(nameof(Id), TypeName = "int", Order = 0)]
    public int Id { get; set; }

    [Column(nameof(CoursId), TypeName = "int", Order = 1)]
    public int? CoursId { get; set; }

    [Column(nameof(Nom), Order = 2)]
    [MaxLength(MAX_LENGTH_NOM)]
    [Required]
    public string Nom {
        get { return this.nom; }
        set {
            if (value.Length > MAX_LENGTH_NOM) {
                throw new Exception($"Le nom ne peut pas dépasser {MAX_LENGTH_NOM} caractères.");
            }
            this.nom = value;
        }
    }

    [Column(nameof(Prenom), Order = 3)]
    [MaxLength(MAX_LENGTH_PRENOM)]
    [Required]
    public string Prenom {
        get { return this.prenom; }
        set {
            if (value.Length > MAX_LENGTH_PRENOM) {
                throw new Exception($"Le prenom ne peut pas dépasser {MAX_LENGTH_PRENOM} caractères.");
            }
            this.prenom = value;
        }
    }

    [Column(nameof(CodePermanent), Order = 4)]
    [MaxLength(MAX_LENGTH_CP)]
    [Required]
    public string CodePermanent {
        get { return this.codePermanent; }
        set {
            if (value.Length > MAX_LENGTH_CP) {
                throw new Exception($"Le code permanent ne peut pas dépasser {MAX_LENGTH_CP} caractères.");
            }
            this.codePermanent = value;
        }
    }

    [Column(nameof(DateEnregistrement), TypeName = "datetime2(7)", Order = 5)]
    [Precision(7)]
    [Required]
    public DateTime DateEnregistrement { get; set; }


    [Column(nameof(DateCreation), TypeName = "datetime2(7)", Order = 6)]
    [Precision(7)]
    [Required]
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime? DateCreation { get; set; }

    [Column(nameof(DateModification), TypeName = "datetime2", Order = 7)]
    [Precision(7)]
    public DateTime? DateModification { get; set; }

    [Column(nameof(DateSuppression), TypeName = "datetime2", Order = 8)]
    [Precision(7)]
    public DateTime? DateSuppression { get; set; }

    [Column(nameof(RowVersion), Order = 9)]
    [Timestamp]
    public byte[] RowVersion { get; set; }

    [ForeignKey(nameof(CoursId)), DeleteBehavior(DeleteBehavior.SetNull)]
    public Cours? CoursInscrit { get; set; }


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
