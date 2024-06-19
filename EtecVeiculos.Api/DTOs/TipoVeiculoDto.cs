
using System.ComponentModel.DataAnnotations;

namespace EtecVeiculos.Api.DTOs;

public class TipoVeiculoDto
{
    [Required]
    [StringLength(30)]
    [Display(Name = "Nome")]
    public string Nome { get; set; }
}

