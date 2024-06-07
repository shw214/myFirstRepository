// import React, { useState } from 'react';
// import { useNavigate } from "react-router-dom";
// // import {login} from "../axios/UserAPI"


// // const Login = () => {
// //     const [userId, setUserId] = useState('');
// //     const [password, setPassword] = useState('');
    
// //     const navigate = useNavigate()

// //     const checkUser=async()=>{
// //         let response= await login(userId, password).then(response=>{
// //           console.log("response in login", response);
// //           localStorage.setItem("UserId", userId);//שמירת userId

// //           if(response.data.statusCode===200){
// //             alert("welcome to your Calendar")
// //             navigate('/calendar', {replace: false})
// //           }
// //           else {
// //           alert("you are unknown user, Sign up now")
// //           navigate('/register',{replace: false} )}
// //         })



// //     }
   
// //     const enterStyle = {
// //       color: "blue",
// //       backgroundColor: "white",
// //       border:"1px solid black",
// //       height:"300px",
// //       width:"370px",
// //       fontFamily: "Sans-Serif",
// //       textAlign:'center',
// //       margin:"auto",
  
// //     };

// //    return( <div dir="rtl" style={enterStyle}>
// //          <h1>כניסה</h1>
// //        <label htmlFor="username">שם משתמש:</label>
// //           <input style={{height:"18px",width:"150px",margin:"10px"}}
// //             type="text"
// //             id="username"
// //             name="username"
// //             onChange={(e) => setUserId(e.target.value)}
// //             required
// //           />
// //           <br></br>
// //           <label htmlFor="password">סיסמה:</label>
// //           <input style={{height:"18px",width:"150px",margin:"10px"}}
// //             type="password"
// //             id="password"
// //             name="password"
// //             onChange={(e) => setPassword(e.target.value)}
// //             required
// //           />
// //           <br/>
// //           <button style={{height:"18px",width:"150px",margin:"10px"}} onClick={checkUser}> כניסה </button>
// //          <br></br>
//     //      {/* <button onClick={()=>navigate('/register')}> משתמש חדש? עבור להרשמה </button> */}
        

//     // </div>
// )}
// export default Login;