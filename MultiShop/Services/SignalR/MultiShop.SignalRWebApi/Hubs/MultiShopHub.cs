using Microsoft.AspNetCore.SignalR;
using MultiShop.SignalRWebApi.Services.SignalRCommentServices;
using MultiShop.SignalRWebApi.Services.SignalRMessageServices;

namespace MultiShop.SignalRWebApi.Hubs
{
    public class MultiShopHub : Hub
    {
        private readonly ISignalRCommentService _signalRCommentService;

        public MultiShopHub(ISignalRCommentService signalRCommentService)
        {
            _signalRCommentService = signalRCommentService;
        }

        public async Task SendStatisticCount()
        {
            var getTotalCommentCount = await _signalRCommentService.GetTotalCommentCount();
            await Clients.All.SendAsync("GetCommentCount", getTotalCommentCount);
        }
    }
}
