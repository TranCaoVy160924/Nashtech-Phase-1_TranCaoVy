import CategoryDropdown from "./CategoryDropdown";
import { Link } from "react-router-dom";

const NavBar = ({ setCatChoice }) => {
   return (
      <div className="sticky-top">
         <div className="container-fluid bg-dark mb-30">
            <div className="row px-xl-5">
               <CategoryDropdown setCatChoice={setCatChoice}/>
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
                           <Link to="/" className="nav-item nav-link active">Home</Link>
                           <a href="index.html" className="nav-item nav-link">Shop</a>
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