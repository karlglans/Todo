using System;
using Xunit;
using Todo.Model;

namespace Test.Model
{
    [Collection("Serial")]
    public class TodoTest
    {
        private int someSerial = 1;
        private string someValidString = "someValidString";

        [Fact]
        public void CanMakeObject()
        {
            var todo = new Todo.Model.Todo(someSerial, someValidString);
            Assert.NotNull(todo);
            Assert.Equal(someSerial, todo.TodoId);
        }
    }
}
