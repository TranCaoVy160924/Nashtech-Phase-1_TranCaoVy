import React, { useContext } from 'react';
import { AppContext } from '../../../../App';
import { Link } from 'react-router-dom';

const CategoryDropdown = () => {
   const context = useContext(AppContext);
   const setCatChoice = context.setCatChoice;
   const categories = context.categories;

   return (
      <div className="col-lg-3 d-none d-lg-block">
         <a className="btn d-flex align-items-center justify-content-between bg-primary w-100"
            data-toggle="collapse" href="#navbar-vertical" style={{ height: '65px', padding: '0 30px' }}>
            <h6 className="text-dark m-0"><i className="fa fa-bars mr-2"></i>Search By Category</h6>
            <i className="fa fa-angle-down text-dark"></i>
         </a>
         <nav className="collapse position-absolute navbar navbar-vertical navbar-light align-items-start p-0 bg-light"
            id="navbar-vertical" style={{ width: 'calc(100% - 30px)', zIndex: 999 }}>
            <div className="navbar-nav w-100">
               <Link to="/" onClick={() => { setCatChoice(0) }} className="nav-item nav-link">
                  All Category
               </Link>
               {categories.map(c => (
                  <React.Fragment key={c.categoryId}>
                     <Link to="/" onClick={() => { setCatChoice(c.categoryId) }} className="nav-item nav-link">
                        {c.categoryName}
                     </Link>
                  </React.Fragment>
               ))}
            </div>
         </nav>
      </div>
   )
}

export default CategoryDropdown;