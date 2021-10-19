using System;
using Xunit;
using Todo.Data;

namespace Test.Data
{
    [Collection("Serial")]
    public class TodoSequencerTest
    {
        public TodoSequencerTest()
        {
            TodoSequencer.Reset();
        }

        [Fact]
        public void NextTodoId()
        {
            int expectedFirstValue = 1;
            Assert.Equal(expectedFirstValue, TodoSequencer.NextTodoId());
            Assert.Equal(expectedFirstValue + 1, TodoSequencer.NextTodoId());
        }
    }
}
