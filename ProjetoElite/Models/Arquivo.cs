namespace Projeto_Elite.Models;

public class Arquivo
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string PathArquivo { get; set; }
    public string PathThumbnail { get; set; }
    public string Descricao { get; set; }
    public DateTime DataUpload { get; set; }
}