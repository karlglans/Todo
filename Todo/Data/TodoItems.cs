using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
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

        public Todoo[] FindByDoneStatus(bool doneStatus)
        {
            List<Todoo> found = new List<Todoo>();
            foreach (Todoo todo in todoItems)
            {
                if (todo.Done == doneStatus) found.Add(todo);
            }
            return found.ToArray();
        }

        public Todoo[] FindByAssignee(int personId)
        {
            List<Todoo> found = new List<Todoo>();
            foreach (Todoo todo in todoItems)
            {
                if (todo.Assignee != null && todo.Assignee.PersonId == personId) found.Add(todo);
            }
            return found.ToArray();
        }

        public Todoo[] FindByAssignee(Person person)
        {
            return FindByAssignee(person.PersonId);
        }

        public Todoo[] FindUnassignedTodoItems()
        {
            List<Todoo> found = new List<Todoo>();
            foreach (Todoo todo in todoItems)
            {
                if (todo.Assignee == null) found.Add(todo);
            }
            return found.ToArray();
        }

        public bool RemoveTodo(Todoo todo)
        {
            Todoo found = FindById(todo.TodoId);
            todoItems = todoItems.Where(val => val.TodoId != todo.TodoId).ToArray();
            return found != null;
        }
    }
}
