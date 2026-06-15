## Documentatie

Deze applicatie is gebouwd voor het uitwisselen van zorginformatie tussen twee partijen. In de voorbeeldsituatie verwijst Ziekenhuis A een patiënt door naar Verpleeghuis B. Bij deze verwijzing kunnen documenten worden gedeeld, zoals een verwijsbrief, allergie-informatie en later medicatie-informatie.

De belangrijkste entity in de applicatie is `Referral`. Een referral bevat de patiëntgegevens, de verzendende organisatie en de ontvangende organisatie. Aan een referral kunnen meerdere documenten worden gekoppeld.

Documenten worden in deze applicatie opgeslagen als database records met een type, titel en inhoud. Een document kan bijvoorbeeld het type `ReferralLetter`, `AllergyInformation` of `MedicationInformation` hebben.

Medicatiegegevens zijn geen aparte entity. Medicatie-informatie wordt opgeslagen als een document met het type `MedicationInformation`. Hierdoor blijft het datamodel klein en past het beter bij de scope van de opdracht.

Wanneer informatie wordt gedeeld of opgevraagd, wordt dit vastgelegd in `ExchangeLog`. Deze audit log laat zien welke informatie is uitgewisseld, bij welke verwijzing dit hoort en wanneer dit is gebeurd. Bijvoorbeeld wanneer Ziekenhuis A een verwijsbrief deelt of wanneer Verpleeghuis B medicatie-informatie opvraagt.

De API gebruikt DTO’s voor request en response data. Hierdoor worden de database entities niet direct gebruikt als input of output van de endpoints. De controllers roepen services aan, en de services gebruiken repositories voor database-acties. Dit houdt de code beter gescheiden en makkelijker te onderhouden.

De applicatie bevat validatie op verplichte velden. Als een referral niet bestaat, geeft de API een `404 Not Found` terug. Bij ongeldige input geeft de API een `400 Bad Request` terug.

De volgende API endpoints zijn beschikbaar:

| Method | Endpoint                                 | Beschrijving                                                                                 |
| ------ | ---------------------------------------- |----------------------------------------------------------------------------------------------|
| POST   | `/api/referrals`                         | Maakt een nieuwe verwijzing aan                                                              |
| GET    | `/api/referrals`                         | Haalt alle verwijzingen op                                                                   |
| GET    | `/api/referrals/{id}`                    | Haalt één verwijzing op                                                                      |
| POST   | `/api/referrals/{id}/documents`          | Voegt een document toe aan een verwijzing                                                    |
| GET    | `/api/referrals/{id}/documents`          | Haalt documenten van een verwijzing op                                                       |
| POST   | `/api/referrals/{id}/medication-request` | Vraag medicatiedocumenten op (voor nu wordt er alleen gelogd dat er informatie is opgevraagd). |
| GET    | `/api/exchange-logs`                     | Haalt de audit logs op                                                                       |
