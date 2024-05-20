public class TelefonoInteligente : Telefono
{
    public string SistemaOperativo { get; set; }
    public int MemoriaRam { get; set; }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Sistema Operativo: {SistemaOperativo}, Memoria RAM: {MemoriaRam} GB");
    }
}