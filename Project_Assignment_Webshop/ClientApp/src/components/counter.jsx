import React, { Component, Fragment } from "react";

//This react-code we learn:
//  -JSX			-Props
//  -Rendering Lists		-Raising and Handling Events
//  -Conditional Rendering	-Lifting the State
//  -Handling Events		-Functional Components
//  -Updating the State		-Lifecycle Hooks
//---------------------------------------------------------------------------

export default class Counter extends Component { /*IS A CONTROLLED COMPONENT*/
// state = { 
    //value: this.props.counter.value /*was count before*/
    //tags: ['tag1', 'tag2', 'tag3']
//};

//  constructor() {
//    super();
//    this.handleIncrement = this.handleIncrement.bind(this); }

/* using arrow function to inherritate */
/*handleIncrement = product => {  /*product is a event*/
/*this.setState({value: this.state.count + 1 })
};*/ 

//Lifecycle Hooks
componentDidUpdate(prevProps, prevState) {
  console.log("prevProps", prevProps);
  console.log("prevState", prevState);
  if (prevProps.counter.value !== this.props.counter.value) {
    // Ajax call and get new data from the server
  }
}

componentWillUnmount() {
  console.log("Counter - Unmount");
  // here u can clean data as timers and listeners
  // before the component is deleted from the DOM
}

 render() {
    console.log("Counter  - Rendered");
    return ( 
      <Fragment> {/*Creating row*/}
        <span className={this.getBadgeClasses()}>{this.formatCount()}</span>
        <button 
          onClick={() => this.props.onIncrement(this.props.counter)} /*inline arg*/
          className="btn btn-secondary btn-sm"
        >
          +
        </button>
        {" "}
        <button 
          onClick={() => this.props.onDecrement(this.props.counter)} /*inline arg*/
          className="btn btn-secondary btn-sm"
        >
          -
        </button>
        <button
          onClick={() => this.props.onDelete(this.props.counter.id)} 
          className="btn btn-danger btn-sm m-2"
        >
        Delete
        </button> 
        <br /> {/* Preparing new row*/}   
      </Fragment>
    );
  }


  getBadgeClasses() {
    let classes = "badge m-2 badge-"; /*let=changable const*/ 
    classes += this.props.counter.value <= 0 ? "warning" : "primary";
    return classes;
  }

  formatCount() {
    /* object distructer */
    const { value } = this.props.counter; /*CHANGED: before this.state but no state exists now*/
    return value <= 0 ? "Zero" : value; /* was count before */
  } 
}