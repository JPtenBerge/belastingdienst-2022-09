using DemoProject;
using DemoProject.Entities;
using DemoProject.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;

namespace TestProject1;

public class IndexTest
{
    private Mock<IPersonRepository> _mockPersonRepo;
    private DemoProject.Pages.Index _sut;
    
    public IndexTest()
    {
        _mockPersonRepo = new Mock<IPersonRepository>();
        _sut = new DemoProject.Pages.Index(_mockPersonRepo.Object);
    }
    
    [Fact]
    public async Task OnPost_ValidModel_RepositoryCalledAndRedirect()
    {
        _sut.NewPerson = new PersonEntity();
        var result = await _sut.OnPostAsync();

        Assert.IsType<RedirectToPageResult>(result);
        _mockPersonRepo.Verify(x => x.AddAsync(It.IsAny<PersonEntity>()));
        _mockPersonRepo.Verify(x => x.GetAllAsync(), Times.Never());
    }
    
    [Fact]
    public async Task OnPost_InvalidModel_PersonRepositoryCalledForGetAndNoRedirect()
    {
        _sut.NewPerson = new PersonEntity();
        _sut.ModelState.AddModelError("q", "w"); // IsValid false
        var result = await _sut.OnPostAsync();

        Assert.IsType<PageResult>(result);
        _mockPersonRepo.Verify(x => x.AddAsync(It.IsAny<PersonEntity>()), Times.Never());
        _mockPersonRepo.Verify(x => x.GetAllAsync());
    }
}