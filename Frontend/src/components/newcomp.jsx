import React,{Component} from "react";

export default class Newcomp extends Component{

state={
    message:"sign in please",
    isSigned:false,
    items:0
}


 onClickHandler=()=>{

if(!this.state.isSigned){

    this.setState({isSigned:true,message:"singed in succesfully please logout"});
}
 else{
     this.setState({isSigned:false,message:"please singin"})
 }
}

changeButton=()=>{

    if(this.state.isSigned){
        return <button onClick={this.onClickHandler}>{this.state.message}</button>
    }
    else{
        return <button onClick={this.onClickHandler}>{this.state.message}</button>
    }

}

render(){
    let button;
    if(!this.state.isSigned){
        button =<button onClick={this.onClickHandler} className="btn btn-primary">sign in</button>
    }
    else{
        button=<button onClick={this.onClickHandler} className="btn btn-Danger">logout</button>
    }
return (
<>
<p>{this.state.message}</p>
<div>{button}</div>
</>
)

}


}