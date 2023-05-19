using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Models;

[Table("Cliente")]
public partial class Cliente
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string Nome { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    [Display(Name = "Endereço")]
    public string? Endereco { get; set; }

    [InverseProperty("IdClienteNavigation")]
    public virtual ICollection<Contato> Contatos { get; set; } = new List<Contato>();
}
