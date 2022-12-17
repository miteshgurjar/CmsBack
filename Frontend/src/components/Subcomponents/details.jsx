import  {React,useEffect,useState} from 'react';
import { Component} from 'react-dom';
import { useParams } from 'react-router-dom';


 function Details(props)  {

 
const [detail,setDetails]=useState([{ ownerFullName:"",
ownerId:0,
ownerEmail:"",
ownerPassword:"",
serviceId:0,
serviceName:"",
owners:null,
customerId:"",
customerFullName:"",
customerEmail:"",
customer:null,
Owner:null,
Admin:null}]);



const id=useParams();


  

const getCustomerByCustomerId=(e)=>
{
    fetch('http://localhost:62023/api/Customers/'+e)
    .then(e=>{
       return  e.json();
    })
    .then(e=>{detail.customer=e;
    })
    .catch(e=>{
        alert(e+"not found");
    });
}

const displayDetails = () => {

    // props.map()
    const identity=props.identity;
    const passedObj=detail.customer;
    const display=null;
    {
            if(identity === "customer")
            {
                display = <>
                <div>
                    <div className='container '>
                   { passedObj.map(e => {return <><div><span>{e.detail}</span> : </div></>}) }

                    </div>
                </div>
                </>;
            }
            else if(identity === "owner")
            {
                display = <>
                <div>
                    <div className='container '>
                    

                    </div>
                </div>
                </>
            }
            else if(identity === "Admin")
            {
                display = <>
                <div>
                    <div className='container '>
                    

                    </div>
                </div>
                </>
            }
    }

    return (
    <div>
      {display};
    </div>);
}
}


export default Details;