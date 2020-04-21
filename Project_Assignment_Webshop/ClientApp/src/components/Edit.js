import React, { Component, Fragment } from 'react';

export default class Edit extends Component {
    initialState = {
        brand: this.props.productListEdit[0].brand,
        model: this.props.productListEdit[0].model,
        year: this.props.productListEdit[0].year,
        price: this.props.productListEdit[0].price
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
        const { ProductType, Number, Name, Description, Price} = this.state;
        const {handleChange, submitForm} = this;
           
            return (
                    <Fragment>
                        <h2>Edit Product</h2>              
                        <form className="from-group">
                            <label for="">ProductType</label>
                            <input type="text" name="ProductType" id="ProductType" value={ProductType} onChange={handleChange} />

                            <label for="">Number</label>
                            <input type="text" name="Number" id="Number" value={Number} onChange={handleChange} />

                            <label for="">Name</label>
                            <input type="text" name="Name" id="Name" value={Name} onChange={handleChange} />

                            <label for="">Description</label>
                            <input type="text" name="Description" id="Description" value={Description} onChange={handleChange} />

                            <label for="">Price</label>
                            <input type="text" name="Price" id="Price" value={Price} onChange={handleChange} />

                            <input className="btn btn-info" type="button" value="Submit" onClick={submitForm} />                         
                            </form>
                    </Fragment>         
            );
    }
}

                        