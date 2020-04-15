import React, { Component, Fragment } from 'react';

export default class List extends Component {  
     
        render() {  
            const TableHeader = props => {
                return (
                    <tr>
                        <th>
                            <button className="btn btn-link m-2" onClick={() => props.sortByString("Number")}>Number</button>
                        </th>
                        <th>
                            <button className="btn btn-link m-2" onClick={() => props.sortByString("Name")}>Name</button>
                        </th>
                        <th>
                            <button className="btn btn-link m-2" onClick={() => props.sortByInt("Description")}>Description</button>
                        </th>
                        <th>
                            <button className="btn btn-link m-2" onClick={() => props.sortByInt("Price")}>Price</button>
                        </th> 
                        <th>
                            <div className="m-2">Options</div>
                        </th>                     
                    </tr>
                );  
            }

            const TableBody = props => {
                const rows = props.productList.map((row) => {
                    return (                    
                            <tr key={"ProductId" + row.Id}>
                                <td>{row.Number}</td>
                                <td>{row.Name}</td>
                                <td>{row.Description}</td>
                                <td>{row.Price}</td>
                                <td>
                                    <button className="btn btn-primary" onClick={() => props.detailProduct(row.Id)}>Detail</button>
                                    {" "}
                                    <button className="btn btn-danger" onClick={() => props.removeProduct(row.Id) }>Delete</button>
                                    {" "}
                                    <button className="btn btn-success" onClick={() => props.addProductToProductt(row.Id) }>AddToCart</button>                                   
                                </td>                            
                            </tr>                    
                    )
                });
                return <tbody>{rows}</tbody>
            }
            return (
                <Fragment>
                    <TableHeader sortByInt={this.props.sortByInt}
                                sortByString={this.props.sortByString} />
                                
                    <TableBody  productList={this.props.productList}
                                detailProduct={this.props.detailProduct}
                                removeProduct={this.props.removeProduct}
                                addProductToProductt={this.props.addProductToProductt} />
                </Fragment>
            );
        }
    
}