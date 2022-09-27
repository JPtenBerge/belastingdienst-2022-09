using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace DemoProject.Unittests;

[TestClass]
public class AutocompleterTest
{
    private List<string> _data;
    private Autocompleter _sut;
    private Mock<INavigateService> _mockNavigateService;

    [TestInitialize]
    public void Initialize()
    {
        _mockNavigateService = new Mock<INavigateService>();
        _data = new() { "Monitor", "Muis", "Afstandsbediening", "Flesje water", "Kopje koffie", "fluit" };
        _sut = new Autocompleter(_mockNavigateService.Object);
    }

    [TestMethod]
    public void Autocomplete_BasicQueryAndData_GiveSuggestions()
    {
        _sut.Query = "e";
        _sut.Data = _data;

        _sut.Autocomplete();

        Assert.AreEqual(3, _sut.Suggestions.Count);
        Assert.AreEqual(_data[2], _sut.Suggestions[0].Item);
        Assert.AreEqual(_data[3], _sut.Suggestions[1].Item);
        Assert.AreEqual(_data[4], _sut.Suggestions[2].Item);

        // Arrange-Act-Assert-Act-Assert is no-go
    }

    [TestMethod]
    public void Autocomplete_NothingFound_GiveEmptySuggestions()
    {
        _sut.Query = "qqqqq";
        _sut.Data = _data;

        _sut.Autocomplete();

        Assert.AreEqual(0, _sut.Suggestions.Count);
    }

    [TestMethod]
    public void Autocomplete_WithCapitalsInTheQuery_GiveSuggestionsCaseInsensitively()
    {
        _sut.Query = "Fl";
        _sut.Data = _data;

        _sut.Autocomplete();
        
        Assert.AreEqual(2, _sut.Suggestions.Count);
    }

    [TestMethod]
    public void Autocomplete_WithNoQuery_GiveEmptySuggestions()
    {
        _sut.Data = _data;
        _sut.Autocomplete();
        
        Assert.AreEqual(0, _sut.Suggestions.Count);
    }

    [TestMethod]
    public void NextSuggestion_WithNothingHighlighted_HighlightTheFirstItem()
    {
        _sut.NextSuggestion();
        _mockNavigateService.Verify(x => x.Next(It.IsAny<List<NavigableItem>>()));
    }
}