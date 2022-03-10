using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using WorldlineLiveServiceReference;

namespace Week11Day5WebServiceClient.Services
{
    public class BankDetailService : IBankDetailService
    {
        public readonly string serviceUrl = "https://bankdetailsdemo.azurewebsites.net/WebServices/SoapDemo.asmx";
        private readonly ILogger<BankDetailService> _logger;
        private readonly IConfiguration _configuration;
        public readonly EndpointAddress endpointAddress;
        public readonly BasicHttpBinding basicHttpBinding;

        public BankDetailService(ILogger<BankDetailService> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;

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

        private async Task<SoapDemoSoapClient> GetInstanceAsync()
        {
            return await Task.Run(() => new SoapDemoSoapClient(basicHttpBinding, endpointAddress));
        }

        public async Task<List<Bank>> GetBankListAsync()
        {
            try
            {
                var client = await GetInstanceAsync();
                var response = await client.GetBankListAsync();

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
                var client = await GetInstanceAsync();
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
                var client = await GetInstanceAsync();
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
