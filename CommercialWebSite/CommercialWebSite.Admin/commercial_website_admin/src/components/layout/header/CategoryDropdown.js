import React, { useState, useEffect } from 'react';
import CategoryService from '../../../services/category'

const CategoryDropdown = ({ setCatChoice }) => {
   const [categories, setCategories] = useState([]);

   useEffect(() => {
      CategoryService.getAllAsync()
         .then(data => {
            console.log("api category response ", data);
            setCategories(data)
         })
   }, []);

   return (
      <div className="col-lg-3 d-none d-lg-block">
         <a className="btn d-flex align-items-center justify-content-between bg-primary w-100"
            data-toggle="collapse" href="#navbar-vertical" style={{ height: '65px', padding: '0 30px' }}>
            <h6 className="text-dark m-0"><i className="fa fa-bars mr-2"></i>Categories</h6>
            <i className="fa fa-angle-down text-dark"></i>
         </a>
         <nav className="collapse position-absolute navbar navbar-vertical navbar-light align-items-start p-0 bg-light"
            id="navbar-vertical" style={{ width: 'calc(100% - 30px)', zIndex: 999 }}>
            <div className="navbar-nav w-100">
               <a href="#/" onClick={() => {setCatChoice(0)}} className="nav-item nav-link">
                  All Category
               </a>
               {categories.map(c => (
                  <React.Fragment key={c.categoryId}>
                     <a href="#/" onClick={() => {setCatChoice(c.categoryId)}} className="nav-item nav-link">
                        {c.categoryName}
                     </a>
                  </React.Fragment>
               ))}
            </div>
         </nav>
      </div>
   )
}

export default CategoryDropdown;