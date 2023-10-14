﻿using Forces.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forces.Application.Models
{
    public class Room  : AuditableEntity<int>
    {

        public int Id { get; set; }
        public string RoomNumber { get; set; }
        [ForeignKey("BuildingId")]
        public int BuildingId { get; set; }
        public virtual Building Building { get; set; }
    }
}