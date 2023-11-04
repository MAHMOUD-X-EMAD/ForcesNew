﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forces.Application.Features.Person.Queries.GetAll
{
    public class GetAllPersonsResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NationalNumber { get; set; }
        public int RoomId { get; set; }
    }
}
