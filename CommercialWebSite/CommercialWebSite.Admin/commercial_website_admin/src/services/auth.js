import axios from 'axios';
import * as yup from "yup";

const baseUrl = "https://localhost:7281/Authenticate";

const makeAdminAsync = async (userId) => {
   let url = baseUrl + "/Register-admin/" + userId
   console.log("AuthService_ axios patch: ", url);
   const response = await axios.patch(url);

   return response.data;
}

const loginAsync = async (user) => {
   let url = baseUrl + "/Login";
   console.log("AuthService_ axios post: ", url);
   const response = await axios.post(url, user);

   return response.data;
}

const loginSchema = yup.object({
   username: yup.string()
      .required("Username is required"),
   password: yup.string()
      .required("Password is required")
}).required();

const exportObject = {
   loginSchema,
   loginAsync,
   makeAdminAsync,
};

export default exportObject