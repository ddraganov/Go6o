using Go6oClient.Web.Models;

namespace Go6oClient.Web.ABConnect
{
    public interface IReportConnector
    {
        void Send(Report report);
    }
}
