using ReportEngine.Core.Entities;
using ReportEngine.Core.Interfaces;

namespace ReportEngine.Infrastructure.Processors;

public class ExecutiveProcessor : IReportProcessor
{
    public string ProcessData(IEnumerable<FinancialData> data)
    {
        return $"[REPORTE EJECUTIVO] Resumen de Indicadores: Total de registros {data.Count()}";
    }
}
