# HealthcareDocuments

Simpele ASP.NET Core applicatie met Entity Framework Core en SQL Server.

## Benodigdheden

- Docker Desktop
- .NET SDK 10

Controleer je .NET versie met:

```powershell
dotnet --version
```

## Database

De SQL Server database draait via Docker Compose.

Het compose-bestand staat hier:

```text
HealthcareDocuments/Database/docker-compose.yml
```

Maak lokaal een `.env` bestand aan in dezelfde map (je kan het bestand '.env.example' gebruiken als voorbeeld)':

```text
HealthcareDocuments/Database/.env
```

Zet daarin:

```env
DBPASSWORD=JouwSterkeWachtwoordHier
```

Start SQL Server met:

```powershell
cd HealthcareDocuments\Database
docker compose up -d
```

## Connection string

De applicatie gebruikt EF Core met SQL Server. De connection string staat niet in `appsettings.json`, maar in user secrets.

Initialiseer user secrets:

```powershell
dotnet user-secrets init --project HealthcareDocuments
```

Zet daarna de connection string (Vervang `JouwSterkeWachtwoordHier` met je daadwerkelijke wachtwoord die in je `.env` staat):

```powershell
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost,1433;Database=HealthcareDocuments;User Id=sa;Password=JouwSterkeWachtwoordHier;TrustServerCertificate=True;Encrypt=True" --project HealthcareDocuments
```

## Entity Framework Core

Werk de database bij:

```powershell
dotnet ef database update --project HealthcareDocuments
```

## Applicatie starten

Vanaf de root van de repository:

```powershell
dotnet run --project HealthcareDocuments
```
