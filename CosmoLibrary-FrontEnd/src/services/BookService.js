import axios from 'axios';

const API_URL = 'https://localhost:7044/books';

class BookService {
  static async getBooks() {
    try {
      const response = await axios.get(API_URL);
      return response.data;
    } catch (error) {
      console.error('Error fetching books', error);
      throw error;
    }
  }

  static async getBook(id) {
    try {
      const response = await axios.get(`${API_URL}/${id}`);
      return response.data;
    } catch (error) {
      console.error(`Error fetching book with id ${id}`, error);
      throw error;
    }
  }

  static async createBook(book) {
    try {
      const response = await axios.post(API_URL, book, {
        headers: {
          'Content-Type': 'application/json'
        }
      });
  
      return response.data;
    } catch (error) {
      console.error('Error creating book', error);
      throw error;
    }
  }

  static async updateBook(bookId, book) {
    try {
      const response = await axios.put(`${API_URL}/${bookId}`, book, {
        headers: {
          'Content-Type': 'application/json'
        }
      });
  
      return response.data;
    } catch (error) {
      console.error('Error updating book', error);
      throw error;
    }
  }

  static async deleteBook(id) {
    try {
      const response = await axios.delete(`${API_URL}/${id}`);
      return response.data;
    } catch (error) {
      console.error(`Error deleting book with id ${id}`, error);
      throw error;
    }
  }

  static async getBookAuthors(bookId) {
    try {
      const response = await axios.get(`${API_URL}/${bookId}/authors`);
      return response.data;
    } catch (error) {
      console.error(`Error fetching authors for book with id ${bookId}`, error);
      throw error;
    }
  }
}

export default BookService;