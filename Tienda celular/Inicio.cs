public class Inicio
{
    private const int MaxInventario = 100;
    private static Telefono[] inventario = new Telefono[MaxInventario];
    private static int contador = 0;

    public static void Main()
    {
        while (true)
        {
            try
            {
                Console.WriteLine("\nMenú de Gestión de Inventario de Teléfonos");
                Console.WriteLine("1. Registrar Teléfono");
                Console.WriteLine("2. Mostrar Teléfonos Registrados");
                Console.WriteLine("3. Consultar Stock de un Teléfono Específico");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");
                int opcionMenu = int.Parse(Console.ReadLine());

                switch (opcionMenu)
                {
                    case 1:
                        RegistrarTelefono();
                        break;
                    case 2:
                        MostrarTelefonosRegistrados();
                        break;
                    case 3:
                        ConsultarStock();
                        break;
                    case 4:
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrió un error: {ex.Message}");
            }
        }
    }

    private static void RegistrarTelefono()
    {
        if (contador >= MaxInventario)
        {
            Console.WriteLine("El inventario está lleno. No se pueden registrar más teléfonos.");
            return;
        }

        try
        {
            Console.WriteLine("\nSeleccione el tipo de teléfono a registrar:");
            Console.WriteLine("1. Teléfono Inteligente");
            Console.WriteLine("2. Teléfono Básico");
            Console.Write("Seleccione una opción: ");
            int opcion = int.Parse(Console.ReadLine());

            Telefono telefono = null;

            Console.Write("Ingrese la marca: ");
            string marca = Console.ReadLine();
            Console.Write("Ingrese el modelo: ");
            string modelo = Console.ReadLine();
            Console.Write("Ingrese el precio: ");
            decimal precio = decimal.Parse(Console.ReadLine());
            Console.Write("Ingrese el stock: ");
            int stock = int.Parse(Console.ReadLine());

            if (opcion == 1)
            {
                telefono = new TelefonoInteligente();
                Console.Write("Ingrese el sistema operativo: ");
                ((TelefonoInteligente)telefono).SistemaOperativo = Console.ReadLine();
                Console.Write("Ingrese la memoria RAM (GB): ");
                ((TelefonoInteligente)telefono).MemoriaRam = int.Parse(Console.ReadLine());
            }
            else if (opcion == 2)
            {
                telefono = new TelefonoBasico();
                Console.Write("Tiene Radio FM (true/false): ");
                ((TelefonoBasico)telefono).TieneRadioFM = bool.Parse(Console.ReadLine());
                Console.Write("Tiene Linterna (true/false): ");
                ((TelefonoBasico)telefono).TieneLinterna = bool.Parse(Console.ReadLine());
            }
            else
            {
                Console.WriteLine("Opción no válida.");
                return;
            }

            telefono.Marca = marca;
            telefono.Modelo = modelo;
            telefono.Precio = precio;
            telefono.Stock = stock;

            inventario[contador] = telefono;
            contador++;
            Console.WriteLine("Teléfono registrado exitosamente.");
        }
        catch (FormatException)
        {
            Console.WriteLine("Entrada no válida. Por favor, ingrese los datos correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error al registrar el teléfono: {ex.Message}");
        }
    }

    private static void MostrarTelefonosRegistrados()
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay teléfonos registrados.");
            return;
        }

        Console.WriteLine("\nTeléfonos Registrados:");
        for (int i = 0; i < contador; i++)
        {
            inventario[i].MostrarInformacion();
            Console.WriteLine();
        }
    }

    private static void ConsultarStock()
    {
        try
        {
            Console.Write("Ingrese el modelo del teléfono a buscar: ");
            string modelo = Console.ReadLine();
            Telefono telefono = null;

            for (int i = 0; i < contador; i++)
            {
                if (inventario[i].Modelo.Equals(modelo, StringComparison.OrdinalIgnoreCase))
                {
                    telefono = inventario[i];
                    break;
                }
            }

            if (telefono != null)
            {
                telefono.MostrarInformacion();
            }
            else
            {
                Console.WriteLine("Teléfono no encontrado.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ocurrió un error al consultar el stock: {ex.Message}");
        }
    }
}