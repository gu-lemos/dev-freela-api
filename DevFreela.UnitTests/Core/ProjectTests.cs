using DevFreela.Core.Entities;
using DevFreela.Core.Enums;

namespace DevFreela.UnitTests.Core;
public class ProjectTests
{
    [Fact]
    public void ProjectIsPending_Cancel_Success()
    {
        // Arrange
        var project = new Project("Project Name", "Project Description", 1, 2, 1000);
        project.Start();

        // Act
        project.Cancel();

        // Assert
        Assert.Equal(ProjectStatusEnum.Cancelled, project.Status);
    }

    [Fact]
    public void ProjectIsInInvalidState_Cancel_ThrowsException()
    {
        // Arrange
        var project = new Project("Project Name", "Project Description", 1, 2, 1000);

        // Act & Assert
        Action? cancel = project.Cancel;
        var exception = Assert.Throws<InvalidOperationException>(cancel);

        Assert.Equal(Project.INVALID_STATE_MESSAGE, exception.Message);
    }

    [Fact]
    public void ProjectIsCreated_Start_Success()
    {
        // Arrange
        var project = new Project("Project Name", "Project Description", 1, 2, 1000);

        // Act
        project.Start();

        // Assert
        Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
        Assert.NotNull(project.StartedAt);
    }

    [Fact]
    public void ProjectIsInInvalidState_Start_ThrowsException()
    {
        // Arrange
        var project = new Project("Project Name", "Project Description", 1, 2, 1000);
        project.Start();

        // Act & Assert
        Action? start = project.Start;
        var exception = Assert.Throws<InvalidOperationException>(start);

        Assert.Equal(Project.INVALID_STATE_MESSAGE, exception.Message);
    }

    [Theory]
    [InlineData(ProjectStatusEnum.InProgress)]
    [InlineData(ProjectStatusEnum.PaymentPending)]
    public void ProjectIsInProgressOrPaymentPending_Complete_Success(ProjectStatusEnum status)
    {
        // Arrange
        var project = new Project("Project Name", "Project Description", 1, 2, 1000);

        project.Start();

        if (status == ProjectStatusEnum.PaymentPending)
            project.SetPaymentPending();

        // Act
        project.Complete();

        // Assert
        Assert.Equal(ProjectStatusEnum.Completed, project.Status);
        Assert.NotNull(project.CompletedAt);
    }

    [Fact]
    public void ProjectIsInInvalidState_Complete_ThrowsException()
    {
        // Arrange
        var project = new Project("Project Name", "Project Description", 1, 2, 1000);

        // Act & Assert
        Action? complete = project.Complete;
        var exception = Assert.Throws<InvalidOperationException>(complete);

        Assert.Equal(Project.INVALID_STATE_MESSAGE, exception.Message);
    }

    [Fact]
    public void ProjectIsInProgress_SetPaymentPending_Success()
    {
        // Arrange
        var project = new Project("Project Name", "Project Description", 1, 2, 1000);
        project.Start();

        // Act
        project.SetPaymentPending();

        // Assert
        Assert.Equal(ProjectStatusEnum.PaymentPending, project.Status);
    }

    [Fact]
    public void ProjectIsInInvalidState_SetPaymentPending_ThrowsException()
    {
        // Arrange
        var project = new Project("Project Name", "Project Description", 1, 2, 1000);

        // Act & Assert
        Action? setPaymentPending = project.SetPaymentPending;
        var exception = Assert.Throws<InvalidOperationException>(setPaymentPending);

        Assert.Equal(Project.INVALID_STATE_MESSAGE, exception.Message);
    }

    [Fact]
    public void Project_Update_Success()
    {
        // Arrange
        var project = new Project("Project Name", "Project Description", 1, 2, 1000);

        // Act
        project.Update("Updated Project Name", "Updated Project Description", 1500);

        // Assert
        Assert.Equal("Updated Project Name", project.Title);
        Assert.Equal("Updated Project Description", project.Description);
        Assert.Equal(1500, project.TotalCost);
    }
}
