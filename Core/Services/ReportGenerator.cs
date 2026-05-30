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
        // generar, por rol
        string rawReport = processor.ProcessData(data);

        // transformar, decorar
        string finalReport = transformer.Transform(rawReport);

        // 3. enviar por canales
        delivery.Deliver(finalReport, format);
    }
}
