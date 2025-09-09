

namespace PeopleWeb.Api.Source.Domain.Execptions;

public class ValidationException : Exception
{
    public ValidationException(string message) : base(message) { }
}