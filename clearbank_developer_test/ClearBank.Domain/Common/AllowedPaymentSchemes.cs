﻿namespace ClearBank.Domain.Common
{
    public enum AllowedPaymentSchemes
    {
        FasterPayments = 1 << 0,
        Bacs = 1 << 1,
        Chaps = 1 << 2
    }
}