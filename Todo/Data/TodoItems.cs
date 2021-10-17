using System;
using System.Collections.Generic;
using System.Text;
using Todo.Model;
using Todoo = Todo.Model.Todo;

namespace Todo.Data
{
    public class TodoItems
    {
        private static Todoo[] todoItems = new Todoo[0];
        public int Size()
        {
            return todoItems.Length;
        }

        public Todoo[] FindAll()
        {
            return todoItems; // security leak 
        }

        public Todoo FindById(int todoId)
        {
            // TODO: add binary search tree since personId is increasing in array 
            foreach (Todoo todo in todoItems)
            {
                if (todo.TodoId == todoId) return todo;
            }
            return null;
        }

        private void AddTodoToTodos(Todoo todo)
        {
            int lastSize = todoItems.Length;
            Array.Resize(ref todoItems, lastSize + 1);
            todoItems[lastSize] = todo; // will put the person in the last position
        }

        public Todoo CreateTodo(string description)
        {
            int personId = TodoSequencer.NextTodoId();
            Todoo todo = new Todoo(personId, description);
            AddTodoToTodos(todo);
            return todo;
        }

        public void Clear()
        {
            Array.Resize<Todoo>(ref todoItems, 0);
        }
    }
}
