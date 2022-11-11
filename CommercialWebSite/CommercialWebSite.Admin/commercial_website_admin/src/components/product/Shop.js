import React, { useState, useEffect, useContext } from 'react';
import ProductService from "../../services/product";
import ProductDisplay from "./ProductDisplay";
import ShopPagination from './ShopPagination';
import ProductHeader from "../layout/header/product/ProductHeader";
import { AppContext } from '../../App';
import { Table, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';
import Box from '@mui/material/Box';
import { DataGrid } from '@mui/x-data-grid';

const Shop = ({ catChoice, productName }) => {
   const [allProduct, setAllProduct] = useState([]);
   const [currentPageProduct, setCurrentPageProduct] = useState([]);
   const [filteredProducts, setFilteredProducts] = useState([]);
   const context = useContext(AppContext);
   const pagination = context.pagination;
   const setPagination = context.setPagination;

   const rows = filteredProducts.map(p => ({
      productId: p.productId,
      numberInStorage: p.numberInStorage,
      categoryId: p.categoryId,
      price: p.price,
      button: (
         <Link to={`product/${p.productId}`}>
            <Button className="btn-primary">
               Detail
            </Button>
         </Link>
      )
   }));

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
            if (data.length < 1) {
               setPagination({ ...pagination, page: pagination.page - 1 });
            }
            else {
               setCurrentPageProduct(data);
               if (pagination.doPaginate) {
                  setFilteredProducts(data);
               }
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
      console.log("Shop_ chosen category: ", catChoice);
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
         setFilteredProducts(currentPageProduct);
         setPagination({ ...pagination, page: 1, doPaginate: true });
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
            <div className="row px-xl-5 ms-5 me-5">
               {/* {filteredProducts.map(p => (
                  <React.Fragment key={p.productId}>
                     <ProductDisplay product={p} />
                  </React.Fragment>
               ))} */}

               <Table id="user_table" className="display" striped bordered hover>
                  <thead>
                     <tr>
                        <th className="text-center">Id</th>
                        <th className="text-center">Name</th>
                        <th className="text-center">In Storage</th>
                        <th className="text-center">Category</th>
                        <th className="text-center">Price</th>
                        <th className="text-center">To Product Page</th>
                     </tr>
                  </thead>
                  <tbody>
                     {filteredProducts.map(p => (
                        <tr key={p.productId}>
                           <td className="text-center">{p.productId}</td>
                           <td className="text-center">{p.productName}</td>
                           <td className="text-center">{p.numberInStorage}</td>
                           <td className="text-center">{p.categoryName}</td>
                           <td className="text-center">{p.price}</td>
                           <td className="d-flex justify-content-center">
                              <Link to={`/product/${p.productId}`}>
                                 <Button className="btn-primary">
                                    Detail
                                 </Button>
                              </Link>
                           </td>
                        </tr>
                     ))}
                  </tbody>
               </Table>
            </div>
            {pagination.doPaginate && pagination.pageCount > 1 ? (
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