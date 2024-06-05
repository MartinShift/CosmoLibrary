import axios from "axios";

const API_URL = 'https://localhost:7044/images';

class ImageService {    
    
    static async uploadImage(image) {
        try {
          const formData = new FormData();
          formData.append('image', image);
      
          const response = await axios.post(API_URL, formData, {
            headers: {
              'Content-Type': 'multipart/form-data'
            }
          });
      
          return response.data;
        } catch (error) {
          console.error('Error uploading image', error);
          throw error;
        }
      }
}
export default ImageService;