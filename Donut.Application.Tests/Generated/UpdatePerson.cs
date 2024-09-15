using Donut.SharedKernel.DatabaseConnection;
using Donut.SharedKernel.Repositories;
using Donut.SharedKernel.Tabels;
using System.Data;
using Donut.Core.CQRS;
using Dapper;
using Donut.SharedKernel.Results;
using Donut.Repositories;

namespace Donut.CQRS;
public record UpdatePersonCommand: ICommand
{
   public required Person Person { get; set; }
}
public class UpdatePersonCommandHandler: ICommandHandler<UpdatePersonCommand>
{
    private readonly IPersonRepository _repository;
    public UpdatePersonCommandHandler(IPersonRepository repository)
    {
        _repository=repository;
    }
    public async Task<Result> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
    {
        try
        {
            await _repository.Update(request.Person);
            return Result.Success();
        }
        catch(Exception ex)
        {
            return Result.Failure(new Error("UpdatePerson", ex.Message));
        }
    }
}
