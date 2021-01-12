using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSB.EmployeeSelfService.Domain.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string CreatedUser { get; set; }
        public string UpdatedUser { get; set; }
    }
}
