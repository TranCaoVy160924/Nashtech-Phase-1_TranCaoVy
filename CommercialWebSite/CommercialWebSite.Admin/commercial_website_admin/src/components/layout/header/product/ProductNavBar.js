import CategoryDropdown from "./CategoryDropdown";
import { Link, useLocation } from "react-router-dom";

const NavBar = () => {
   const url = useLocation().pathname;

   return (
      <div className="sticky-top">
         <div className="container-fluid bg-dark mb-30">
            <div className="row px-xl-5">
               {url === "/" ? (
                  <CategoryDropdown />
               ) : null}
               <div className="col-lg-9">
                  <nav className="navbar navbar-expand-lg bg-dark navbar-dark py-3 py-lg-0 px-0">
                     <Link to="/" className="text-decoration-none d-block d-lg-none">
                        <span className="h1 text-uppercase text-dark bg-light px-2">Multi</span>
                        <span className="h1 text-uppercase text-light bg-primary px-2 ml-n1">Shop</span>
                     </Link>
                     <button type="button" className="navbar-toggler" data-toggle="collapse" data-target="#navbarCollapse">
                        <span className="navbar-toggler-icon"></span>
                     </button>
                     <div className="collapse navbar-collapse justify-content-between" id="navbarCollapse">
                        <div className="navbar-nav mr-auto py-0">
                           <Link to="/" className="nav-item nav-link active">Manage Product</Link>
                           <Link to="/newProduct" className="nav-item nav-link">Add New Product</Link>
                           <Link to="/category" className="nav-item nav-link">Manage Category</Link>
                           <Link to="/user" className="nav-item nav-link">Manage User</Link>
                        </div>
                     </div>
                  </nav>
               </div>
            </div>
         </div>
      </div>
   )
}

export default NavBar;