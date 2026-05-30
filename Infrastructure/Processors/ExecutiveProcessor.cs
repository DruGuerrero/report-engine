using ReportEngine.Core.Entities;
using ReportEngine.Core.Interfaces;

namespace ReportEngine.Infrastructure.Processors;

public class ExecutiveProcessor : IReportProcessor
{
    public string ProcessData(IEnumerable<FinancialData> data)
    {
        var totalRecords = data.Count();
        var totalValue = data.Sum(d => d.Value);
        var averageValue = data.Any() ? data.Average(d => d.Value) : 0;
        
        return $"""
            [REPORTE EJECUTIVO - ALTO NIVEL]
            Resumen de Indicadores Clave:
            -----------------------------------------
            Total de indicadores reportados : {totalRecords}
            Suma Total de Valores           : {totalValue:N2}
            Promedio General                : {averageValue:N2}
            -----------------------------------------
            (Reporte generado el: {DateTime.Now:yyyy-MM-dd HH:mm})
            """;
    }
}
