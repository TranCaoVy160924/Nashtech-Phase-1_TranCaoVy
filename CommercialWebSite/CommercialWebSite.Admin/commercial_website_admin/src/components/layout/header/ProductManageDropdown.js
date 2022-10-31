import { Link } from "react-router-dom";

const ProductManageDropdown = () => {
   return (
      <div className="col-lg-3 d-none d-lg-block">
         <a className="btn d-flex align-items-center justify-content-between bg-primary w-100"
            data-toggle="collapse" href="#navbar-product" style={{ height: '65px', padding: '0 30px' }}>
            <h6 className="text-dark m-0"><i className="fa fa-bars mr-2"></i>Manage Products</h6>
            <i className="fa fa-angle-down text-dark"></i>
         </a>
         <nav className="collapse position-absolute navbar navbar-vertical navbar-light align-items-start p-0 bg-light"
            id="navbar-product" style={{ width: 'calc(100% - 30px)', zIndex: 999 }}>
            <div className="navbar-nav w-100">
               <Link to="/" className="nav-item nav-link">
                  Shop
               </Link>
               <Link to="/newProduct" className="nav-item nav-link">
                  Add New Product
               </Link>
            </div>
         </nav>
      </div>
   )
}

export default ProductManageDropdown;