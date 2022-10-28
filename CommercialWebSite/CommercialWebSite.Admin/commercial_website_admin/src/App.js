import Header from "./components/layout/header/Header";
import React, { useState, useEffect } from "react";
import Shop from "./components/product/Shop";
import Footer from "./components/layout/footer/Footer";
import ProductDetail from "./components/product/ProductDetail";
import CategoryService from "./services/category";
import {
   BrowserRouter as Router,
   Routes,
   Route
} from "react-router-dom";

export const AppContext = React.createContext();

const App = () => {
   const [catChoice, setCatChoice] = useState(0);
   const [productName, setProductName] = useState("");
   const [categories, setCategories] = useState([]);

   useEffect(() => {
      CategoryService.getAllAsync()
         .then(data => {
            console.log("api category response ", data);
            setCategories(data)
         })
   }, []);

   const onSubmitProductNameForm = data => {
      console.log("App_ product form dat ", data.productName);
      setProductName(data.productName);
   }

   const headerStateControl = {
      categories,
      setCatChoice,
      onSubmitProductNameForm
   }

   const productStateControl = {
      categories
   }

   return (
      <Router>
         <AppContext.Provider value={headerStateControl}>
            <Header />
            <Routes>
               <Route path="/" element={<Shop productName={productName} catChoice={catChoice} />} />
               <Route path="product/:productId" element={<ProductDetail />} />
            </Routes>
         </AppContext.Provider>
         <Footer />
      </Router>
   );
}

export default App;
