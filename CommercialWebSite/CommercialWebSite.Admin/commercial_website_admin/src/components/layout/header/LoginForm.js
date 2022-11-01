import AuthService from "../../../services/auth";
import { useForm } from "react-hook-form";
import { yupResolver } from '@hookform/resolvers/yup';
import { useContext } from "react";
import { AppContext } from '../../../App';

const LoginForm = () => {
   const schema = AuthService.loginSchema;
   const context = useContext(AppContext);
   let setJwtToken = context.setJwtToken;

   const { register, handleSubmit, formState: { errors } } = useForm({
      resolver: yupResolver(schema)
   });

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
            let closeButton = document.getElementById('closeLogin');
            closeButton.click();
            setJwtToken(data.token);
         })
         .catch(error => {
            console.log("LoginForm_ login failed: ", error);
         })
   }

   return (
      <div className="modal fade" id="loginModal" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
         <div className="modal-dialog">
            <div className="modal-content">
               <div className="modal-header">
                  <h1 className="modal-title fs-5" id="exampleModalLabel">New message</h1>
                  <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
               </div>
               <form id="loginFrm" onSubmit={handleSubmit(login)}>
                  <div className="modal-body">

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
                  </div>
                  <div className="modal-footer">
                     <button id="closeLogin" type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                     <button type="submit" className="btn btn-primary">Login</button>
                  </div>
               </form>
            </div>
         </div>
      </div>
   )
}

export default LoginForm;