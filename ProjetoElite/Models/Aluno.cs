namespace Projeto_Elite.Models;

public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public double Nota1 { get; set; }
    public double Nota2 { get; set; }
    public double Nota3 { get; set; }
    public double Nota4 { get; set; }
    public ICollection<AlunoDisciplina> AlunoDisciplinas { get; set; }


    public double Media()
    {
        return (Nota1 + Nota2 + Nota3 + Nota4) / 4;
    } 
}
