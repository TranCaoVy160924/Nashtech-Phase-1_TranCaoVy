import React, { useState, useEffect } from "react";
import Shop from "./components/product/Shop";
import Footer from "./components/layout/footer/Footer";
import ProductDetail from "./components/product/ProductDetail";
import CategoryService from "./services/category";
import AuthService from "./services/auth";
import CategoryManage from "./components/category/CategoryManage";
import CategoryDetail from "./components/category/CategoryDetail";
import AddNewCategoryForm from "./components/category/AddNewCategoryForm";
import {
   BrowserRouter as Router,
   Routes,
   Route
} from "react-router-dom";
import UserManage from "./components/user/UserManage";
import AddNewProductForm from "./components/product/AddNewProductForm";
import LoginPage from "./components/standalone/LoginPage";
import NotFoundPage from "./components/standalone/NotFoundPage";

export const AppContext = React.createContext();

const App = () => {
   const [catChoice, setCatChoice] = useState(0);
   const [productName, setProductName] = useState("");
   const [categories, setCategories] = useState([]);
   const [jwtToken, setJwtToken] = useState(localStorage.getItem("jwtToken") || "none");
   const [authorized, setAuthorized] = useState(true);
   const [loginAttemp, setLoginAttemp] = useState(-1);

   useEffect(() => {
      CategoryService.getAllAsync()
         .then(data => {
            console.log("App_ api category response ", data);
            setCategories(data)
         })
   }, []);

   useEffect(() => {
      AuthService.checkToken()
         .then(data => {
            console.log("App_ api check token response: ", data);
            setAuthorized(data);
         })
         .catch(error => {
            console.log("App_ api check token error: ", error);
            setAuthorized(false);
         })
      setLoginAttemp(loginAttemp + 1);
      console.log()
   }, [jwtToken])

   useEffect(() => {
      localStorage.setItem("jwtToken", jwtToken)
   }, [jwtToken])

   const onSubmitProductNameForm = data => {
      console.log("App_ product form dat ", data.productName);
      setProductName(data.productName);
   }

   const contextStateControl = {
      categories,
      jwtToken,
      authorized,
      loginAttemp,
      setLoginAttemp,
      setJwtToken,
      setCategories,
      setCatChoice,
      onSubmitProductNameForm
   }

   return (
      <Router>
         <AppContext.Provider value={contextStateControl}>
            <Routes>
               {!authorized ?
                  (
                     <React.Fragment>
                        <Route path="/" element={<LoginPage />} />
                     </React.Fragment>
                  ) : (
                     <React.Fragment>
                        <Route path="/" element={<Shop productName={productName} catChoice={catChoice} />} />
                        <Route path="product/:productId" element={<ProductDetail />} />
                        <Route path="newProduct" element={<AddNewProductForm />} />
                        <Route path="category" element={<CategoryManage />} />
                        <Route path="category/:categoryId" element={<CategoryDetail />} />
                        <Route path="newCategory" element={<AddNewCategoryForm />} />
                        <Route path="user" element={<UserManage />} />
                     </React.Fragment>
                  )
               }
               <Route path="login" element={<LoginPage />} />
               <Route path="*" element={<NotFoundPage />} />
            </Routes>
            {authorized ? (
               <Footer />
            ) : null}
         </AppContext.Provider>
      </Router>
   );
}

export default App;
