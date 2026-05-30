using ReportEngine.Core.Interfaces;

namespace ReportEngine.Infrastructure.Transformers;

public class EncryptDecorator : BaseReportTransformer
{
    public EncryptDecorator(IReportTransformer innerTransformer) : base(innerTransformer) { }

    public override string Transform(string content)
    {
        string baseContent = base.Transform(content);
        return $"[CIFRADO-AES256]({baseContent})";
    }
}
