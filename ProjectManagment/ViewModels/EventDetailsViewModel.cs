namespace ProjectManagment.ViewModels;

public class EventDetailsViewModel
{
    public string OrganizationName { get; set; } = string.Empty;
    public EventDashboardItem Event { get; set; } = new();
}
