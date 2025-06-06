namespace App.Areas.Management.ApiModels
{
    public record MovieResponse(string? Avatar, int? Views, ItemHoverResponse? ItemHover);
    public record ItemHoverResponse(string? Name, string? Description, string? Author, string? Categories, string? Performer, InfoResponse? Info);
    public record InfoResponse(float? Rate, string? CreatedAt, string? Quality, int? Episode);
}