﻿using Fast_Fit_Final_Project.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fast_Fit_Final_Project.ViewModels
{
    public class MembersViewModel
    {

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters")]
        public string Name { get; set; }

        public int Age { get; set; }


        [Required(ErrorMessage = "Shoe size is required.")]
        [Range(0, 37)]
        public double ShoeSize { get; set; }

        [Required(ErrorMessage = "Shoe type is required.")]
        public MemberGender Gender { get; set; }

        public List<SelectListItem> MemberGenders { get; set; } = new List<SelectListItem>
        {

            new SelectListItem(MemberGender.Male.ToString(), ((int)MemberGender.Male).ToString()),
            new SelectListItem(MemberGender.Female.ToString(), ((int)MemberGender.Female).ToString())
        };
    }
}
