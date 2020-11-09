import React, { Component, Fragment } from "react";
import Counter from "./counter";

export default class Counters extends Component {
  
/*render a expression with curlbrackets*/

  render() {
    console.log("Counters - Rendered");

      const { counters, onDelete, onIncrement, onDecrement } = this.props; {/*onReset*/ }

    return (
      <Fragment>
            {/*<button onClick={onReset} className="btn btn-primary btn-sm m- 2"> Reset </button>*/}
        <br />
          {counters.map(counter => (
            <Counter
              key={counter.id}
              onIncrement={onIncrement}
              onDecrement={onDecrement}
              counter={counter}
           />
           ))  
          }
      </Fragment>
    );
  }
}

{/*onDelete = { onDelete }*/ } /*is a function*/ /*bubbeling this event  to counter component*/