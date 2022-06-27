using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialServices
{
    internal class LegalEntityContracts : Contract
    {
        public string CNPJ { get; set; }
        public string StateRegistration { get; set; }
        public override void CalculateInstallment()
        {
            Console.WriteLine($"A prestação do contrato é: {(ContractValue / ContractTerm) + 3}");
        }
    }
}
