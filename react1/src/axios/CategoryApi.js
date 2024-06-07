import axios from 'axios';

axios.defaults.baseURL="http://localhost:5158";

export async function postCategory(category){
    console.log('Present from ps ',category);
  
    return await axios.post('Category/Add', category)       
    .then(function (response) {
      console.log('response',response); 
      return response;
    })
    .catch(function (error) {
      console.log(error);
    });
  }
  

export async function GetAllCategories(){

  return await axios.get('Category/GetAllCategories')    
  .then(function (response) {
    console.log('response',response); 
    return response.data;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function deleteCategory(categoryId){
  console.log('Category from delete');
  return await axios.delete(`Category/${categoryId}`)       
  .then(function (response) {
    console.log('response',response); 
    return response;
  })
  .catch(function (error) {
    console.log(error);
  });
}

export async function UpdateCategory(categoryId){
    return await axios.put(`Category/${categoryId}`)    
    .then(function (response) {
      console.log('response',response); 
      return response.data;
    })
    .catch(function (error) {
      console.log(error);
    });
  }

export async function FindCategoryByName(name){
    return await axios.get(`Category/${name}`)    
    .then(function (response) {
      console.log('response',response); 
      return response.data;
    })
    .catch(function (error) {
      console.log(error);
    });
  }


