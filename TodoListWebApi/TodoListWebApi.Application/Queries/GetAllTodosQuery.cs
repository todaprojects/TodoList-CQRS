using System.Collections.Generic;
using MediatR;
using TodoListWebApi.Domain.Entities;

namespace TodoListWebApi.Application.Queries
{
    public class GetAllTodosQuery : IRequest<IEnumerable<Todo>>
    {
    }
}