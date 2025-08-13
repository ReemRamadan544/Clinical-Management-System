using OfficeOpenXml;
using System.Security.Cryptography.Pkcs;
using universty_dental_clinical.Models;

namespace universty_dental_clinical.Services
{
    public class ExcelService
    {
        public ExcelService()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        public List<Student> ImportStudentsFromExcel(Stream excelStream)
        {
            using var package = new ExcelPackage(excelStream);
            var worksheet = package.Workbook.Worksheets[0];
            var rowCount = worksheet.Dimension.Rows;
            var students = new List<Student>();

            for (int row = 2; row <= rowCount; row++)
            {
                var studentName = worksheet.Cells[row, 1].Text;
                var studentId = worksheet.Cells[row, 2].Text;
                var level = worksheet.Cells[row, 3].Text;
                var student = new Student
                {

                    UniversityID = studentId,
                    Name = studentName,
                    Level = level,
                    Password = GeneratePassword(),
                    UniversityEmail= "Not Set",
                    Gender = "Not Set",
                    ContactInfo= "Not Set",
                    Role = "Student",
                };
                students.Add(student);
            }

            return students;
        }

        private string GeneratePassword()
        {
            var password = Path.GetRandomFileName().Replace(".", "").Substring(0, 8);
            return password;
        }

        public byte[] ExportStudentsToExcel(List<Student> students)
        {
            using var package = new ExcelPackage();
            var worksheet = package.Workbook.Worksheets.Add("Students");

            worksheet.Cells[1, 1].Value = "StudentName";
            worksheet.Cells[1, 2].Value = "StudentId";
            worksheet.Cells[1, 3].Value = "Level";
            worksheet.Cells[1, 4].Value = "Password";

            for (int i = 0; i < students.Count; i++)
            {
                worksheet.Cells[i + 2, 1].Value = students[i].Name;
                worksheet.Cells[i + 2, 2].Value = students[i].UniversityID;
                worksheet.Cells[i + 2, 3].Value = students[i].Level;
                worksheet.Cells[i + 2, 4].Value = students[i].Password;
            }

            return package.GetAsByteArray();
        }
    }
}
