import { Link } from 'react-router-dom';

const ProductDisplay = ({ product }) => {
   return (
      <div className="col-lg-3 col-md-4 col-sm-6 pb-1">
         <div className="product-item bg-light mb-4">
            <div className="product-img position-relative overflow-hidden">
               <img className="img-fluid w-100" src={product.productPicture} width="150px" height="150px" alt="" />
               <div className="product-action">
                  <form id="productDetailForm-@(Model.ProductId)">
                     <input type="hidden" name="id" value="@Model.ProductId" />
                  </form>
                  <Link to={`product/${product.productId}`}
                     className="btn btn-outline-dark btn-square">
                     <i className="fa fa-search"></i>
                  </Link>
               </div>
            </div>
            <div className="text-center py-4">
               <Link to={`product/${product.productId}`}
                  className="h6 text-decoration-none text-truncate">
                  {product.productName}
               </Link>
               <div className="d-flex align-items-center justify-content-center mt-2">
                  <h5>{product.price}</h5>
               </div>
               <div className="d-flex align-items-center justify-content-center mb-1">
                  <small className="fa fa-star text-primary mr-1"></small>
                  <small className="fa fa-star text-primary mr-1"></small>
                  <small className="fa fa-star text-primary mr-1"></small>
                  <small className="fa fa-star text-primary mr-1"></small>
                  <small className="fa fa-star text-primary mr-1"></small>
                  <small>{product.numberInStorage}</small>
               </div>
            </div>
         </div>
      </div>
   )
}

export default ProductDisplay;