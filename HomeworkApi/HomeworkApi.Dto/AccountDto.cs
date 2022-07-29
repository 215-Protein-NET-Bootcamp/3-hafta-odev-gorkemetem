using HomeworkApi.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace HomeworkApi.Dto
{
    public class AccountDto 
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(125)]
        [UserNameAttribute]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [PasswordAttribute]
        public string Password { get; set; }

        [Required]
        [MaxLength(500)]
        public string Name { get; set; }

        [Required]
        [EmailAddressAttribute]
        [MaxLength(500)]
        public string Email { get; set; }

 
        [Display(Name = "Last Activity")]
        public DateTime LastActivity { get; set; }
    }
}
