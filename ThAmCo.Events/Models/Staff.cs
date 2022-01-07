using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ThAmCo.Events.Models
{
    public class Staff
    {
        public Staff()
        {
        }
        public Staff(int StfId, string EM, string FN, string LN, string JTy, bool FA)
        {
            StaffId = StfId;
            Email = EM;
            FirstName = FN;
            LastName = LN;
            JobType = JTy;
            FirstAid = FA;
        }

        public int StaffId { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string JobType { get; set; }
        [Required]
        public bool FirstAid { get; set; }

        public ICollection<Staffing> Staffing { get; set; }
    }
}
