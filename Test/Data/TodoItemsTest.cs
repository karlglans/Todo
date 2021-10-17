using System;
using Xunit;
using Todo.Model;
using Todo.Data;

namespace Test.Data
{
    public class TodoItemsTest
    {
        TodoItems todoItems;
        const string someTodoDesc = "someTodoDesc";

        public TodoItemsTest()
        {
            todoItems = new TodoItems();
            todoItems.Clear(); // to make sure static People:people is resetted befor each test
        }

        [Fact]
        public void todoItems_shouldHaveSizeZero_whenFirstCreated()
        {
            Assert.Equal(0, todoItems.Size());
        }

        [Fact]
        public void Clear_shouldLeadToSizeZero()
        {
            // WARNING: this test seems problematic when run in conjuction with other tests
            todoItems.Clear();
            todoItems.CreateTodo(someTodoDesc);
            Assert.Equal(1, todoItems.Size());
            todoItems.Clear();
            Assert.Equal(0, todoItems.Size());
        }

        [Fact]
        public void CreateTodo_shouldGenerateATodoObject()
        {
            Todo.Model.Todo todo = todoItems.CreateTodo(someTodoDesc);
            Assert.Equal(someTodoDesc, todo.Description);
            Assert.NotEqual(0, todo.TodoId); // is given an valid id above 0
        }

        [Fact]
        public void CreateTodo_shouldStoreTheCreatedTodo()
        {
            int sizeBefore = todoItems.Size();
            Assert.Equal(0, sizeBefore);
            Todo.Model.Todo todo = todoItems.CreateTodo(someTodoDesc);
            int sizeAfter = todoItems.Size();
            Assert.Equal(1, sizeAfter);
            Todo.Model.Todo lastTodoInArray = todoItems.FindAll()[0];
            Assert.Equal(todo, lastTodoInArray);
        }

        [Fact]
        public void FindById_whenGivenAnExistingPersonId()
        {
            string textForTodoTwo = "textForTodoTwo";
            // adding 3 persons
            todoItems.CreateTodo(someTodoDesc);
            Todo.Model.Todo todo2 = todoItems.CreateTodo(textForTodoTwo);
            todoItems.CreateTodo(someTodoDesc);

            Todo.Model.Todo foundTodo = todoItems.FindById(todo2.TodoId);
            Assert.Equal(todo2, foundTodo);
        }

        [Fact]
        public void FindById_whenGivenAnNoneExistentPersonId_shouldGiveNull()
        {
            // adding 3 persons
            todoItems.CreateTodo(someTodoDesc);
            Todo.Model.Todo todo2 = todoItems.CreateTodo(someTodoDesc);
            todoItems.CreateTodo(someTodoDesc);

            int nonexistentId = todo2.TodoId + 10; // since we did not add more the 3 persons
            Assert.Null(todoItems.FindById(nonexistentId));
        }

        [Fact]
        public void FindByDoneStatus_whenGivenMatchingTodos()
        {
            Todo.Model.Todo todo = todoItems.CreateTodo(someTodoDesc);
            todo.Done = true;

            Todo.Model.Todo todo2 = todoItems.CreateTodo(someTodoDesc);
            todo2.Done = true;

            Todo.Model.Todo todo3 = todoItems.CreateTodo(someTodoDesc);
            todo3.Done = false;

            // assert: 2 of 3 todos done
            var doneTodos = todoItems.FindByDoneStatus(true);
            Assert.Equal(2, doneTodos.Length);
        }

        [Fact]
        public void FindByDoneStatus_whenGivenTodosWithAssignee()
        {
            People people = new People();
            Person person = people.CreatePerson("first", "last");
            Todo.Model.Todo todo = todoItems.CreateTodo(someTodoDesc);
            todo.Assignee = person;

            Todo.Model.Todo todo2 = todoItems.CreateTodo(someTodoDesc);
            todo2.Assignee = person;

            // unAssigned todo
            todoItems.CreateTodo(someTodoDesc);

            // assert: 2 of 3 todos assigned to this person
            var todoArr = todoItems.FindByAssignee(person.PersonId);
            Assert.Equal(2, todoArr.Length);
        }

        [Fact]
        public void FindByDoneStatus_whenGivenTodosWithAssigneePerson()
        {
            People people = new People();
            Person person = people.CreatePerson("first", "last");
            Todo.Model.Todo todo = todoItems.CreateTodo(someTodoDesc);
            todo.Assignee = person;

            Todo.Model.Todo todo2 = todoItems.CreateTodo(someTodoDesc);
            todo2.Assignee = person;

            // unAssigned todo
            todoItems.CreateTodo(someTodoDesc);
            todoItems.CreateTodo(someTodoDesc);

            // assert: 2 of 4 todos assigned to this person
            var todoArr = todoItems.FindByAssignee(person);
            Assert.Equal(2, todoArr.Length);
        }

        [Fact]
        public void FindByDoneStatus_whenGivenSomeUnassignedTodos()
        {
            People people = new People();
            Person person = people.CreatePerson("first", "last");

            todoItems.CreateTodo(someTodoDesc); // first

            Todo.Model.Todo todo = todoItems.CreateTodo(someTodoDesc);
            todo.Assignee = person;

            Todo.Model.Todo todo2 = todoItems.CreateTodo(someTodoDesc);
            todo2.Assignee = person;

            // 2 more unAssigned todos
            
            todoItems.CreateTodo(someTodoDesc);
            todoItems.CreateTodo(someTodoDesc);

            // assert: 3 of 5 todos unassigned
            var todoArr = todoItems.FindUnassignedTodoItems();
            Assert.Equal(3, todoArr.Length);
        }
    }
}
