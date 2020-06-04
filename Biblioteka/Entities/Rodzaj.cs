using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace BibliotekaDb.Entities
{
    public enum RodzajEnum
    {
        Książka,
        DVD,
        CD,
        Vinyl

    }
    public class Rodzaj
    {
        private Rodzaj(RodzajEnum @enum)
        {
            Id = (int)@enum;
            Name = @enum.ToString();
            //Description = @enum.GetEnumDescription();

        }
        protected Rodzaj()
        {

        }
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(24)")]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }

        public static implicit operator Rodzaj(RodzajEnum @enum) => new Rodzaj(@enum);

        public static implicit operator RodzajEnum(Rodzaj rodzaj) => (RodzajEnum)rodzaj.Id;
    }
    public class ExapleClass
    {
        public virtual Rodzaj Rodzaj { get; set; }
    }
}