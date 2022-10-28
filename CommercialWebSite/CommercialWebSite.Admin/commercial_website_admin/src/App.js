import Header from "./components/layout/header/Header";
import React, { useState } from "react";
import Shop from "./components/product/Shop";
import Footer from "./components/layout/footer/Footer";
import ProductDetail from "./components/product/ProductDetail";
import {
   BrowserRouter as Router,
   Routes,
   Route
} from "react-router-dom";

const App = () => {
   const [catChoice, setCatChoice] = useState(0); 
   const [productName, setProductName] = useState("");

   const onSubmitProductNameForm = data => {
      console.log("App_ product form dat ", data.productName);
      setProductName(data.productName);
   }
   // const handleStateChange = (stateSetter) => {
   //    return (event) => {
   //       stateSetter(event.target.value)
   //    }
   // }

   const headerStateControl = {
      setCatChoice,
      onSubmitProductNameForm
   }

   return (
      <Router>
         <Header headerStateControl={headerStateControl}/>
         <Routes>
            <Route path="/" element={<Shop productName={productName} catChoice={catChoice}/>} />
            <Route path="product/:productId" element={<ProductDetail />} />
         </Routes>
         <Footer />
      </Router>
   );
}

export default App;
