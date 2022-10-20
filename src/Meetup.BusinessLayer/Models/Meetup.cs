namespace Meetup.BusinessLayer.Models;

public class Meeting
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Desciption { get; set; } = string.Empty;

    public string Speaker { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public string Place { get; set; } = string.Empty;
}
