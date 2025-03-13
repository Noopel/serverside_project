"use client"
import Container from "@/components/ui/Container";
import GenreBox from "@/components/ui/GenreBox";
import { useGenresQuery } from "@/hooks/queries/useGenresQuery";

const Home = () => {
  const {isLoading, data, isError, error} = useGenresQuery();
  
  return (
    <main>
      <Container className="flex gap-8 flex-wrap my-12">
        {data && data.map(genreData => <GenreBox key={genreData.id} genreData={genreData} />)}
      </Container>
     
    </main>
  );
};

export default Home;
