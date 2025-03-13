import React from 'react'

const BookSection = ({bookData}: {bookData: Book}) => {
  return (
    <section>
        <h4 className='text-2xl uppercase font-bold'>{bookData.title}</h4>
        <p className='uppercase'>{bookData.description}</p>
    </section>
  )
}

export default BookSection