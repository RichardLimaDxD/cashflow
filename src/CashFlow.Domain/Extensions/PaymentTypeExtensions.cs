using CashFlow.Domain.Enums;
using CashFlow.Domain.PaymentTypeMessages;

namespace CashFlow.Domain.Extensions
{
    public static class PaymentTypeExtensions
    {
        public static string PaymentTypeToString(this PaymentType paymentType)
        {
            return paymentType switch
            {
                PaymentType.Cash => ResourcePaymentTypeGenerationMessages.CASH,
                PaymentType.CreditCard => ResourcePaymentTypeGenerationMessages.CREDIT_CARD,
                PaymentType.DebitCard => ResourcePaymentTypeGenerationMessages.DEBIT_CARD,
                PaymentType.EletronicTransfer => ResourcePaymentTypeGenerationMessages.ELETRONIC_TRANSFER,
                _ => string.Empty
            };
        }
    }
}
