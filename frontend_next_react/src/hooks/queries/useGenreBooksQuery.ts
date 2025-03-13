import { useQuery } from "@tanstack/react-query";

export const useGenreBooksQuery = (genreId: number | string) => {
  return useQuery<{genre: Genre, books: Book[]}>({
    queryKey: ["genreBooksQuery"+genreId],
    staleTime: 1000*60*10,

    queryFn: async () => {
      const response = await fetch("https://localhost:7156/genres/books/"+genreId);
      return await response.json();
    },
  });
};
