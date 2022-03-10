﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Week11Day4Test.Models;

namespace Week11Day4Test.Services
{
    public class StudentService
    {
        public List<Student> GetAllStudents()
        {
            var students = new List<Student>();

            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString;

            using (var connection = new SqlConnection(connectionString))
            {
                var query = "select * from Students";
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    var dataReader = command.ExecuteReader();

                    if (dataReader.HasRows)
                    {
                        while (dataReader.Read())
                        {
                            var student = new Student
                            {
                                RollNo = (int)dataReader["RollNo"],
                                Name = dataReader["Name"].ToString(),
                                DateOfBirth = (DateTime)dataReader["DateOfBirth"],
                                Percentage = (double)dataReader["Percentage"]
                            };

                            students.Add(student);
                        }
                    }
                }
            }

            return students;
        }
    }
}