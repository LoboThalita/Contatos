using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Contatos.Models;

[PrimaryKey("Id", "IdCliente")]
[Table("Contato")]
public partial class Contato
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? Perfil { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Tipo { get; set; }

    [Key]
    public int IdCliente { get; set; }

    [ForeignKey("IdCliente")]
    [InverseProperty("Contatos")]
    public virtual Cliente IdClienteNavigation { get; set; } = null!;
}


//CÓDIGO DO CONSOLE DO GERENCIADOR DE PACOTES PARA CRIAR AS MODELS A PARTIR DO DATABASE FIRST
//Scaffold-DbContext “Server=RPOTI007\SQLEXPRESS;Initial Catalog=Contatos;Persist Security Info=True;User ID=sa;Password=SenhaBk@123;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context "ContatosContext" -DataAnnotations -NoOnConfiguring -Force
