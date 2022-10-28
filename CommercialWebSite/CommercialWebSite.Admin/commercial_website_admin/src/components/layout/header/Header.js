import SearchBar from "./SearchBar";
import NavBar from "./NavBar";
import React from "react";

const Header = ({ headerStateControl }) => {
   return (
      <React.Fragment>
         <SearchBar onSubmitProductNameForm={headerStateControl.onSubmitProductNameForm}/>
         <NavBar setCatChoice={headerStateControl.setCatChoice}/>
      </React.Fragment>
   )
}

export default Header;

