using ApiCatalog.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiCatalog.Model
{
    [Table("Produtos")]
    public class Produtos : IValidatableObject
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="O nome é obrigatorio")]
        [StringLength(80)]
        //[PrimeiraLetraMaiuscula]// validation
        public string?  Nome { get; set; }

        [Required]
        [StringLength(300)]
        public string? Descricao { get; set; }

        [Required]
        [Column(TypeName ="decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(300)]
        public string? ImagemURL { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public int CategoriaId { get; set; }

        [JsonIgnore] // com isso em determinad propriedade, ela nao sera mostrada quando chamar ela no swager 
        public Categoria? Categoria { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)//apenas para esse modelo, nao posso usar em outro parte do codigo, diferente da outra 
        {
            if (!string.IsNullOrEmpty(Nome))
            {
                var primeraletra = this.Nome[0].ToString();
                if(primeraletra != primeraletra.ToUpper())
                {
                    yield return new ValidationResult("Primeira letra do nome deve ser maiuscula", 
                        new[] { nameof(this.Nome) });
                }
            }
        }
    }
}
