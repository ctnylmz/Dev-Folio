using Dev_Folio.Data;
using Microsoft.AspNetCore.Mvc;
using Dev_Folio.Data;

namespace Dev_Folio.Areas.Admin.Components
{
    public class MessageListViewComponent : ViewComponent
    {
        DevFolioContext _context;

        public MessageListViewComponent(DevFolioContext context)
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
