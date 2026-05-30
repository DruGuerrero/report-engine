using ReportEngine.Core.Interfaces;

namespace ReportEngine.Infrastructure.Delivery;

public class SharedFolderDelivery : IReportDelivery
{
    public void Deliver(string content, string format)
    {
        Console.WriteLine($"[CARPETA COMPARTIDA] Guardando reporte en formato {format} en \\\\googledrive\\reportes...");
        Console.WriteLine($"Contenido guardado:\n{content}\n");
    }
}
