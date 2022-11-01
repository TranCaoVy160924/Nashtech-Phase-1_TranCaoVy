import { useContext } from "react";
import { AppContext } from '../../../App';
import LoginForm from './LoginForm';

const Topbar = () => {
   const context = useContext(AppContext);
   let jwtToken = context.jwtToken;

   return (
      <div className="container-fluid" >
         <div className="row bg-secondary py-1 px-xl-5">
            <div className="col-lg-12 text-center text-lg-right">
               <div className="d-inline-flex align-items-center">
                  <div className="btn-group">
                     <button type="button" className="btn btn-sm btn-light dropdown-toggle" data-toggle="dropdown">My Account</button>
                     <div className="dropdown-menu dropdown-menu-right">
                        {jwtToken !== "" &&
                           <form method="get" asp-controller="Auth" asp-action="Logout">
                              <button className="dropdown-item btn" type="submit">
                                 Logout
                              </button>
                           </form>
                        }
                        {jwtToken === "" &&
                           <>
                              <button className="dropdown-item btn" type="button"
                                 data-bs-toggle="modal"
                                 data-bs-target="#loginModal"
                                 data-bs-whatever="@mdo">
                                 Sign in
                              </button>
                           </>
                        }
                     </div>
                  </div>
               </div>
               <div className="d-inline-flex align-items-center d-block d-lg-none">
                  {/* <a href="#" className="btn px-0 ml-2">
                     <i className="fas fa-heart text-dark"></i>
                     <span className="badge text-dark border border-dark rounded-circle" style="padding-bottom: 2px;">0</span>
                  </a>
                  <a href="#" className="btn px-0 ml-2">
                     <i className="fas fa-shopping-cart text-dark"></i>
                     <span className="badge text-dark border border-dark rounded-circle" style="padding-bottom: 2px;">0</span>
                  </a> */}
               </div>
            </div>
         </div>

         <LoginForm />
      </div >
   )
}

export default Topbar;