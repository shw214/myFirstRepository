import axios from 'axios';

axios.defaults.baseURL="http://localhost:5158";

export async function GetAllPurchase(){

  return await axios.get('Purchase/GetAllPurchases')    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function postPurchase(purchase){
  console.log('Purchase from ps ',purchase);

  return await axios.post('Purchase/Add', purchase)       
  .then(function (response) {
    console.log('response',response); 
    return response;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function deletePurchase(purchaseId){
  console.log('Purchase from delete');
  return await axios.delete(`Purchase/${purchaseId}`)       
  .then(function (response) {
    console.log('response',response); 
    return response;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function FindPurchaseById(Id){
  return await axios.get(`Purchase/${Id}`)    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}
  export async function GetCustomerDetails(purchaseId){
    return await axios.get(`Purchase/${purchaseId}`)    
    .then(function (response) {
      console.log('response',response); 
      return response.data;
    })
    .catch(function (error) {
      console.log(error);
    });
  }