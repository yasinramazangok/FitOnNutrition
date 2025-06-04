using MultiShop.Message.Dtos;

namespace MultiShop.Message.Services
{
    public interface IUserMessageService
    {
        Task<List<ResultMessageDto>> GetAllMessagesAsync();
        Task<List<ResultInboxMessageDto>> GetInboxMessagesAsync(string id);
        Task<List<ResultSendboxMessageDto>> GetSendboxMessagesAsync(string id);
        Task CreateMessageAsync(CreateMessageDto createMessageDto);
        Task UpdateMessageAsync(UpdateMessageDto updateMessageDto);
        Task DeleteMessageAsync(int id);
        Task<GetByIdMessageDto> GetByIdMessageAsync(int id);
    }
}
