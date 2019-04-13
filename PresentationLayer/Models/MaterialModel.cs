using DataLayer.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PresentationLayer.Models
{
    public class MaterialViewModel : PageViewModel
    {
        public Material Material { get; set; }
        public Material NextMaterial { get; set; }
    }

    public class MaterialEditModel : PageEditModel
    {
        [Required]
        public int DerictoryId { get; set; }
    }
}
