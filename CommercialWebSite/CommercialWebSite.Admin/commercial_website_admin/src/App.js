import React, { useState, useEffect } from "react";
import Shop from "./components/product/Shop";
import Footer from "./components/layout/footer/Footer";
import ProductDetail from "./components/product/ProductDetail";
import CategoryService from "./services/category";
import CategoryManage from "./components/category/CategoryManage";
import CategoryDetail from "./components/category/CategoryDetail";
import {
   BrowserRouter as Router,
   Routes,
   Route
} from "react-router-dom";
import AddNewProductForm from "./components/product/AddNewProductForm";

export const AppContext = React.createContext();

const App = () => {
   const [catChoice, setCatChoice] = useState(0);
   const [productName, setProductName] = useState("");
   const [categories, setCategories] = useState([]);

   useEffect(() => {
      CategoryService.getAllAsync()
         .then(data => {
            console.log("App_ api category response ", data);
            setCategories(data)
         })
   }, []);

   const onSubmitProductNameForm = data => {
      console.log("App_ product form dat ", data.productName);
      setProductName(data.productName);
   }

   const contextStateControl = {
      categories,
      setCategories,
      setCatChoice,
      onSubmitProductNameForm
   }

   return (
      <Router>
         <AppContext.Provider value={contextStateControl}>
            <Routes>
               <Route path="/" element={<Shop productName={productName} catChoice={catChoice} />} />
               <Route path="product/:productId" element={<ProductDetail />} />
               <Route path="newProduct" element={<AddNewProductForm />} />
               <Route path="category" element={<CategoryManage />} />
               <Route path="category/:categoryId" element={<CategoryDetail />} />
            </Routes>
         </AppContext.Provider>
         <Footer />
      </Router>
   );
}

export default App;
