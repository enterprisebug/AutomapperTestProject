namespace AutomapperTestProject.Models;

public class DiscountFactorModel
{
    public DiscountPreventiveMaintenanceFactorModel DiscountPreventiveMaintenanceFactor { get; set; } = new();
    public DiscountSpecificFactorModel DiscountSpecificFactor { get; set; } = new();
}