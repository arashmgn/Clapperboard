// Shapes of the DTOs exposed by the Clapperboard API (Application/Dtos).

export interface Genre { id: string; title: string }

export interface Movie {
  id: string; imdbId: string; title: string; releaseDate: string; description: string;
  duration: number; genres: Genre[]; posterUrl: string; rate: number;
}

export interface Series {
  id: string; imdbId: string; title: string; releaseDate: string; description: string;
  genres: Genre[]; posterUrl: string; rate: number;
}

export interface Episode {
  id: string; imdbId: string; title: string; releaseDate: string; description: string;
  episodeNumber: number; durationMinutes: number | null; seasonId: string; posterUrl: string; rate: number;
}

export interface Season {
  id: string; imdbId: string; title: string; releaseDate: string; description: string;
  seasonNumber: number; episodesCount: number; seriesId: string; posterUrl: string; rate: number; episodes: Episode[];
}

export interface Person { id: string; imdbId: string; fullName: string; birthDate: string; bio: string | null; photoUrl: string }

export const CAST_ROLES = ["Actor", "Director", "Writer", "Producer", "Cinematographer", "Editor", "Composer", "SoundDepartment", "CostumeDesigner"] as const;
export type CastRole = (typeof CAST_ROLES)[number] | string;

export interface Cast { id: string; mediaId: string; personId: string; role: CastRole; person: Person | null }

export interface Comment { id: string; text: string; mediaId: string; userId: string; userName: string | null; createdOn: string; lastUpdatedOn: string }

export const SCORES = ["Zero", "One", "Two", "Three", "Four", "Five"] as const;
export interface Rate { id: string; mediaId: string; userId: string; userName: string | null; score: (typeof SCORES)[number] | string }

export interface NewUser { userName: string; email: string; token: string }

export type Media = Movie | Series;
