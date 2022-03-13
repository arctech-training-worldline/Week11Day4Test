using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Services;
using Week11Day4Test.Models;
using Week11Day4Test.Services;

namespace Week11Day4Test.WebServicesDev;

/// <summary>
/// Summary description for BankData
/// </summary>
[WebService(Namespace = "http://arctechinfo.com/webservies/worldline-training")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
[System.ComponentModel.ToolboxItem(false)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class BankData : System.Web.Services.WebService
{
    [WebMethod]
    public List<Bank> GetBankList(int offset, int rowCount)
    {
        var bankBranchDataService = new BankBranchDataService();
        return bankBranchDataService.GetBankList(0, 3);
    }

    [WebMethod]
    public BankDetails GetBranchDetailsByIfsc(string ifscCode)
    {
        var bankBranchDataService = new BankBranchDataService();
        return bankBranchDataService.GetBranchDetailsByIfsc(ifscCode);
    }

    [WebMethod]
    public List<BankDetails> GetBranchDetailsByBank(string bankName, int offset, int rowCount)
    {
        var bankBranchDataService = new BankBranchDataService();
        return bankBranchDataService.GetBranchDetailsByBank(bankName, 0, 3);
    }
}