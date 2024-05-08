# Casen Præsentation:

- Start med en kort beskrivelse af casen og dens ønskede funktionalitet.
- Forklar hvilke problemer systemet sigter mod at løse og dets overordnede formål.

# Systemudviklingsværktøjer:

- Beskriv den valgte systemudviklingsmetode, som er agil og iterativ.
- Forklar de forskellige faser: Inception, Elaboration, Construction og Testing.
  - Inception: Kunden giver os en forklaring af hvad de vil have. Vi omskriver det til krav specifikationer (**IKKE Design valg**).
  - Elaboration: Her finder vi alle de entities der kan være, hvorefter vi filtrere dem en efter en (Vi brugte Tillægsord og navneord. Kan ikke huske hvad det var)
  - Construction: Her går vi i gang med at løse opgaven. Så få database, klasser og filer op og køre ud fra den analyse og de diagrammer vi lavede tidligere.
  - Testing: Det har vi ikke været så meget inde under, ud over SWAGGER og når vi skulle teste en ny feature eller teste UI.
- **Inception:** Identificer krav gennem interviews, workshops osv. Et godt krav er klart, specifikt, målbart og realistisk.
- **Elaboration:** Fra identificerede krav til en mere detaljeret forståelse og planlægning af systemet. Brug af værktøjer som analyse- og design-diagrammer.
- Vis projektstyring på GitHub og hvordan issues håndteres.

- Fandt ud af vi mangler at kunne tilføje et nyt event
  - Kunden mangler en måde at kunne tilføje, redigere og fjerne events.

# UI/UX og Funktionaliteter:

- Vis eksempler på UI og hvordan det interagerer med de bagvedliggende systemkomponenter.
- Gennemgå de funktionelle krav og hvordan de implementeres i UI'et.

# Construction:

- Forklar et klient-server system og dets komponenter.
- Beskriv kommunikationen mellem klienten og serveren ved brug af HTTP-metoder og JSON.
- Demonstrer arkitektur med Separation of Concerns og modulær opbygning.
- Gennemgå API-design, herunder endpoints og rollen af IIS.

- IIS er som en vært for hjemmesider på internettet. Det tager imod anmodninger fra folk, der vil besøge disse hjemmesider, og viser dem det rigtige indhold. Det sørger for, at internettet fungerer godt, ligesom en vært sørger for, at gæsterne har det godt til en fest.
  - Tog: Sørger for at dem der skal til Vejle fra Fredericia kan stige på ved spor 3, og komme til vejle kl 8:28
- Forklar Data Access gennem Repository designmønster.
- Diskuter OOP-principper som indkapsling, komposition/aggregation og arv og hvordan de anvendes i systemet.

## Keywords

- **Aggregation:** "Has a"
- **Composition/Komposition:** "Part of"
- **Encapsulation/Indkapsling:** Making sure "outsiders" can't access and mutate the values directly. Meaning our private fields (i.e. the variables) cannot be modified without our "approval". If they want to access or modify the variables themselves they have to go through our **properties** (like a public methods). Our private field: `private int id` cannot be accessed directly from outside the class. Public property: `public int Id` gives us controlled access to `id` with the Getter and Setter (Setter sets the value of `id` after checking a/multiple conditions).
- **Encapsulation/Indkapsling SUMMARY:** 1. Internal state is hidden from direct external access. 2. Access is mediated through methods or properties, which can (And should) implement validation or other logic. 3. Data integrity is maintained by preventing improper settings of field values.
  **Controlling access to components of an object**
- **Inheritance/Arv:** Something is something else (Is a Volkswagen ID.4 a Car. In this example the Car is the base-class)

## Other

- Class: The structure of which objects are created from. Think of it as our DNA strings (It tells you how you should be created, look and all of that) and the object as YOU.
- Objects: An instance of a class. It represents a specific example of THE class where the class's methods and properties have been initialized and are ready to be used. (Think of this as a bunch of crows, every crow is a crow, but this specific crow is not the same crow as the one next to it)
- State: The state of the object is all of its property values and fields at any given time. This state can change as methods modify the properties or fields.
- Members: Members of a class is stuff like fields, properties, methods and events. More or less, members are all the components that makes up the class.
- Fields: Fields are variables of any type that are declared directly in a class. Fields usually store the data that can be accessed by class either public or private methods.
- Constructors: The method being called when an instance of the class is created. Usually used to initialize fields, set default values, etc.
- Properties: Properties gives us a flexible way to read, write, or compute values of private fields. Properties can include a Get and a Set method, which provide controlled access to the fields.
- Separation of concerns: A design princaple for separating a program into distinct sections/components so that each section/component addresses a specific concern (This thing only does this one thing. It's not a god class). This makes it more manageable (overskueligt), easier to find errors and maintain.
- Architecture: Architecture in software development refers to the overall structure of the software and the ways in which that structure provides conceptual integrity for a system. It includes the main components of the system, their relationships, and the guidelines governing their design and evolution over time.
- Data Format: Data format refers to the specific structure of how data is stored, processed, and transmitted, such as JSON, XML, or CSV.
- HTTP: HTTP (Hypertext Transfer Protocol) is the protocol used for transmitting web pages over the Internet. It defines how messages are formatted and transmitted, and how web servers and browsers should respond to various commands.
- REST: REST (Representational State Transfer) is an architectural style used in web development for creating networked applications. It relies on a stateless, client-server, cacheable communications protocol -- the HTTP.
- JSON: (JavaScript Object Notation), it's a format that's lightweight and easy for humans to read and write. often used for transmitting data in web applications between clients and servers.
- API: An API (Application Programming Interface) is a set of rules that allows different software entities to communicate with each other. APIs simplify software development and innovation by enabling applications to exchange data and functionality easily and securely.
- Controller: In MVC architecture, a controller is responsible for handling incoming requests, manipulating data through models, and sending data to the view to be rendered as a web page.
- Parameter and Argument: `void PrintMsg(string msg)` msg is a paramater. While an argument is `PrintMsg("I'm the argument");` "I'm the argument".
- CRUD: Create, Read, Update, Delete.
- Accesmodifires: Protected - like a private variable or function but only inheritance (FIX THIS SENTENCE LATER).
