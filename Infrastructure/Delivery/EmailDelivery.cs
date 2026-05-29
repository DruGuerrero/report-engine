using ReportEngine.Core.Interfaces;

namespace ReportEngine.Infrastructure.Delivery;

public class EmailDelivery : IReportDelivery
{
    public void Deliver(string content, string format)
    {
        Console.WriteLine($"[EMAIL] Enviando reporte en formato {format} por correo electrónico...");
        Console.WriteLine($"Contenido enviado:\n{content}\n");
    }
}
