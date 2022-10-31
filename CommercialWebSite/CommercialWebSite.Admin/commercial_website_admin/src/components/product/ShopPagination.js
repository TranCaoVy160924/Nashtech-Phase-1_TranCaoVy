import { useEffect, useState } from "react";

const ShopPagination = ({ pagination, changePage }) => {
   const [pageLink, setPageLink] = useState([]);
   
   useEffect(() => {
      let tempPageLink = [];
      for (let i = 1; i <= pagination.pageCount; i++) {
         if (i === pagination.page) {
            tempPageLink.push(
               <li key={i} className="page-item active">
                  <button className="page-link" onClick={() => changePage(i)}>{i}</button>
               </li>
            );
         }
         else {
            tempPageLink.push(
               <li key={i} className="page-item">
                  <button className="page-link" onClick={() => changePage(i)}>{i}</button>
               </li>
            );
         }
      }
      console.log("ShopPagination_ temp page link: ", tempPageLink);
      setPageLink(tempPageLink);
   }, [pagination.page, pagination.pageCount])

   return (
      <>
         {pageLink}
      </>
   )
}

export default ShopPagination;