
using FastFitProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FastFitProject.ViewModels
{
    public class MemberDetailViewModel 
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters")]
        public string Name { get; set; }
        public int Age { get; set; }

        [Required(ErrorMessage = "Shoe size is required.")]
        [Range(5.0, 14.0)]
        public string ShoeSize { get; set; }

        [Required(ErrorMessage = "Shoe type is required.")]
        public MemberGender Gender { get; set; }

        public List<SelectListItem> MemberGenders { get; set; } = new List<SelectListItem>
        {
            new SelectListItem(MemberGender.Man.ToString(), ((int)MemberGender.Man).ToString()),
            new SelectListItem(MemberGender.Woman.ToString(), ((int)MemberGender.Woman).ToString())
        };

        public MemberDetailViewModel (Members theMember)
        {
            Id = theMember.Id;
            Name = theMember.Name;
            ShoeSize= theMember.ShoeSize;
            Age = theMember.Age;
            Gender = theMember.Gender;
        }
        public MemberDetailViewModel() { }

    }
}
