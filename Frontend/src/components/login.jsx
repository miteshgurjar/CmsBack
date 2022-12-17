import React from 'react';
import { Component } from 'react';
import Select from 'react-select';
import { Navigate, redirect, useNavigate, Redirect } from 'react-router-dom';
import {withRoute} from 'react-router';
import axios from 'axios';
import customerDashboard from '../components/Customers/customerDashboard'
export default class Login extends Component{
  Owners="http://localhost:62023/api/Owners/" ;
  Customers="http://localhost:62023/api/Customers/";

  users=[{label:"Owner",value:1},{label:"Customer",value:2},{label:"Admin",value:3}];
  
  constructor(props){
    super(props)
    this.state={
      email:"",
      number:"",
      password:"",
      owners:null,
      customers:null,
      selectedOption: null,
      customer:null,
      owner:null,
      admin:null,
      isValidated:false,
      getHistory:''
      };

      // this.handelValidation=this.handelValidation.bind(this.state);
      // this.handelChanges=this.handelChanges.bind(this)
      
  }

  // handelOwner


// handelValidation=()=>{


// if((this.state.email).length >5){
// this.setState(this.state.isValidated=true);
// }
// else{

// }

// }

handelSubmit=(e)=>{
e.preventDefault();

console.log(this.state.selectedOption);
if(this.state.selectedOption.label === "Owner")
{

}
else if(this.state.selectedOption.label === "Customer")
{
 
  this.loadCustomerWithMail(this.state.email);
  
  
    // console.log("inside customer");
   
     
    
    
  
  

}
else if(this.state.selectedOption.label === "Admin")
{

}


alert(this.state.password);

}
 handelChanges=(e)=>{
 
  }

  loadAllOwners=async()=>{
    await fetch( (this.Owners+"GetAllOwners"),{
      method: 'GET'
    }).
    then(e=>e.json()).
    then(res=>{
      this.setState(this.state.owners=res);
      console.log(this.state.owners);
    })
  }

   loadAllCustomers=async()=>{
    await fetch((this.Customers +"AllCustomers"),{
      method:'GET'
    }).
   then(res=> res.json())
  .then(res=>{
    this.setState(this.state.customers=res);
    console.log(this.state.customers);
  } ).catch(e=> alert("cannot find object" + e));
  }

  pathHistory=(e)=>{
this.setState(this.state.getHistory=e);
console.log(this.state.getHistory);
  }

  loadCustomerWithMail=async()=>{
    // const history=useNavigate();
    // console.log(history);
    console.log(this.props.params);
         await fetch((this.Customers +"Customer"+"/"+this.state.email),{
      method:'GET'
    }).
   then(res=> res.json())
  .then(res=>{
    this.setState(this.state.customer=res);
    console.log(res);
  
    // navigate('/Customer');
    if(this.state.customer.customerEmail === this.state.email && this.state.customer.customerPassword === this.state.password){
      
    // console.log(this.state.customer);
    // history('/customer');
    // const newHistory=useNavigate();

    // console.log(newHistory);
  
    // <customerDashboard  findHistory={this.pathHistory}></customerDashboard>

    window.location='/Customer/'+this.state.customer.CustomerId;
    }
    else{
      // redirect('/login');
    }
  } ).catch(e=> alert("cannot find object" + e));

  
  }

  loadOwnerWithMail=async()=>{
    await fetch((this.Customers +"Customer"+"/"+this.state.email),{
      method:'GET'
    }).
   then(res=> res.json())
  .then(res=>{
    this.setState(this.state.customer=res);
  } ).catch(e=> alert("cannot find object" + e));
  }

  componentDidMount(){
     
    this.loadAllOwners();
    this.loadAllCustomers();
   
  }

  handelUserSelection = (selectedOption) => {
    // this.setState(this.state.hasIdentity = selectedOption.label);
    this.setState({ selectedOption });
  };

    render(){
        
        return(
         <>
  <section className="vh-100">
  <div className="container py-5 h-100">
    <div className="row d-flex align-items-center justify-content-center h-100">
    {/* <div className="col-md-2 col-lg-7 col-xl-6">
        {/* <img
          src="https://mdbcdn.b-cdn.net/img/Photos/new-templates/bootstrap-login-form/draw2.svg"
          className="img-fluid"
          alt="Phone image"
        /> 
      </div> */
      }
      <div className="col-md col-lg-5 col-xl-5 offset-xl-1">
        <form onSubmit={this.handelSubmit} >
           {/* Email input */} 
          <div className="form-outline mb-4">
            <input
              type="email"
              id="form1Example13"
              
              className="form-control form-control-lg"
              onChange={(e)=>{ 
                 this.setState({email:e.target.value});
                }
                }
            />
            <label className="form-label" htmlFor="form1Example13">
              Email address
            </label>
          </div>
        {/* Password input */}
          <div className="form-outline mb-4">
            <input
              type="password"
              id="form1Example23"
              className="form-control form-control-lg"
              onChange={(e)=>this.setState({password:e.target.value})}
            />
            <label className="form-label" htmlFor="form1Example23">
              Password
            </label>
          </div>

          <div className="form-outline mb-4">
           <Select value={this.state.selectedOption} onChange={this.handelUserSelection} options={this.users}/>
          </div>

          <div className="d-flex justify-content-around align-items-center mb-4">
            {/* Checkbox */} 
            <div className="form-check">
              <input
                className="form-check-input"
                type="checkbox"
                defaultValue=""
                id="form1Example3"
                defaultChecked=""
              />
              <label className="form-check-label" htmlFor="form1Example3">
                Remember me
              </label>
            </div>
            <a href="#!">Forgot password?</a>
          </div>
           {/* Submit button */} 
          <button type="submit" className="btn btn-primary btn-lg btn-block">
            Sign in
          </button>
          <div className="divider d-flex align-items-center my-4">
            <p className="text-center fw-bold mx-3 mb-0 text-muted">OR</p>
          </div>
          <a
            className="btn btn-primary btn-lg btn-block"
            style={{ backgroundColor: "#3b5998" }}
            href="#!"
            role="button"
          >
            <i className="fab fa-facebook-f me-2" />
            Continue with Facebook
          </a>
          <a
            className="btn btn-primary btn-lg btn-block"
            style={{ backgroundColor: "#55acee" }}
            href="#!"
            role="button"
          >
            <i className="fab fa-twitter me-2" />
            Continue with Twitter
          </a>
        </form>
      </div>
    </div>
  </div>
</section>

      </>);
    }


}