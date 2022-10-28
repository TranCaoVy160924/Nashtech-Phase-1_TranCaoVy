import axios from 'axios';
const baseUrl = "https://localhost:7281/Product";

const getAllAsync = async () => {
   console.log("ProductService_ axios get: ", baseUrl);
   const response = await axios.get(baseUrl);
   const products = response.data;
   return products;
}

const getByIdAsync = async (id) => {
   console.log("ProductService_ axios get: ", `${baseUrl}/${id}`);
   const response = await axios.get(`${baseUrl}/${id}`);
   const product = response.data;
   return product;
}

const exportObject = {
   getAllAsync,
   getByIdAsync
};

export default exportObject