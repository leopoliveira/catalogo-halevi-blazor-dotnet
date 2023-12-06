import type { Metadata } from "next";
import { Roboto } from "next/font/google";
import "./globals.css";

const inter = Roboto({
  subsets: ["latin"],
  weight: ["100", "300", "400", "500", "700"],
});

export const metadata: Metadata = {
  title: "Catálogo Halevi",
  description:
    "Catálogo digital para os produtos vendidos por Halevi.",
};

export default function RootLayout({
  children,
}: {
  children: React.ReactNode;
}) {
  return (
    <html
      className="bg-slate-200"
      lang="pt-br">
      <body className={inter.className}>
        <div className="max-w-7xl mx-auto p-4 ">{children}</div>
      </body>
    </html>
  );
}
