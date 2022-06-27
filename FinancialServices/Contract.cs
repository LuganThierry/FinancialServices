using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialServices
{
    public class Contract
    {
        public Guid IdContract { get; set; }
        public string ContractingParty { get; set; }
        public decimal ContractValue { get; set; }
        public int ContractTerm { get; set; }
        public virtual void CalculateInstallment()
        {
            return;
        }
        public virtual void DisplayInfo()
        {
            Console.WriteLine($"O valor do contrato é: {ContractValue}\n" +
            $"O prazo do contrato é: {ContractTerm}");
            CalculateInstallment();
        }

    }
}
