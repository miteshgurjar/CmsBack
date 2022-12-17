import logo from './logo.svg';
import './App.css';
import { BrowserRouter  ,Routes, Route, Link, Outlet, useNavigate } from 'react-router-dom';
import Login from './components/login'; 
import Navigation from './components/Navigation';
import CustomerDashboard from './components/Customers/customerDashboard';
// import CustomerDashboard from './components/Customers/customerDashboard';
function App() {
  return (
     <div>
        <BrowserRouter>
          <Routes>
              <Route exact path="/" element={<>Home</>} />
              <Route exact path="/login" element={<Login />} />  
              <Route exact path="/Customer/:Id" element={<CustomerDashboard />} />  
          </Routes>
        </BrowserRouter>
    </div>
  );
}

export default App;
