using Donut.SharedKernel.DatabaseConnection;
using Donut.SharedKernel.Repositories;
using Donut.SharedKernel.Tabels;
using System.Data;
using Donut.Core.CQRS;
using Dapper;
using Donut.SharedKernel.Results;
using Donut.Repositories;

namespace Donut.CQRS;
public record DeletePersonCommand: ICommand
{
   public required Person Person { get; set; }
}
public class DeletePersonCommandHandler: ICommandHandler<DeletePersonCommand>
{
    private readonly IPersonRepository _repository;
    public DeletePersonCommandHandler(IPersonRepository repository)
    {
        _repository=repository;
    }
    public async Task<Result> Handle(DeletePersonCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.Delete(request.Person);
            return Result.Success();
        }
        catch(Exception ex)
        {
            return Result.Failure(new Error("DeletePerson", ex.Message));
        }
    }
}
