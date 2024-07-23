namespace Projeto_Elite.Models;

public class Auditoria
{
    public int Id { get; set; }
    public int Identificador { get; set; }
    public string Acao { get; set; }
    public DateTime DataCriacao { get; set; }
}