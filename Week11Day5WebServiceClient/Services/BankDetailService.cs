using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using BankDataServiceReference;
using Microsoft.Extensions.Options;
using Week11Day5WebServiceClient.Settings;


namespace Week11Day5WebServiceClient.Services
{
    public class BankDetailService : IBankDetailService
    {
        public readonly string serviceUrl = "https://localhost:44352/WebServicesDev/BankData.asmx";
        private readonly ILogger<BankDetailService> _logger;
        public readonly EndpointAddress endpointAddress;
        public readonly BasicHttpBinding basicHttpBinding;
        private readonly BankDetailsApiAuth _bankDetailsApiAuth;

        public BankDetailService(ILogger<BankDetailService> logger, IOptions<BankDetailsApiAuth> bankDetailsApiAuthAccessor)
        {
            _logger = logger;
            _bankDetailsApiAuth = bankDetailsApiAuthAccessor.Value;

            endpointAddress = new EndpointAddress(serviceUrl);

            basicHttpBinding = new BasicHttpBinding(
                endpointAddress.Uri.Scheme.ToLower() == "http" ?
                    BasicHttpSecurityMode.None :
                    BasicHttpSecurityMode.Transport)
            {
                OpenTimeout = TimeSpan.MaxValue,
                CloseTimeout = TimeSpan.MaxValue,
                ReceiveTimeout = TimeSpan.MaxValue,
                SendTimeout = TimeSpan.MaxValue
            };
        }

        public async Task<List<Bank>> GetBankListAsync()
        {
            try
            {
                var client = new BankDataSoapClient(basicHttpBinding, endpointAddress);

                var response = await client.GetBankListAsync(0, 25);
                var result = response.Body.GetBankListResult.ToList();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting bank list");
                throw;
            }
        }

        public async Task<List<BankDetails>> GetBranchDetailsByBankAsync(string bankName, int offset, int rowCount)
        {
            try
            {
                var client = new BankDataSoapClient(basicHttpBinding, endpointAddress);
                
                var response = await client.GetBranchDetailsByBankAsync(bankName, offset, rowCount);
                var result = response.Body.GetBranchDetailsByBankResult.ToList();

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting bank list");
                throw;
            }
        }

        public async Task<BankDetails> GetBranchDetailsByIfscAsync(string ifsc)
        {
            try
            {
                var client = new BankDataSoapClient(basicHttpBinding, endpointAddress);

                var response = await client.GetBranchDetailsByIfscAsync(ifsc);
                var result = response.Body.GetBranchDetailsByIfscResult;

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting bank list");
                throw;
            }
        }
    }
}
