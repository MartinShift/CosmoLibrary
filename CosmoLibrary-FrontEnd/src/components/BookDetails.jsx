import { useState, useEffect } from 'react';
import BookService from '../services/BookService';
import { useParams } from 'react-router-dom';
import Swal from 'sweetalert2';
import { useNavigate } from 'react-router-dom';

const BookDetails = () => {
  const [book, setBook] = useState(null);
  const [authors, setAuthors] = useState([]);
  const { id } = useParams();
    const navigate = useNavigate();

  useEffect(() => {
    const fetchBook = async () => {
      try {
        const fetchedBook = await BookService.getBook(id);
        console.log(fetchedBook);
        setBook(fetchedBook);
      } catch (error) {
        console.error('Error fetching book', error);
      }
    };

    const fetchAuthors = async () => {
      try {
        const fetchedAuthors = await BookService.getBookAuthors(id);
        setAuthors(fetchedAuthors);
      } catch (error) {
        console.error('Error fetching authors', error);
      }
    };

    fetchBook();
    fetchAuthors();
  }, [id]);

  
  const handleEdit = (bookId) => {
    console.log(`Editing book with ID: ${bookId}`);
  };

  const handleDelete = async (bookId) => {
    const result = await Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this book!',
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'Yes, delete it!',
      cancelButtonText: 'No, keep it'
    });
  
    if (result.value) {
      try {
        await BookService.deleteBook(bookId);
        Swal.fire('Deleted!', 'Your book has been deleted.', 'success');
        navigate('/books')
      } catch (error) {
        Swal.fire('Error!', 'There was an error deleting this book.', 'error');
      }
    }
  };
  if (!book) {
    return <div>Loading...</div>;
  }

  return (
    <div className="p-6 bg-white shadow-md rounded-lg">
      <h1 className="text-2xl font-bold mb-2">{book.title}</h1>
      <img className="w-full h-64 object-cover mb-6" src={book.imageUrl} alt={book.title} />
      <p className="mb-2"><strong>Publisher:</strong> {book.publisher.name}</p>
      <p className="mb-2"><strong>Publication Date:</strong> {book.publicationDate}</p>
      <p className="mb-2"><strong>Address:</strong> {book.publisher.address.street}, {book.publisher.address.houseNumber}, {book.publisher.address.city}, {book.publisher.address.country}</p>
      <h2 className="text-xl font-bold mb-2">Authors</h2>
      <ul>
        {authors.map(author => (
          <li key={author.id} className="mb-1">{author.firstName} {author.lastName}</li>
        ))}
      </ul>
      <button onClick={handleEdit}  className="mr-2 bg-blue-500 hover:bg-blue-700 text-white font-bold py-1 px-2 rounded">
              Edit
            </button>
            <button onClick={() => handleDelete(book.id)}  className="bg-red-500 hover:bg-red-700 text-white font-bold py-1 px-2 rounded">
              Delete
            </button>
    </div>

    
  );
};

export default BookDetails;