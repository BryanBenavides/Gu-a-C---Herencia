public class TelefonoBasico : Telefono
{
    public bool TieneRadioFM { get; set; }
    public bool TieneLinterna { get; set; }

    public override void MostrarInformacion()
    {
        base.MostrarInformacion();
        Console.WriteLine($"Tiene Radio FM: {TieneRadioFM}, Tiene Linterna: {TieneLinterna}");
    }
}