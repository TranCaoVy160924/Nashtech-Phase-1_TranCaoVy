import React, { useContext } from 'react';
import { AppContext } from '../../App';
import CategoryDisplay from './CategoryDisplay';
import CategoryHeader from '../layout/header/category/CategoryHeader';
import { Table, Button } from 'react-bootstrap';
import { Link } from 'react-router-dom';

const CategoryManage = () => {
   const context = useContext(AppContext);
   const categories = context.categories;

   return (
      <React.Fragment>
         <CategoryHeader />
         <div className="container-fluid pt-5 pb-3">
            <div className="row px-xl-5 ms-5 me-5">
               {/* <div className="row px-xl-5">
               {categories.map(c => (
                  <React.Fragment key={c.categoryId}>
                     <CategoryDisplay category={c} />
                  </React.Fragment>
               ))}
            </div> */}
               <Table id="user_table" className="display" striped bordered hover>
                  <thead>
                     <tr>
                        <th className="text-center">Id</th>
                        <th className="text-center">Name</th>
                        <th className="text-center">Product</th>
                        <th className="text-center">To Category Page</th>
                     </tr>
                  </thead>
                  <tbody>
                     {categories.map(c => (
                        <tr key={c.categoryId}>
                           <td className="text-center">{c.categoryId}</td>
                           <td className="text-center">{c.categoryName}</td>
                           <td className="text-center">{c.productCount}</td>
                           <td className="d-flex justify-content-center">
                              <Link to={`/category/${c.categoryId}`}>
                                 <Button className="btn-primary">
                                    Detail
                                 </Button>
                              </Link>
                           </td>
                        </tr>
                     ))}
                  </tbody>
               </Table>
            </div>
         </div>
      </React.Fragment>
   )
}

export default CategoryManage;