import React, { Component, Fragment } from 'react';

export default class List extends Component {  
     
        render() {  
            const TableHeader = props => {
                return (
                        <tr>
                            <th>
                                <button className="btn btn-link m-2" onClick={() => props.sortByString("brand")}>Brand</button>
                            </th>
                            <th>
                                <button className="btn btn-link m-2" onClick={() => props.sortByInt("model")}>Model</button>
                            </th>
                            <th>
                                <button className="btn btn-link m-2 " onClick={() => props.sortByInt("year")}>Year</button>
                            </th>
                            <th>
                                <button className="btn btn-link m-2" onClick={() => props.sortByInt("price")}>Price</button>
                            </th> 
                            <th>
                                <div className="m-2">Options</div>
                            </th>                     
                        </tr>
                );  
            }

            const TableBody = props => {
                const rows = props.carList.map((row) => {
                    return (                    
                            <tr key={"carId" + row.Id}>

                                <td className="">{row.brand}</td>
                                <td>{row.model}</td>
                                <td>{row.year}</td>
                                <td>{row.price}</td>
                                <td>
                                    <button className="btn btn-primary" onClick={() => props.detailCar(row.Id)}>Detail</button>
                                    {" "}
                                    <button className="btn btn-danger" onClick={() => props.removeCar(row.Id) }>Delete</button>
                                    {" "}
                                    <button className="btn btn-success" onClick={() => props.addCarToCart(row.Id) }>AddToCart</button>
                                    
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
                                
                    <TableBody  carList={this.props.carList}
                                detailCar={this.props.detailCar}
                                removeCar={this.props.removeCar}
                                addCarToCart={this.props.addCarToCart} />
                </Fragment>
            );
        }
    
}