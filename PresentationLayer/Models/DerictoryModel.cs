using DataLayer.Entites;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Models
{
    public class DerictoryViewModel : PageViewModel
    {
        public Directory Directory { get; set; }
        public List<MaterialViewModel> Materials { get; set; }

    }

    public class DerictoryEditModel : PageEditModel
    {
    }
}
