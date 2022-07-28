using System.ComponentModel.DataAnnotations;

namespace HomeworkApi.Data
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int DeptId { get; set; }

    }
}
