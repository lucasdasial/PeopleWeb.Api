using System.Text.RegularExpressions;
using PeopleWeb.Api.Source.Domain.Interfaces;

namespace PeopleWeb.Api.Source.Services;

public  class DocumentService: IDocumentService
{
    public bool ValidateCpf(string cpf)
    {
        if (string.IsNullOrWhiteSpace(cpf))
            return false;

        cpf = Regex.Replace(cpf, @"[^\d]", "");

        if (cpf.Length != 11)
            return false;

        if (new string(cpf[0], cpf.Length) == cpf)
            return false;

        var numbers = new int[11];
        for (var i = 0; i < 11; i++)
            numbers[i] = int.Parse(cpf[i].ToString());

        var acc = 0;
        for (var i = 0; i < 9; i++)
            acc += numbers[i] * (10 - i);

        var firstDigit = acc % 11;
        firstDigit = firstDigit < 2 ? 0 : 11 - firstDigit;

        if (numbers[9] != firstDigit)
            return false;

        
        acc = 0;
        for (var i = 0; i < 10; i++)
            acc += numbers[i] * (11 - i);

        var secondDigit = acc % 11;
        secondDigit = secondDigit < 2 ? 0 : 11 - secondDigit;

        return numbers[10] == secondDigit;
    }
}