﻿using System.Collections.Generic;

namespace ClearBank.Domain.Entities
{
    public class AllowedPaymentScheme
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Account> Accounts { get; set; }
    }
}