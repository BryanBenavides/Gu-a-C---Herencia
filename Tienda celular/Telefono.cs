using System;

public class Telefono
{
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public decimal Precio { get; set; }
    public int Stock { get; set; }

    public virtual void MostrarInformacion()
    {
        Console.WriteLine($"Marca: {Marca}, Modelo: {Modelo}, Precio: ${Precio}, Stock: {Stock}");
    }
}