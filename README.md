# Clapperboard

A movie and series catalogue: browse titles, see cast and seasons, rate and comment.
ASP.NET Core 10 Web API (Clean Architecture, DDD, MediatR) with a Next.js frontend.

## Layout

```
Domain/          entities, value objects, domain rules (no dependencies)
Application/     use cases (MediatR commands and queries), DTOs, AutoMapper profile
Infrastructure/  EF Core + SQL Server, ASP.NET Identity, JWT, migrations, seeding
api/             controllers, auth wiring, error handling, Swagger
frontend/        Next.js app (talks to the API through a /api proxy)
Tests/           xunit tests
```

Dependencies point inwards: api -> Infrastructure -> Application -> Domain.

## Run locally (.NET 10 SDK)

The development settings use SQL Server LocalDB and create the database on first start.

```bash
dotnet run --project api --launch-profile http
```

The API listens on http://localhost:5000 (Swagger UI at `/swagger`).
Migrations are applied and the admin user from `Seed:*` in `api/appsettings.Development.json` is created at startup.

```bash
cd frontend
cp .env.example .env.local
npm install
npm run dev
```

The site is on http://localhost:3000. Sign in with the seeded admin to open the admin page.

## Run with Docker

```bash
cp env.example .env
docker compose up --build
```

Web: http://localhost:3000, API: http://localhost:5000, SQL Server: localhost:1433.

## API in short

Responses are wrapped as `{ "success": true, "data": ... }`; errors as `{ "success": false, "errors": [...] }`.

| Area | Endpoints |
| --- | --- |
| Account | `POST /api/Account/register`, `POST /api/Account/login` |
| Genre, Movie, Series, Person | `GET` list, `GET paged`, `GET {id}`; admin: `POST`, `PUT {id}`, `DELETE {id}` |
| Season | `GET /api/Season`, `GET /api/Season/{id}`; admin management under `/api/Series/{id}/seasons[/{seasonId}/episodes]` |
| Cast | `GET /api/Cast/media/{mediaId}`; admin: `POST /api/Cast/media/{mediaId}`, `PUT`, `DELETE` |
| Rate, Comment | `GET /api/{Rate,Comment}/media/{mediaId}`; signed in users: `POST .../media/{mediaId}`, `PUT {id}`, `DELETE {id}` (owner only) |

## Configuration

Secrets are never committed. In production set `ConnectionStrings__DefaultConnection`, `Jwt__SigningKey`
and the `Seed__Admin*` values as environment variables (see `docker-compose.yaml` and `env.example`).

## Tests

```bash
dotnet test
```
