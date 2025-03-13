import type { Metadata } from "next";
import "./globals.css";
import ReactQueryClientProvider from "@/components/query/ReactQueryClientProvider";

export const metadata: Metadata = {
  title: "Library of Books",
  description: "A library of books",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <ReactQueryClientProvider>
      <html lang="en">{children}</html>
    </ReactQueryClientProvider>
  );
}
