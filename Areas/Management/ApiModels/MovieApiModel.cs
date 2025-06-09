namespace App.Areas.Management.ApiModels
{
    public record MovieSearchResponse(string? Id, string? Name, string? Avatar, int? CountEpisodes, int? CountViews, float? Vote);
    public record MovieResponse(string? Avatar, int? Views, ItemHoverResponse? ItemHover);
    public record ItemHoverResponse(string? Id, string? Name, string? Description, string? Author, string? Categories, string? Performer, InfoResponse? Info);
    public record InfoResponse(float? Rate, string? CreatedAt, string? Quality, int? Episode);
    public record MinimalMovieResponse(string? Id, string? Name, int? Episode);

}