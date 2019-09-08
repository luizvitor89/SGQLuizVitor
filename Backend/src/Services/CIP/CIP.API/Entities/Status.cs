﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CIP.API.Entities
{
    public class Status
    {
        [Key]
        public Guid StatusId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
