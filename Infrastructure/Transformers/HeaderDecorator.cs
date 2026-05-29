using ReportEngine.Core.Interfaces;

namespace ReportEngine.Infrastructure.Transformers;

public class HeaderDecorator : BaseReportTransformer
{
    public HeaderDecorator(IReportTransformer innerTransformer) : base(innerTransformer) { }

    public override string Transform(string content)
    {
        string baseContent = base.Transform(content);
        return $"*** FINANTECH SOLUTIONS - REPORTE CONFIDENCIAL ***\n{baseContent}\n*** FIN DEL REPORTE ***";
    }
}
