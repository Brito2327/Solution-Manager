namespace ClinicNestWebApi.Entities;

public class Remedio
{
    public Remedio(int iD, string nome, string principioAtivo)
    {
        ID = iD;
        Nome = nome;
        PrincipioAtivo = principioAtivo;
    }

    public int ID { get; set; }
    public string Nome { get; set; }
    public string PrincipioAtivo { get; set; }
}