namespace ToDoAppTests;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.Controllers;
using ToDoApp.Models;

public class UnitTest1
{
    [Fact]
    public void AddValidTask()
    {   var mockSet = new Mock<DbSet<ToDo>>();
        var mockContext = new Mock<ToDoAppContext>();
        mockContext.Setup(t => t.ToDos).Returns(mockSet.Object);
        var mockController = new HomeController(mockContext.Object);
        mockController.Add(new ToDo { Description = "Test Task", DueDate = DateTime.Now, CategoryId = "work", StatusId = "open"});
        mockSet.Verify(t => t.Add(It.IsAny<ToDo>()), Times.Once());
        mockContext.Verify(t => t.SaveChanges(), Times.Once());
    }

    [Fact]
    public void AddInvalidTask(){

        var mockSet = new Mock<DbSet<ToDo>>();
        var mockContext = new Mock<ToDoAppContext>();
        mockContext.Setup(t => t.ToDos).Throws(new ArgumentNullException());
        var mockController = new HomeController(mockContext.Object);
        Assert.Throws<ArgumentNullException>(() => mockContext.Object.ToDos.Add(new ToDo{}));
    }


}