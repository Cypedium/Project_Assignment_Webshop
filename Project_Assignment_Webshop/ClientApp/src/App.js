import React, { Component, Fragment, } from 'react';
import axios from 'axios';
import Details from './components/Details';
import Create from './components/Create';
import List from './components/List';
import Edit from './components/Edit';
import NavBar from './components/NavBar';
import Counters from './components/counters';
import Cart from './components/Cart';

const API = 'https://localhost:44399/API/'; //Hur kommer jag åt min genererade API lista?

console.log("CleanAPI:" + API);
//const DEFAULT_QUERY = 'redux';

class App extends Component {
    //constructor(props) {
      //  super(props);

        state = {
            productList: [],

            cartList: [],
                
            counters: [
                { id: 1, value: 0 },
                { id: 2, value: 0 },  
                { id: 3, value: 0 }  
            ],

            indexList: true,
            createButtonClicked: false,
            addToCartButtonClicked: false,
            editButtonClicked: false,
            details: false,
            toggleSort: true,
            oldColumn: "",

            isLoading: false,
            error: null
        }
     //---END OF STATE---------------------------------------------------------------------------------------------------------------------------
      
   
    componentDidMount() {
        this.setState({ isLoading: true });
        axios.get(API)
            .then(result => this.setState({
                productList: result.data,
                isLoading: false
            }))
            .catch(error => this.setState({
                error,
                isLoading: false
            }));
    }
    

    //-----SHOPPING CART--------------------------------------------------------------------------------------------------------------------------------

    handleIncrement = counter => {
        const counters = [...this.state.counters]; /*clone the state*/
        const index = counters.indexOf(counter);
        counters[index] = { ...counter };
        counters[index].value++;
        this.setState({ counters });
    };

    handleDecrement = counter => {
        const counters = [...this.state.counters]; /*clone the state*/
        const index = counters.indexOf(counter);
        counters[index] = { ...counter };
        if (counters[index].value > 0) {
            counters[index].value--;
            this.setState({ counters });
        }
    };

   

    handleReset = () => {
        const counters = this.state.counters.map(c => { /*this creates an array*/
            c.value = 0;
            return c;
        });
        this.setState({ counters });
    };

    handleDelete = (counterId) => {
        const counters = this.state.counters.filter(c => c.id !== counterId);
        this.setState({ counters: counters }) /*override property with constant*/
    };
    //-----------------------------------------------------------------------------------------------------------------

    
    //---PREPARED FUNCTION FOR PROJECT WEBSHOP------------------------------------------------------------------------
    addProductToCart = Id => {
        const { productList, addToCartButtonClicked } = this.state;
        console.log("add:" + Id);
        this.setState(
            {
                cartList: productList.filter((cartProduct) => { return cartProduct.Id === Id }),

            });
        this.setState({ addToCartButtonClicked: true });
        this.setState({ indexList: false})
            console.log("button:" + addToCartButtonClicked);
    }
    //-----------------------------------------------------------------------------------------------------------------

    detailProduct = Id => {
        const { productList, } = this.state;
        this.setState(
            {
                productListView: productList.filter((aProduct) => { return aProduct.Id === Id })
            });
        this.setState({ details: true });
        this.setState({ indexList: false });
    }

    editProduct = Id => {
        const { productList } = this.state;
        this.setState(
            {
                editButtonClicked: true,
                productListEdit: productList.filter((aProduct) => { return aProduct.Id === Id })
            });
    }

    handleSubmitCreate = product => {
        this.setState({ productList: [...this.state.productList, product] });
        this.setState({ createButtonClicked: false })
    }

    handleSubmitEdit = product => {
        this.setState({ productList: [...this.state.productList, product] });
        this.setState({ editButtonClicked: false })
    }

    sortByString = (column) => { /* use arrowfunction to binds this */
        const { productList, toggleSort, oldColumn } = this.state;
        this.setState({
            carList: productList.sort((a, b) => (
                toggleSort === true
                    ? ((a[column].toLowerCase() < b[column].toLowerCase()) || column !== oldColumn)
                        ? -1
                        : ((a[column].toLowerCase() > b[column].toLowerCase()) || column !== oldColumn)
                            ? 1
                            : 0
                    :
                    ((a[column].toLowerCase() > b[column].toLowerCase()) || column !== oldColumn)
                        ? -1
                        : ((a[column].toLowerCase() < b[column].toLowerCase()) || column !== oldColumn)
                            ? 1
                            : 0
            )),
            toggleSort:
                toggleSort === true
                    ? false
                    : true,
            oldColumn: column
        })
    }

