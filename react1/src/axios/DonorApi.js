import axios from 'axios';

axios.defaults.baseURL="http://localhost:5158";

export async function postDonor(donor){
  console.log('Present from ps ',donor);

  return await axios.post('Donor/Add', donor)       
  .then(function (response) {
    console.log('response',response); 
    return response;
  })
  .catch(function (error) {
    console.log(error);
  });
}


export async function GetAllDonor(){

  return await axios.get('Donor/GetAllDonors')    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}

// export async function deleteDonor(donorId){
//   console.log('Donor from delete');
//   return await axios.delete(`Donor/${donorId}`)       
//   .then(function (response) {
//     console.log('response',response); 
//     return response;
//   })
//   .catch(function (error) {
//     console.log(error);
//   });
// }

export async function GetPresentByDonor(donoreId){
  return await axios.get(`Donor/${donoreId}`)    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function GetDonorByMail(mail){
  return await axios.get(`Donor/${mail}`)    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function GetDonorByName(name){
  return await axios.get(`Donor/${name}`)    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function UpdateDonor(donorId){
  return await axios.put(`Donor/${donorId}`)    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}