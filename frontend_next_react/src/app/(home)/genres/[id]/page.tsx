"use client"
import BookSection from '@/components/ui/BookSection';
import Container from '@/components/ui/Container'
import { useGenreBooksQuery } from '@/hooks/queries/useGenreBooksQuery';
import React, { use } from 'react'

const GenreBooksPage = ({params}: {params: Promise<{id: string}>}) => {
    const {id} = use(params);

    const {isLoading, data, isError, error} = useGenreBooksQuery(id);


  return (
    <main className='relative'>
    {
        data && <div className='w-[12%] h-16 flex justify-end items-end absolute ' style={{backgroundColor: data.genre.color}}>
            <p className='font-bold uppercase me-2 mb-0'> {data.genre.name}</p>
        </div>
    }
      <Container className="flex gap-8 flex-wrap my-12 pt-8 flex-col">
        {data && data.books.map(bookData => <BookSection key={bookData.id} bookData={bookData} />)}
      </Container>
     
    </main>
  )
}

export default GenreBooksPage