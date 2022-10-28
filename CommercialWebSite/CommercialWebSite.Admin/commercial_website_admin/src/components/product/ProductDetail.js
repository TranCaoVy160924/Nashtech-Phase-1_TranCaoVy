import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";
import ProductService from '../../services/product';

const ProductDetail = () => {
   const { productId } = useParams();
   const [product, setProduct] = useState({})

   useEffect(() => {
      ProductService.getByIdAsync(productId)
         .then(data => {
            console.log("ProductDetail_ product: ", data);
            setProduct(data);
         });
   }, [])

   return (
      <div className="container-fluid pb-5">
         <div className="row px-xl-5">
            <div className="col-lg-5 mb-30">
               <img className="w-100 h-100" src={product.productPicture} alt="Product" />
            </div>

            <div className="col-lg-7 h-auto mb-30">
               <div className="h-100 bg-light p-30">
                  <h3>{product.productName}</h3>
                  <div className="d-flex mb-3">
                     <div className="text-primary mr-2">
                        <small className="fas fa-star"></small>{product.agregateUserRate}
                     </div>
                  </div>
                  <h3 className="font-weight-semi-bold mb-4">{product.price}</h3>
                  <p className="mb-4">
                     {product.description}
                  </p>
                  <div className="d-flex align-items-center mb-4 pt-2">
                     <button className="btn btn-primary px-3">
                        <i className="fa fa-shopping-cart mr-1"></i>
                        Update Product
                     </button>
                  </div>
               </div>
            </div>
         </div>
      </div>
   );
}

export default ProductDetail;