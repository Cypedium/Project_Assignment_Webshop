import React, { Component, Fragment, } from 'react';
import axios from 'axios';
import Details from './components/Details';
import Create from './components/Create';
import List from './components/List';
import Edit from './components/Edit';
import NavBar from './components/navbar';
import Counters from './components/counters';

const API = 'https://localhost:44399/API/'; //Hur kommer jag åt min genererade API lista?

console.log("CleanAPI:" + API);
//const DEFAULT_QUERY = 'redux';

class App extends Component {
    //constructor(props) {
      //  super(props);

        state = {
            productList: [],
                
            counters: [
                { id: 1, value: 0 },
                { id: 2, value: 0 },
                { id: 3, value: 0 },
                { id: 4, value: 0 }
            ],

            createButtonClicked: false,
            addToCartButtonClicked: false,
            editButtonClicked: false,
            details: true,
            showEditCar: false,
            toggleSort: true,
            oldColumn: "",

            isLoading: false,
            error: null
        }
        //---END OF STATE-----------------------------------------------------------------------------------------------------------------------------------
    //}   
   
    componentDidMount() {
        this.setState({ isLoading: true });
        axios.get(API)
            .then(result => this.setState({
                productList: result.data, //before result.data.productList

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

    //------MANAGE CAR-------------------------------------------------------------------------------------------------
    removeCar = Id => {
        const { productList } = this.state;
        this.setState(
            {
                carList: productList.filter((aProduct) => { return aProduct.Id !== Id })
            });
    }

    //---PREPARED FUNCTION FOR PROJECT WEBSHOP------------------------------------------------------------------------
    addProductToCart = Id => {
      const { productList } = this.state;
    }
    //-----------------------------------------------------------------------------------------------------------------

    detailProduct = Id => {

        const { productList } = this.state;
        this.setState(
            {
                productListView: productList.filter((aProduct) => { return aProduct.Id === Id })
            });
        this.setState({ details: false });
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

    sortByInt = (column) => { /* use arrowfunction to binds this */
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
        const { addToCartButtonClicked, createButtonClicked, details, editButtonClicked, counters } = this.state;
        return (
            <Fragment>
                <NavBar
                    totalCounters={counters.filter(c => c.value > 0).length} /*only display values greater than zero*/
                />

                <table> {/* Head */}
                    <tr>
                        <td></td>
                        <td>
                            <h1>Handle Products</h1>
                            <button className="btn btn-info" onClick={() => this.setState({ createButtonClicked: true })}>Create new Product</button>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            {details ? (
                                <Fragment>
                                    <h2>List of Products</h2>
                                    <List productList={this.state.productList}
                                        detailProduct={this.detailProduct}
                                        removeProduct={this.removeProduct}
                                        sortByInt={this.sortByInt}
                                        sortByString={this.sortByString}   
                                    />
                                    {/*
                                     *<span>
                                    <button className="btn btn-secondary" onClick={() => this.setState({ addToCartButtonClicked: true })}> AddToCart </button>
                                    </span>*/
                                    }
                                </Fragment>
                            ) : (
                                    <Fragment>
                                        <h2>Details</h2>
                                        <span>
                                            <button className="btn btn-secondary" onClick={() => this.setState({ details: true })}> Back to List </button>
                                        </span>
                                        <Details
                                            productListView={this.state.productListView}
                                            removeProduct={this.removeProduct}
                                            editProduct={this.editProduct} />
                                    </Fragment>
                                )
                            }
                            <br />
                        </td>
                        <td>
                            {createButtonClicked ? (
                                <Create handleSubmitCreate={this.handleSubmitCreate} />
                            )
                            : editButtonClicked ? (
                                <Edit
                                    productListEdit={this.state.productListEdit}
                                    handleSubmitEdit={this.handleSubmitEdit}
                                />
                            )
                            : addToCartButtonClicked ? (  
                                <main className="container">
                                    <Counters
                                        counters={counters}
                                        onReset={this.handleReset}
                                        onIncrement={this.handleIncrement}
                                        onDecrement={this.handleDecrement}
                                        onDelete={this.handleDelete}
                                    />
                               
                                <span>
                                    <button onClick={() => this.setState({ addToCartButtonClicked: false })}> Back to List </button>
                                            </span>
                                        </main>
                            )
                     : (null)
                            }
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                </table>
            </Fragment>
        );
    }
}

export default App;