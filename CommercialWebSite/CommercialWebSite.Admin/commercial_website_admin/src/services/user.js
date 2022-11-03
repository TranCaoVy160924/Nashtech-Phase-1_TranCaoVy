import api from './api';
const baseUrl = "https://localhost:7281/User";

const getAllAsync = async () => {
   console.log("UserService_ axios get: ", baseUrl);
   const response = await api.get(baseUrl);

   return response.data;
}

const exportObject = {
   getAllAsync,
};

export default exportObject