namespace API.Model.Dtos;

public record PaginationRequest(int PageSize = 10, int PageIndex = 0);

public record PaginationResponse<T>(int TotalItems, int PageIndex, int PageSize, List<T> Items);
