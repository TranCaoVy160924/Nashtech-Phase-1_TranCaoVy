import { useContext } from "react";
import { useNavigate } from "react-router-dom";
import { AppContext } from '../../../App';
import AuthService from '../../../services/auth';

const Topbar = () => {
   const context = useContext(AppContext);
   let jwtToken = context.jwtToken;
   let setJwtToken = context.setJwtToken;
   let setLoginAttemp = context.setLoginAttemp;
   let navigate = useNavigate();

   const signOut = () => {
      AuthService.logoutAsync();
      setJwtToken("");
      setLoginAttemp(-1);
      navigate("/");
   }

   return (
      <div className="container-fluid" >
         <div className="row bg-secondary py-1 px-xl-5">
            <div className="col-lg-12 text-center text-lg-right">
               <div className="d-inline-flex align-items-center">
                  <div className="btn-group">
                     <button type="button" className="btn btn-sm btn-light dropdown-toggle" data-toggle="dropdown">My Account</button>
                     <div className="dropdown-menu dropdown-menu-right">
                        {jwtToken !== "none" &&
                           <button className="dropdown-item btn"
                              onClick={signOut}>
                              Logout
                           </button>
                        }
                        {jwtToken === "none" &&
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
               </div>
            </div>
         </div>
      </div >
   )
}

export default Topbar;