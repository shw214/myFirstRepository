import axios from 'axios';

axios.defaults.baseURL="http://localhost:5158";

export async function getAllCustomers(){

  return await axios.get('Customer/getAllCustomers')    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function postCustomer(customer){
  console.log('customer from ps ',customer);

  return await axios.post('Customer/Add', customer)       
  .then(function (response) {
    console.log('response',response); 
    return response;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function deleteCustomer(customerId){
  console.log('customer from delete');
  return await axios.delete(`Customer/${customerId}`)       
  .then(function (response) {
    console.log('response',response); 
    return response;
  })
  .catch(function (error) {
    console.log(error);
  });
}
export async function UpdateCustomer(newCustomer,customerId){
  console.log('customer from delete');
  return await axios.put(`Customer/${customerId}`,newCustomer)       
  .then(function (response) {
    console.log('response',response); 
    return response;
  })
  .catch(function (error) {
    console.log(error);
  });
}
export async function FindCustomerByName(Name){

  return await axios.get(`Customer/${Name}`)    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}
export async function FindCustomerById(Id){

  return await axios.get(`Customer/${Id}`)    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}


