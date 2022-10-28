import React from "react"

const Footer = () => {
   return (
      <React.Fragment>
         <div className="container-fluid bg-dark text-secondary mt-5 pt-5">
            <div className="row border-top mx-xl-5 py-4" style={{borderColor: 'rgba(256, 256, 256, .1)', important: true}}>
               <div className="col-md-6 px-xl-0">
                  <p className="mb-md-0 text-center text-md-left text-secondary">
                     &copy; <a className="text-primary" href="#/">Domain</a>. All Rights Reserved. Designed
                     by
                     <a className="text-primary" href="#/">HTML Codex</a>
                  </p>
               </div>
               <div className="col-md-6 px-xl-0 text-center text-md-right">
                  <img className="img-fluid" src="https://res.cloudinary.com/dddvmxs3h/image/upload/v1666854128/payments_xhkyvz.png" alt="" />
               </div>
            </div>
         </div>

         <a href="#/" className="btn btn-primary back-to-top"><i className="fa fa-angle-double-up"></i></a>
      </React.Fragment>
   )
}

export default Footer;