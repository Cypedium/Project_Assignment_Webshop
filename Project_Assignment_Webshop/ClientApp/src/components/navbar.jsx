import React, { Component, Fragment } from "react"; /*imrc*/

class NavBar extends Component { /*object desctructure {} needs no props*/
  render() {
  /* console.log("Navbar- Rendered"); */
      return (
            <nav className="navbar navbar-light bg-light">
                <a className="navbar-brand" href="#">
                      <button onClick={this.props.onReset} className="btn btn-primary btn-sm m- 2"> Reset Cart </button>
                      {"      "}
                        Cart{" "}
                    <span className="badge badge-pill badge-secondary">
                        {this.props.totalCounters}
                    </span>
                </a>
             </nav>
    );
  }
}

export default NavBar;