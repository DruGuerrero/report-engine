using ReportEngine.Core.Interfaces;

namespace ReportEngine.Infrastructure.Transformers;

public abstract class BaseReportTransformer : IReportTransformer
{
    protected readonly IReportTransformer _innerTransformer;

    protected BaseReportTransformer(IReportTransformer innerTransformer)
    {
        _innerTransformer = innerTransformer;
    }

    public virtual string Transform(string content) => _innerTransformer.Transform(content);
}
