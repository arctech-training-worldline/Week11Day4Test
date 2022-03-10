using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Week11Day4Test.Models;

namespace Week11Day4Test.Services
{
    public class BankBranchDataService
    {
        public List<Bank> GetBankList()
        {
            var banks = new List<Bank>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var query = $"worldline.GetBankList";
                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    connection.Open();

                    var dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            var bank = new Bank
                            {
                                Name = dataReader["Bank"].ToString()
                            };

                            banks.Add(bank);
                        }
                    }
                }
            }

            return banks;
        }

        public BankDetails GetBranchDetailsByIfsc(string ifscCode)
        {
            var bankDetails = new List<BankDetails>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var query = $"worldline.GetBankDetailsByIfsc";
                using (var command = new SqlCommand(query, connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@IfscCode", ifscCode);

                    connection.Open();

                    var dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        dataReader.Read();
                        var bankDetail = new BankDetails
                        {
                            Bank = dataReader["Bank"].ToString(),
                            Ifsc = dataReader["IFSC"].ToString(),
                            MicrCode = dataReader["MICR_CODE"].ToString(),
                            Branch = dataReader["BRANCH"].ToString(),
                            StdCode = dataReader["STD_CODE"].ToString(),
                            Contact = dataReader["CONTACT"].ToString(),
                            City = dataReader["CITY"].ToString(),
                            District = dataReader["DISTRICT"].ToString(),
                            State = dataReader["STATE"].ToString(),
                        };

                        return bankDetail;
                    }
                }
            }

            return null;
        }

        public List<BankDetails> GetBranchDetailsByBank(string bankName, int offset, int rowCount)
        {
            var bankDetails = new List<BankDetails>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand("worldline.GetBankDetailsByName", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@bankName", bankName);
                    command.Parameters.AddWithValue("@offset", offset);
                    command.Parameters.AddWithValue("@rowCount", rowCount);

                    connection.Open();

                    var dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            var student = new BankDetails
                            {
                                Bank = dataReader["Bank"].ToString(),
                                Ifsc = dataReader["IFSC"].ToString(),
                                MicrCode = dataReader["MICR_CODE"].ToString(),
                                Branch = dataReader["BRANCH"].ToString(),
                                StdCode = dataReader["STD_CODE"].ToString(),
                                Contact = dataReader["CONTACT"].ToString(),
                                City = dataReader["CITY"].ToString(),
                                District = dataReader["DISTRICT"].ToString(),
                                State = dataReader["STATE"].ToString(),
                            };

                            bankDetails.Add(student);
                        }
                    }
                }
            }

            return bankDetails;
        }
    }
}