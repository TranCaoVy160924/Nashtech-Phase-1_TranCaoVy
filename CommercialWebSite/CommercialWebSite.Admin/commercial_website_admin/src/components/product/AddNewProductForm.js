import { Navigate } from "react-router-dom";
import {
   useState,
   useContext,
   useEffect
} from "react";
import React from 'react';
import ProductHeader from "../layout/header/product/ProductHeader";
import ProductService from '../../services/product';
import CloudinaryService from "../../services/cloudinary";
import { AppContext } from "../../App";
import { useForm } from "react-hook-form";
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import { yupResolver } from '@hookform/resolvers/yup';

const AddNewProductForm = () => {
   const context = useContext(AppContext);
   const categories = context.categories;

   const schema = ProductService.productSchema;

   const [succeeded, setSucceeded] = useState(false);
   const [displayImage, setDisplayImage] = useState("https://res.cloudinary.com/dddvmxs3h/image/upload/v1667030485/background_dui8e3.jpg");
   const { register, handleSubmit, watch, formState: { errors } } = useForm({
      resolver: yupResolver(schema)
   });

   useEffect(() => {
      // create the preview
      let objectUrl;
      let tempImageData = watch("productImage");
      console.log("AddNewProductForm_ chosen image: ", tempImageData)
      if (tempImageData !== null && tempImageData.length > 0) {
         objectUrl = URL.createObjectURL(watch("productImage")[0]);
         setDisplayImage(objectUrl);
      }

      // free memory when ever this component is unmounted
      return () => URL.revokeObjectURL(objectUrl)
   }, [watch("productImage")])

   const onSubmitForm = async data => {
      let imageUrl;
      console.log(data.productImage)
      if (data.productImage[0]) {
         await CloudinaryService.uploadImage(data.productImage[0])
            .then(data => {
               imageUrl = data;
            })
         console.log("AddNewProductForm_ uploaded image: ", imageUrl)
      }
      let newProduct = {
         productName: data.productName,
         description: data.description,
         productPicture: imageUrl,
         numberInStorage: data.numberInStorage,
         price: data.productPrice,
         categoryId: data.productCategory
      };
      console.log("AddNewProductForm_ add : ", newProduct)
      ProductService.addAsync(newProduct)
         .then(data => {
            console.log("AddNewProductForm_ updating product api resposne: ",
               data);
            setSucceeded(true);
         })
         .catch(error => {
            console.log("AddNewProductForm_ updating product api error: ",
               error)
         });
   }

   if (succeeded) {
      return (
         <Navigate to="/" replace />
      );
   }

   return (
      <React.Fragment>
         <ProductHeader />
         <div className="container-fluid pb-5">
            <Form onSubmit={handleSubmit(onSubmitForm)}>
               <div className="row px-xl-5">
                  <div className="col-lg-5 mb-30">
                     <img className="w-100 h-100" src={displayImage} alt="Product" />
                     <Form.Control {...register("productImage")}
                        type="file" accept="image/*" defaultValue={""} />
                     <p className="text-danger">{errors.productImage?.message}</p>
                  </div>

                  <div className="col-lg-7 h-auto mb-30">
                     <div className="h-100 bg-light p-30">
                        <Row className="mb-3">
                           <Col>
                              <Form.Label>Product Name</Form.Label>
                              <Form.Control {...register("productName")}
                                 className="mb-3" />
                              <p className="text-danger">{errors.productName?.message}</p>
                           </Col>
                           <Col>
                              <Form.Label>Product Price</Form.Label>
                              <Form.Control {...register("productPrice")}
                                 className="mb-3" />
                              <p className="text-danger">{errors.productPrice?.message}</p>
                           </Col>
                        </Row>
                        <Row className="mb-3">
                           <Col>
                              <Form.Label>Number In Storage</Form.Label>
                              <Form.Control {...register("numberInStorage")}
                                 className="mb-3" />
                              <p className="text-danger">{errors.numberInStorage?.message}</p>
                           </Col>
                           <Col>
                              <Form.Label>Category</Form.Label>
                              <Form.Select {...register("productCategory")}
                                 className="mb-4" >
                                 <option value={0}>Choose a category</option>
                                 {categories.map(c => (
                                    <option key={c.categoryId} value={c.categoryId}>{c.categoryName}</option>
                                 ))}
                              </Form.Select>
                              <p className="text-danger">{errors.productCategory?.message}</p>
                           </Col>
                        </Row>
                        <Row className="mb-4">
                           <Col>
                              <Form.Label>Description</Form.Label>
                              <Form.Control as="textarea" rows={5}
                                 {...register("description")}
                                 className="mb-3" />
                              <p className="text-danger">{errors.description?.message}</p>
                           </Col>
                        </Row>
                        <div className="d-flex align-items-center mb-4 pt-2">
                           <button className="btn btn-primary px-3">
                              <i className="fa fa-shopping-cart mr-1"></i>
                              Add New Product Product
                           </button>
                        </div>

                     </div>
                  </div>
               </div>

            </Form>
         </div>
      </React.Fragment>
   );
}

export default AddNewProductForm;