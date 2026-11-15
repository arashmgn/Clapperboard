# 🎬 Clapperboard

A movie and series catalogue. Browse titles, see cast, seasons and episodes, rate what you watched and join the discussion.

Built with an ASP.NET Core 10 Web API (Clean Architecture, DDD, CQRS with MediatR) and a Next.js frontend.

## Features

- Movies, series (with seasons and episodes), genres and people (cast)
- Ratings (one per user per title) and comments, editable only by their owner
- Registration and login with JWT, an `Admin` role for managing the catalogue
- Paged lists, a consistent `{ success, data, errors }` response envelope
- Swagger UI in development, a `/health` endpoint, automatic migrations and admin seeding at startup

## Tech stack

| Part | Technology |
| --- | --- |
| API | ASP.NET Core 10, MediatR 14, AutoMapper 17 |
| Data | EF Core 10, SQL Server, ASP.NET Core Identity |
| Auth | JWT bearer tokens |
| Frontend | Next.js 16, React 19, TypeScript |
| Tests | xUnit, EF Core InMemory |

## Project layout

```
Domain/          entities, value objects, domain rules (no dependencies)
Application/     use cases (MediatR commands and queries), DTOs, AutoMapper profile
Infrastructure/  EF Core + SQL Server, Identity, JWT, migrations, seeding
api/             controllers, auth wiring, error handling, Swagger
frontend/        Next.js app (reaches the API through an /api proxy)
Tests/           unit and handler tests
```

Dependencies point inwards: `api` → `Infrastructure` → `Application` → `Domain`.
Controllers stay thin: they send a command or query through MediatR and the response filter wraps the result.

## Prerequisites

- .NET 10 SDK
- SQL Server (LocalDB is enough on Windows; Docker works everywhere)
- Node.js 22 or newer, only for the frontend

## Quick start

### 1. API

```bash
dotnet run --project api --launch-profile http
```

The API listens on http://localhost:5000 and Swagger UI is at http://localhost:5000/swagger.
The development settings use LocalDB: the `Clapperboard` database is created, migrated and seeded on first start.

### 2. Frontend

```bash
cd frontend
cp .env.example .env.local
npm install
npm run dev
```

The site runs on http://localhost:3000. `BACKEND_URL` in `.env.local` points the `/api` proxy at the API.

### 3. Sign in as admin

The development admin comes from `Seed:*` in `api/appsettings.Development.json` (user `admin`, password `Admin#12345`).
It is for local development only; production values must come from environment variables.

## Run with Docker

```bash
cp env.example .env
docker compose up --build
```

| Service | URL |
| --- | --- |
| Web | http://localhost:3000 |
| API | http://localhost:5000 |
| SQL Server | localhost:1433 |

## API overview

Every response is wrapped: `{ "success": true, "data": ... }` on success and `{ "success": false, "errors": [...] }` on failure.
Reads are public. Writes need a bearer token from `POST /api/Account/login`.

| Area | Endpoints |
| --- | --- |
| Account | `POST /api/Account/register`, `POST /api/Account/login` |
| Genre, Movie, Series, Person | `GET` list, `GET paged`, `GET {id}`. Admin: `POST`, `PUT {id}`, `DELETE {id}` |
| Season | `GET /api/Season`, `GET /api/Season/{id}`. Admin management under `/api/Series/{id}/seasons[/{seasonId}/episodes]` |
| Cast | `GET /api/Cast/media/{mediaId}`. Admin: `POST /api/Cast/media/{mediaId}`, `PUT`, `DELETE` |
| Rate, Comment | `GET /api/{Rate,Comment}/media/{mediaId}`. Signed-in users: `POST .../media/{mediaId}`, `PUT {id}`, `DELETE {id}` (owner only) |

Status codes: `400` validation or duplicate, `401` not signed in, `403` not allowed, `404` not found.
The full contract is in Swagger, and `api/api.http` has ready-made requests.

## Configuration

Secrets are never committed. Settings use the standard .NET configuration, so environment variables use `__` as the separator.

| Setting | Purpose |
| --- | --- |
| `ConnectionStrings__DefaultConnection` | SQL Server connection string |
| `Jwt__SigningKey` | JWT signing key, at least 32 bytes (the API refuses to start without it) |
| `Jwt__Issuer`, `Jwt__Audience` | token issuer and audience |
| `Seed__AdminUserName`, `Seed__AdminEmail`, `Seed__AdminPassword` | admin created at startup if missing |
| `Database__MigrateOnStartup` | set to `false` to skip automatic migrations |

See `docker-compose.yaml` and `env.example` for a working set.

## Database migrations

```bash
dotnet tool restore
dotnet tool run dotnet-ef migrations add <Name> --project Infrastructure --startup-project api --output-dir Persistence/Migrations
```

Migrations are applied automatically at startup.

## Tests

```bash
dotnet test
```

Covers domain rules, the AutoMapper profile and the command and query handlers.
