import SearchBar from "../SearchBar";
import ProductNavBar from "./ProductNavBar";
import Topbar from "../Topbar";
import React from "react";

const ProductHeader = () => {
   return (
      <React.Fragment>
         <Topbar />
         <SearchBar />
         <ProductNavBar />
      </React.Fragment>
   )
}

export default ProductHeader;

