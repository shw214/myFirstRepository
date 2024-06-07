import axios from 'axios';

axios.defaults.baseURL="http://localhost:5158";

export async function postPresent(present){
  console.log('Present from ps ',present);

  return await axios.post('Present/Add', present)       
  .then(function (response) {
    console.log('response',response); 
    return response;
  })
  .catch(function (error) {
    console.log(error);
  });
}
export async function GetAllPresent(){

  return await axios.get('Present/GetAllPresents')    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function deletePresent(presentId){
  console.log('Present from delete',presentId);
  return await axios.delete(`Present/${presentId}`)       
  .then(function (response) {
    console.log('response',response); 
    return response;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function UpdatePresent(presentId){
  return await axios.put(`Present/${presentId}`)    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function GetPresentByName(presentName){
  return await axios.get(`Present/${presentName}`)    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function GetPresentByDonor(donorName){
  return await axios.get(`Present/${donorName}`)    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}