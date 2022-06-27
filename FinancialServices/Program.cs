using FinancialServices;
using System.Text.RegularExpressions;

Console.WriteLine("Registrar novo contrato. Clique em qualquer tecla para continuar");
Console.ReadKey();
Console.Clear();
Console.WriteLine("Digite [1] para pessoa física e [2] para pessoa jurídica");
int typeofPerson = int.Parse(Console.ReadLine());

while (typeofPerson != 1 && typeofPerson != 2)
{
    Console.WriteLine("Digite uma opção válida");
    typeofPerson = int.Parse(Console.ReadLine());
}

if (typeofPerson == 1)
{
    NaturalPersonContracts newContract = new NaturalPersonContracts();
    newContract.IdContract = new Guid(); 
    Console.WriteLine("Qual o nome da pessoa que está contratando o financiamento?");
    newContract.ContractingParty = Console.ReadLine();
    Console.WriteLine("Qual o CPF da pessoa que está contratando o financiamento?");
    newContract.CPF = Console.ReadLine();
    newContract.CPF = CPFandCNPJRegex(newContract.CPF);
    Console.WriteLine("Qual a data de nascimento da pessoa contratante?");
    newContract.BirthDate = DateTime.Parse(Console.ReadLine());
    Console.WriteLine("Qual o valor do financiamento almejado?");
    newContract.ContractValue = decimal.Parse(Console.ReadLine());
    Console.WriteLine("Qual o prazo de pagamento do financiamento em número meses?");
    newContract.ContractTerm = int.Parse(Console.ReadLine());
    while (newContract.ContractTerm <= 0)
    {
        Console.WriteLine("Digite um prazo de pagamento maior que zero");
        newContract.ContractTerm = int.Parse(Console.ReadLine());
    }
    Console.Clear();
    newContract.DisplayInfo();
}
else if (typeofPerson == 2)
{
    LegalEntityContracts newContract = new LegalEntityContracts();
    Console.WriteLine("Qual o nome da empresa que está contratando o financiamento?");
    newContract.ContractingParty = Console.ReadLine();
    Console.WriteLine("Qual o CNPJ da empresa que está contratando o financiamento?");
    newContract.CNPJ = Console.ReadLine();
    newContract.CNPJ = CPFandCNPJRegex(newContract.CNPJ);
    Console.WriteLine("Qual a inscrição estadual da empresa?");
    newContract.StateRegistration = Console.ReadLine();
    while (newContract.StateRegistration.Length != 11)
    {
        Console.WriteLine("Digite uma inscrição válida");
        newContract.StateRegistration = Console.ReadLine();
    }
    Console.WriteLine("Qual o valor do financiamento almejado?");
    newContract.ContractValue = decimal.Parse(Console.ReadLine());
    Console.WriteLine("Qual o prazo de pagamento do financiamento em número de meses?");
    newContract.ContractTerm = int.Parse(Console.ReadLine());
    while (newContract.ContractTerm <= 0)
    {
        Console.WriteLine("Digite um prazo de pagamento maior que zero");
        newContract.ContractTerm = int.Parse(Console.ReadLine());
    }
    Console.Clear();
    newContract.DisplayInfo();
}


static string CPFandCNPJRegex(string registration)
{
    Regex regexRegistration = new Regex(@"\b([0-9]{3}\.?[0-9]{3}\.?[0-9]{3}\-?[0-9]{2}|[0-9]{2}\.?[0-9]{3}\.?[0-9]{3}\/?[0-9]{4}\-?[0-9]{2})\b");
 
    while(!regexRegistration.Match(registration).Success)
    {
        Console.WriteLine("Número de cadastro inválido. Digite novamente");
        registration = Console.ReadLine();
    }

    if (regexRegistration.Match(registration).Success)
    {
        Console.WriteLine($"Número de cadastro registrado: {registration}");
    }
    return registration;
}