﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class Kategori
    {
        [Key]
        public string KategoriID { get; set; }
        public string KategoriAd { get; set; }
    }
}