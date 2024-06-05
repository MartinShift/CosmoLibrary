import { useState } from 'react';
import AuthorService from '../services/AuthorService';
import { useNavigate } from 'react-router-dom';

function AddAuthor() {
  const [firstName, setFirstName] = useState('');
  const [lastName, setLastName] = useState('');
  const navigate = useNavigate();
  const handleSubmit = async (event) => {
    event.preventDefault();

    const author = {
      firstName: firstName,
      lastName: lastName,
    };

    try {
      await AuthorService.createAuthor(author);
      navigate('/authors');
    } catch (error) {
      console.error('Error creating author', error);
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
      <button type="submit" className="bg-blue-500 text-white p-2 rounded">Add Author</button>
    </form>
  );
}

export default AddAuthor;