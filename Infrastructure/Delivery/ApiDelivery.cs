using ReportEngine.Core.Interfaces;

namespace ReportEngine.Infrastructure.Delivery;

public class ApiDelivery : IReportDelivery
{
    public void Deliver(string content, string format)
    {
        Console.WriteLine($"[API] Enviando reporte en formato {format} a la API externa de reportes...");
        Console.WriteLine($"Payload:\n{content}\n");
    }
}
