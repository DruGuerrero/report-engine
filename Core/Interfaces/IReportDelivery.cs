namespace ReportEngine.Core.Interfaces;

public interface IReportDelivery
{
    void Deliver(string content, string format);
}
