import SearchBar from "../SearchBar";
import Topbar from "../Topbar";
import CategoryNavBar from "./CategoryNavBar";
import React from "react";

const CategoryHeader = () => {
   return (
      <React.Fragment>
         <Topbar />
         <SearchBar />
         <CategoryNavBar />
      </React.Fragment>
   )
}

export default CategoryHeader;
