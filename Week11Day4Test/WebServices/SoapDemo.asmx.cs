using System.Collections.Generic;
using System.Web.Services;
using Week11Day4Test.Models;
using Week11Day4Test.Services;

namespace Week11Day4Test.WebServices
{
    /// <summary>
    /// Summary description for SoapDemo
    /// </summary>
    [WebService(Namespace = "http://arctechinfo.com/webservies/worldline-training")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SoapDemo : WebService
    {
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public List<Student> GetOrders()
        {
            var studentService = new StudentService();
            return studentService.GetAllStudents();
        }

        //[WebMethod]
        //public List<Bank> GetBankList()
        //{
        //    var bankBranchDataService = new BankBranchDataService();
        //    return bankBranchDataService.GetBankList();
        //}

        //[WebMethod]
        //public BankData GetBranchDetailsByIfsc(string ifscCode)
        //{
        //    var bankBranchDataService = new BankBranchDataService();
        //    return bankBranchDataService.GetBranchDetailsByIfsc(ifscCode);
        //}

        //[WebMethod]
        //public List<BankData> GetBranchDetailsByBank(string bankName, int offset, int rowCount)
        //{
        //    var bankBranchDataService = new BankBranchDataService();
        //    return bankBranchDataService.GetBranchDetailsByBank(bankName, offset, rowCount);
        //}
    }
}
