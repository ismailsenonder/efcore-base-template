using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFProject.Data.Models
{
    public class BaseModel
    {
        //this base model can be modified. This is the version I use for my database design.
        [Key]
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        public Guid? DeletedBy { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
