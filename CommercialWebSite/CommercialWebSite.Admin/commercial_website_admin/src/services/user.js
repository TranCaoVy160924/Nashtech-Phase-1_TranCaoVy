import axios from 'axios';
const baseUrl = "https://localhost:7281/User";

const getAllAsync = async () => {
   console.log("UserService_ axios get: ", baseUrl);
   const response = await axios.get(baseUrl);

   return response.data;
}

const exportObject = {
   getAllAsync,
};

export default exportObject