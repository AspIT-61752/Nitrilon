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

**Aggregation: "Has a"**
