import { useParams } from "react-router-dom";
import {
   useEffect,
   useState,
   useContext
} from "react";
import ProductService from '../../services/product';
import CloudinaryService from "../../services/cloudinary";
import { AppContext } from "../../App";
import { useForm } from "react-hook-form";
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import { yupResolver } from '@hookform/resolvers/yup';

const ProductDetail = () => {
   const { productId } = useParams();
   const [product, setProduct] = useState({});
   const context = useContext(AppContext);
   const categories = context.categories;

   const schema = ProductService.productSchema;

   const { register, handleSubmit, reset, formState: { errors } } = useForm({
      resolver: yupResolver(schema)
   });

   useEffect(() => {
      ProductService.getByIdAsync(productId)
         .then(data => {
            console.log("ProductDetail_ product: ", data);
            setProduct(data);
            reset(data);
         });
   }, [reset])

   const onSubmitForm = async data => {
      let imageUrl = product.productPicture;
      if (data.productImage[0]) {
         await CloudinaryService.uploadImage(data.productImage[0])
            .then(data => {
               console.log(data);
               imageUrl = data;
            })
         console.log("ProductDetail_ uploaded image: ", imageUrl)
      }
      let patchProduct = {
         productId: product.productId,
         productName: data.productName,
         description: data.description,
         productPicture: imageUrl,
         agregateUserRate: product.agregateUserRate,
         numberInStorage: data.numberInStorage,
         price: data.productPrice,
         categoryId: data.productCategory
      };
      console.log("ProductDetail_ update : ", patchProduct)
      ProductService.updateAsync(patchProduct)
         .then(data => {
            console.log("ProductDetail_ updating product api resposne: ",
               data);
            setProduct({ ...data });
         })
         .catch(error => {
            console.log("ProductDetail_ updating product api error: ",
               error)
         });
   }

   return (
      <div className="container-fluid pb-5">
         <Form onSubmit={handleSubmit(onSubmitForm)}>
            <div className="row px-xl-5">
               <div className="col-lg-5 mb-30">
                  <img className="w-100 h-100" src={product.productPicture} alt="Product" />
                  <Form.Control {...register("productImage")}
                     type="file" accept="image/*" />
               </div>

               <div className="col-lg-7 h-auto mb-30">
                  <div className="h-100 bg-light p-30">
                     <Row className="mb-3">
                        <Col>
                           <Form.Label>Product Name</Form.Label>
                           <Form.Control {...register("productName")}
                              defaultValue={product.productName}
                              className="mb-3" />
                           <p className="text-danger">{errors.productName?.message}</p>
                        </Col>
                        <Col>
                           <Form.Label>Product Price</Form.Label>
                           <Form.Control {...register("productPrice")}
                              defaultValue={product.price}
                              className="mb-3" />
                           <p className="text-danger">{errors.productPrice?.message}</p>
                        </Col>
                     </Row>
                     <Row className="mb-3">
                        <Col>
                           <Form.Label>Number In Storage</Form.Label>
                           <Form.Control {...register("numberInStorage")}
                              defaultValue={product.numberInStorage}
                              className="mb-3" />
                           <p className="text-danger">{errors.numberInStorage?.message}</p>
                        </Col>
                        <Col>
                           <Form.Label>Category</Form.Label>
                           <Form.Select {...register("productCategory")}
                              className="mb-4" defaultValue={product.categoryId}>
                              {categories.map(c => {
                                 if (product.categoryId === c.categoryId) {
                                    return (
                                       <option key={c.categoryId} value={c.categoryId} selected>{c.categoryName}</option>
                                    )
                                 }
                                 else {
                                    return (
                                       <option key={c.categoryId} value={c.categoryId}>{c.categoryName}</option>
                                    )
                                 }
                              })}
                           </Form.Select>
                        </Col>
                     </Row>
                     <Row className="mb-4">
                        <Col>
                           <Form.Label>Description</Form.Label>
                           <Form.Control as="textarea" rows={5}
                              {...register("description")}
                              defaultValue={product.description}
                              className="mb-3" />
                           <p className="text-danger">{errors.description?.message}</p>
                        </Col>
                     </Row>
                     <div className="d-flex align-items-center mb-4 pt-2">
                        <button className="btn btn-primary px-3">
                           <i className="fa fa-shopping-cart mr-1"></i>
                           Update Product
                        </button>
                     </div>

                  </div>
               </div>
            </div>

         </Form>
      </div>
   );
}

export default ProductDetail;