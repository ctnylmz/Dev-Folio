using Microsoft.AspNetCore.Mvc;
using Portfolio_DevFolio.Data;

namespace Portfolio_DevFolio.Areas.Admin.Components
{
    public class MessageListViewComponent : ViewComponent
    {
        DevfolioContext _context;

        public MessageListViewComponent(DevfolioContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            int totalNumber = _context.Messages.Sum(message => message.Number);

            ViewBag.TotalNumber = totalNumber;

            var result = _context.Messages.OrderByDescending(m => m.Id).Take(4).ToList();

            return View(result);
        }
    }
}
