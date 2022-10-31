import React, { useContext } from 'react';
import { AppContext } from '../../App';
import CategoryDisplay from './CategoryDisplay';

const CategoryManage = () => {
   const context = useContext(AppContext);
   const categories = context.categories;

   return (
      <div className="container-fluid pt-5 pb-3">
         <div className="row px-xl-5">
            {categories.map(c => (
               <React.Fragment key={c.categoryId}>
                  <CategoryDisplay category={c} />
               </React.Fragment>
            ))}

         </div>
      </div>
   )
}

export default CategoryManage;