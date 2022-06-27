using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialServices
{
    internal class NaturalPersonContracts : Contract
    {
        public string CPF { get; set; }
        public DateTime BirthDate { get; set; }
        public void RegisterBirthDate(int year, int month, int day)
        {
            BirthDate = new DateTime(year, month, day);
        }

        private int ContractingPartyAge()
        {
            if (BirthDate.Month > DateTime.Now.Month)
            {
                return (DateTime.Now.Year - BirthDate.Year) - 1;
            }
            else if (BirthDate.Month < DateTime.Now.Month)
            {
                return (DateTime.Now.Year - BirthDate.Year);
            }
            else
            {
                if (BirthDate.Day < DateTime.Now.Day)
                {
                    return (DateTime.Now.Year - BirthDate.Year);
                }
                else
                {
                    return (DateTime.Now.Year - BirthDate.Year) - 1;
                }
            }
        }

        public int AdditionalFee()
        {
            switch(ContractingPartyAge())
            {
                case <= 30:
                    return 1;
                    break;

                case <= 40:
                    return 2;
                    break;

                case <= 50:
                    return 3;
                    break;

                case > 50:
                    return 4;
                    break;
            }
        }

        public override void CalculateInstallment()
        {
            Console.WriteLine($"A prestação do contrato é: {(ContractValue / ContractTerm) + AdditionalFee()}");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine($"O valor do contrato é: {ContractValue}\n" +
            $"O prazo do contrato é: {ContractTerm}");
            CalculateInstallment();
            Console.WriteLine($"A idade do contratante é: {ContractingPartyAge()}");
        }
    }
}
