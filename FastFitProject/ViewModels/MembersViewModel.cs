
using FastFitProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Net.Http.Headers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace FastFitProject.ViewModels
{
    public class MembersViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters")]
        public string Name { get; set; }

        public int Age { get; set; }


        [Required(ErrorMessage = "Shoe size is required.")]
        [Range(5, 14)]
        public string ShoeSize { get; set; }

        [Required(ErrorMessage = "Shoe type is required.")]
        public MemberGender Gender { get; set; }

        public List<SelectListItem> MemberGenders { get; set; } = new List<SelectListItem>
        {

            new SelectListItem(MemberGender.Male.ToString(), ((int)MemberGender.Male).ToString()),
            new SelectListItem(MemberGender.Female.ToString(), ((int)MemberGender.Female).ToString())
        };

        public MembersViewModel(Members theMember)
        {
            Id = theMember.Id;
            Name = theMember.Name;
            ShoeSize = theMember.ShoeSize;
            Age = theMember.Age;
            Gender = theMember.Gender;
        }
        public MembersViewModel() { }
    }
}
