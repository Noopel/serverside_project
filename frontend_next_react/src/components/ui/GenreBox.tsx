import Link from 'next/link'
import React from 'react'

const GenreBox = ({genreData}: {genreData: Genre}) => {
  return (
    <Link href={"/genres/"+genreData.id} className='w-[30%] aspect-[2/1] flex justify-end items-end hover:shadow-2xl transition-all' style={{backgroundColor: genreData.color}}>
        <h4 className='font-bold text-3xl mb-2 me-2 uppercase'>{genreData.name}</h4>
    </Link>
  )
}

export default GenreBox