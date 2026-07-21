using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace BuildingBlocks.CORS
{
    public  interface IQueryHandler<in TQuery, TResponse> : IRequestHandler <TQuery, TResponse>
        where TQuery : IQuery<TResponse>
        where TResponse : notnull
    {
    }
}
