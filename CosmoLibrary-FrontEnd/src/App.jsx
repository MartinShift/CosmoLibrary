import { BrowserRouter as Router, Route, Link, Routes } from 'react-router-dom';
import BookList from './components/BookList';
import AuthorList from './components/AuthorList';
import AddBook from './components/AddBook';
import AddAuthor from './components/AddAuthor';
import EditAuthor from './components/EditAuthor';
import BookDetails from './components/BookDetails';

function App() {
  return (
    <Router>
      <div className="p-6">
        <nav className="flex justify-between items-center mb-6">
          <div className="text-2xl font-bold">CosmoLibrary</div>
          <div>
            <Link to="/books" className="mr-4 text-blue-500 hover:text-blue-800">Books</Link>
            <Link to="/authors" className="text-blue-500 hover:text-blue-800">Authors</Link>
          </div>
        </nav>

        <Routes>
          <Route path="/books" element={<BookList />} />
          <Route path="/authors" element={<AuthorList />} />
          <Route path="/add-book" element={<AddBook />} />
          <Route path="/add-author" element={<AddAuthor />} />
          <Route path="/edit-author/:id" element={<EditAuthor />} />
          <Route path='/books/:id' element={<BookDetails/>} />
          <Route path="*" element={<h1>Welcome</h1>} />
        </Routes>
      </div>
    </Router>
  );
}

export default App;