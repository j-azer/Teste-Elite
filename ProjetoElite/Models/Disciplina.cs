namespace Projeto_Elite.Models;
public class Disciplina
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string NomeProfessor { get; set; }
    public ICollection<AlunoDisciplina> AlunoDisciplinas { get; set; }
}