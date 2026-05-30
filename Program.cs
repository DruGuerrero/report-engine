using ReportEngine.Core.Entities;
using ReportEngine.Core.Services;
using ReportEngine.Core.Interfaces;
using ReportEngine.Infrastructure.Processors;
using ReportEngine.Infrastructure.Transformers;
using ReportEngine.Infrastructure.Delivery;

var mockData = new List<FinancialData>
{
    new("Sueldos", 600000m, DateTime.Now.AddDays(-1)),
    new("Impuestos", 350000m, DateTime.Now.AddDays(-2)),
    new("Gastos Operativos", 150000m, DateTime.Now),
    new("Margen Neto", 25.4m, DateTime.Now),
    new("Ingresos Brutos", 800000m, DateTime.Now.AddDays(-5))
};

var engine = new ReportGenerator();

while (true)
{
    Console.Clear();
    Console.WriteLine("=== SISTEMA DE REPORTES FINANTECH ===");

    IReportProcessor processor;
    while (true)
    {
        Console.WriteLine("\nSeleccione el tipo de usuario (Procesador):");
        Console.WriteLine("1. Ejecutivo");
        Console.WriteLine("2. Auditor / Analista");
        Console.Write("Opción (1-2): ");
        var processorOption = Console.ReadLine();
        
        if (processorOption == "1") { processor = new ExecutiveProcessor(); break; }
        if (processorOption == "2") { processor = new AuditorProcessor(); break; }
        
        Console.WriteLine("Opción inválida. Intente nuevamente.");
    }

    IReportTransformer transformer = new PlainTextTransformer();
    
    Console.Write("\n¿Desea agregar encabezado al reporte? (s/n): ");
    if (Console.ReadLine()?.ToLower() == "s")
    {
        transformer = new HeaderDecorator(transformer);
    }

    Console.Write("¿Desea encriptar el reporte? (s/n): ");
    if (Console.ReadLine()?.ToLower() == "s")
    {
        transformer = new EncryptDecorator(transformer);
    }

    IReportDelivery delivery;
    while (true)
    {
        Console.WriteLine("\nSeleccione el método de entrega:");
        Console.WriteLine("1. Correo Electrónico");
        Console.WriteLine("2. Carpeta Compartida");
        Console.WriteLine("3. API Rest");
        Console.Write("Opción (1-3): ");
        var deliveryOption = Console.ReadLine();

        if (deliveryOption == "1") { delivery = new EmailDelivery(); break; }
        if (deliveryOption == "2") { delivery = new SharedFolderDelivery(); break; }
        if (deliveryOption == "3") { delivery = new ApiDelivery(); break; }
        
        Console.WriteLine("Opción inválida. Intente nuevamente.");
    }

    string format;
    while (true)
    {
        Console.Write("\nIngrese el formato de salida deseado (ej. PDF, CSV, JSON): ");
        format = Console.ReadLine()?.Trim() ?? string.Empty;
        if (!string.IsNullOrWhiteSpace(format))
            break;
            
        Console.WriteLine("El formato no puede estar vacío. Intente nuevamente.");
    }

    Console.WriteLine("\n--- GENERANDO REPORTE ---");
    engine.CreateReport(mockData, processor, transformer, delivery, format);
    Console.WriteLine("-------------------------");

    Console.Write("\n¿Desea generar otro reporte? (s/n): ");
    if (Console.ReadLine()?.ToLower() != "s")
    {
        break;
    }
}
