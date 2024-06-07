import logo from './logo.svg';
import './App.css';
import AllCustomers from './componnents/customers';
import ProductsDemo from './componnents/homePage';
import BasicDemo from './componnents/presentView';
import DonorDemo from './componnents/donorManager';
function App() {
  return (
    <div className="App">
      {/* <AllCustomers></AllCustomers> */}
      {/* <BasicDemo></BasicDemo> */}
      {/* <ProductsDemo></ProductsDemo> */}
      <DonorDemo></DonorDemo>


    </div>
  );
}

export default App;
