import React, { Component, Fragment } from 'react';

export default class Edit extends Component {
    initialState = {
        brand: this.props.carListEdit[0].brand,
        model: this.props.carListEdit[0].model,
        year: this.props.carListEdit[0].year,
        price: this.props.carListEdit[0].price
    }
    
    state = this.initialState;

    handleChange = event => {
        const { name, value } = event.target;
        this.setState( { [name]: value } );
    }

    submitForm = () => {
        this.props.handleSubmitEdit(this.state);
        this.setState(this.initialState);
    }

    /* Use this function to debug my code */

    componentDidMount = () => {
    }


    render() {
        const {brand, model, year, price} = this.state;
        const {handleChange, submitForm} = this;
           
            return (
                    <Fragment>
                        <h2>Edit Car</h2>              
                        <form className="from-group">
                            <label for="">Brand</label>
                            <input type="text" name="brand" id="brand" value={brand} onChange={handleChange} />
                            <br />
                            <label for="">Model</label>
                            <input type="text" name="model" id="model" value={model} onChange={handleChange} />
                            <br />
                            <label for="">Year</label>
                            <input type="text" name="year" id="year" value={year} onChange={handleChange} />
                            <br />
                            <label for="">Price</label>
                            <input type="text" name="price" id="price" value={price} onChange={handleChange} />
                            <br />
                            <input className="btn btn-primary" type="button" value="Submit" onClick={submitForm} />                          
                        </form>
                    </Fragment>         
            );
    }
}