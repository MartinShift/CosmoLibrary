import { useState, useEffect } from 'react';
import AuthorService from '../services/AuthorService';
import { useNavigate, useParams } from 'react-router-dom';

function EditAuthor() {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const navigate = useNavigate();
  const { id } = useParams();

  useEffect(() => {
    const fetchAuthor = async () => {
      try {
        const response = await AuthorService.getAuthor(id);
          setFirstName(response.firstName);
          setLastName(response.lastName);
      } catch (error) {
        console.error('Error fetching author', error);
      }
    };

    fetchAuthor();
  }, [id]);

  const handleSubmit = async (event) => {
    event.preventDefault();

    const author = {
      id: id,
      firstName: firstName,
      lastName: lastName,
    };

    try {
      await AuthorService.updateAuthor(id, author);
      navigate('/authors');
    } catch (error) {
      console.error('Error updating author', error);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-4">
      <div className="flex flex-col">
        <label className="font-bold mb-1">First Name:</label>
        <input type="text" value={firstName} onChange={e => setFirstName(e.target.value)} required className="border p-2 rounded" />
      </div>
      <div className="flex flex-col">
        <label className="font-bold mb-1">Last Name:</label>
        <input type="text" value={lastName} onChange={e => setLastName(e.target.value)} required className="border p-2 rounded" />
      </div>
      <button type="submit" className="bg-blue-500 text-white p-2 rounded">Update Author</button>
    </form>
  );
}

export default EditAuthor;