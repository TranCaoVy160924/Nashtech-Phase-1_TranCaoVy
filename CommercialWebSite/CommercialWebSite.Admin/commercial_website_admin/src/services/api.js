import axios from "axios";

const api = axios.create({});

function getToken() {
   const token = localStorage.getItem("jwtToken");
   return token !== "none" ? `Bearer ${token}` : null;
}

api.interceptors.request.use(
   config => {
      if (!config.headers.Authorization) {
         config.headers.Authorization = getToken();
      }
      return config;
   },
   error => {
      return Promise.reject(error);
   }
);
// api.interceptors.response.use(
//    config => {
//       return config;
//    },
//    error => {
//       return Promise.reject(error.response.data);
//    }
// );
export default api;

