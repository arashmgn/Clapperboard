import type { Metadata } from "next";
import { SessionProvider } from "@/lib/api";
import "./globals.css";

export const metadata: Metadata = {
  title: { template: "%s · Clapperboard", default: "Clapperboard" },
  description: "Browse movies and series, rate them and join the discussion.",
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="en">
      <body>
        <SessionProvider>{children}</SessionProvider>
      </body>
    </html>
  );
}
