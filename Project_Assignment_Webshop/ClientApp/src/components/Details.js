import React, { Component } from 'react';

export default class Details extends Component {
        
     
        render() {
            
            const TableHeader = () => {
                return (
                    <thead>
                        <tr className="m-2">
                            <th>ProductType</th>
                            <th>Number</th>
                            <th>Name</th>
                            <th>Description</th>
                            <th>Price</th>
                            <th>Options</th>
                        </tr>
                    </thead>
                )
            }
            const TableBody = props => {
                const rows = props.productListView.map((row) => {
                    return (                    
                        <tr key={"ProductId" + row.Id} className="m-2">
                                <td>{row.ProductType}</td>
                                <td>{row.Number}</td>
                                <td>{row.Name}</td>
                                <td>{row.Description}</td>
                                <td>{row.Price}</td>
                            {/*<td>
                                    <button className="btn btn-danger" onClick={() => props.removeProduct(row.Id) }>Delete</button>
                                </td>
                                {" "}
                                <td>
                                    <button className="btn btn-primary" onClick={() => props.editProduct(row.Id)}>Edit</button>
                                </td>*/}                                                  
                            </tr>                    
                    )
                });
                return <tbody>{rows}</tbody>
            }
            return (
                <table>
                    <TableHeader />
                    <TableBody  productListView={this.props.productListView} removeProduct={this.props.removeProduct} editProduct={this.props.editProduct} />
                </table>
            );
        }
    
}