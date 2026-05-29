using ReportEngine.Core.Entities;
using ReportEngine.Core.Interfaces;

namespace ReportEngine.Core.Services;

public class ReportGenerator
{
    public void CreateReport(
        IEnumerable<FinancialData> data, 
        IReportProcessor processor, 
        IReportTransformer transformer, 
        IReportDelivery delivery, 
        string format)
    {
        // 1. Generar / Procesar por rol
        string rawReport = processor.ProcessData(data);

        // 2. Transformar (Decoradores aplicados)
        string finalReport = transformer.Transform(rawReport);

        // 3. Entregar
        delivery.Deliver(finalReport, format);
    }
}
