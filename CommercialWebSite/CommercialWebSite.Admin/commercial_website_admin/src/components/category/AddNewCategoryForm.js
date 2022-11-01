import { Navigate } from "react-router-dom";
import {
   useState,
   useContext
} from "react";
import React from "react";
import { AppContext } from '../../App';
import CategoryService from '../../services/category';
import CloudinaryService from "../../services/cloudinary";
import CategoryHeader from "../layout/header/category/CategoryHeader";
import { useForm } from "react-hook-form";
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Button from 'react-bootstrap/Button';
import { yupResolver } from '@hookform/resolvers/yup';

const AddNewCategoryForm = () => {
   const context = useContext(AppContext);
   const categories = context.categories;
   const setCategories = context.setCategories;

   const schema = CategoryService.categorySchema;

   const [succeeded, setSucceeded] = useState(false);
   const { register, handleSubmit, formState: { errors } } = useForm({
      resolver: yupResolver(schema)
   });

   const onSubmitForm = async data => {
      let imageUrl;
      if (data.categoryImage[0]) {
         await CloudinaryService.uploadImage(data.categoryImage[0])
            .then(data => {
               imageUrl = data;
            })
         console.log("AddNewCategoryForm_ uploaded image: ", imageUrl)
      }
      let newCategory = {
         categoryName: data.categoryName,
         categoryPicture: imageUrl
      };
      console.log("AddNewCategoryForm_ add : ", newCategory)
      CategoryService.addAsync(newCategory)
         .then(data => {
            console.log("AddNewCategoryForm_ updating category api resposne: ", data);
            setCategories(categories.concat(data));
            setSucceeded(true);
         })
         .catch(error => {
            console.log("AddNewCategoryForm_ updating category api error: ", error)
         });
   }

   if (succeeded) {
      return (
         <Navigate to="/category" replace />
      );
   }

   return (
      <React.Fragment>
         <CategoryHeader />
         <div className="container-fluid pb-5">
            <Form onSubmit={handleSubmit(onSubmitForm)}>
               <div className="row px-xl-5">
                  <div className="col-lg-5 mb-30">
                     <img className="w-100 h-100" src="https://res.cloudinary.com/dddvmxs3h/image/upload/v1667030485/background_dui8e3.jpg" alt="Category" />
                     <Form.Control {...register("categoryImage")}
                        type="file" accept="image/*" />
                  </div>

                  <div className="col-lg-7 h-auto mb-30">
                     <div className="h-100 bg-light p-30">
                        <Row className="mb-3">
                           <Col>
                              <Form.Label>Category Name</Form.Label>
                              <Form.Control {...register("categoryName")}
                                 className="mb-3" />
                              <p className="text-danger">{errors.categoryName?.message}</p>
                           </Col>
                        </Row>
                        <div className="d-flex justify-content-center mb-4 pt-2">
                           <Button type="submit" variant="primary" className="px-3">
                              Add New Category
                           </Button>
                        </div>
                     </div>
                  </div>
               </div>
            </Form>
         </div>
      </React.Fragment>
   );
}

export default AddNewCategoryForm;