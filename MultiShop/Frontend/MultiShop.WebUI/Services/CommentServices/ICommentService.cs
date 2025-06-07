using MultiShop.DtoLayer.Dtos.CommentDtos;

namespace MultiShop.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultUserCommentDto>> GetAllCommentAsync();
        Task CreateCommentAsync(CreateUserCommentDto createUserCommentDto);
        Task UpdateCommentAsync(UpdateUserCommentDto updateUserCommentDto);
        Task DeleteCommentAsync(string id);
        Task<UpdateUserCommentDto> GetByIdCommentAsync(string id);
        Task<List<ResultUserCommentDto>> GetCommentListByProductId(string id);
        Task<int> GetTotalCommentCount();
        Task<int> GetActiveCommentCount();
        Task<int> GetPassiveCommentCount();
    }
}
