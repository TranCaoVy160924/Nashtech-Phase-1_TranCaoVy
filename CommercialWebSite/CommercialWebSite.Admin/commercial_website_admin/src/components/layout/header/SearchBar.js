import { Link } from "react-router-dom";
import { useForm } from "react-hook-form";
import Button from 'react-bootstrap/Button';
import Form from 'react-bootstrap/Form';
import { useContext } from "react";
import { AppContext } from "../../../App";

const SearchBar = () => {
   const { register, handleSubmit, watch, formState: { errors } } = useForm();
   const context = useContext(AppContext);
   const onSubmitForm = context.onSubmitProductNameForm;

   return (
      <div className="container-fluid">
         <div className="row align-items-center bg-light py-3 px-xl-5 d-none d-lg-flex">
            <div className="col-lg-4">
               <Link to="/" className="text-decoration-none">
                  <span className="h1 text-uppercase text-primary bg-dark px-2">Multi</span>
                  <span className="h1 text-uppercase text-dark bg-primary px-2 ml-n1">Shop</span>
               </Link>
            </div>
            <div className="col-lg-4 col-6 text-left">
               <Form onSubmit={handleSubmit(onSubmitForm)}>
                  <div className="input-group">
                     <Form.Control defaultValue="" {...register("productName")}
                        placeholder="Search for products" />
                     <div className="input-group-append">
                        <Button type="submit" className="input-group-text bg-transparent text-primary">
                           <i className="fa fa-search"></i>
                        </Button>
                     </div>
                  </div>
               </Form>
            </div>
            <div className="col-lg-4 col-6 text-right">
               <p className="m-0">Customer Service</p>
               <h5 className="m-0">+0 985 097 145</h5>
            </div>
         </div>
      </div>
   )
}

export default SearchBar