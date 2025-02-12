namespace bioscoop_soa3;

public interface IExportBehavior
{
    void Export(Order order, string path);
}
