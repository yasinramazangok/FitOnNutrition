using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class ProductDetailReviewViewComponentPartial : ViewComponent
    {
        private readonly ICommentService _commentService;

        public ProductDetailReviewViewComponentPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            var values = await _commentService.GetCommentListByProductId(id);
            return View(values);
        }
    }
}
