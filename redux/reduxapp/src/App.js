import './App.css';
import View from './View';
import { Provider } from "react-redux";
import store from "./redux/store";


function App() {
  return (
    <Provider store={store}>
      <div className="App">
        <View />
      </div>
    </Provider>
  );
}

export default App;
