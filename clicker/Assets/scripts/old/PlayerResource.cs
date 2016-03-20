using System.ComponentModel;

public class PlayerResource {
    [Description("RsourceId")]
    public int ResourceId { get; set; }

    [Description("Quantity")]
    public int Quantity { get; set; }

    [Description("DisplayName")]
    public string Name { get; set; }

    [Description("SystemName")]
    public string SystemName { get; set; }
}
