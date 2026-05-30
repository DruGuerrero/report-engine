using ReportEngine.Core.Entities;
using ReportEngine.Core.Interfaces;

namespace ReportEngine.Infrastructure.Processors;

public class AuditorProcessor : IReportProcessor
{
    public string ProcessData(IEnumerable<FinancialData> data)
    {
        var details = string.Join("\n", data.Select(d => 
            $"  => [{d.Date:yyyy-MM-dd HH:mm:ss}] | INDICADOR: {d.IndicatorName,-20} | VALOR: {d.Value,15:N2}"));
            
        return $"""
            [REPORTE DE AUDITORÍA - DETALLADO]
            Registro histórico de operaciones (Nivel de precisión: Alto):
            =============================================================================
            {details}
            =============================================================================
            Total de operaciones registradas: {data.Count()}
            Fin del registro de auditoría.
            """;
    }
}