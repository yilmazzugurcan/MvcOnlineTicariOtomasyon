﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Class
{
    public class Departman
    {
        [Key]
        public int Departmanid { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Departmanad { get; set; }

        //1 departman birden fazla personel bulunabilir. bu yüzden icollection kullanılır.
        public bool Durum { get; set; }
        public ICollection<Personel> Personels { get; set; }


    }
}