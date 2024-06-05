import { useEffect, useState } from 'react';
import BookService from '../services/BookService';
import { useNavigate } from 'react-router-dom';

function BookList() {
    const [books, setBooks] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchBooks = async () => {
      try {
        const books = await BookService.getBooks();
        console.log(books);
        setBooks(books);
      } catch (error) {
        console.error('Error fetching books', error);
      }
    };

    fetchBooks();
  }, []);

  const handleAdd = () => {
    navigate('/add-book');
  }

  const handleDetails = (bookId) => {
    navigate(`/books/${bookId}`);
  }

  return (
    <div>
      <button onClick={handleAdd} className="mb-4 bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded">
        Add
      </button>

      <div className="grid grid-cols-3 gap-4">
        {books.map((book) => (
          <div key={book.id} className="border p-4 rounded">
            <img onClick={() => handleDetails(book.id)} src={book.imageUrl} alt={book.title} className="mb-4" />
            <h2 onClick={() => handleDetails(book.id)} className="text-xl mb-2">{book.title}</h2>
            <p onClick={() => handleDetails(book.id)} className="mb-4">{book.author}</p>

            <button onClick={() => handleDetails(book.id)} className="mr-2 bg-blue-500 hover:bg-blue-700 text-white font-bold py-1 px-2 rounded">
              Details
            </button>
          </div>
        ))}
      </div>
    </div>
  );
}

export default BookList;