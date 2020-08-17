import React, { Component, Fragment } from 'react';
import salami from './pictures/salami.jpg';

export default class Cart extends Component {

    render() {
        const TableHeader = props => {
            return (
                <tr>
                    <th>
                        <div className="text-left m-2">Picture</div>
                    </th>
                    <th>
                        <button className="text-left btn btn-link" onClick={() => props.sortByInt("ProductType")}>ProductType</button>
                    </th>
                    <th>
                        <button className="text-left btn btn-link" onClick={() => props.sortByInt("Number")}>Number</button>
                    </th>
                    <th>
                        <button className="text-left btn btn-link" onClick={() => props.sortByString("Name")}>Name</button>
                    </th>
                    <th>
                        <button className="text-left btn btn-link" onClick={() => props.sortByString("Description")}>Description</button>
                    </th>
                    <th>
                        <button className="text-left btn btn-link" onClick={() => props.sortByInt("Price")}>Price</button>
                    </th>
                    <th>
                        <div className="text-left m-2">Options</div>
                    </th>
                </tr>
            );
        }

        {/*------ Not working------------------------- 
            {row.ProductType > 0 && row.ProductType < 4 ?
            (<td>Pizza Klass: {row.ProductType} </td>)
                : (<td> {row.ProductType} </td>)
                }
                {row.ProductType == 4 ?
                (<td>Special Pizzor</td>)
                : (<td> {row.ProductType} </td>)
                } 
             ------------------------------------------*/}


        const TableBody = props => {
            const rows = props.cartList.map((row) => {
                return (<tr key={"ProductId" + row.Id}>
                    <td><img src={salami} height="49" width="49" /></td>
                    <td> {row.ProductType} </td>
                    <td>{row.Number}</td>
                    <td>{row.Name}</td>
                    <td>{row.Description}</td>
                    <td>{row.Price}</td>
                    <td>
                        <p>Tillbehör</p>
                        <button className="btn btn-success m-2" onClick={() => props.addProductToCart(row.Id)}>AddToCart</button>
                    </td>
                </tr>
                )
            });
            return <tbody className="table table-striped">{rows}</tbody>
        }
        return (
            <Fragment>
                <TableHeader
                    sortByInt={this.props.sortByInt}
                    sortByString={this.props.sortByString}
                />
                <TableBody
                    cartList={this.props.cartList} 
                    addProductToCart={this.props.addProductToCart}
                />
            </Fragment>
        );
    }

}