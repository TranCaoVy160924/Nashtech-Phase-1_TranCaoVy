import axios from 'axios';
import * as yup from "yup";
const baseUrl = "https://localhost:7281/Category";

const getAllAsync = async () => {
   console.log("CategoryService_ axios get: ", baseUrl);
   const response = await axios.get(baseUrl);

   return response.data;
}

const getByIdAsync = async (id) => {
   let url = `${baseUrl}/${id}`;
   console.log("CategoryService_ axios get: ", url);
   const response = await axios.get(url);

   return response.data;
}

const updateAsync = async (patchCategory) => {
   console.log("CategoryService_ axios patch: ", baseUrl);
   const response = await axios.patch(baseUrl, patchCategory);

   return response.data;
}

const deleteAsync = async (id) => {
   let url = `${baseUrl}/${id}`;
   console.log("CategoryService_ axios delete: ", url);
   const response = await axios.delete(url);

   return response.data;
}

const categorySchema = yup.object({
   categoryImage: yup.mixed()
      .required("file is required"),
   categoryName: yup.string()
      .required("Name is required"),
}).required();

const exportObject = {
   getAllAsync,
   getByIdAsync,
   updateAsync,
   deleteAsync,
   categorySchema
};

export default exportObject