import { Component } from "react"
import React from "react"




function getText (val) {

    


    return 
    (<>
        <button onClick={this.changeButtonText}>
            <getButtonText isLoggedIn={this.state.isLoggedIn}>
            </getButtonText>
        </button>
    
   
     
        <p>
            {this.state.textDisplay}
        </p>
        <button onClick={onClickHandler}>
            <getButtonText isLoggedIn={this.state.isLoggedIn}>
            </getButtonText>
        </button>
    
    
    </>)

}

function getButtonText(val){
    if(!val)
    {
        return 
        <>
        login
        </>
    }
    else{
        return 
        <>
        logout
        </>
    }
}

class Changable extends Component{
state={
    isLoggedIn:false,
    textDisplay:"please login"
};


changeButtonText(){
if(!this.state.isLoggedIn)
{
this.setState({isLoggedIn:true,textDisplay:"logout"});
}
else{
    this.setState({isLoggedIn:false,textDisplay:"please login"});
}

};

render(){
return (
<>
<div>empty</div>;
{this.state.isLoggedIn}? <><getText ref={this.state}></getText></>:<><getText isLoggedIn={this.state.isLoggedIn}></getText></>
</>);
}





}





export default Changable;