    sortByInt = (column) => { /* use arrowfunction to bind this */
        const { productList, toggleSort, oldColumn } = this.state;
        this.setState({
            productList: productList.sort((a, b) => (
                toggleSort === true || column !== oldColumn
                    ? parseFloat(a[column]) - parseFloat(b[column])
                    : parseFloat(b[column]) - parseFloat(a[column])
            )),
            toggleSort:
                toggleSort === true
                    ? false
                    : true,
            oldColumn: column
        })
    }

    //----------------------------------------------------------------------------------------------------------------------

    render() {
        console.log("App - Rendered");
        console.log("ComponentDidMount:" + this.productList);
        const { addToCartButtonClicked, createButtonClicked, details, editButtonClicked, counters, indexList } = this.state;
        return (
            <Fragment>
                <NavBar
                    totalCounters={counters.filter(c => c.value > 0).length} /*only display values greater than zero*/
                    onReset={this.handleReset} /*new code*/
                />
                
                <table class="center"> {/* App Table */}
                    <tr> 
                        <td></td>
                        <td>
                            {/*Head*/}
                            {(indexList && !(details && addToCartButtonClicked)) ? ( <Fragment> <h1> List of Food        </h1> </Fragment> ) : ( null ) } 
                            {(details && !(indexList && addToCartButtonClicked)) ? ( <Fragment> <h1> Details             </h1> </Fragment> ) : ( null ) } 
                            {(addToCartButtonClicked && !(details && indexList)) ? ( <Fragment> <h1> Add Product To Cart </h1> </Fragment> ) : ( null ) }
                            
                            {/*<button className="btn btn-info" onClick={() => this.setState({ createButtonClicked: true })}>Create new Product</button>*/}
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            {
                                (indexList) ?  (
                                    <Fragment>                                       
                                        {/*List of Products*/}
                                        <p>Choose your Food Product to your order.</p>
                                        <List
                                            productList={this.state.productList}
                                            detailProduct={this.detailProduct}
                                            addProductToCart={this.addProductToCart}
                                            removeProduct={this.removeProduct}
                                            sortByInt={this.sortByInt}
                                            sortByString={this.sortByString}
                                        />
                                    </Fragment>                                      
                                ) : (null)
                            }
                            {    
                                (details) ? (
                                    <Fragment>
                                        {/*Details*/}
                                        <p>These are the details for the product</p>
                                        <Details
                                            productListView={this.state.productListView}
                                            removeProduct={this.removeProduct}
                                            editProduct={this.editProduct} />
                                        <span>
                                            <button className="btn btn-secondary" onClick={() => this.setState({
                                                indexList: true,
                                                details: false
                                            })}> Back to List </button>
                                        </span>
                                    </Fragment>
                                ) : (null)
                            }
                       
                            {
                                (addToCartButtonClicked) ? (
                                    <Fragment>
                                        {/*Add Product To Cart*/}
                                        <p>Do you want to order the product?</p>
                                        <td>
                                            <Cart
                                                cartList={this.state.cartList}
                                            />
                                        </td>
                                        <td> 
                                            <main className="container">
                                                <Counters
                                                    counters={counters}
                                                    onIncrement={this.handleIncrement}
                                                    onDecrement={this.handleDecrement}     
                                                />
                                            </main>
                                        </td>   
                                        <span>
                                            <button className="btn btn-secondary" onClick={() => this.setState({
                                                indexList: true,
                                                addToCartButtonClicked: false
                                            })}> Back to List </button>
                                        </span>
                                    </Fragment>
                                ) : (null)
                            }
                        </td>
                        <td></td>
                    </tr>
                </table>                            
            </Fragment>
        );
    }
}

export default App;
{/*Optional code*/ }
{/*onDelete = { this.handleDelete }
  onReset={this.handleReset} 

    handleReset = () => {
        const counters = this.state.counters.map(c => { /*this creates an array
           c.value = 0;
           return c;
           });
        this.setState({ counters });
    };*/}

{/* New Developments*/}
{/*
                                addToCartButtonClicked ? (
                                    <Create
                                        handleSubmitCreate={this.handleSubmitCreate}
                                    />

                                ) : editButtonClicked ? (
                                    <Edit
                                        productListEdit={this.state.productListEdit}
                                        handleSubmitEdit={this.handleSubmitEdit}
                                    />
                                ): (null)
                            
                                
                            <span>
                            <button onClick={() => this.setState({ indexList: true })}> Back to List </button>
                            </span>
                            */}