using Donut.SharedKernel.DatabaseConnection;
using Donut.SharedKernel.Repositories;
using Donut.SharedKernel.Tabels;
using System.Data;
using Donut.Core.CQRS;
using Dapper;
using Donut.SharedKernel.Results;
using Donut.Repositories;

namespace Donut.CQRS;
public record AddPersonCommand: ICommand<Person>
{
   public required Person Person { get; set; }
}
public class AddPersonCommandHandler: ICommandHandler<AddPersonCommand,Person>
{
    private readonly IPersonRepository _repository;
    public AddPersonCommandHandler(IPersonRepository repository)
    {
        _repository=repository;
    }
    public async Task<Result<Person>> Handle(AddPersonCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var entity = await _repository.Add(request.Person);
            return Result.Success(entity);
        }
        catch(Exception ex)
        {
            return Result.Failure<Person>(new Error("AddPerson", ex.Message));
        }
    }
}
