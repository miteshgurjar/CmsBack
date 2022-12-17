import React, { Component } from 'react';

class Counter extends Component {
    state = { 
        count:0,
        tags : ['tag1','tag2','tag3']
     } 

     styles={

     }


    render() { 
        let classes='badge m-2 badge-';
        classes+= this.state.count === 0 ? "warning":"primary";
        return <>
        <span className='badge badge-warning m-2'>spannig
        </span>

        <ul>
            {this.state.tags.map(val=> <li key={val}>{val}</li> )}
        </ul>
        <h1 style={this.styles}>Hello World {this.state.count} </h1></>;
    }
}
 
export default Counter;