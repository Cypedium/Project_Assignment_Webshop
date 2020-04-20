import React, { Component, Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import Details from "./components/Details";
import Create from "./components/Create";
import List from "./components/List";
import Edit from "./components/Edit";
import NavBar from "./components/navbar";
import Counters from "./components/counters";


class App extends Component {

    state = {
        counters: [
            { id: 1, value: 0 },
            { id: 2, value: 0 },
            { id: 3, value: 0 },
            { id: 4, value: 0 }
        ],
        //productList: [
            //{
            //    "Id": "1",
            //    "ProductType": "0",
            //    "Number": "1",
            //    "Name": "Margerita",
            //    "Description": "Tomatsås, ost.",
            //    "Price": "75 kr",
            //    "addedToCart": "0"
            //},
            //{
            //    "Id": "2",
            //    "ProductType": "0",
            //    "Number": "2",
            //    "Name": "Hawaii",
            //    "Description": "Tomatsås, ost, skinka, annanas.",
            //    "Price": "75 kr",
            //    "addedToCart": "0"
            //},
            //{
            //    "Id": "3",
            //    "ProductType": "5",
            //    "Number": "1",
            //    "Name": "Hamburgare 90 g",
            //    "Description": "Nötkött, ost.",
            //    "Price": "80 kr",
            //    "addedToCart": "0"
            //},
            //{
            //    "Id": "4",
            //    "ProductType": "3",
            //    "Number": "1",
            //    "Name": "Kebabtallrik",
            //    "Description": "Kebab, strips, tomat, gurka, sallad",
            //    "Price": "75 kr",
            //    "addedToCart": "0"
            //}
        //],
        createButtonClicked: false, addToCartButtonClicked: false, editButtonClicked: false, details: true, showEditCar: false, toggleSort: true, oldColumn: ""
    }

    state = () => {
        const [setData] = useState({ productList: [] });
        useEffect(async () => {
            const fetchData = async () => {
                const result = await axios('./API',
                );

                setData(result.data);
            }
            fetchData()
        }, []);
        console.log(this.productList);
    }

    


    //-----SHOPPING CART--------------------------------------------------------------------------------------------------------------------------------
    constructor(props) {
        super(props);
        console.log("App - Constructor"); /*need to passing throw props*/
        // this.state = this.props.api;
    };

    componentDidMount() {
        console.log("App - Mounted");
        // Ajax Call
        //this.setState({api})
    }

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
    //addCarToCart = Id => {
    //  const { productList } = this.state;
    //}
    //-----------------------------------------------------------------------------------------------------------------

    detailProduct = Id => {

        const { productList } = this.state;
        this.setState(
            {
                productListView: productList.filter((aProduct) => { return aProduct.Id === Id })
            });
        this.setState({ details: false });
    }

    /* editCar = car => {
    const { carList } =this.state;
    this.setState(
        {
          carList: carList.append(car)
        }
      );
      this.setState({showEditCar: false})
    } */

    editProduct = Id => {
        const { productList } = this.state;
        this.setState(
            {
                editButtonClicked: true,
                productListEdit: productList.filter((aProduct) => { return aProduct.Id === Id })
            });
    }


    handleSubmitCreate = product => {
        this.setState({ productList: [...this.state.carList, product] });
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
            carList: productList.sort((a, b) => (
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
                                    <span>
                                        <button onClick={() => this.setState({ addToCartButtonClicked: true })}> AddToCart </button>
                                    </span>
                                </Fragment>
                            ) : (
                                    <Fragment>
                                        <h2>Details</h2>
                                        <span>
                                            <button onClick={() => this.setState({ details: true })}> Back to List </button>
                                        </span>
                                        <Details
                                            carListView={this.state.productListView}
                                            removeCar={this.removeProduct}
                                            editCar={this.editProduct} />
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