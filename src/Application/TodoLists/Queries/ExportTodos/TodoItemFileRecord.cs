using flex_notify.Application.Common.Mappings;
using flex_notify.Domain.Entities;

namespace flex_notify.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
