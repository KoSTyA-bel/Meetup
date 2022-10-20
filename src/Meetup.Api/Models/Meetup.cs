namespace Meetup.Api.Models;

/// <summary>
/// Public performance of meeting.
/// </summary>
public class Meetup
{
    /// <summary>
    /// Gets or sets the identifier.
    /// </summary>
    /// <value>
    /// The identifier.
    /// </value>
    public string Id { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>
    /// The name.
    /// </value>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the desciption.
    /// </summary>
    /// <value>
    /// The desciption.
    /// </value>
    public string Desciption { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the speaker.
    /// </summary>
    /// <value>
    /// The speaker.
    /// </value>
    public string Speaker { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date.
    /// </summary>
    /// <value>
    /// The date.
    /// </value>
    public string Date { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the place.
    /// </summary>
    /// <value>
    /// The place.
    /// </value>
    public string Place { get; set; } = string.Empty;
}
