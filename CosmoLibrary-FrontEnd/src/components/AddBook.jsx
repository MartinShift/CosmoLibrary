import { useState, useEffect } from 'react';
import Select from 'react-select';
import BookService from '../services/BookService';
import AuthorService from '../services/AuthorService';
import ImageService from '../services/ImageService';
import { useNavigate } from 'react-router-dom';

function AddBook() {
  const [title, setTitle] = useState('');
  const [publisherName, setPublisherName] = useState('');
  const [country, setCountry] = useState('');
  const [city, setCity] = useState('');
  const [street, setStreet] = useState('');
  const [houseNumber, setHouseNumber] = useState('');
  const [publicationDate, setPublicationDate] = useState('');
  const [authorIds, setAuthorIds] = useState([]);
  const [authors, setAuthors] = useState([]);
  const [selectedAuthors, setSelectedAuthors] = useState([]);
  const [uploadedImage, setUploadedImage] = useState(null);
  const navigate = useNavigate();

  useEffect(() => {
    const fetchAuthors = async () => {
      try {
        const data = await AuthorService.getAuthors();
        setAuthors(data.map(author => ({ value: author.id, label: `${author.firstName} ${author.lastName}` })));
      } catch (error) {
        console.error('Error fetching authors', error);
      }
    };

    fetchAuthors();
  }, []);

  const handleAuthorChange = (selectedOptions) => {
    setSelectedAuthors(selectedOptions);
    setAuthorIds(selectedOptions.map(option => option.value));
  };


  const handleSubmit = async (event) => {
    event.preventDefault();

    try {
      const imageUrl = await ImageService.uploadImage(uploadedImage);
      const book = {
        book: {
          id : "",
          title: title,
          publisher: {
            id: "",
            name: publisherName,
            address: {
              id: "",
              country: country,
              city: city,
              street: street,
              houseNumber: houseNumber,
            },
          },
          publicationDate: publicationDate,
          imageUrl: imageUrl,
        },
        authorIds: authorIds,
      };

      console.log(book);

      await BookService.createBook(book);
      navigate('/books')
    } catch (error) {
      console.error('Error creating book', error);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="space-y-4">
      <div className="flex flex-col">
        <label className="font-bold mb-1">Title:</label>
        <input type="text" value={title} onChange={e => setTitle(e.target.value)} required className="border p-2 rounded" />
      </div>
      <div className="flex flex-col">
        <label className="font-bold mb-1">Publisher Name:</label>
        <input type="text" value={publisherName} onChange={e => setPublisherName(e.target.value)} required className="border p-2 rounded" />
      </div>
      <div className="flex flex-col">
        <label className="font-bold mb-1">Country:</label>
        <input type="text" value={country} onChange={e => setCountry(e.target.value)} required className="border p-2 rounded" />
      </div>
      <div className="flex flex-col">
        <label className="font-bold mb-1">City:</label>
        <input type="text" value={city} onChange={e => setCity(e.target.value)} required className="border p-2 rounded" />
      </div>
      <div className="flex flex-col">
        <label className="font-bold mb-1">Street:</label>
        <input type="text" value={street} onChange={e => setStreet(e.target.value)} required className="border p-2 rounded" />
      </div>
      <div className="flex flex-col">
        <label className="font-bold mb-1">House Number:</label>
        <input type="text" value={houseNumber} onChange={e => setHouseNumber(e.target.value)} required className="border p-2 rounded" />
      </div>
      <div className="flex flex-col">
        <label className="font-bold mb-1">Publication Date:</label>
        <input type="date" value={publicationDate} onChange={e => setPublicationDate(e.target.value)} required className="border p-2 rounded" />
      </div>
      <div className="flex flex-col">
        <label className="font-bold mb-1">Upload Image:</label>
        <input type="file" onChange={e => setUploadedImage(e.target.files[0])} required className="border p-2 rounded" />
      </div>
      <div className="flex flex-col">
        <label className="font-bold mb-1">Authors:</label>
        <Select
          isMulti
          options={authors}
          value={selectedAuthors}
          onChange={handleAuthorChange}
          className="border p-2 rounded"
        />
      </div>
      <button type="submit" className="bg-blue-500 text-white p-2 rounded">Add Book</button>
    </form>
  );
}

export default AddBook;