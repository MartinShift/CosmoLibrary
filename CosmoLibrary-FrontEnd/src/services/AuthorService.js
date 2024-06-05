import axios from 'axios';

const API_URL = 'https://localhost:7044/authors';

class AuthorService {
  static async getAuthors() {
    try {
      const response = await axios.get(API_URL);
      return response.data;
    } catch (error) {
      console.error('Error fetching authors', error);
      throw error;
    }
  }

  static async getAuthor(id) {
    try {
      const response = await axios.get(`${API_URL}/${id}`);
      return response.data;
    } catch (error) {
      console.error(`Error fetching author with id ${id}`, error);
      throw error;
    }
  }

  static async createAuthor(author) {
    try {
      const response = await axios.post(API_URL, author);
      return response.data;
    } catch (error) {
      console.error('Error creating author', error);
      throw error;
    }
  }

  static async updateAuthor(id, author) {
    try {
      const response = await axios.put(`${API_URL}/${id}`, author);
      return response.data;
    } catch (error) {
      console.error(`Error updating author with id ${id}`, error);
      throw error;
    }
  }

  static async deleteAuthor(id) {
    try {
      const response = await axios.delete(`${API_URL}/${id}`);
      return response.data;
    } catch (error) {
      console.error(`Error deleting author with id ${id}`, error);
      throw error;
    }
  }
}

export default AuthorService;