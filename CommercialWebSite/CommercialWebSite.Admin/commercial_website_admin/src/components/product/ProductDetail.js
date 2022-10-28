import { useParams } from "react-router-dom";
import {
   useEffect,
   useState,
   useContext
} from "react";
import ProductService from '../../services/product';
import { AppContext } from "../../App";
import { useForm } from "react-hook-form";
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import { yupResolver } from '@hookform/resolvers/yup';
import * as yup from "yup";
import axios from "axios";

const ProductDetail = () => {
   const { productId } = useParams();
   const [product, setProduct] = useState({});
   const context = useContext(AppContext);
   const categories = context.categories;

   const schema = yup.object({
      productName: yup.string().required()
   }).required();

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

   useEffect(() => {
      console.log("ProductDetail_ reset try: ", categories);
   }, [categories]);

   const onSubmitForm = data => {
      console.log(data.productImage[0])
      var imageData = new FormData();
      imageData.append('file', data.productImage[0]);
      imageData.append('upload_preset', "mchs1zmt")

      axios.post("https://api.cloudinary.com/v1_1/dddvmxs3h/image/upload", imageData)
         .then((response) => {
            console.log("ProductDetail_ uploaded image url: ", response.data)
         })
         .catch(function (error) {
            console.log(error);
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
                              defaultValue={product.productName} />
                           <p>{errors.productName?.message}</p>
                        </Col>
                        <Col>
                           <Form.Label>Product Price</Form.Label>
                           <Form.Control {...register("productPrice")}
                              defaultValue={product.price}
                              className="mb-4" />
                        </Col>
                     </Row>
                     <Row className="mb-3">
                        <Col>
                           <Form.Label>Number In Storage</Form.Label>
                           <Form.Control {...register("numberInStorage")}
                              defaultValue={product.numberInStorage} />
                        </Col>
                        <Col>
                           <Form.Label>Category</Form.Label>
                           <Form.Select {...register("productCategory")}
                              className="mb-4" value={product.categoryId}>
                              {/* <option value={1}>One</option>
                              <option value={2}>Two</option>
                              <option value={3}>Three</option>
                              <option value={4}>Four</option> */}
                              {categories.map(c => (
                                 <option key={c.categoryId} value={c.categoryId}>{c.categoryName}</option>
                              ))}
                           </Form.Select>
                        </Col>
                     </Row>
                     <Row className="mb-4">
                        <Col>
                           <Form.Label>Description</Form.Label>
                           <Form.Control as="textarea" rows={5}
                              {...register("description")}
                              defaultValue={product.description} />
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