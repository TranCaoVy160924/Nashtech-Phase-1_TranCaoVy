import axios from 'axios';
const baseUrl = "https://localhost:7281/Category";

const getAllAsync = async () => {
   const response = await axios.get(baseUrl);
   const categories = response.data;

   console.log(categories)
   return categories;
}

const exportObject = {
   getAllAsync
};

export default exportObject