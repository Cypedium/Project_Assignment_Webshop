import React, { Component, Fragment } from 'react';

export default class Create extends Component {
      
        initialState = { //clear the form
          ProductType: '',
          Number: '',
          Name: '',
          Description: '',
          Price: ''
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
        const {ProductType, Number, Name, Description, Price} = this.state;
        const {handleChange, submitForm} = this;
        
            return (
                    <Fragment>
                        <h2>Create New Product</h2>              
                        <form>
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
                            
                            <input type="button" value="Submit" onClick={submitForm} />                           
                        </form>
                    </Fragment>         
            );
    }
}