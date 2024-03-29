﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using VehicleQuote.Api;

namespace VehicleQuote.Models
{
    public class MyModel
    {
        [Required(ErrorMessage = "Make selection is required")]
        [Display(Name = "Select Make")]
        public string makeId { get; set; }
        public IEnumerable<Make> lstMakes { get; set; }

        [Required(ErrorMessage = "Model selection is required")]
        [Display(Name = "Select Model")]
        public string modelId { get; set; }
        public IEnumerable<MakeModels> lstModels { get; set; }
    }
}