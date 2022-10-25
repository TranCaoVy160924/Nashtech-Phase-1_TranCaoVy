const SearchBar = () => {
   return (
      <div className="container-fluid">
         <div className="row align-items-center bg-light py-3 px-xl-5 d-none d-lg-flex">
            <div className="col-lg-4">
               <a href="https://localhost:7263" className="text-decoration-none">
                  <span className="h1 text-uppercase text-primary bg-dark px-2">Multi</span>
                  <span className="h1 text-uppercase text-dark bg-primary px-2 ml-n1">Shop</span>
               </a>
            </div>
            <div className="col-lg-4 col-6 text-left">
               <form id="seachProdByNameForm">
                  <div className="input-group">
                     <input type="text" name="prodName" className="form-control" placeholder="Search for products" />
                     <div className="input-group-append">
                        <button type="submit" className="input-group-text bg-transparent text-primary">
                           <i className="fa fa-search"></i>
                        </button>
                     </div>
                  </div>
               </form>
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