using System.Collections.Generic;
using System.Threading.Tasks;
using Week11Day5WebServiceClient.Models;
using WorldlineLiveServiceReference;

namespace Week11Day5WebServiceClient.Services
{
    public interface IBankDetailService
    {
        public Task<List<Bank>> GetBankListAsync();
        Task<List<BankDetails>> GetBranchDetailsByBankAsync(string bankName, int offset = 0, int rowCount = 10);
        Task<BankDetails> GetBranchDetailsByIfscAsync(string ifsc);
    }
}