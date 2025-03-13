import { useQuery } from "@tanstack/react-query";

export const useGenresQuery = () => {
  return useQuery<Genre[]>({
    queryKey: ["getBooksQuery"],
    staleTime: 1000*60*10,

    queryFn: async () => {
      const response = await fetch("https://localhost:7156/genres");
      return await response.json();
    },
  });
};
