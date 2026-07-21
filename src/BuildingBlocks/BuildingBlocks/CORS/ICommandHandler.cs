using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BuildingBlocks.CORS
{
    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, Unit>
         where TCommand : ICommand<Unit>
    {
    }

    public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse> // Corregido: Ahora apunta a ICommand
        where TResponse : notnull
    {
    }
}