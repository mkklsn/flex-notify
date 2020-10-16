using flex_notify.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace flex_notify.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
