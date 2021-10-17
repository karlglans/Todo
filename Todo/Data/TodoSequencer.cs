using System;
using System.Collections.Generic;
using System.Text;

namespace Todo.Data
{
    public class TodoSequencer
    {
        static private int todoId;

        public static int NextTodoId()
        {
            return ++todoId;
        }

        public static void Reset()
        {
            todoId = 0;
        }
    }
}
