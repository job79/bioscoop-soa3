using System.Text.Json;

namespace bioscoop_soa3;

public class PlainTextExport : IExportBehavior
{
    public void Export(Order order, string path)
    {
        File.WriteAllText(path, JsonSerializer.Serialize(order));
    }
}
