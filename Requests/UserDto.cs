using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Event_management_System.Requests
{
    public class UserDto
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        [PasswordPropertyText]
        public string Password {get; set;} = string.Empty;
    }
}