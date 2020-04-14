import React, { Component, Fragment } from "react";
import Counter from "./counter";

export default class Counters extends Component {
  
/*render a expression with curlbrackets*/

  render() {
    console.log("Counters - Rendered");

    const { counters, onReset, onDelete, onIncrement, onDecrement } = this.props;

    return (
      <Fragment>
        <button onClick={onReset} className="btn btn-primary btn-sm m- 2"> Reset </button>
        <br />
          {counters.map(counter => (
            <Counter
              key={counter.id}
              onDelete={onDelete} /*is a function*/ /*bubbeling this event  to counter component*/
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