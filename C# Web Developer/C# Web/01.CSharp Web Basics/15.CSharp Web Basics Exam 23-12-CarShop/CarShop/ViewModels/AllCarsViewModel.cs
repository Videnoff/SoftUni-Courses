using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels
{
    public class AllCarsViewModel
    {
        public string Id { get; set; }

        public string Year { get; set; }

        public string Model { get; set; }

        public string Img { get; set; }

        public string CarPlate { get; set; }

        public string RemIssues { get; set; } = "1";

        public string FixIssues { get; set; } = "2";
    }
}