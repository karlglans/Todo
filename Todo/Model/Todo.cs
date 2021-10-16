using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Model
{
    public class Todo
    {
        private readonly int todoId;
        private string description;
        private bool done;
        private Person assignee;

        public Todo(int todoId, string description)
        {
            this.todoId = todoId;
            Description = description;
        }

        public int TodoId
        {
            get { return todoId; }
        }

        public Person Assignee { get => assignee; set => assignee = value; }
        public bool Done { get => done; set => done = value; }
        public string Description { get => description; set => description = value; }
    }
}
