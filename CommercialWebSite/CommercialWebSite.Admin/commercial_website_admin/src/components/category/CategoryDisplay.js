import { Link } from "react-router-dom";

const CategoryDisplay = ({ category }) => {
   return (
      <div className="col-lg-3 col-md-4 col-sm-6 pb-1">
         <div className="product-item bg-light mb-4">
            <div className="product-img position-relative overflow-hidden">
               <img className="img-fluid w-100" src={category.categoryPicture} width="150px" height="150px" alt="" />
               <div className="product-action">
                  <form id="productDetailForm-@(Model.ProductId)">
                     <input type="hidden" name="id" value="@Model.ProductId" />
                  </form>
                  <Link to={`${category.categoryId}`}
                     className="btn btn-outline-dark btn-square">
                     <i className="fa fa-search"></i>
                  </Link>
               </div>
            </div>
            <div className="text-center py-4">
               <Link to={`${category.categoryId}`}
                  className="h6 text-decoration-none text-truncate">
                  {category.categoryName}
               </Link>
               <div className="d-flex align-items-center justify-content-center mb-1">
                  <small>Number Of Products: </small>
                  <small>{category.productCount}</small>
               </div>
            </div>
         </div>
      </div>
   )
}

export default CategoryDisplay;