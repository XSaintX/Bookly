using Bookly.Domain.Abstractions;
using MediatR;

namespace Bookly.Application.Abstractions.Messaging
{
    public interface ICommand:IRequest<Result>, IBaseCommand
    {

    }
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
    {

    }
    public interface IBaseCommand
    {

    }
}
