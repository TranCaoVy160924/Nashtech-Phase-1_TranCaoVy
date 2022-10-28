const RegisterForm = () => {
   return (
      <div className="modal fade" id="registerModal" tabIndex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
         <div className="modal-dialog">
            <div className="modal-content">
               <div className="modal-header">
                  <h1 className="modal-title fs-5" id="exampleModalLabel">Create a new account</h1>
                  <button type="button" className="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
               </div>
               <div className="modal-body">
                  <form id="registerFrm" method="post" encType="multipart/form-data">

                     <div className="mb-3">
                        <label className="col-form-label"
                        >Username:</label>
                        <input type="text" className="form-control"
                           id="register-name" />
                        <span asp-validation-for="Username" className="text-danger"></span>
                     </div>
                     <div className="mb-3">
                        <label className="col-form-label"
                        >Password:</label>
                        <input type="password" className="form-control"
                           id="register-password" />
                        <span asp-validation-for="Password" className="text-danger"></span>
                     </div>
                     <div className="mb-3">
                        <label className="col-form-label"
                        >Email:</label>
                        <input type="text" className="form-control"
                           id="register-email" />
                        <span asp-validation-for="Email" className="text-danger"></span>
                     </div>
                  </form>
               </div>
               <div className="modal-footer">
                  <button type="button" className="btn btn-secondary" data-bs-dismiss="modal">Close</button>
                  <button type="submit" className="btn btn-primary" form="registerFrm">Register</button>
               </div>
            </div>
         </div>
      </div>
   )
}

export default RegisterForm;