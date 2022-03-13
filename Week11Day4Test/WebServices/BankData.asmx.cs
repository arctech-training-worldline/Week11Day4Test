using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Xml;
using Week11Day4Test.Models;
using Week11Day4Test.Services;

namespace Week11Day4Test.WebServices;

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
    public UserAuthSoapHeader UserAuthSoapHeader { get; set; }

    [WebMethod]
    [SoapHeader("UserAuthSoapHeader")]
    public List<Bank> GetBankList(int offset, int rowCount)
    {
        if (UserAuthSoapHeader == null)
            throw new SoapHeaderException("Soap Header [UserAuthSoapHeader] is missing", new XmlQualifiedName(nameof(UserAuthSoapHeader)));

        if (!UserAuthSoapHeader.IsValid())
            throw new SoapHeaderException("Invalid Authentication Details", new XmlQualifiedName(nameof(UserAuthSoapHeader)));

        var bankBranchDataService = new BankBranchDataService();
        return bankBranchDataService.GetBankList(offset, rowCount);
    }

    [WebMethod]
    [SoapHeader("UserAuthSoapHeader")]
    public BankDetails GetBranchDetailsByIfsc(string ifscCode)
    {
        if (UserAuthSoapHeader == null)
            throw new SoapHeaderException("Soap Header [UserAuthSoapHeader] is missing", new XmlQualifiedName(nameof(UserAuthSoapHeader)));

        if (!UserAuthSoapHeader.IsValid())
            throw new SoapHeaderException("Invalid Authentication Details", new XmlQualifiedName(nameof(UserAuthSoapHeader)));

        var bankBranchDataService = new BankBranchDataService();
        return bankBranchDataService.GetBranchDetailsByIfsc(ifscCode);
    }

    [WebMethod]
    [SoapHeader("UserAuthSoapHeader")]
    public List<BankDetails> GetBranchDetailsByBank(string bankName, int offset, int rowCount)
    {
        if (UserAuthSoapHeader == null)
            throw new SoapHeaderException("Soap Header [UserAuthSoapHeader] is missing", new XmlQualifiedName(nameof(UserAuthSoapHeader)));

        if (!UserAuthSoapHeader.IsValid())
            throw new SoapHeaderException("Invalid Authentication Details", new XmlQualifiedName(nameof(UserAuthSoapHeader)));

        var bankBranchDataService = new BankBranchDataService();
        return bankBranchDataService.GetBranchDetailsByBank(bankName, offset, rowCount);
    }
}