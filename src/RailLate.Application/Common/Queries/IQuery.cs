using MediatR;

namespace RailLate.Application.Common.Queries;

public interface IQuery<out TResult> : IRequest<TResult>
{
    
}