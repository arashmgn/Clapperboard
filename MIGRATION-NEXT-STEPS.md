# Clapperboard: migration status and next steps

Learning project. Goal: migrate the old layered IMDB-style WebAPI to Clean Architecture + tactical DDD + MediatR.
Solution: `Clapperboard.sln` (net8.0, SQL Server, ASP.NET Identity + JWT).
A finished reference version exists elsewhere (separate repo, built for a portfolio). This repo is the step-by-step learning version: do not copy from the reference, migrate gradually.

## Working mode

- The developer types the code himself. Explain one step at a time, show code, wait for confirmation. Only edit files directly when asked.
- Talk in Persian. Do not use bullet or numbered lists in replies. Every line of a Persian reply starts with the marker `آ)`.
- Keep the build green where possible. The solution does NOT fully build right now (see below).

## Target layout and dependency rule

- `Domain/` (IMDB.Domain): entities, value objects, enums. No packages ideally.
- `Application/` (IMDB.Application): use cases (MediatR), interfaces such as `IIdentityService`. References Domain.
- `Infrastructure/` (IMDB.Infrastructure): EF Core `ApplicationDbContext`, `AppUser` (Identity), `IdentityService`, repository implementations, migrations. References Application.
- `api/` (IMDB.WebAPI): controllers, DTOs, DI wiring. References Application and Infrastructure.
- Dependency direction: api -> Infrastructure -> Application -> Domain.

## Decisions already made

- Keep existing repositories (`IRepository` / `Repository`), migrate gradually. MediatR is piloted on Genre first (queries, then commands), then the pattern is copied to other entities. Handlers return domain objects or DTOs, not `IActionResult`. Controllers keep their try/catch for now.
- `AppUser` lives in Infrastructure. Domain entities only hold a string `UserId`. Usernames come from `IIdentityService` (`GetUserNameAsync`, `GetUserNamesAsync`, already written in Application).
- Score is a plain `int` (1..5), validated in the domain (`Rate.Create` / `ChangeScore`) and by `[Range(1, 5)]` on the request DTO. `ScoreEnum` was removed.
- Movies, series, seasons and episodes are NOT a `Media` inheritance hierarchy anymore. `Reviewable` and `Media` were deleted.
  - `Movie` and `Series` are separate aggregate roots that share the `MediaInfo` value object (imdb id, title, description, poster, release date). `AverageRating` replaces the old `Rate` double.
  - `Season` and `Episode` are entities inside the `Series` aggregate. Created only via `Series.AddSeason` / `Series.AddEpisode` (internal constructors, read-only collections). They have no repository or controller of their own in the target design.
  - `Comment`, `Rate` and `Cast` are their own aggregate roots and point at their target by `TargetType` (`ReviewTargetType`: Movie, Series, Episode) + `TargetId`, with no navigation property and no foreign key. The handler must check that the target exists.
- Domain base types: `BaseEntity` (Id, protected set) and `AggregateRoot : BaseEntity`. `IEntity` was removed. `Repository<T>` is constrained to `AggregateRoot`.
- Genre and Person are aggregate roots with factory methods; their back-navigations were removed. Movie/Series own the many-to-many `Genres` collection.

## Current state (what compiles)

- `Domain` builds clean. `Application` builds clean.
- `Infrastructure`, `api` and `Tests` do NOT build yet: DbContext, repositories, mappers, DTOs and controllers still use the old model (Media, `MediaId`, `Season.ImdbId`, public setters, `AppUser` navigation, `Season`/`Episode` repositories).
- `api/Interfaces/IRepositories/IRepository.cs` (old copy, namespace `api.Interfaces.IRepositories`) is a leftover: delete it. The new one is `Domain/Repositories/IRepository.cs`.
- Open decision: move all repository interfaces (`IRepository<T>`, `IMovieRepository`, ...) from Domain to `Application/Common/Interfaces`, because MediatR handlers and `IIdentityService` live in Application. Recommended: yes, move them.
- The solution file was renamed to `Clapperboard.sln`; project names and namespaces are still `IMDB.*` (rename later, not now).
- `Domain/IMDB.Domain.csproj` still references `Microsoft.Extensions.Identity.Stores`, which is no longer needed: remove it.
- `appsettings*.json` contain dev-only placeholder secrets (SQL password, JWT key). Move them to environment variables or user-secrets before the repo is ever made public.

## Next steps, in order

1. Decide where repository interfaces live (see open decision) and delete the old `IRepository.cs` in `api`.
2. Clean `Infrastructure/AppUser.cs`: remove the `Comments` and `Rates` collections (Comment/Rate no longer reference the user).
3. Implement `IdentityService : IIdentityService` in Infrastructure using `UserManager<AppUser>`.
4. Write the new `ApplicationDbContext` in Infrastructure (move it from `api/Data`):
   - `OwnsOne(m => m.Info)` for Movie and Series (`MediaInfo`).
   - Series -> Seasons -> Episodes as owned/child collections with shadow foreign keys (`HasMany(...).WithOne().HasForeignKey("SeriesId")`), using the private backing fields.
   - Many-to-many Movie/Genres and Series/Genres.
   - Indexes on (`TargetType`, `TargetId`) for Comment, Rate and Cast. Remove the old TPT `ToTable("Media")` setup, the `Comment.Media` / `Rate.Media` relations, and the `Score` `HasConversion<double>()`.
   - `Cast.Role` stays stored as string.
   - `MigrationsAssembly` points to Infrastructure.
5. Move repository implementations to Infrastructure. Repositories only for aggregate roots (drop `SeasonRepository`, `EpisodeRepository`, `MediaRepository`; season/episode operations go through `Series`).
6. Fix `Clapperboard.sln` and `Tests/Tests.csproj` project references. Add DI wiring in `api/Program.cs`.
7. Register MediatR (`AddMediatR` in Program.cs; package v14.2.0 is already installed in `api`). Pilot on Genre: `GetGenresQuery`, `GetGenreByIdQuery`, then create/update/delete commands. Then copy the pattern to Movie, Series, Person, Comment, Rate, Cast.
8. Rewrite mappers and DTOs for the new model (`movie.Info.Title`, factories instead of `new X { ... }`). On comment/rate creation, check that the target exists.
9. Delete the old database and migrations and create a fresh initial migration (schema changed heavily).
10. Later DDD polish: `DomainException`, `Score` value object, Fluent API instead of data annotations, computed average rating, unit tests for aggregates.
