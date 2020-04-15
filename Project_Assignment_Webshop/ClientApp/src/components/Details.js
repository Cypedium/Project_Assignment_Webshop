import React, { Component } from 'react';

export default class Details extends Component {
        
     
        render() {
            
            const TableHeader = () => {
                return (
                    <thead>
                        <tr>
                            <th>Brand</th>
                            <th>Model</th>
                            <th>Year</th>
                            <th>Price</th>
                            <th>Options</th>                           
                        </tr>
                    </thead>
                )
            }
            const TableBody = props => {
                const rows = props.productListView.map((row) => {
                    return (                    
                            <tr key={"ProductId" + row.Id}>
                                <td>{row.brand}</td>
                                <td>{row.model}</td>
                                <td>{row.year}</td>
                                <td>{row.price}</td>
                                <td>
                                    <button className="btn btn-danger" onClick={() => props.removeProduct(row.Id) }>Delete</button>
                                </td>
                                {" "}
                                <td>
                                    <button className="btn btn-primary" onClick={() => props.editProduct(row.Id)}>Edit</button>
                                </td>                                                  
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