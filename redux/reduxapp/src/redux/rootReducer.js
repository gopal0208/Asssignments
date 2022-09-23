import { combineReducers } from 'redux'  
import Reducer from './reducer'  
  
const rootReducer = combineReducers({  
  user: Reducer  
})  
  
export default rootReducer  