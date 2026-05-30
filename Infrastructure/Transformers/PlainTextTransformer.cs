using ReportEngine.Core.Interfaces;

namespace ReportEngine.Infrastructure.Transformers;

public class PlainTextTransformer : IReportTransformer
{
    public string Transform(string content) => content;
}
