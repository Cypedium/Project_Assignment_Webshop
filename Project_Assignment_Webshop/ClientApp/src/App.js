import React, { Component, Fragment, useEffect, useState } from 'react';
import axios from 'axios';
import Details from "./components/Details";
import Create from "./components/Create";
import List from "./components/List";
import Edit from "./components/Edit";
import NavBar from "./components/navbar";
import Counters from "./components/counters";
import FetchData from "./components/FetchData";

export default class App extends Component {
    //Implement Axios
    state = () => {
        const [data, setData] = this.useState({ productList: [] });
        useEffect(async () => {
            const fetchData = async () => {
                const result = await axios('https://localhost:44399/API',
                );

                setData(result.data);
            }
            fetchData()
        }, []);
    }

    state = {
        counters: [
            { id: 1, value: 0 },
            { id: 2, value: 0 },
            { id: 3, value: 0 },
            { id: 4, value: 0 }
        ], productList: [],
        //productList: [],
        //    {
        //        "Id": "1",
        //        "brand": "Saab",
        //        "model": "9-5 Turbo",
        //        "year": "2005",
        //        "price": "5000 SEK",
        //        "addedToCart" : "0"
        //    },
        //    {
        //        "Id": "2",
        //        "brand": "Volvo",
        //        "model": "760",
        //        "year": "1994",
        //        "price": "3000 SEK",
        //        "addedToCart" : "0"
        //    },
        //    {
        //        "Id": "3",
        //        "brand": "BMW",
        //        "model": "525i",
        //        "year": "2001",
        //        "price": "11000 SEK",
        //        "addedToCart" : "0"
        //    },
        //    {
        //        "Id": "4",
        //        "brand": "Nissan",
        //        "model": "300",
        //        "year": "2012",
        //        "price": "185000 SEK",
        //        "addedToCart" : "0"
        //    },
        //    {
        //        "Id": "5",
        //        "brand": "Tesla",
        //        "model": "1000",
        //        "year": "2019",
        //        "price": "1995000 SEK",
        //        "addedToCart" : "0"
        //    }
        //]
        createButtonClicked: false, editButtonClicked: false, details: true, showEditproduct: false, toggleSort: true, oldColumn: ""
    }

    



    //-----SHOPPING productT--------------------------------------------------------------------------------------------------------------------------------
    //constructor(props) {
    //  super(props);
    //  console.log("App - Constructor"); /*need to passing throw props*/
    // this.state = this.props.api;
    //}

    //componentDidMount() {
    //  console.log("App - Mounted");
    // Ajax Call
    //this.setState({api})
    //}

    handleIncrement = counter => {
        const counters = [...this.state.counters]; /*clone the state*/
        const index = counters.indexOf(counter);
        counters[index] = { ...counter };
        counters[index].value++;
        this.setState({ counters });
    }

    handleDecrement = counter => {
        const counters = [...this.state.counters]; /*clone the state*/
        const index = counters.indexOf(counter);
        counters[index] = { ...counter };
        if (counters[index].value > 0) {
            counters[index].value--;
            this.setState({ counters });
        }
    }

    handleReset = () => {
        const counters = this.state.counters.map(c => { /*this creates an array*/
            c.value = 0;
            return c;
        });
        this.setState({ counters });
    }

    handleDelete = (counterId) => {
        const counters = this.state.counters.filter(c => c.id !== counterId);
        this.setState({ counters: counters }); /*override property with constant*/
    }
    //-----------------------------------------------------------------------------------------------------------------

    //------MANAGE product-------------------------------------------------------------------------------------------------
    removeproduct = Id => {
        const { productList } = this.state;
        this.setState(
            {
                productList: productList.filter((aProduct) => { return aProduct.Id !== Id })
            });
    }

    //---PREPARED FUNCTION FOR PROJECT WEBSHOP------------------------------------------------------------------------
    //addProductToCart = Id => {
    //    const { productList } = this.state;
    //}
    //-----------------------------------------------------------------------------------------------------------------

    detailproduct = Id => {
        const { productList } = this.state;
        this.setState(
            {
                productListView: productList.filter((aProduct) => { return aProduct.Id === Id })
            });
        this.setState({ details: false });
    }

    editproduct = Id => {
        const { productList } = this.state;
        this.setState(
            {
                editButtonClicked: true,
                productListEdit: productList.filter((aProduct) => { return aProduct.Id === Id })
            });
    }


    handleSubmitCreate = product => {
        this.setState({ productList: [...this.state.productList, product] });
        this.setState({ createButtonClicked: false });
    }

    handleSubmitEdit = product => {
        this.setState({ productList: [...this.state.productList, product] });
        this.setState({ editButtonClicked: false });
    }

    sortByString = (column) => { /* use arrowfunction to binds this */
        const { productList, toggleSort, oldColumn } = this.state;
        this.setState({
            productList: productList.sort((a, b) => (
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
        });
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
        });
    }

    render() {
        console.log("App - Rendered");
        const { createButtonClicked, details, editButtonClicked, counters } = this.state;
        return (
            <Fragment>
                <ul>
                    {data.productList.map(item => (
                        <li key={item.objectID}>
                            <a href={item.url}>{item.title}</a>
                        </li>
                    ))}
                </ul>

                <Layout>
                    <Route exact path='/' component={App} />
                    <Route path='/fetch-data' component={FetchData} />
                </Layout>

                <NavBar
                    totalCounters={counters.filter(c => c.value > 0).length} /*only display values greater than zero*/
                />
                <main className="container">
                    <Counters
                        counters={counters}
                        onReset={this.handleReset}
                        onIncrement={this.handleIncrement}
                        onDecrement={this.handleDecrement}
                        onDelete={this.handleDelete}
                    />
                </main>
                <table> {/* Head */}
                    <tr>
                        <td></td>
                        <td>
                            <h1>Handle products</h1>
                            <button className="btn btn-info" onClick={() => this.setState({ createButtonClicked: true })}>Create new product</button>
                        </td>
                        <td></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td>
                            {details ? (
                                <Fragment>
                                    <h2>List of products</h2>
                                    <List productList={this.state.productList}
                                        detailproduct={this.detailproduct}
                                        removeproduct={this.removeproduct}
                                        sortByInt={this.sortByInt}
                                        sortByString={this.sortByString}
                                        addproductToproductt={this.addproductToproductt} />
                                </Fragment>
                            ) : (
                                    <Fragment>
                                        <h2>Details</h2>
                                        <span>
                                            <button onClick={() => this.setState({ details: true })}> Back to List </button>
                                        </span>
                                        <Details
                                            productListView={this.state.productListView}
                                            removeproduct={this.removeproduct}
                                            editproduct={this.editproduct} />
                                    </Fragment>
                                )
                            }
                            <br />
                        </td>
                        <td>
                            {createButtonClicked
                                ? (
                                    <Create handleSubmitCreate={this.handleSubmitCreate} />
                                )
                                : editButtonClicked
                                    ? (
                                        <Edit
                                            productListEdit={this.state.productListEdit}
                                            handleSubmitEdit={this.handleSubmitEdit}
                                        />
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