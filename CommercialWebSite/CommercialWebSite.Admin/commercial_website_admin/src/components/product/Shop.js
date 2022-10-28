import React, { useState, useEffect } from 'react';
import ProductService from "../../services/product";
import ProductDisplay from "./ProductDisplay";

const Shop = ({ catChoice, productName }) => {
   const [products, setProducts] = useState([]);
   const [filteredProducts, setFilteredProducts] = useState([]);

   useEffect(() => {
      ProductService.getAllAsync()
         .then(data => {
            console.log("api product data", data);
            setProducts(data);
            setFilteredProducts(data);
         });
   }, [])

   useEffect(() => {
      console.log("Shop_ filtering by name: ", productName);
      console.log("Shop_ filtering by category: ", catChoice);
      console.log("")
      let filtered = products
         .filter(p => p.productName.includes(productName));

      if (catChoice !== 0) {
         filtered = filtered
            .filter(p => p.categoryId === catChoice);
      }

      setFilteredProducts(filtered);
   }, [productName, catChoice]);

   return (
      <div className="container-fluid pt-5 pb-3">
         <div className="row px-xl-5">
            {filteredProducts.map(p => (
               <React.Fragment key={p.productId}>
                  <ProductDisplay product={p} />
               </React.Fragment>
            ))}
         </div>
      </div>
   )
}

export default Shop;