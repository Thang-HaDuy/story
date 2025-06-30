namespace App.Areas.Management.ApiModels
{
    public record MovieSearchResponse(string? Id, string? Name, string? Avatar, int? CountEpisodes, int? CountViews, float? Vote);
    public record MovieResponse(string? Avatar, int? Views, ItemHoverResponse? ItemHover);
    public record ItemHoverResponse(string? Id, string? Name, string? Description, string? Author, string? Categories, string? Performer, InfoResponse? Info);
    public record InfoResponse(float? Rate, string? CreatedAt, string? Quality, int? Episode);
    public record MinimalMovieResponse(string? Id, string? Name, int? Episode);
    public record GetMovieBanerByIdResponse(string? Id, string? Name, string? Background, string? Avatar, string? Description, int? Episode, string? CreatedAt, int? CountViews, float? Rate, float? AverageRate);
    public record GetMovieInfoByIdResponse(string? Id, string? NewEpisode, string? Status, string? Categories, string? Author, int? Duration, string? Quality, float? Rating, string? Language);
    public record GetMovieSuggestResponse(string? Id, string? Name, string? Avatar, float? Rating, float? Episode);
    public record GetMovieInLibraryRespone(string? Id, string? Name, string? Avatar, string? CreatedAt, string? Categories, float? Rating);

}