using ReportEngine.Core.Entities;
using ReportEngine.Core.Services;
using ReportEngine.Core.Interfaces;
using ReportEngine.Infrastructure.Processors;
using ReportEngine.Infrastructure.Transformers;
using ReportEngine.Infrastructure.Delivery;

var mockData = new List<FinancialData>
{
    new("ROI", 15.5m, DateTime.Now),
    new("EBITDA", 500000m, DateTime.Now)
};

var engine = new ReportGenerator();

while (true)
{
    Console.Clear();
    Console.WriteLine("=== SISTEMA DE REPORTES FINANTECH ===");

    // 1. Elegir Procesador
    Console.WriteLine("\nSeleccione el tipo de usuario (Procesador):");
    Console.WriteLine("1. Ejecutivo");
    Console.WriteLine("2. Auditor / Analista");
    Console.Write("Opción (1-2): ");
    var processorOption = Console.ReadLine();
    
    IReportProcessor processor = processorOption == "1" 
        ? new ExecutiveProcessor() 
        : new AuditorProcessor();

    // 2. Elegir Transformadores
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

    // 3. Elegir Método de Entrega
    Console.WriteLine("\nSeleccione el método de entrega:");
    Console.WriteLine("1. Correo Electrónico");
    Console.WriteLine("2. Carpeta Compartida");
    Console.WriteLine("3. API Rest");
    Console.Write("Opción (1-3): ");
    var deliveryOption = Console.ReadLine();

    IReportDelivery delivery = deliveryOption switch
    {
        "1" => new EmailDelivery(),
        "2" => new SharedFolderDelivery(),
        "3" => new ApiDelivery(),
        _ => new EmailDelivery() // Default
    };

    // 4. Formato
    Console.Write("\nIngrese el formato de salida deseado (ej. PDF, CSV, JSON): ");
    var format = Console.ReadLine() ?? "PDF";

    // 5. Generar
    Console.WriteLine("\n--- GENERANDO REPORTE ---");
    engine.CreateReport(mockData, processor, transformer, delivery, format);
    Console.WriteLine("-------------------------");

    Console.Write("\n¿Desea generar otro reporte? (s/n): ");
    if (Console.ReadLine()?.ToLower() != "s")
    {
        break;
    }
}
