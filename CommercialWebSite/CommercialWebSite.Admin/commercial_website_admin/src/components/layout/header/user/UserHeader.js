import React from "react";
import SearchBar from "../SearchBar";
import Topbar from "../Topbar";
import UserNavBar from "./UserNavBar";

const UserHeader = () => {
   return (
      <React.Fragment>
         <Topbar />
         <SearchBar />
         <UserNavBar />
      </React.Fragment>
   )
}

export default UserHeader;