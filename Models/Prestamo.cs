namespace LibreríaELADIO.Models;

public class Prestamo
{
    public int Id { get; set; }
    public int IdClient { get; set; }
    public Client Client { get; set; }
    public int IdLibro { get; set; }
    public Libro Libro { get; set; }
    
    
}