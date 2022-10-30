import axios from 'axios';
import * as yup from "yup";
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

const updateAsync = async (patchProduct) => {
   let id = patchProduct.productId
   console.log("ProductService_ axios patch: ", `${baseUrl}/${id}`);
   const response = await axios.patch(`${baseUrl}/${id}`, patchProduct);

   return response.data;
}

const addAsync = async (newProduct) => {
   console.log("ProductService_ axios post: ", `${baseUrl}`);
   const response = await axios.post(`${baseUrl}`, newProduct); 

   return response.data;
}

const deleteAsync = async (id) => {
   console.log("ProductService_ axios delete: ", `${baseUrl}/${id}`);
   const response = await axios.delete(`${baseUrl}/${id}`);

   return response.data;
}

const productSchema = yup.object({
   productImage: yup.mixed()
      .required("file is required"),
   productCategory: yup.number()
      .positive("Category is required"),
   productName: yup.string()
      .required("Name is required"),
   productPrice: yup.number()
      .typeError("Price must be a number")
      .positive("Price must be positive")
      .required("Price is required"),
   numberInStorage: yup.number()
      .typeError("Number in storage  must be a number")
      .min(0, "Number in storage must be positive")
      .required("Number in storage is required"),
   description: yup.string()
      .required("Description is required"),
}).required();

const exportObject = {
   getAllAsync,
   getByIdAsync,
   updateAsync,
   addAsync,
   deleteAsync,
   productSchema
};



export default exportObject