import { render } from '@testing-library/react';
import  React from 'react';
import { Component } from 'react';
import { BrowserRouter as Router,Routes,Route,NavLink,Redirect } from 'react-router-dom';
import {Details} from '../Subcomponents/details';

import { useNavigate } from 'react-router-dom';

export default function CustomerDashboard(props){


// const transferHistory=()=>{
//     const history=useNavigate();
//  this.props.findHistory(history);
// }

    return(
        <>

        <div className='container'>
            <div className='container-body'>
               
            <nav className='navbar navbar-expand-lg navbar-light bg-light'>
                
                <navLink to='Customer/:Id'>Home</navLink>
                <navLink to='Customer/details'>Details</navLink>
            </nav>




            </div>
        </div>
        </>
        );
    


}

// export class CustomerDashboard extends Component{
//     render(){
//         return(
//             <div>gaand marao</div>
//         );
//     }
// }