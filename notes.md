# Notes training Unit testing in Visual Studio

## Unittesten

Waarom?

- Programmeurs te irriteren?
- Bugs te voorkomen
  - Test-driven development
- Later geïntroduceerde bugs voorkomen
- Dat iemand anders niet jouw werk kapot maakt
- Wanneer je iets nieuws maakt/aanpast, dat het blijft werken
- Documenteren van je code

    "uitvoerbare documentatie"

- Beter dan het alternatief

90% - code coverage

## Verschillende testvormen

**Unittesten**
- specifiek gedeelte van de applicatie
- veeeeeel kleiner stuk
- geisoleerd
- duizenden tests

- feature vs method?
  - method
  - per method waarschijnlijke meerdere tests

Termen:
* Arrange-Act-Assert
* SUT: System Under Test

### Black box vs white box

black box
- inkomst/uitkomst, niks tussendoor

white box
- wel tussendoor
- internals zijn zichtbaar
- private
- je moet bekend zijn met al die internals
- afhankelijkheid

**Integratietesten**

- database
- API
- UI renderen
  - klikken op knoppen
- meerdere componenten en hun samenwerking

**End-to-end (UI) testen / ketentesten**
- klikken op knoppen
- de browser aan het automatiseren
- de eindgebruiker aan het simuleren


Ontwikkel-Test-Acceptatie-Productie

**Acceptatietesten**
- is de gebruiker/business er blij mee?

**Regressietesten**
- iets wat zomaar in de loop van de tijd stukgaat: regressie

monkey testing - fuzzing

## Testframeworks

- MSTest
- xUnit
- NUnit

```cs
[TestMethod]    // MSTest
[Fact]/[Theory] // xUnit attributes
[TestCase]      // NUnint
```

ZIjn de afgelopen jaren steeds meer naar elkaar toe gegroeid. xUnit/NUnit doen strings mooi printen als ze niet matchen.

Als je FluentAssertions gebruikt, maakt de keuze van testframework nog minder uit.

## JP's onofficiele lijst van wanneer je niet hoeft te testen:

- Als je de stagiaire/tester alle tests laat schrijven
- Als je je unittests genereert
- Als je x% code coverage probeert te halen
- Als je project < 6 maanden leeft

    let wel: "niets is zo permanent als een tijdelijke oplossing"

## Naming convention for test methods

- heel expliciet zeggen wat je doet, wat je verwacht,
- Methode die hij test
- Wat je meestuurt (state)
- Welke edge case
- DoThis_ShouldReturn
- ShouldReturn
- ShouldThrowException
- Feature
- Given/When/Then


## Mutation testing

Past je broncode aan:
```cs
if (x == 4) { } 
```

```cs
if (x == -4) { }
if (x > 4) { }
if (x < 4) { }
```

zogeheten mutaties/mutanten.

Tool: Stryker. Vernoemd naar William Stryker van X-Men

## Test-driven development

1. Schrijf een test
2. Run de test en zie dat hij faalt
3. Schrijf code (implementeer)
4. Run de test en zie dat hij slaagt
5. Refactor (code mooier maken)

Repeat.

"technical debt"
