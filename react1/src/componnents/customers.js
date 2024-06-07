import { useEffect, useState } from "react";
import { getAllCustomers,postCustomer,deleteCustomer } from "../axios/CustomerApi";

const AllCustomers = (props) => {
const [firstName, setFirstName] = useState();
const [lastName, setLastName] = useState();
const [email, setEmail] = useState();
const [phone, setPhone] = useState();
const [password, setPassword] = useState('');

const [customers,setCustomers]=useState([])
const [addCustomers,setAddCustomers]=useState([])
const Save = () => {
    customerObj(firstName, lastName, email, phone,password);
}
const customerObj = async (firstName, lastName, email, phone) => {
    // console.log('startDate',startDate);
    const customer = {
        firstName,
        lastName,
        email,
        phone,
        password
    }
    let response = await postCustomer(customer).then(response => {
        if (response.data.statusCode === 200) {
          console.log("the customer succeed");
        }
      })
}


const  getAll=async()=>
{
    const a=await getAllCustomers();
    setCustomers(a)
}

    useEffect(() => {
        getAll();
       
    }
    , []) ;
    const enterStyle = {
        color: "blue",
        backgroundColor: "white",
        border:"1px solid black",
        height:"300px",
        width:"370px",
        fontFamily: "Sans-Serif",
        textAlign:'center',
        margin:"auto",
    
      };
return (
    <>
    {customers&&customers.map(x=> <h1>{x.firstName}</h1>)}

    <div dir="rtl" style={enterStyle}>
        <h1>רישום משתמש חדש</h1>
        {/* <form onSubmit={handleRegistration}> */}
        <div>
          {/* <label htmlFor="username">שם משתמש:</label>
          <input
            type="text"
            id="username"
            name="username"
            onBlur={(e) => setUserId(e.target.value)}
            required
          /> */}
          <br></br>
          <label htmlFor="password">סיסמה:</label>
          <input
            type="password"
            id="password"
            name="password"
            onBlur={(e) => setPassword(e.target.value)}
            required
          />
          <br />
          <label htmlFor="firstName">שם פרטי:</label>
          <input
            type="text"
            id="firstName"
            name="firstName"
            onBlur={(e) => setFirstName(e.target.value)}
            required
          />
          <br />
          <label htmlFor="lastName">שם משפחה:</label>
          <input
            type="text"
            id="lastName"
            name="lastName"
            onBlur={(e) => setLastName(e.target.value)}
            required
          />
          <br />
          <label htmlFor="phone"> טלפון:</label>
          <input
            type=""
            id="phone"
            name="phone"
            onBlur={(e) => setPhone(e.target.value)}
            required
          />
          <br />
          <label htmlFor="email">מייל:</label>
          <input
            type="email"
            id="email"
            name="email"
           onBlur={(e) => setEmail(e.target.value)}
            required
          />
          <br />
          {/* <button type="submit">רישום</button> */}
          <button onClick={Save}>רישום</button>

        </div>
      </div>
 </> 
)
}


export default AllCustomers;
