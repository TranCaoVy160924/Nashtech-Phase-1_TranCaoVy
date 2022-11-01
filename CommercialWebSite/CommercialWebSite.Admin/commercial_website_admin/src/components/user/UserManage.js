import React, { useState, useEffect } from "react";
import UserHeader from "../layout/header/user/UserHeader";
import Table from 'react-bootstrap/Table';
import UserService from "../../services/user";
import AuthService from "../../services/auth";
import { useForm } from "react-hook-form";
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

const UserManage = () => {
   const [users, setUsers] = useState([]);
   const [makeAdminSuccess, setMakeAdminSuccess] = useState(false);

   const { register, handleSubmit } = useForm();

   useEffect(() => {
      const loadTable = async () => {
         UserService.getAllAsync()
            .then(async data => {
               console.log("UserManager_ api response use: ", data);
               setUsers(data);
            })
      }
      loadTable();
      setMakeAdminSuccess(false);
   }, [makeAdminSuccess])

   const makeAdmin = (userId) => {
      console.log("UserManage_ make user admin: ", userId)
      AuthService.makeAdminAsync(userId)
         .then(data => {
            console.log("UserManage_ make admin succeeded: ", data);
            setMakeAdminSuccess(true);
         })
         .catch(error => {
            console.log("UserManage_ make admin failed: ", error);
         })
   }

   return (
      <React.Fragment>
         <UserHeader />
         <div className="px-4 mx-5">
            <Table id="user_table" className="display" striped bordered hover>
               <thead>
                  <tr>
                     <th className="text-center">Username</th>
                     <th className="text-center">First Name</th>
                     <th className="text-center">Last Name</th>
                     <th className="text-center">Role</th>
                     <th className="text-center">Make Admin</th>
                  </tr>
               </thead>
               <tbody>
                  {users.map(u => (
                     <tr key={u.id}>
                        <td className="text-center">{u.username}</td>
                        <td className="text-center">{u.firstName}</td>
                        <td className="text-center">{u.lastName}</td>
                        <td className="text-center">{u.role}</td>
                        <td className="d-flex justify-content-center">{
                           u.role === "Admin"
                              ? (
                                 <button className="btn-secondary" disabled>Make Admin</button>
                              )
                              : (
                                 <Form onSubmit={handleSubmit(() => makeAdmin(u.id))}>
                                    <Button type="submit" {...register("userId")}
                                       value={u.id} className="btn-primary">
                                       Make Admin
                                    </Button>
                                 </Form>
                              )
                        }</td>
                     </tr>
                  ))}
               </tbody>
            </Table>
         </div>
      </React.Fragment>
   )
}

export default UserManage;