﻿using System;
using System.Collections.Generic;

namespace CutieShop.API.Models.Entities.Models.Entities
{
    public partial class ServiceOnlineOrder
    {
        public string ServiceOnlineOrderId { get; set; }
        public string PetId { get; set; }
        public DateTime DateBegin { get; set; }

        public OnlineOrder ServiceOnlineOrderNavigation { get; set; }
    }
}
