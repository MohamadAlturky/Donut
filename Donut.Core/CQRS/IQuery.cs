using Donut.SharedKernel.Results;
using MediatR;
namespace Donut.Core.CQRS;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> { }
public interface IQueryHandler<TQuery, TResponse>
    : IRequestHandler<TQuery, Result<TResponse>>
        where TQuery : IQuery<TResponse>
{ }