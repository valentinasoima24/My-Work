using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine_SV.Interfaces;
using VendingMachine_SV.PresentationLayer;
using VendingMachine_SV.ProductSpecifications;

namespace VendingMachine_SV.Payment
{
    internal class CardPayment :IPaymentMethod
    {
        private CardPaymentTerminal card_Payment;
        public int Id => 2;
        public string Name=>"Card";

        public CardPayment(CardPaymentTerminal card_Payment)
        {
            this.card_Payment = card_Payment ?? throw new ArgumentNullException(nameof(card_Payment));
        }

        public void Run(decimal price)
        {
            string cardNumber= card_Payment.AskForCardNumber();

            if (string.IsNullOrEmpty(cardNumber))
            {
                throw new CancelException();
            }

            if (!CheckCardNumber(cardNumber))
            {
                throw new InvalidCardNumberException(cardNumber);
            }
        }

        private bool CheckCardNumber(string cardNumber)
        {
            double sum = 0;

            for(int i = 0; i < cardNumber.Length; i++)
            {
                double number=char.GetNumericValue(cardNumber[i]);

                if (i % 2 == 1)
                {
                    sum+=number;
                }
                else
                {
                    sum += number * 2;
                    if (number * 2 > 9)
                    {
                        sum-=9;
                    }
                }
            }

            if (sum % 10 != 0)
            {
                return false;
            }
            return true;
        }
    }
}
