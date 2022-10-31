import { useParams, Navigate } from "react-router-dom";
import {
   useEffect,
   useState,
   useContext
} from "react";
import CategoryService from '../../services/category';
import CloudinaryService from "../../services/cloudinary";
import { AppContext } from "../../App";
import { useForm } from "react-hook-form";
import Col from 'react-bootstrap/Col';
import Form from 'react-bootstrap/Form';
import Row from 'react-bootstrap/Row';
import Button from 'react-bootstrap/Button';
import Modal from 'react-bootstrap/Modal';
import { yupResolver } from '@hookform/resolvers/yup';

const CategoryDetail = () => {
   const { categoryId } = useParams();
   const [category, setCategory] = useState({});
   const [show, setShow] = useState(false);
   const [deleteSucceeded, setDeleteSucceeded] = useState(false);

   const handleClose = () => setShow(false);
   const handleShow = () => setShow(true);
   const context = useContext(AppContext);
   const categories = context.categories;
   const setCategories = context.setCategories;

   const schema = CategoryService.categorySchema;

   const { register, handleSubmit, setValue, reset, formState: { errors } } = useForm({
      resolver: yupResolver(schema)
   });

   useEffect(() => {
      CategoryService.getByIdAsync(categoryId)
         .then(data => {
            console.log("CategoryDetail_ category: ", data);
            setCategory(data);
            reset(data);
         })
   }, [reset])

   const onSubmitForm = async data => {
      let imageUrl = category.categoryPicture;
      if (data.categoryImage[0]) {
         await CloudinaryService.uploadImage(data.categoryImage[0])
            .then(data => {
               console.log(data);
               imageUrl = data;
            })
         console.log("CategoryDetail_ uploaded image: ", imageUrl)
      }
      let patchCategory = {
         categoryId: category.categoryId,
         categoryName: data.categoryName,
         categoryPicture: imageUrl,
         productCount: category.productCount
      };
      console.log("CategoryDetail_ update : ", patchCategory)
      CategoryService.updateAsync(patchCategory)
         .then(data => {
            console.log("CategoryDetail_ updating category api resposne: ", data);
            setCategory({ ...data });
            setValue('categoryImage', null);
         })
         .catch(error => {
            console.log("CategoryDetail_ updating category api error: ", error)
         });
   }

   const deleteCategory = async () => {
      await CategoryService.deleteAsync(category.categoryId)
         .then(data => {
            console.log("CategoryDetail_ delete category api succeeded: ", data);
            setCategories(categories.filter(c => c.categoryId !== category.categoryId));
            setDeleteSucceeded(true);
         })
         .catch(error => {
            console.log("CategoryDetail_ delete category api error: ", error);
         });
   }

   if (deleteSucceeded) {
      return (
         <Navigate to="../category" replace />
      );
   };

   return (
      <div className="container-fluid pb-5">
         <Form onSubmit={handleSubmit(onSubmitForm)}>
            <div className="row px-xl-5">
               <div className="col-lg-5 mb-30">
                  <img className="w-100 h-100" src={category.categoryPicture} alt="Product" />
                  <Form.Control {...register("categoryImage")}
                     type="file" accept="image/*" />
               </div>

               <div className="col-lg-7 h-auto mb-30">
                  <div className="h-100 bg-light p-30">
                     <Row className="mb-3">
                        <Col>
                           <Form.Label>Category Name</Form.Label>
                           <Form.Control {...register("categoryName")}
                              defaultValue={category.categoryName}
                              className="mb-3" />
                           <p className="text-danger">{errors.categoryName?.message}</p>
                        </Col>
                        <Col>
                           <Form.Label>Product Count</Form.Label>
                           <div className="mb-3">{category.productCount}</div>
                        </Col>
                     </Row>
                     <div className="d-flex justify-content-center mb-4 pt-2">
                        <Button type="submit" variant="primary" className="px-3">
                           Update Category
                        </Button>
                        <Button variant="danger" className="px-3 ms-3"
                           onClick={handleShow}>
                           Delete Category
                        </Button>
                     </div>
                  </div>
               </div>
            </div>

         </Form>

         <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
               <Modal.Title>Confirm Delete</Modal.Title>
            </Modal.Header>
            <Modal.Body>Do you want to delete?</Modal.Body>
            <Modal.Footer>
               <Button variant="secondary" onClick={handleClose}>
                  No
               </Button>
               <Button variant="primary" onClick={deleteCategory}>
                  Yes
               </Button>
            </Modal.Footer>
         </Modal>
      </div>
   );
}

export default CategoryDetail;