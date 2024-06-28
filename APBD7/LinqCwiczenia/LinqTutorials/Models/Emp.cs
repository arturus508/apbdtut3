using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LinqTutorials.Models
{
    public class Emp
    {
        [Key]
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int Salary { get; set; }
        public DateTime? HireDate { get; set; }
        public int? Deptno { get; set; }
        
        [ForeignKey("Deptno")]
        public Dept Dept { get; set; }
        
        public int? MgrId { get; set; }
        [ForeignKey("MgrId")]
        public Emp Mgr { get; set; }
    }
}
