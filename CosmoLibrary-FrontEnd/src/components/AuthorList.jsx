import { useState, useEffect } from 'react';
import { useNavigate } from 'react-router-dom';
import AuthorService from '../services/AuthorService';
import Swal from 'sweetalert2';
function AuthorList() {
  const [authors, setAuthors] = useState([]);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchAuthors = async () => {
      try {
        const data = await AuthorService.getAuthors();
        setAuthors(data);
      } catch (error) {
        console.error('Error fetching authors', error);
      }
    };

    fetchAuthors();
  }, []);

  const handleAdd = () => {
    navigate('/add-author');
  };

  const handleEdit = (authorId) => {
    navigate(`/edit-author/${authorId}`);
  };

  const handleDelete = (authorId) => {
    Swal.fire({
      title: 'Are you sure?',
      text: "You won't be able to revert this!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Yes, delete it!'
    }).then(async (result) => {
      if (result.isConfirmed) {
        try {
          await AuthorService.deleteAuthor(authorId);
          setAuthors(authors.filter(author => author.id !== authorId));
          Swal.fire(
            'Deleted!',
            'The author has been deleted.',
            'success'
          );
        } catch (error) {
          console.error('Error deleting author', error);
          Swal.fire(
            'Failed!',
            'There was an error deleting the author.',
            'error'
          );
        }
      }
    });
  };

  return (
    <div className="space-y-4">
      <button onClick={handleAdd} className="bg-blue-500 text-white p-2 rounded mb-4">Add Author</button>
      {authors && authors.map((author) => (
        <div key={author.id} className="p-4 border rounded space-y-2">
          <h2 className="font-bold">{author.firstName} {author.lastName}</h2>
          <div>
            <button onClick={() => handleEdit(author.id)} className="bg-blue-500 text-white p-2 rounded mr-2">Edit</button>
            <button onClick={() => handleDelete(author.id)} className="bg-red-500 text-white p-2 rounded">Delete</button>
          </div>
        </div>
      ))}
    </div>
  );
}

export default AuthorList;