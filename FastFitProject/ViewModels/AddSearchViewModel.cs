using FastFitProject.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace FastFitProject.ViewModels
{
    public class AddSearchViewModel
    {
        public int MembersId { get; set; }

        public List<SelectListItem> Members { get; set; }

        public AddSearchViewModel(List<Members> members)
        {
            Members = new List<SelectListItem>();

            foreach (var member in members)
            {
                // populating search list with members
                Members.Add(
                    new SelectListItem
                    {
                        Value = member.Id.ToString(),
                        Text = member.Name
                    }
                ); ;
            }
        }
    }
}
