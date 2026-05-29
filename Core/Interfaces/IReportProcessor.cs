using ReportEngine.Core.Entities;

namespace ReportEngine.Core.Interfaces;

public interface IReportProcessor
{
    string ProcessData(IEnumerable<FinancialData> data);
}
