import axios from 'axios'  
import {  
  GET_USERS_REQUEST,  
  GET_USERS_SUCCESS,  
  GET_USERS_FAILURE  
} from './type' 
  
export const GethUsers = () => {  
  return (dispatch) => {  
    dispatch(getUsersRequest())  
    axios  
      .get('https://reqres.in/api/users')  
      .then(response => {  
        const users = response.data  
        console.log(response.data);  
        dispatch(getUsersSuccess(users.data))  
      })  
      .catch(error => {  
        dispatch(getUsersFailure(error.message))  
      })  
  }  
}  
  
export const getUsersRequest = () => {  
  return {  
    type: GET_USERS_REQUEST  
  }  
}  
  
export const getUsersSuccess = users => {  
  return {  
    type: GET_USERS_SUCCESS,  
    payload: users  
  }  
}  
  
export const getUsersFailure = error => {  
  return {  
    type: GET_USERS_FAILURE,  
    payload: error  
  }  
}  
