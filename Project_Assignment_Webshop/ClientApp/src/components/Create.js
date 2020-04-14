import React, { Component, Fragment } from 'react';

export default class Create extends Component {
      
        initialState = { //clear the form
          brand: '',
          model: '',
          year: '',
          price: ''
        }
    
        state = this.initialState
      
    handleChange = event => {
        const { name, value } = event.target;
        this.setState( { [name]: value } );
    }

    submitForm = () => {
        this.props.handleSubmitCreate(this.state);
        this.setState(this.initialState);
    }
    
    render() {
        const {brand, model, year, price} = this.state;
        const {handleChange, submitForm} = this;
        
            return (
                    <Fragment>
                        <h2>Create New Car</h2>              
                        <form>
                            <label for="">Brand</label>
                            <input type="text" name="brand" id="brand" value={brand} onChange={handleChange} />

                            <label for="">Model</label>
                            <input type="text" name="model" id="model" value={model} onChange={handleChange} />

                            <label for="">Year</label>
                            <input type="text" name="year" id="year" value={year} onChange={handleChange} />

                            <label for="">Price</label>
                            <input type="text" name="price" id="price" value={price} onChange={handleChange} />
                            
                            <input type="button" value="Submit" onClick={submitForm} />                           
                        </form>
                    </Fragment>         
            );
    }
}