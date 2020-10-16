using flex_notify.Application.Common.Mappings;
using flex_notify.Domain.Entities;
using System.Collections.Generic;

namespace flex_notify.Application.TodoLists.Queries.GetTodos
{
    public class TodoListDto : IMapFrom<TodoList>
{
    public TodoListDto()
    {
        Items = new List<TodoItemDto>();
    }

    public int Id { get; set; }

    public string Title { get; set; }

    public IList<TodoItemDto> Items { get; set; }
}
}
