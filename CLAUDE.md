# Clapperboard: working mode

Learning project. Goal: migrate the old layered IMDB-style WebAPI to Clean Architecture + tactical DDD + MediatR.
Solution: `Clapperboard.sln` (net8.0, SQL Server, ASP.NET Identity + JWT).
A finished reference version exists elsewhere (separate repo, built for a portfolio). This repo is the step-by-step learning version: do not copy from the reference, migrate gradually.
Full status and ordered next steps are in `MIGRATION-NEXT-STEPS.md`.

## Working mode

- The developer types the code himself. Explain one step at a time, show code, wait for confirmation. Only edit files directly when asked.
- Talk in Persian. Do not use bullet or numbered lists in replies. Every line of a Persian reply starts with the marker `آ)`.
- Keep the build green where possible. The solution does NOT fully build right now (see `MIGRATION-NEXT-STEPS.md`).

## Target layout and dependency rule

- `Domain/` (IMDB.Domain): entities, value objects, enums. No packages ideally.
- `Application/` (IMDB.Application): use cases (MediatR), interfaces such as `IIdentityService` and repository interfaces. References Domain.
- `Infrastructure/` (IMDB.Infrastructure): EF Core `ApplicationDbContext`, `AppUser` (Identity), `IdentityService`, repository implementations, migrations. References Application.
- `api/` (IMDB.WebAPI): controllers, DTOs, DI wiring. References Application and Infrastructure.
- Dependency direction: api -> Infrastructure -> Application -> Domain.

## Decisions already made

- Keep existing repositories (`IRepository` / `Repository`), migrate gradually. MediatR is piloted on Genre first (queries, then commands), then the pattern is copied to other entities. Handlers return domain objects or DTOs, not `IActionResult`. Controllers keep their try/catch for now.
- `AppUser` lives in Infrastructure. Domain entities only hold a string `UserId`. Usernames come from `IIdentityService`.
- Score is a plain `int` (1..5), validated in the domain and by `[Range(1, 5)]` on the request DTO.
- `Movie` and `Series` are separate aggregate roots sharing the `MediaInfo` value object. `Season` and `Episode` live inside the `Series` aggregate.
- `Comment`, `Rate` and `Cast` are their own aggregate roots pointing at their target by `TargetType` + `TargetId`, with no navigation property and no foreign key.
- Domain base types: `BaseEntity` and `AggregateRoot : BaseEntity`. `Repository<T>` is constrained to `AggregateRoot`.
- Repository interfaces move from Domain to `Application/Common/Interfaces`.
