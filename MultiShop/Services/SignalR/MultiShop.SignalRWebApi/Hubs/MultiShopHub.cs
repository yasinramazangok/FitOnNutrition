using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRWebApi.Services.SignalRCommentServices;
using MultiShop.SignalRWebApi.Services.SignalRMessageServices;

namespace MultiShop.SignalRWebApi.Hubs
{
    public class MultiShopHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;
        private readonly ISignalRMessageService _signalRMessageService;

        public MultiShopHub(ISignalRCommentService signalRCommentService, ISignalRMessageService signalRMessageService)
        {
            _signalRCommentService = signalRCommentService;
            _signalRMessageService = signalRMessageService;
        }

        public async Task SendStatisticCount(string id)
        {
            var getTotalCommentCount = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("GetCommentCount", getTotalCommentCount);

            var getTotalMessageCount = await _signalRMessageService.GetTotalMessageCountByReceiverId(id);
            await Clients.All.SendAsync("GetMessageCount", getTotalMessageCount);
        }
    }
}
