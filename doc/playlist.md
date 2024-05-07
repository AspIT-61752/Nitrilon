# PLAYLISTE TIL EKSAMEN

1. Præsenter casen (fordi så viser man at man har forstået hvad man skal lave). Det vil sige at man kort beskriver systemets ønskede funktionalitet aka. systembeskrivelsen.
   **NOTES: Nitrilon, rollespil forening, Nitricon event.
   Nitrilon skal bruge et system til at modtage ratings om deres nitricon oplevelse, og et system til at håndtere medlemmer og deres informationer og medlemskab.**

2. Præsentation af systemudviklingsværktøjer, herunder systemudviklingsmetoden og projektstyringen.

   - Systemudviklingsmetoden: **Agil og iterativ, inception, elaboration, construction, testing.** _Hvad er formålet med hver af disse?_
   - Inception: Hvordan har man lavet kravspec? Hvad er et godt krav?
     **NOTES: Tvetydigt, ingen bindeord, kort og præcist**
   - Elaboration: Hvordan kommer man fra Inception til Elaboration? Vi anvendte værktøjerne:
     - **"Find navneord" => Entiteter**
     - Lavede **analyse diagrammer (ER)**, hvad er relationerne mellem entiteterne.
     - Bagefter lavede vi design diagrammer, ER og UML.
   - Projekstyring på GitHub: **Vis github projektet og issues.**

3. Begynd at vise hvordan UI virker ift. de funktionelle krav.

4. Construction:
   - Hvad er et klient-server system?
   - UI/UX kode, hvordan kommunikerer klienten med serveren? **HTTP metoderne og JSON.**
   - Arkitektur med Separation of Concerns: Modulær opbygning med klassebiblioteker og applikationer.
   - API: **endpoint (IP + port) og IIS'ens rolle**
     - **Controllere og deres action methods, herunder URI'en**
   - Data Access: Repository design pattern.
   - Database: SQL + tabeller, kolonner, rækker, **PK, FK.**
   - OOP:
     - **Indkapsling:** Hvad er formålet og hvordan anvender man det? Eks.: Entities.
     - **Komposition/aggregation:** Hvad er formålet og hvordan anvender man det? Eks.: Entities.
     - **Arv:** Hvad er formålet og hvordan anvender man det? Eks.: DataAccess.
