using System;
using Xunit;
using Todo.Data;

namespace Test.Data
{
    public class PersonSequencerTest
    {
        public PersonSequencerTest()
        {
            PersonSequencer.Reset();
        }

        [Fact]
        public void NextPersonId()
        {
            int expectedFirstValue = 1;
            Assert.Equal(expectedFirstValue, PersonSequencer.NextPersonId());
            Assert.Equal(expectedFirstValue + 1, PersonSequencer.NextPersonId());
        }
    }
}
