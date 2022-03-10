using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;
using Week11Day5WebServiceClient.Services;
using WorldlineLiveServiceReference;

namespace Week11Day5WebServiceClient.Controllers
{
    public class BankDetailsController : Controller
    {
        private readonly IBankDetailService _bankDetailService;

        public BankDetailsController(IBankDetailService bankDetailService)
        {
            _bankDetailService = bankDetailService;
        }

        // GET: BankDetails
        public async Task<ActionResult> Index()
        {
            var banks = await _bankDetailService.GetBankListAsync();
            ViewData["BanksSelectList"] = new SelectList(banks, "Name", "Name");

            return View();
        }

        public async Task<ActionResult> LoadDetails(string bankName, string ifsc)
        {
            var banks = await _bankDetailService.GetBankListAsync();
            ViewData["BanksSelectList"] = new SelectList(banks, "Name", "Name", bankName);

            List<BankDetails> bankDetails;

            if (!string.IsNullOrEmpty(bankName))
            {
                bankDetails = await _bankDetailService.GetBranchDetailsByBankAsync(bankName);

                ViewData["offset"] = 0;
                ViewData["rowCount"] = 10;
            }
            else if (!string.IsNullOrEmpty(ifsc))
            {
                var bankDetail = await _bankDetailService.GetBranchDetailsByIfscAsync(ifsc);
                bankDetails = new List<BankDetails> {  bankDetail};
            }
            else
                bankDetails = null;
            
            return View(nameof(Index), bankDetails);
        }
    }
}
