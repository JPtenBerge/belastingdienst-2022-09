# Notes ASP.NET Core with Razor Pages

## About

ASP.NET - 2002
- WebForms
- MVC - 2008
- .NET Framework, niet cross-platform
- serverside

ASP.NET Core - 2016
- MVC Model Controller - APIs
- Razor Pages (pagina-georienteerde)
- serverside


Blazor - webapplicatieframework
- meer het model van de razor pages
- razor pages met components
- server-side logica uitvoeren in client
- client-side
- WebAssembly (hello world = 7MB) / Server
  - 25kb
  - intranet

Project aanmaken:
- ASP.NET Core Empty - wat meer werk, maar je weet wel wat er gedaan wordt
- ASP.NET Core Web App - minder werk, veel wordt gedaan voor je
  - niet de MVC-variant
  - zonder security - geen auth - https is prima

## jQuery

voordelen jQuery:

- AJAX

    ```js
    $.getJSON('api/whatever').then(x => { });
    fetch('api/whatever').then(x => x.json()).then(x => { ... });
    ```

- DOM manipulatie
  - Daar zijn andere libraries simpelweg beter in/chiquer bij:
    - Angular
    - Svelte
    - Vue
    - React - facebook

- browserabstractie
  - IE6
    ```js
    var btn = document.getElementById('btn');
    if (btn.addEventListener) { // alle andere browser
        btn.addEventListener('click', function() {

        });
    }
    else { // IE 6 7 8
        btn.attachEvent('onclick', function() {

        });
    }

    $('#btn').click(function() {

    });
    ```