using MultiShop.DtoLayer.Dtos.CommentDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task CreateCommentAsync(CreateUserCommentDto createUserCommentDto)
        {
            await _httpClient.PostAsJsonAsync<CreateUserCommentDto>("usercomments", createUserCommentDto);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _httpClient.DeleteAsync("comments?id=" + id);
        }

        public async Task<UpdateUserCommentDto> GetByIdCommentAsync(string id)
        {
            var responseMessage = await _httpClient.GetAsync("usercomments/" + id);
            var values = await responseMessage.Content.ReadFromJsonAsync<UpdateUserCommentDto>();
            return values;
        }

        public async Task<List<ResultUserCommentDto>> GetAllCommentAsync()
        {
            var responseMessage = await _httpClient.GetAsync("usercomments");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultUserCommentDto>>(jsonData);
            return values;
        }

        public async Task UpdateCommentAsync(UpdateUserCommentDto updateUserCommentDto)
        {
            await _httpClient.PutAsJsonAsync<UpdateUserCommentDto>("usercomments", updateUserCommentDto);
        }

        public async Task<List<ResultUserCommentDto>> GetCommentListByProductId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"usercomments/GetCommentListByProductId/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultUserCommentDto>>(jsonData);
            return values;
        }
    }
}
