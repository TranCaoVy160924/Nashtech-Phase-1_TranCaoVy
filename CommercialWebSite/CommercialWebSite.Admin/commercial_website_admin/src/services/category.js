import api from './api';
import * as yup from "yup";
const baseUrl = "https://localhost:7281/Category";

const getAllAsync = async () => {
   console.log("CategoryService_ axios get: ", baseUrl);
   const response = await api.get(baseUrl);

   return response.data;
}

const getByIdAsync = async (id) => {
   let url = `${baseUrl}/${id}`;
   console.log("CategoryService_ axios get: ", url);
   const response = await api.get(url);

   return response.data;
}

const updateAsync = async (patchCategory) => {
   console.log("CategoryService_ axios patch: ", baseUrl);
   const response = await api.patch(baseUrl, patchCategory);

   return response.data;
}

const deleteAsync = async (id) => {
   let url = `${baseUrl}/${id}`;
   console.log("CategoryService_ axios delete: ", url);
   const response = await api.delete(url);

   return response.data;
}

const addAsync = async (newProduct) => {
   let url = baseUrl;
   console.log("CategoryService_ axios post: ", url);
   const response = await api.post(url, newProduct);

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
   addAsync,
   categorySchema
};

export default exportObject