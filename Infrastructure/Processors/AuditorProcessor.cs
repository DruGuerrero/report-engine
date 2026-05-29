using ReportEngine.Core.Entities;
using ReportEngine.Core.Interfaces;

namespace ReportEngine.Infrastructure.Processors;

public class AuditorProcessor : IReportProcessor
{
    public string ProcessData(IEnumerable<FinancialData> data)
    {
        var details = string.Join("\n", data.Select(d => $"{d.IndicatorName}: {d.Value} (Fecha: {d.Date:yyyy-MM-dd})"));
        return $"[REPORTE AUDITORÍA] Detalle de transacciones:\n{details}";
    }
}
