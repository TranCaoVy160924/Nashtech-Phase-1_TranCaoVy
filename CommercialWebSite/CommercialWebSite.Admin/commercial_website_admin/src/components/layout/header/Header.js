import SearchBar from "./SearchBar";
import NavBar from "./NavBar";
import React from "react";

const Header = () => {
   return (
      <React.Fragment>
         <SearchBar />
         <NavBar />
      </React.Fragment>
   )
}

export default Header;

