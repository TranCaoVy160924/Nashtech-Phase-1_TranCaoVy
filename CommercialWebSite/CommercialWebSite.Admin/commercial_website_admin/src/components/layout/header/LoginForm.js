import AuthService from "../../../services/auth";
import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup';
import { useContext, useEffect } from "react";
import { AppContext } from '../../../App';
import Modal from 'react-bootstrap/Modal';

const LoginForm = () => {
   const schema = AuthService.loginSchema;
   const context = useContext(AppContext);
   const jwtToken = context.jwtToken;
   const setJwtToken = context.setJwtToken;
   let closeButton = document.getElementById('closeLogin');

   const { register, handleSubmit, formState: { errors } } = useForm({
      resolver: yupResolver(schema)
   });

   useEffect(() => {
      console.log("LoginForm_ jwtToken: ", jwtToken);
      if (jwtToken === "none") {
         console.log("LoginForm_ unauthorize");
      }
   }, [jwtToken])

   const login = async data => {
      console.log("LoginForm_ loging in");
      console.log("LoginForm_ username: ", data.username);
      console.log("LoginForm_ password: ", data.password);
      let user = {
         username: data.username,
         password: data.password
      }
      AuthService.loginAsync(user)
         .then(data => {
            console.log("LoginForm_ login success: ", data);
            setJwtToken(data.token);
            closeButton.click();
         })
         .catch(error => {
            console.log("LoginForm_ login failed: ", error);
         })
   }

   return (
      <Modal show={jwtToken === "none"} id="loginModal" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
         <Modal.Header>
            <h1 className="modal-title fs-5" id="exampleModalLabel">New message</h1>
            {/* <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button> */}
         </Modal.Header>
         <form id="loginFrm" onSubmit={handleSubmit(login)}>
            <Modal.Body>

               <div className="mb-3">
                  <label className="col-form-label"
                  >Username:</label>
                  <input type="text" className="form-control"
                     {...register("username")} />
                  <p className="text-danger">{errors.username?.message}</p>
               </div>
               <div className="mb-3">
                  <label className="col-form-label">
                     Password:
                  </label>
                  <input type="password" className="form-control"
                     {...register("password")} />
                  <p className="text-danger">{errors.password?.message}</p>
               </div>
            </Modal.Body>
            <Modal.Footer>
               {/* <button id="closeLogin" type="button" className="btn btn-secondary hidden" data-bs-dismiss="modal">Close</button> */}
               <button type="submit" className="btn btn-primary">Login</button>
            </Modal.Footer>
         </form>
      </Modal>
   )
}

export default LoginForm;