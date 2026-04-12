namespace ProjectManagment.ViewModels;

public class HomeDashboardViewModel
{
    public string OrganizationName { get; set; } = string.Empty;
    public string LoginHint { get; set; } = string.Empty;
    public List<EventDashboardItem> Events { get; set; } = new();
}

public class EventDashboardItem
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Location { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Audience { get; set; } = string.Empty;
    public DateTime EventDate { get; set; }
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public bool Featured { get; set; }
}
