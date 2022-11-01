import React, { useState, useEffect } from 'react';
import ProductService from "../../services/product";
import ProductDisplay from "./ProductDisplay";
import ShopPagination from './ShopPagination';
import ProductHeader from "../layout/header/product/ProductHeader";

const Shop = ({ catChoice, productName }) => {
   const [allProduct, setAllProduct] = useState([]);
   const [filteredProducts, setFilteredProducts] = useState([]);
   const [pagination, setPagination] = useState({
      doPaginate: true,
      pageCount: 0,
      page: 1
   });

   useEffect(() => {
      console.log("Shop_ pagination: ", pagination.doPaginate);
      ProductService.getPageCountAsync()
         .then(data => {
            console.log("Shop_ page count: ", data);
            setPagination({ ...pagination, pageCount: data });
         })
      ProductService.getByPageAsync(pagination.page)
         .then(data => {
            console.log("Shop_ page: ", pagination.page);
            console.log("Shop_ api product data by page", data);
            if (pagination.doPaginate) {
               setFilteredProducts(data);
            }
         });
      ProductService.getAllAsync()
         .then(data => {
            console.log("Shop_ api all product data", data);
            setAllProduct(data);
            if (!pagination.doPaginate) {
               setFilteredProducts(data);
            }
         });
   }, [pagination.page])

   useEffect(() => {
      if (productName !== "" || catChoice !== 0) {
         console.log("Shop_ filtering by name: ", productName);
         console.log("Shop_ filtering by category: ", catChoice);
         console.log("")
         let filtered = allProduct
            .filter(p => p.productName.includes(productName));

         if (catChoice !== 0) {
            filtered = filtered
               .filter(p => p.categoryId === catChoice);
         }
         setFilteredProducts(filtered);
         setPagination({ ...pagination, doPaginate: false });
      } else {
         setPagination({ ...pagination, doPaginate: true });
      }
   }, [productName, catChoice]);

   const changePage = (page) => {
      console.log("ShopPagination_ changing to page: ", page);
      setPagination({ ...pagination, page: page });
   }

   return (
      <React.Fragment>
         <ProductHeader />
         <div className="container-fluid pt-5 pb-3">
            <div className="row px-xl-5">
               {filteredProducts.map(p => (
                  <React.Fragment key={p.productId}>
                     <ProductDisplay product={p} />
                  </React.Fragment>
               ))}

            </div>
            {pagination.doPaginate ? (
               <div className="col-12">
                  <nav>
                     <ul className="pagination justify-content-center">
                        <ShopPagination pagination={pagination} changePage={changePage} />
                     </ul>
                  </nav>
               </div>
            ) : null}
         </div>
      </React.Fragment>
   )
}

export default Shop;